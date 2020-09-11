using System;
namespace GAPI.Grammars {

    public class MessageBuilder {

        private IMessage _message;

        public string UseEmail () {

            _message = new EmailMessage ();

            return _message.Send ();

        }

        public string UseSms () {
            _message = new SmsMessage ();
            return _message.Send ();
        }

    }

}
