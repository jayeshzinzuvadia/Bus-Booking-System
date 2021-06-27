using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface ITicketRepository
    {
        Ticket Add(Ticket ticket);
        Ticket Update(Ticket ticketChanges);
        bool Delete(int ticketId);
        bool UpdateTicketStatus(int ticketId, string newStatus);
        bool AddUserRating(int ticketId, int userRating);
        Ticket GetTicket(int ticketId);
        Ticket GetTicketFromPEmailAndTicketId(int ticketId, string pEmail);
        List<Ticket> GetAllTicketsFromBusRouteIdDateAndStatus(string busName, DateTime dateOfJourney, string ticketStatus);
        List<Ticket> GetAllTicketsFromBusRouteIdAndDate(string busName, DateTime dateOfJourney);
    }
}
