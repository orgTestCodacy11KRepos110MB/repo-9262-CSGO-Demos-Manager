﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Core;
using Core.Models;
using Core.Models.Events;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using MahApps.Metro.Controls.Dialogs;
using Manager.Properties;
using Manager.Services;
using Manager.ViewModel.Demos;
using Services.Concrete;
using Services.Interfaces;
using Services.Models;
using Services.Models.Stats;
using Services.Models.Timelines;

namespace Manager.ViewModel.Rounds
{
    public class RoundDetailsViewModel : DemoViewModel
    {
        #region Properties

        private readonly IDialogService _dialogService;

        private readonly IRoundService _roundService;

        private readonly IPlayerService _playerService;

        private readonly ICacheService _cacheService;

        private int _roundNumber;

        private Round _currentRound;

        private KillEvent _selectedKill;
        private DateTime _periodStart;
        private DateTime _periodEnd;

        private List<TimelineEvent> _roundEventList;

        private List<PlayerRoundStats> _playersStats;

        private DateTime _visibleStartTime;

        private DateTime _visibleEndTime;

        private RelayCommand _windowLoadedCommand;

        private RelayCommand<KillEvent> _watchKillCommand;

        private RelayCommand _goToNextRoundCommand;

        private RelayCommand _goToPreviousRound;

        private RelayCommand _watchRoundCommand;

        #endregion

        #region Accessors

        public int RoundNumber
        {
            get { return _roundNumber; }
            set { Set(() => RoundNumber, ref _roundNumber, value); }
        }

        public Round CurrentRound
        {
            get { return _currentRound; }
            set { Set(() => CurrentRound, ref _currentRound, value); }
        }

        public DateTime PeriodStart
        {
            get { return _periodStart; }
            set { Set(() => PeriodStart, ref _periodStart, value); }
        }

        public DateTime PeriodEnd
        {
            get { return _periodEnd; }
            set { Set(() => PeriodEnd, ref _periodEnd, value); }
        }

        public List<TimelineEvent> RoundEventList
        {
            get { return _roundEventList; }
            set { Set(() => RoundEventList, ref _roundEventList, value); }
        }

        public List<PlayerRoundStats> PlayersStats
        {
            get { return _playersStats; }
            set { Set(() => PlayersStats, ref _playersStats, value); }
        }

        public KillEvent SelectedKill
        {
            get { return _selectedKill; }
            set { Set(() => SelectedKill, ref _selectedKill, value); }
        }

        public DateTime VisibleStartTime
        {
            get { return _visibleStartTime; }
            set { Set(() => VisibleStartTime, ref _visibleStartTime, value); }
        }

        public DateTime VisibleEndTime
        {
            get { return _visibleEndTime; }
            set { Set(() => VisibleEndTime, ref _visibleEndTime, value); }
        }

        #endregion

        #region Commands

        /// <summary>
        /// Command to watch the round
        /// </summary>
        public RelayCommand WatchRoundCommand
        {
            get
            {
                return _watchRoundCommand
                       ?? (_watchRoundCommand = new RelayCommand(
                           async () =>
                           {
                               try
                               {
                                   GameLauncherConfiguration config = Config.BuildGameLauncherConfiguration(Demo);
                                   config.FocusPlayerSteamId = Settings.Default.WatchAccountSteamId;
                                   GameLauncher launcher = new GameLauncher(config);
                                   await launcher.WatchDemoAt(CurrentRound.Tick);
                               }
                               catch (Exception ex)
                               {
                                   await HandleGameLauncherException(ex);
                               }
                           },
                           () => CurrentRound != null));
            }
        }

        /// <summary>
        /// Command to go to the next round
        /// </summary>
        public RelayCommand GoToNextRoundCommand
        {
            get
            {
                return _goToNextRoundCommand
                       ?? (_goToNextRoundCommand = new RelayCommand(
                           async () =>
                           {
                               RoundNumber++;
                               await LoadData();
                           },
                           () => RoundNumber < Demo.Rounds.Count));
            }
        }

        /// <summary>
        /// Command to go to the previous round
        /// </summary>
        public RelayCommand GoToPreviousRoundCommand
        {
            get
            {
                return _goToPreviousRound
                       ?? (_goToPreviousRound = new RelayCommand(
                           async () =>
                           {
                               RoundNumber--;
                               await LoadData();
                           },
                           () => RoundNumber > 1));
            }
        }

        public RelayCommand WindowLoaded
        {
            get
            {
                return _windowLoadedCommand
                       ?? (_windowLoadedCommand = new RelayCommand(
                           async () => { await LoadData(); }));
            }
        }

        #endregion

        private async Task LoadData()
        {
            Demo.WeaponFired = await _cacheService.GetDemoWeaponFiredAsync(Demo);
            CurrentRound = Demo.Rounds.First(r => r.Number == RoundNumber);
            PeriodStart = DateTime.Today;
            PeriodEnd = DateTime.Today.AddSeconds(CurrentRound.Duration);
            VisibleStartTime = PeriodStart.AddSeconds(-5);
            VisibleEndTime = PeriodEnd.AddSeconds(5);
            RoundEventList = await _roundService.GetTimeLineEventList(Demo, CurrentRound);
            PlayersStats = await _playerService.GetPlayerRoundStatsListAsync(Demo, CurrentRound);
        }

        public RelayCommand<KillEvent> WatchKillCommand
        {
            get
            {
                return _watchKillCommand
                       ?? (_watchKillCommand = new RelayCommand<KillEvent>(
                           async kill =>
                           {
                               try
                               {
                                   GameLauncherConfiguration config = Config.BuildGameLauncherConfiguration(Demo);
                                   config.FocusPlayerSteamId = kill.KillerSteamId;
                                   GameLauncher launcher = new GameLauncher(config);
                                   await launcher.WatchDemoAt(kill.Tick, true);
                               }
                               catch (Exception ex)
                               {
                                   await HandleGameLauncherException(ex);
                               }
                           }));
            }
        }

        public RoundDetailsViewModel(IDialogService dialogService, IRoundService rounderService, IPlayerService playerService,
            ICacheService cacheService)
        {
            _dialogService = dialogService;
            _roundService = rounderService;
            _playerService = playerService;
            _cacheService = cacheService;

            if (IsInDesignMode)
            {
                DispatcherHelper.Initialize();
                Application.Current.Dispatcher.Invoke(async () =>
                {
                    Demo = await _cacheService.GetDemoDataFromCache(string.Empty);
                    RoundNumber = 10;
                    await LoadData();
                });
            }
        }
    }
}
