using Umniah_E_Sport.Application.Contracts.Persistence;
using Umniah_E_Sport.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umniah_E_Sport.Persistence.Repos
{
    public class NotificationLogRepo : BaseManager<NotificationLog>,INotificationLogManager
    {
        public NotificationLogRepo(UmniahContext context) : base(context)
        {
        }
    }
}
