using Laba26.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba26.WPF.Commands
{
    public class AddEntityAsyncCommand<TEntity> : AsyncCommandBase
    {
        private readonly MainViewModel _mainViewModel;
        private TEntity _entity;

        public AddEntityAsyncCommand(MainViewModel mainViewModel, TEntity entity)
        {
            _mainViewModel = mainViewModel;
            _entity = entity;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return Task.WhenAll(AddNumber());
        }

        private async Task AddNumber()
        {
            await Task.Factory.StartNew(() =>
            {
                _mainViewModel.InputText = _mainViewModel.InputText.Insert(_mainViewModel.InputText.Length, _entity.ToString());
            });
        }
    }
}