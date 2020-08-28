
using DatingApp.DataLayer;
using DatingApp.Entities;
using MailKit.Net.Smtp;
using MimeKit;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DatingApp.BusinessLayer.Service.Repository
{
    public class DateRepository : IDateRepository
    {
        private readonly IMongoDBContext _mongoDBContext;
        private readonly IMongoCollection<DateDetails> _mongoCollection;


        /// <summary>
        /// Inject UserContext object
        /// </summary>
        public DateRepository(IMongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
            _mongoCollection = _mongoDBContext.GetCollection<DateDetails>(typeof(User).Name);

        }

        /// <summary>
        /// In-Memory DB logic to send request
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>eeee
        public async Task<string> SendRequest(DateDetails user)
        {
            try
            {
                string returnResult = string.Empty;
                var sresult = _mongoCollection.InsertOneAsync(user);
                if (sresult != null)
                {
                    MimeMessage message = new MimeMessage();
                    MailboxAddress from = new MailboxAddress(user.RequestSenderName, user.RequestSenderEmail);
                    message.From.Add(from);

                    MailboxAddress To = new MailboxAddress(user.RequestReceiverName, user.RequestReceiverEmail);
                    message.To.Add(To);

                    message.Subject = "Dating invitation ";

                    BodyBuilder bodyBuilder = new BodyBuilder();
                    bodyBuilder.HtmlBody = "<h1>Hello" + user.RequestReceiverName + "</h1>";
                    bodyBuilder.TextBody = user.RequestMessage;
                    message.Body = bodyBuilder.ToMessageBody();

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    CancellationToken token = new CancellationToken(false);
                    await client.AuthenticateAsync(user.RequestSenderEmail, "PACHAKKI",token);
           
                    client.Send(message);
                    client.Disconnect(true);
                    client.Dispose();
                    returnResult = "Invitation Send Succcessfully";
                }
                return returnResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
