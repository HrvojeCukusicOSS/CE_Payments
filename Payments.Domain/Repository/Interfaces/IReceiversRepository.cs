using Payments.Domain;
using Payments.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payments.Domain.Repository.Interfaces
{
    public interface IReceiversRepository
    {
        Task<IEnumerable<ReceiversTable>> GetReceivers();
        Task<ReceiversTable> GetReceiver(int ReceiverId);
        Task<ReceiversTable> AddReceiver(ReceiversTable Receiver);
        Task<ReceiversTable> UpdateReceiver(ReceiversTable Receiver);
        Task<ReceiversTable> DeleteReceiver(int ReceiverId);
        Task<ReceiversTable> GetReceiverByName(string ReceiverName);
    }
}