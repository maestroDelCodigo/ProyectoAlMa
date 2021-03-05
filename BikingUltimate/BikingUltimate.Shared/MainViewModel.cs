using System.Collections.Generic;
using System.Reactive;
using BikingUltimate.Client;
using BikingUltimate.Client.Model;
using ConsoleClient.Model;
using ReactiveUI;

namespace BikingUltimate
{
    public class MainViewModel : ReactiveObject
    {
        private ObservableAsPropertyHelper<ICollection<User>> users;

        public MainViewModel(IBikingService bikingService)
        {
            LoadUsers = ReactiveCommand.CreateFromTask(() => bikingService.GetUsers());
            users = LoadUsers.ToProperty(this, model => model.Users);
        }

        public ICollection<User> Users => users.Value;

        public ReactiveCommand<Unit, ICollection<User>> LoadUsers { get; }
    }
}