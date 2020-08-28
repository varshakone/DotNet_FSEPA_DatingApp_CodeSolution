
using DatingApp.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dating.BusinessLayer.Interface
{
   public interface IDateService
    {
        Task<String> SendRequest(DateDetails user);

    }
}
