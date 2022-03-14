using Sample.POO.Core.abstractions;
using System;
using System.Windows.Input;

namespace Sample.POO.ApplicationB.ViewModels
{
    public class SearchReferenceCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IRequestStorageQuantityService requestStorageQuantityService;

        public SearchReferenceCommand(IRequestStorageQuantityService requestStorageQuantityService)
        {
            this.requestStorageQuantityService = requestStorageQuantityService;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await requestStorageQuantityService.RequestForQuantity(new Core.Domain.StorageReferenceRequest()
            {
                Reference = parameter.ToString()
            });
        }
    }
}
