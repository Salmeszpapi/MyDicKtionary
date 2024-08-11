using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDicKtionary.Models
{
    public class ViewModelFactory : IViewModelFactory
    {
        private IServiceProvider _serviceProvider;

        public ViewModelFactory(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public T Create<T>() where T : class
        {
            return _serviceProvider.GetRequiredService<T>();
        }
    }
}
