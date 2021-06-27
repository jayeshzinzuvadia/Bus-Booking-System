using BusBookingSystem.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusBookingSystem.Models.IEntityRepositories
{
    public interface ITransactionRepository
    {
        Transaction AddTransaction(Transaction passengerTicket);
        Transaction UpdateTransaction(Transaction passengerTicketChanges);
        bool DeleteTransactionFromTicketId(int ticketId);
        bool DeleteTransaction(int ticketId, int passengerInfoId);
        List<Transaction> GetTransactionDetails(int ticketId);
        List<PassengerInfo> GetPassengerInfoListFromTicketId(int ticketId);
    }
}
