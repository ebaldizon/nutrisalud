using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class MessageBus
    {
        public bool create(Message message)
        {
            MessageDa messageDa = new MessageDa();
            return messageDa.create(message);
        }

        public DataTable read(Message message)
        {
            MessageDa messageDa = new MessageDa();
            return messageDa.Read(message);
        }

        /*
         * Custom Message Error
         * return 1 - roomId
         * return 2 - userId
         * return 0 - okay
         */
        public int validateMessage(string roomId, string userId)
        {
            if(CanConvert<Int32>(roomId) == false)
            {
                return 1;
            }
            else if(CanConvert<Int32>(userId) == false)
            {
                return 2;
            }
            else
            {
                return 0;
            }

        }

        

        public bool CanConvert<T>(string data)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return converter.IsValid(data);
        }
    }
}
