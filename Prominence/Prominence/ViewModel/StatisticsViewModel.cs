using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Prominence.Model;
using Prominence.Model.Interfaces;

namespace Prominence.ViewModel
{
    public class StatisticsViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public StatisticsViewModel(ICreatureEntity creature)
        {
            _name = creature.Name;
            _experience = creature.Experience;
            _maxHealth = creature.MaxHealth; 
            _health = creature.Health;
            _strength = creature.Strength;
            _magic = creature.Magic;
            _speed = creature.Speed;


            var player = (PlayerModel)creature;
            if (player != null)
            {
                _maxEnergy = player.MaxEnergy;
                _energy = player.Energy;
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        private double _experience;
        public double Experience
        {
            get { return _experience; }
            set
            {
                _experience = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Experience)));
            }
        }

        private double _maxHealth;
        public double MaxHealth
        {
            get { return _maxHealth; }
            set
            {
                _maxHealth = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxHealth)));
            }
        }

        private double _health;
        public double Health
        {
            get { return _health; }
            set
            {
                _health = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Health)));
            }
        }

        private double _maxEnergy;
        public double MaxEnergy
        {
            get { return _maxEnergy; }
            set
            {
                _maxEnergy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(MaxEnergy)));
            }
        }

        private double _energy;
        public double Energy
        {
            get { return _energy; }
            set
            {
                _energy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Energy)));
            }
        }

        private double _strength;
        public double Strength { 
            get { return _strength; } 
            set
            {
                _strength = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Strength)));
            }
        }

        private double _magic;
        public double Magic
        {
            get { return _magic; }
            set
            {
                _magic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Magic)));
            }
        }

        private double _speed;
        public double Speed
        {
            get { return _speed; }
            set
            {
                _magic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Speed)));
            }
        }



    }
}
