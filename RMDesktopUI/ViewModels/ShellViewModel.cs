using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using RMDesktopUI.EventModels;

namespace RMDesktopUI.ViewModels
{
    /// <summary>
    /// Wrapps user-controlls in order to make them visible without oppening to many windows.
    /// </summary>
    public class ShellViewModel : Conductor<object>, IHandle<LogOnEvent>
    {
        private IEventAggregator _events;
        private SalesViewModel _salesVM;
        private SimpleContainer _container;

        public ShellViewModel(IEventAggregator events, SalesViewModel salesVM,
            SimpleContainer container)
        {
            //Help us to publish and subscribe to events.
            _events = events;
            _salesVM = salesVM;

            _container = container;

            //Subscribing this class to ever event that should happen in our event system
            //but we only handle LogOnEvents because our ShellViewModel class listen for 
            //this particular event messages through the implementation of the interface IHandle<LogOnEvent>
            _events.Subscribe(this);
            
            //Assures that this particular VM (login) is empty ever time it is requested
            //in order to prevent that sensitive information from some sorting of leaking
            ActivateItem(_container.GetInstance<LoginViewModel>());
        }
               
        public void Handle(LogOnEvent message)
        {
            ActivateItem(_salesVM);          
        }
    }
}
