﻿using System.Collections.Generic;
using AspComet.Eventing;

namespace AspComet.MessageHandlers
{
    /// <summary>
    ///     A message handler which swallows the message without sending to any clients
    /// </summary>
    public class SwallowHandler : IMessageHandler
    {
        public string ChannelName { get; private set; }
        public IEnumerable<Client> Recipients { get; private set; }

        public SwallowHandler(string channelName)
        {
            this.ChannelName = channelName;
        }

        public MessageHandlerResult HandleMessage(Message request)
        {
            var e = new PublishingEvent(request);
            EventHub.Publish(e);

            return null;
        }
    }
}