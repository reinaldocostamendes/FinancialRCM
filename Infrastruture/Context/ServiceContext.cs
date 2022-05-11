﻿using Infrastruture.Context.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastruture.Context
{
    public class ServiceContext : IServiceContext
    {
        private readonly List<string> _notifications;

        public ServiceContext()
        {
            _notifications = new List<string>();
        }

        public IReadOnlyCollection<string> Notifications
        { get { return _notifications.AsReadOnly(); } }

        public bool HasNotification() => Notifications.Count > 0;

        public void AddNotification(string message)
        {
            if (!Notifications.Contains(message))
                _notifications.Add(message);
        }
    }
}
