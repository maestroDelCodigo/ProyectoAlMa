using System;

namespace ApiEjemplo.Features.Activities
{
    public class ActivityRead
    {
        public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset FinishDate { get; set; }
        public string Creator { get; set; }
    }
}