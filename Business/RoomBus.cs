using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RoomBus
    {
        public bool create(Room room)
        {
            RoomDa roomDa = new RoomDa();
            return roomDa.create(room);
        }

        public bool validateBus(string id)
        {
            if (CanConvert<Int32>(id))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CanConvert<T>(string data)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            return converter.IsValid(data);
        }
    }
}
