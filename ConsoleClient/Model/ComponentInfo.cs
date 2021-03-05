using System;

namespace ConsoleClient.Model
{
    internal class ComponentInfo
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public double Distance { get; set; }
        public double Weight { get; set; }
        public ComponentType ComponentType { get; set; }
        public DateTimeOffset AddedOn { get; set; }
        public DateTimeOffset? RetiredOn { get; set; }
    }
}