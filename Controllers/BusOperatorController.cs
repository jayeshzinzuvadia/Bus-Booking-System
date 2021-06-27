using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusBookingSystem.Models;
using BusBookingSystem.Models.Entities;
using BusBookingSystem.Models.IEntityRepositories;
using BusBookingSystem.ViewModels.BusOperator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BusBookingSystem.Controllers
{
    [Authorize(Roles = AppConstant.BUS_OPERATOR)]
    public class BusOperatorController : Controller
    {
        private readonly IApplicationUserRepository applicationUserRepository;
        private readonly IBusOperatorRepository busOperatorRepository;
        private readonly IBusRepository busRepository;
        private readonly IBusRouteRepository busRouteRepository;
        private readonly ISeatRepository seatRepository;
        private readonly ITicketRepository ticketRepository;
        private readonly ITransactionRepository transactionRepository;
        private readonly IPassengerInfoRepository passengerInfoRepository;

        public BusOperatorController(
            IApplicationUserRepository applicationUserRepository,
            IBusOperatorRepository busOperatorRepository,
            IBusRepository busRepository,
            IBusRouteRepository busRouteRepository,
            ISeatRepository seatRepository,
            ITicketRepository ticketRepository,
            ITransactionRepository transactionRepository,
            IPassengerInfoRepository passengerInfoRepository)
        {
            this.applicationUserRepository = applicationUserRepository;
            this.busOperatorRepository = busOperatorRepository;
            this.busRepository = busRepository;
            this.busRouteRepository = busRouteRepository;
            this.seatRepository = seatRepository;
            this.ticketRepository = ticketRepository;
            this.transactionRepository = transactionRepository;
            this.passengerInfoRepository = passengerInfoRepository;
        }

        [HttpGet]
        public IActionResult ViewBookingList()
        {
            List<BusBookingListViewModel> model = new List<BusBookingListViewModel>();
            ApplicationUser appUser = applicationUserRepository.GetApplicationUserFromEmail(HttpContext.User.Identity.Name);
            if (appUser != null)
            {                
                Bus bus = busRepository.GetBusFromBusOperatorId(appUser.Id);
                // For bus details
                ViewBag.BusName = bus.BusName;
                ViewBag.RouteSequence = bus.RouteSequence;
                ViewBag.BusTime = bus.BusTime;

                List<Ticket> ticketList = ticketRepository.GetAllTicketsFromBusRouteIdDateAndStatus(bus.BusName, DateTime.Today, AppConstant.BOOKED);
                foreach (var t in ticketList)
                {
                    var passengerList = transactionRepository.GetPassengerInfoListFromTicketId(t.TicketId);
                    foreach (var p in passengerList)
                    {
                        var obj = new BusBookingListViewModel
                        {
                            Passenger = p,
                            Source = t.Source,
                            Destination = t.Destination,                        
                        };
                        model.Add(obj);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult ViewPassengerCheckList()
        {
            List<PassengerCheckListViewModel> model = new List<PassengerCheckListViewModel>();
            ApplicationUser appUser = applicationUserRepository.GetApplicationUserFromEmail(HttpContext.User.Identity.Name);
            if (appUser != null)
            {
                Bus bus = busRepository.GetBusFromBusOperatorId(appUser.Id);
                List<Ticket> ticketList = ticketRepository.GetAllTicketsFromBusRouteIdAndDate(bus.BusName, DateTime.Today);
                foreach (var t in ticketList)
                {
                    var passengerList = transactionRepository.GetPassengerInfoListFromTicketId(t.TicketId);
                    bool flag = true;
                    if(t.TicketStatus == AppConstant.BOOKED)
                    {
                        flag = false;
                    }
                    else if(t.TicketStatus == AppConstant.CHECKED)
                    {
                        flag = true;
                    }
                    else
                    {
                        continue;
                    }
                    foreach (var p in passengerList)
                    {
                        var obj = new PassengerCheckListViewModel
                        {
                            Passenger = p,
                            Source = t.Source,
                            Destination = t.Destination,
                            TicketId = t.TicketId,
                            IsChecked = flag,                            
                        };
                        model.Add(obj);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult ViewPassengerCheckList(List<PassengerCheckListViewModel> model)
        {
            foreach(var p in model)
            {
                if(p.IsChecked)
                {
                    ticketRepository.UpdateTicketStatus(p.TicketId, AppConstant.CHECKED);
                }
                else
                {
                    ticketRepository.UpdateTicketStatus(p.TicketId, AppConstant.BOOKED);
                }
            }
            return RedirectToAction("ViewBookingList");
        }
    }
}
