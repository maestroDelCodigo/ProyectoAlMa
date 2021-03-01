using System;

namespace ApiEjemplo.Controllers
{
    public class ActivityCreate
    {
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset FinishDate { get; set; }
    }
}