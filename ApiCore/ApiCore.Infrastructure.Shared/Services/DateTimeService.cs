using ApiCore.Application.Interfaces;
using System;

namespace ApiCore.Infrastructure.Shared.Services
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}
