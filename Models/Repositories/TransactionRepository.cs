using BusBookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;
using BusBookingSystem.Models.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusBookingSystem.Models.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext context;
        public TransactionRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Transaction AddTransaction(Transaction passengerTicket)
        {
            context.Transaction.Add(passengerTicket);
            context.SaveChanges();
            return passengerTicket;
        }

        public bool DeleteTransaction(int ticketId, int passengerInfoId)
        {
            Transaction transaction = context.Transaction.FirstOrDefault(id => id.TicketId == ticketId && id.PassengerInfoId == passengerInfoId); ;
            if (transaction != null)
            {
                context.Transaction.Remove(transaction);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteTransactionFromTicketId(int ticketId)
        {
            List<PassengerInfo> userList = GetPassengerInfoListFromTicketId(ticketId);
            if(userList != null)
            {
                foreach (PassengerInfo user in userList)
                {
                    context.PassengerInfo.Remove(user);
                    context.SaveChanges();
                }
                return true;
            }
            return false;
        }

        public List<PassengerInfo> GetPassengerInfoListFromTicketId(int ticketId)
        {
            List<Transaction> transactionList = GetTransactionDetails(ticketId);
            List<PassengerInfo> passengerInfoList = new List<PassengerInfo>();
            foreach(Transaction t in transactionList)
            {
                PassengerInfo passengerInfo = context.PassengerInfo.FirstOrDefault(p => p.PassengerInfoId == t.PassengerInfoId);
                passengerInfoList.Add(passengerInfo);
            }
            return passengerInfoList;
        }

        public List<Transaction> GetTransactionDetails(int ticketId)
        {
            return context.Transaction.ToList().FindAll(id => id.TicketId == ticketId);
        }

        public Transaction UpdateTransaction(Transaction passengerTicketChanges)
        {
            var transaction = context.Transaction.Attach(passengerTicketChanges);
            transaction.State = EntityState.Modified;
            context.SaveChanges();
            return passengerTicketChanges;
        }
    }
}
