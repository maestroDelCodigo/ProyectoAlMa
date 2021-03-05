namespace BikingUltimate.Client.Model
{
    public class User
    {
        public string Username { get; set; }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return
                $"{nameof(Username)}: {Username}, {nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}";
        }
    }
}