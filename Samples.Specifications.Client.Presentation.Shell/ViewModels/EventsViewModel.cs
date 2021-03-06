﻿using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using LogoFX.Client.Mvvm.Commanding;
using LogoFX.Client.Mvvm.ViewModel;
using LogoFX.Client.Mvvm.ViewModel.Extensions;
using Samples.Client.Model.Contracts;

namespace Samples.Specifications.Client.Presentation.Shell.ViewModels
{
    public sealed class EventsViewModel : BusyScreen, IDisposable
    {
        private readonly IDataService _dataService;        

        public EventsViewModel(IDataService dataService)
        {
            _dataService = dataService;
        }

        private IActionCommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _clearCommand ??
                       (_clearCommand = ActionCommand
                           .When(() => true)
                           .Do(async () =>
                           {
                               IsBusy = true;

                               try
                               {
                                   await _dataService.ClearEventsAsync();
                               }

                               finally
                               {
                                   IsBusy = false;
                               }
                           }));
            }
        }

        private IActionCommand _startCommand;
        public ICommand StartCommand
        {
            get
            {
                return _startCommand ??
                       (_startCommand = ActionCommand
                           .When(() => !_dataService.EventMonitoringStarted)
                           .Do(() =>
                           {
                               _dataService.StartEventMonitoring();
                           })                           
                           .RequeryOnPropertyChanged(this, () => _dataService.EventMonitoringStarted));
            }
        }

        private IActionCommand _stopCommand;
        public ICommand StopCommand
        {
            get
            {
                return _stopCommand ??
                       (_stopCommand = ActionCommand
                           .When(() => _dataService.EventMonitoringStarted)
                           .Do(() =>
                           {
                               _dataService.StopEventMonitoring();
                           })
                           .RequeryOnPropertyChanged(this, () => _dataService.EventMonitoringStarted));
            }
        }

        private IEnumerable _events;
        public IEnumerable Events => _events ?? (_events = CreateEvents());

        private IEnumerable CreateEvents()
        {
            var result = new WrappingCollection
            {
                FactoryMethod = o => new EventViewModel((IEvent) o)
            };
            result.AddSource(_dataService.Events);

            var view = result.AsView();
            view.SortDescriptions.Add(new SortDescription("Time", ListSortDirection.Descending));

            return view;
        }

        public void Dispose()
        {
            _clearCommand?.Dispose();
            _startCommand?.Dispose();
            _stopCommand?.Dispose();
        }
    }
}