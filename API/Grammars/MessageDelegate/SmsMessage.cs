using System;

namespace GAPI.Grammars {
    public class SmsMessage : IMessage
    {
        public string Send()
        {
            return  "Sms发送成功";
        }


        
    }

}