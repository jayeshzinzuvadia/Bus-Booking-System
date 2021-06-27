using BusBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BusBookingSystem.Models.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusBookingSystem.Models.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext context;
        public TicketRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Ticket Add(Ticket ticket)
        {
            context.Ticket.Add(ticket);
            context.SaveChanges();
            return ticket;
        }

        public bool AddUserRating(int ticketId, int userRating)
        {
            Ticket t = GetTicket(ticketId);
            t.PUserRatings = userRating;
            t = Update(t);
            if(t == null)
            {
                return false;
            }
            return true;
        }

        public bool Delete(int ticketId)
        {
            Ticket ticket = GetTicket(ticketId);
            if (ticket != null)
            {
                context.Ticket.Remove(ticket);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Ticket> GetAllTicketsFromBusRouteIdAndDate(string busName, DateTime dateOfJourney)
        {
            List<Ticket> ticketList = context.Ticket.Where(t => t.DateOfJourney == dateOfJourney && t.BusName == busName).ToList();
            return ticketList;
        }

        public List<Ticket> GetAllTicketsFromBusRouteIdDateAndStatus(string busName, DateTime dateOfJourney, string ticketStatus)
        {
            List<Ticket> ticketList = context.Ticket.Where(t => t.DateOfJourney == dateOfJourney && t.BusName == busName && t.TicketStatus == ticketStatus).ToList();
            return ticketList;
        }

        public Ticket GetTicket(int ticketId)
        {
            return context.Ticket.FirstOrDefault(t => t.TicketId == ticketId);
        }

        public Ticket GetTicketFromPEmailAndTicketId(int ticketId, string pEmail)
        {
            return context.Ticket.FirstOrDefault(t => t.TicketId == ticketId && t.PEmail == pEmail);
        }

        public Ticket Update(Ticket ticketChanges)
        {
            var ticket = context.Ticket.Attach(ticketChanges);
            ticket.State = EntityState.Modified;
            context.SaveChanges();
            return ticketChanges;
        }

        public bool UpdateTicketStatus(int ticketId, string newStatus)
        {
            Ticket t = GetTicket(ticketId);
            t.TicketStatus = newStatus;
            t = Update(t);
            if (t == null)
            {
                return false;
            }
            return true;
        }
    }
}
