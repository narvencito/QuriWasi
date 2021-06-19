using QuriWasi.Application.Common.Interfaces;
using System;

namespace QuriWasi.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
