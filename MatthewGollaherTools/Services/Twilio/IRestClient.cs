﻿using Twilio.Rest.Api.V2010.Account;
using System.Threading.Tasks;

namespace GlobalTools.BusinessLogic
{
    public interface IRestClient
    {
        Task<MessageResource> SendMessage(string from, string to, string body);
    }
}
