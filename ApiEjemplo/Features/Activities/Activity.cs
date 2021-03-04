using System;

namespace ApiEjemplo.Features.Activities
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset FinishDate { get; set; }
        public string Creator { get; set; }
    }
}