using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using System.ComponentModel;
using Prominence.Model.Interfaces;
using Prominence.Model;
using Combat.Interfaces;

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

        public CombatViewModel(PlayerModel player)
        {
            _playerHealth = player.Health;
            _playerMaxHealth = player.MaxHealth;


            _playerEnergy = player.Energy;
            _playerMaxEnergy = player.MaxEnergy;
            
        }

        public void GetPlayerAction()
        {

        }

        public void ResolveStartOfTurnEffects(PlayerModel player, ICombatCreature creature)
        {
            foreach (var status in player.Statuses) {
                status.StartOfTurn();
            }
            foreach (var status in creature.Statuses) {
                status.StartOfTurn();
            }
        }

        public void ResolvePrePlayerCombatEffects(PlayerModel player, ICombatCreature creature)
        {
            foreach (var status in player.Statuses)
            {
                status.PrePlayerCombat();
            }
            foreach (var status in creature.Statuses) 
            {
                status.PrePlayerCombat();
            }
        }

        public bool Fight(PlayerModel player, ICombatCreature creature, Func<bool> battleCondition, Func<bool> winCondition)
        {


            while (battleCondition())
            {

                ResolveStartOfTurnEffects(player, creature);

                GetPlayerAction();

                ResolvePrePlayerCombatEffects(player, creature);


            }

            return winCondition();


        }



    }
}
