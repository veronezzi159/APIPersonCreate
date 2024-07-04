using APIPersonCreate.Domain.Contracts.v1;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIPersonCreate.Domain.Services.v1
{
    public sealed class DomainNotificationServiceHandler : IDomainNotificationService
    {
        private readonly List<string> _notifications = new List<string>();

        private bool _disposed;

        public bool HasNotification => _notifications.Count > 0;

        public void Add(string message)
        {
            _notifications.Add(message);
        }

        public void AddRange(IEnumerable<string> messages)
        {
            _notifications.AddRange(messages);
        }

        public IReadOnlyList<string> Get()
        {
            return _notifications.ToImmutableList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~DomainNotificationServiceHandler()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing) _notifications.Clear();

            _disposed = true;
        }
    }
}
