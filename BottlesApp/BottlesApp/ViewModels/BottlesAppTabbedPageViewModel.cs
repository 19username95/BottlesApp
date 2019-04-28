using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BottlesApp.ViewModels
{
	public class BottlesAppTabbedPageViewModel : ViewModelBase
	{
        public BottlesAppTabbedPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {

        }
	}
}
