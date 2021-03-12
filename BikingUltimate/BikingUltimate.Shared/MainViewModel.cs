using System.Collections.Generic;

namespace BikingUltimate
{
    public class MainViewModel : ReactiveObject
    {
        private ObservableAsPropertyHelper<ICollection<User>> users;

        public MainViewModel(IPaymentSystemService bikingService)
        {
            LoadUsers = ReactiveCommand.CreateFromTask(() => bikingService.GetUsers());
            users = LoadUsers.ToProperty(this, model => model.Users);
        }

        public ICollection<User> Users => users.Value;

        public ReactiveCommand<Unit, ICollection<User>> LoadUsers { get; }
    }
}