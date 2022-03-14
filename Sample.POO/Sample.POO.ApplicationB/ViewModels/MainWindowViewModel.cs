using Microsoft.Extensions.Logging;
using Sample.POO.Core.abstractions;
using Sample.POO.Core.Domain;
using Sample.POO.Services.ReceiveMessagesServices;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace Sample.POO.ApplicationB.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<TruckEvent> TruckEvents { get; } = new ObservableCollection<TruckEvent>();
        public ObservableCollection<StorageReferenceResponse> StorageReferenceResponses { get; } = new ObservableCollection<StorageReferenceResponse>();

        private readonly ITruckEventListenerService truckEventListenerService;
        private readonly IStorageQuantityAnswerListenerService storageQuantityAnswerListenerService;
        private readonly ILogger<MainWindowViewModel> logger;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string reference = "Sample reference";
        public string Reference
        {
            get { return reference; }
            set
            {
                reference = value;
                OnPropertyChanged();
            }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                // Call OnPropertyChanged whenever the property is updated
                OnPropertyChanged();
            }
        }

        public ICommand SearchQuantityCommand { get; }

        public MainWindowViewModel(ITruckEventListenerService truckEventListenerService,
                                    IStorageQuantityAnswerListenerService requestStorageQuantityListenerService,
                                    SearchReferenceCommand searchCommand,
                                    ILogger<MainWindowViewModel> logger)
        {
            this.truckEventListenerService = truckEventListenerService;
            this.storageQuantityAnswerListenerService = requestStorageQuantityListenerService;
            this.SearchQuantityCommand = searchCommand;
            this.logger = logger;
        }

        public async Task Init(Dispatcher dispatcher)
        {
            logger.LogInformation("Init main view model.");

            await truckEventListenerService.StartListener(e =>
            {
                dispatcher.Invoke(() =>
                {
                    TruckEvents.Add(e);
                });
            });

            await storageQuantityAnswerListenerService.StartListener(e =>
            {
                dispatcher.Invoke(() =>
                {
                    StorageReferenceResponses.Add(e);
                });
            });
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
