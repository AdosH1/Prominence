using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using Prominence.Model.Interfaces;
using Prominence.Model;

namespace Prominence.ViewModel 
{
    public class CombatViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Label> CombatLog { get; set; }

        private double _playerHealth;
        private double _playerMaxHealth;
        private double _playerEnergy;
        private double _playerMaxEnergy;
        public double PlayerMaxHealth
        {
            get { return _playerMaxHealth; }
            set
            {
                _playerMaxHealth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerMaxHealth)));
            }
        }
        public double PlayerHealth
        {
            get { return _playerHealth; }
            set
            {
                _playerHealth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerHealth)));
            }
        }
        public double PlayerMaxEnergy
        {
            get { return _playerMaxEnergy; }
            set
            {
                _playerMaxEnergy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerMaxEnergy)));
            }
        }
        public double PlayerEnergy
        {
            get { return _playerEnergy; }
            set
            {
                _playerEnergy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayerEnergy)));
            }
        }

        public CombatViewModel(ICreatureEntity creature)
        {
            _playerHealth = creature.Health;
            _playerMaxHealth = creature.MaxHealth;

            var player = (PlayerModel)creature;
            if (player != null)
            {
                _playerEnergy = player.Energy;
                _playerMaxEnergy = player.MaxEnergy;
            }
        }



    }
}
