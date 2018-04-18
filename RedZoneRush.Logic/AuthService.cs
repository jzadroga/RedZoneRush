using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RedZoneRush.Common.Config;
using RedZoneRush.Logic.Interfaces;
using Twilio;
using Twilio.Clients;
using Twilio.Types;
using Twilio.Rest.Api.V2010.Account;

namespace RedZoneRush.Logic
{
    public class AuthService : IAuthService
    {
        /// <summary>Gets the Twilio configuration.</summary>
        public TwilioSettings TwilioSettings { get; }

        /// <summary>Gets the configuration of the application.</summary>
        public IConfiguration Configuration { get; }

        public AuthService(IConfiguration config)
        {
            this.Configuration = config;
            this.TwilioSettings = Configuration.GetSection(nameof(this.TwilioSettings)).Get<TwilioSettings>();
        }

        public string SendToken(string phoneNumber)
        {
            try
            {

            
            var r = new Random((int)DateTime.Now.Ticks);
           // var twilioClient = new TwilioRestClient(
          //      TwilioSettings.AccountSid,
           //     TwilioSettings.AuthToken);

            TwilioClient.Init(TwilioSettings.AccountSid, TwilioSettings.AuthToken);


            // Generate six-digit token
            string token = r.Next(100000, 1000000).ToString();

            /* await twilioClient.RequestAsync(
                TwilioConfig.PhoneNumber,
                phoneNumber,
                 string.Format("Your auth token is {0}.", token));
             */

            var to = new PhoneNumber("+16106625573");
            var message = MessageResource.Create(
                to,
                from: new PhoneNumber(TwilioSettings.PhoneNumber),
                body: "This is the ship that made the Kessel Run in fourteen parsecs?");

            //Console.WriteLine(message.Sid);

            return token;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
