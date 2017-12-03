﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.EventHubs;
using Microsoft.Azure.EventHubs.Processor;
using Newtonsoft.Json;

namespace STTestBackend
{
    public class PersonEventProcessor : IEventProcessor
    {
        public Task OpenAsync(PartitionContext context)
        {
            return Task.CompletedTask;
        }

        public Task CloseAsync(PartitionContext context, CloseReason reason)
        {
            return Task.CompletedTask;
        }

        public Task ProcessEventsAsync(PartitionContext context, IEnumerable<EventData> messages)
        {
            foreach (var eventData in messages)
            {
                var data = Encoding.UTF8.GetString(eventData?.Body != null ? eventData.Body.Array : new byte[0], eventData.Body.Offset, eventData.Body.Count);
                var person = JsonConvert.DeserializeObject<Person>(data);
                var dataPerson = new Model.Person()
                {
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    BirthDate = person.DateOfBirdth,
                    Id = Guid.NewGuid(),
                    FullName = $"{person.FirstName} {person.LastName}"
                };
            }

            return context.CheckpointAsync();
        }

        public Task ProcessErrorAsync(PartitionContext context, Exception error)
        {
            return Task.CompletedTask;
        }
    }
}
