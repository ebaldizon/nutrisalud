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
    public class UserBus   
    {
        public bool create(User user)
        {
            UserDa userDa = new UserDa();
            return userDa.create(user);
        }


        /* 
        CUSTOM MESSAGE TEXT ERROR 
        if return 0 - okay 
        if return 1 - Error for id
        if return 2 - Error for name
        if return 3 - Error for email
        if return 3 - Error for password
        */
        public int validateUserText(string id, string name, string email, string password)
        {
            if (CanConvert<Int32>(id) == false)
            {
                return 1;
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
