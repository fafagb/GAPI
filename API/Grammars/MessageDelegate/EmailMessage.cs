using System;

namespace GAPI.Grammars {
    public class EmailMessage : IMessage
    {
        public string Send()
        {
            return  "Email发送成功";
        }
    }

}