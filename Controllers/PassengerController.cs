using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BusBookingSystem.Models.Entities;
using BusBookingSystem.Models.IEntityRepositories;
using BusBookingSystem.Models;
using Microsoft.AspNetCore.Authorization;
using BusBookingSystem.ViewModels.Passenger;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using BusBookingSystem.Utilities;
using MimeKit;
using MailKit.Net.Smtp;

namespace BusBookingSystem.Controllers
{
    [Authorize]
    public class PassengerController : Controller
    {
        private readonly IPassengerRepository passengerRepository;
        private readonly IBusRepository busRepository;
        private readonly IBusRouteRepository busRouteRepository;
        private readonly ISeatRepository seatRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IPassengerInfoRepository passengerInfoRepository;

        public PassengerController(
            IPassengerRepository passengerRepository,
            IBusRepository busRepository,
            IBusRouteRepository busRouteRepository,
            ISeatRepository seatRepository,
            ITicketRepository ticketRepository,
            ITransactionRepository transactionRepository,
            IPassengerInfoRepository passengerInfoRepository)
        {
            this.passengerRepository = passengerRepository;
            this.busRepository = busRepository;
            this.busRouteRepository = busRouteRepository;
            this.seatRepository = seatRepository;
            this.ticketRepository = ticketRepository;
            this.passengerInfoRepository = passengerInfoRepository;
            this.transactionRepository = transactionRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Home()
        {
            HttpContext.Session.Clear();
            return View();
        }

        string FormatDateOfJourney(DateTime dateOfJourney)
        {
            string monthZeroPrefix = "", dayZeroPrefix = "";
            if (dateOfJourney.Month < 10)
                monthZeroPrefix = "0";
            if (dateOfJourney.Day < 10)
                dayZeroPrefix = "0";
            return dateOfJourney.Year + "-" + monthZeroPrefix + dateOfJourney.Month + "-" + dayZeroPrefix + dateOfJourney.Day;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ViewBusSearchResults(PassengerHomeViewModel model, string busType)
        {
            List<BusRoute> busList = busRouteRepository.SearchBuses(model.Source, model.Destination);
            List<BusViewModel> busSearchResults = new List<BusViewModel>();

            // Storing source, destination and date in ViewBag
            ViewBag.Source = model.Source;
            ViewBag.Destination = model.Destination;
            ViewBag.DateParam = FormatDateOfJourney(model.DateOfJourney);

            string date = model.DateOfJourney.ToLongDateString();
            HttpContext.Session.SetString("Source", model.Source);
            HttpContext.Session.SetString("Destination", model.Destination);
            ViewBag.DateOfJourney = date;

            // Traverse busList to fetch complete search results details
            foreach (BusRoute busRoute in busList)
            {
                var busObj = busRepository.GetBus(busRoute.BusId);
                busSearchResults.Add(
                    new BusViewModel
                    {
                        Bus = busObj,
                        BusRoute = busRoute,
                        Seat = seatRepository.GetSeatDetails(busRoute.BusRouteId, model.DateOfJourney),
                    }
                );
            }
            BusSearchResultViewModel searchModel = new BusSearchResultViewModel();
            if (busType != null)
            {
                BusTypes tmp = BusTypes.Seater;
                if (busType == "2")
                    tmp = BusTypes.Sleeper;
                else if (busType == "3")
                    tmp = BusTypes.AC;
                if(busType != "0")
                {
                    busSearchResults = busSearchResults.FindAll(b => b.Bus.BusType == tmp);
                    searchModel.BusTypes = tmp;
                }
            }
            ViewBag.TotalSearchBusCount = busSearchResults.Count();
            searchModel.BusList = busSearchResults;
            searchModel.DateOfJourney = model.DateOfJourney;
            return View("ViewBusSearchResults", searchModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ViewSeatLayout(int busRouteId, string date)
        {
            BusRoute busRoute = busRouteRepository.GetBusRoute(busRouteId);
            //DateTime dateOfJourney = DateTime.ParseExact(date, "dd-MM-yyyy hh.mm.ss tt", CultureInfo.InvariantCulture);
            DateTime dateOfJourney = DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            HttpContext.Session.SetInt32("BusRouteId", busRouteId);
            HttpContext.Session.SetString("DateOfJourney", date);
            BusSeatLayoutViewModel model = new BusSeatLayoutViewModel
            {
                BusRoute = busRoute,
                Bus = busRepository.GetBus(busRoute.BusId),
                Seat = seatRepository.GetSeatDetails(busRouteId, dateOfJourney),
                DateOfJourney = dateOfJourney,
                BookedSeats = seatRepository.GetBookedSeatList(busRouteId, dateOfJourney).ToList(),
            };
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult PassengerDetails(int seatCount, string selectedSeats, int ticketPrice)
        {
            HttpContext.Session.SetInt32("SeatCount", seatCount);
            HttpContext.Session.SetString("SelectedSeats", selectedSeats);
            HttpContext.Session.SetInt32("TicketPrice", ticketPrice);
            ViewBag.SeatCount = seatCount;
            List<int> selectedSeatList = selectedSeats.Split(",").Select(Int32.Parse).ToList();
            PassengerInfoViewModel model = new PassengerInfoViewModel
            {
                PInfo = new List<PassengerInfo>()
            };
            foreach (int seatNo in selectedSeatList)
            {
                model.PInfo.Add(new PassengerInfo { PSeatNo = seatNo });
            }
            return View("PassengerDetails", model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult TicketPayment(PassengerInfoViewModel model)
        {
            ViewBag.DateOfJourney = HttpContext.Session.GetString("DateOfJourney");
            ViewBag.Source = HttpContext.Session.GetString("Source");
            ViewBag.Destination = HttpContext.Session.GetString("Destination");

            // Storing passengerinfoviewmodel in Session
            HttpContext.Session.SetString("PEmail", model.PEmail);
            HttpContext.Session.SetString("PPhoneNumber", model.PPhoneNumber);
            if (model.PInfo != null)
            {
                int id = 1;
                foreach (var passenger in model.PInfo)
                {
                    HttpContext.Session.SetString("PName" + id, passenger.PName);
                    HttpContext.Session.SetInt32("PGender" + id, (passenger.PGender == Gender.Male) ? 0 : 1);
                    HttpContext.Session.SetInt32("PSeatNo" + id, passenger.PSeatNo);
                    HttpContext.Session.SetInt32("PAge" + id, passenger.PAge);
                    id++;
                }
            }

            int ticketPrice = (int)HttpContext.Session.GetInt32("TicketPrice");
            TicketPaymentViewModel ticketPaymentViewModel = new TicketPaymentViewModel
            {
                TicketPrice = ticketPrice,
                TotalAmount = ticketPrice + AppConstant.RESERVATION_FEE + AppConstant.TOLL_FEE,
            };
            return View(ticketPaymentViewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult ViewTicket(TicketPaymentViewModel model)
        {
            // Fetch all the data from session and model objects
            int busRouteId = (int)HttpContext.Session.GetInt32("BusRouteId");
            string dateOfJourneyStr = HttpContext.Session.GetString("DateOfJourney");
            DateTime dateOfJourney = DateTime.ParseExact(dateOfJourneyStr, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            int seatCount = (int)HttpContext.Session.GetInt32("SeatCount");
            string selectedSeats = HttpContext.Session.GetString("SelectedSeats");

            // Creating Bus and BusRoute objects
            BusRoute busRouteObj = busRouteRepository.GetBusRoute(busRouteId);
            Bus busObj = busRepository.GetBus(busRouteObj.BusId);

            // Manage Seat table
            Seat seatObj = seatRepository.GetSeatDetails(busRouteId, dateOfJourney);
            // Check if seat for a given busRouteId and dateOfBooking exists or not
            if (seatObj == null)
            {
                // If seat doesn't exist then create a new seat row from the given dateOfBooking and busRouteId
                seatObj = new Seat
                {
                    BusRouteId = busRouteId,
                    AvailableSeats = (busObj.TotalSeat - seatCount),
                    DateOfJourney = dateOfJourney,
                    SeatStructure = selectedSeats,
                };
                seatRepository.Add(seatObj);
            }
            else
            {
                seatObj.AvailableSeats -= seatCount;
                seatObj.SeatStructure = seatObj.SeatStructure + "," + selectedSeats;
                seatRepository.Update(seatObj);
            }
            // Copy seat structures of other routes for avoiding collision between routes

            // Manage ticket table
            Ticket ticket = new Ticket
            {
                PNRCode = UniqueIdGenerator.GenerateId(busRouteObj.Source[0] + "" + busRouteObj.Destination[0]),
                Source = busRouteObj.Source,
                Destination = busRouteObj.Destination,
                DateOfJourney = dateOfJourney,
                BusName = busObj.BusName,
                BusVehicleNumber = busObj.BusVehicleNumber,
                ArrivalTime = busRouteObj.ArrivalTime,
                DepartureTime = busRouteObj.DepartureTime,
                PassengerCount = seatCount,
                TicketStatus = AppConstant.BOOKED,
                TicketPrice = model.TotalAmount,
                PBankName = model.BankName,
                PBankSecretCode = model.BankSecretCode,
                PEmail = HttpContext.Session.GetString("PEmail"),
                PPhoneNumber = HttpContext.Session.GetString("PPhoneNumber"),
            };

            // Add ticket data to Ticket database table
            ticket = ticketRepository.Add(ticket);

            List<PassengerInfo> passengerList = new List<PassengerInfo>();
            for (int id = 1; id <= seatCount; id++)
            {
                Gender gender = (int)HttpContext.Session.GetInt32("PGender" + id) == 0 ? Gender.Male : Gender.Female;
                PassengerInfo passengerInfo = new PassengerInfo
                {
                    PName = HttpContext.Session.GetString("PName" + id),
                    PGender = gender,
                    PSeatNo = (int)HttpContext.Session.GetInt32("PSeatNo" + id),
                    PAge = (int)HttpContext.Session.GetInt32("PAge" + id),
                };
                // Add passengerinfo data to database
                passengerInfo = passengerInfoRepository.Add(passengerInfo);
                // Add transaction
                transactionRepository.AddTransaction(
                    new Transaction
                    {
                        PassengerInfoId = passengerInfo.PassengerInfoId,
                        TicketId = ticket.TicketId,
                    }
                );
                passengerList.Add(passengerInfo);
            }

            // Put the data in PassengerTicketViewModel for the view purpose
            PassengerTicketViewModel passengerTicketViewModel = new PassengerTicketViewModel
            {
                Ticket = ticket,
                Passengers = passengerList,
            };

            // Sending mail to passenger
            SendEmailToPassenger(passengerTicketViewModel);

            return View(passengerTicketViewModel);
        }

        public void SendEmailToPassenger(PassengerTicketViewModel model) 
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(AppConstant.ORGANIZATION_NAME, AppConstant.ORGANIZATION_EMAIL_ADDRESS));
            message.To.Add(new MailboxAddress(model.Passengers[0].PName, model.Ticket.PEmail));
            message.Subject = "Bus Ticket Booked from " + model.Ticket.Source 
                                + " to " + model.Ticket.Destination 
                                + " on " + model.Ticket.DateOfJourney.ToLongDateString();
            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = WriteEmail(model),
            };

            // Send mail logic
            using var client = new SmtpClient();
            client.Connect(AppConstant.SMTP_ADDRESS, AppConstant.SMTP_PORT, false);
            client.Authenticate(AppConstant.ORGANIZATION_EMAIL_ADDRESS, AppConstant.ORGANIZATION_PASSWORD);
            client.Send(message);
            client.Disconnect(true);
        }

        private string WriteEmail(PassengerTicketViewModel model)
        {
            string messageBody = "<table border=" + 1 + " cellpadding=" + 12 + " cellspacing=" + 0 + " width = " + 80 + "%>" +
                "<tbody>" +
                        "<tr>" +
                            "<td><b>Ticket Id:</b></td>" +
                            "<td>" + model.Ticket.TicketId + "</td>" +
                            "<td><b>PNR Code:</b></td>" +
                            "<td>" + model.Ticket.PNRCode + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><b>Source:</b></td>" +
                            "<td>" + model.Ticket.Source + "</td>" +
                            "<td><b>Destination:</b></td>" +
                            "<td>" + model.Ticket.Destination + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><b>Departure Time:</b></td>" +
                            "<td>" + model.Ticket.DepartureTime.ToShortTimeString() + "</td>" +
                            "<td><b>Arrival Time:</b></td>" +
                            "<td>" + model.Ticket.ArrivalTime.ToShortTimeString() + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><b>Date of Journey:</b></td>" +
                            "<td>" + model.Ticket.DateOfJourney.ToLongDateString() + "</td>" +
                            "<td><b>Ticket Price:</b></td>" +
                            "<td> INR " + model.Ticket.TicketPrice + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><b>Bus Name:</b></td>" +
                            "<td>" + model.Ticket.BusName + "</td>" +
                            "<td><b>Bus Vehicle Number:</b></td>" +
                            "<td>" + model.Ticket.BusVehicleNumber + "</td>" +
                        "</tr>" +
                        "<tr>" +
                            "<td><b>Passenger Count:</b></td>" +
                            "<td>" + model.Ticket.PassengerCount + "</td>" +
                            "<td></td><td></td>" +
                        "</tr>";
            foreach (var passenger in model.Passengers)
            {
                messageBody +=  "<tr>" +
                                    "<td><b>Passenger Name:</b></td>" +
                                    "<td>" + passenger.PName + "</td>" +
                                    "<td><b>Seat No.:</b></td>" +
                                    "<td>" + passenger.PSeatNo + "</td>" +
                                "</tr>" +
                                "<tr>" +
                                    "<td><b>Age:</b></td>" +
                                    "<td>" + passenger.PAge + "</td>" +
                                    "<td><b>Gender:</b></td>" +
                                    "<td>" + passenger.PGender + "</td>" +
                                "</tr>";
            }
            messageBody += "</tbody>";
            messageBody += "</table>";
            return messageBody;
        }

        [HttpGet]
        public IActionResult ManageBookings()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ManageBookings(ManageBookingsViewModel model)
        {
            // Fetch ticket details from ticket id
            Ticket ticket = ticketRepository.GetTicketFromPEmailAndTicketId(model.TicketId, model.PEmail);
            if(ticket == null)
            {
                return View("ManageBookings");
            }
            // Fetch passenger infos associated with ticket
            List<PassengerInfo> passengers = transactionRepository.GetPassengerInfoListFromTicketId(model.TicketId);
            // Create Passenger Ticket View Model Object
            PassengerTicketViewModel ptModel = new PassengerTicketViewModel
            {
                Ticket = ticket,
                Passengers = passengers,
            };
            return View("ManageTicket", ptModel);
        }

        [HttpPost]
        public IActionResult RateBus(int ticketId, int userRatings) 
        {
            ticketRepository.AddUserRating(ticketId, userRatings);
            // Update total ratings of the bus
            Ticket t = ticketRepository.GetTicket(ticketId);
            BusRoute busRouteObj = busRouteRepository.GetBusRouteFromBusName(t.BusName, t.Source, t.Destination);
            Bus bus = busRepository.GetBus(busRouteObj.BusId);
            double mean = (bus.TotalRateCounts * Double.Parse(bus.Ratings) + userRatings) / (bus.TotalRateCounts + 1);
            bus.TotalRateCounts += 1;
            bus.Ratings = mean.ToString();
            busRepository.Update(bus);
            // Update ticket status
            ticketRepository.UpdateTicketStatus(ticketId, AppConstant.RATED);
            return View("ManageBookings");
        }

        [HttpPost]
        public IActionResult CancelTicket(int ticketId)
        {
            Ticket t = ticketRepository.GetTicket(ticketId);
            BusRoute busRouteObj = busRouteRepository.GetBusRouteFromBusName(t.BusName, t.Source, t.Destination);
            Seat seat = seatRepository.GetSeatDetails(busRouteObj.BusRouteId, t.DateOfJourney);
            // Remove seat numbers from bookedList in Seat obj
            List<int> bookedList = seatRepository.GetBookedSeatList(busRouteObj.BusRouteId, t.DateOfJourney).ToList();
            List<PassengerInfo> passengers = transactionRepository.GetPassengerInfoListFromTicketId(ticketId);
            foreach(var p in passengers)
            {
                bookedList.Remove(p.PSeatNo);
                // Remove data from passengerinfo and transaction data
                transactionRepository.DeleteTransaction(ticketId, p.PassengerInfoId);
                passengerInfoRepository.Delete(p.PassengerInfoId);
            }
            seat.SeatStructure = string.Join(",", bookedList);
            seat.AvailableSeats += t.PassengerCount;
            seatRepository.Update(seat);
            // Update ticket status
            ticketRepository.UpdateTicketStatus(ticketId, AppConstant.CANCELLED);
            return View("ManageBookings");
        }
    }
}
