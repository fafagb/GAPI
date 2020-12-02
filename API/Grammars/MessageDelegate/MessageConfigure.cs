using System;
namespace GAPI.Grammars {

    public class MessageConfigure {

        public void Send (Action<MessageBuilder> configure) {

            MessageBuilder builder = new MessageBuilder ();
            configure (builder);

        }

    }
}