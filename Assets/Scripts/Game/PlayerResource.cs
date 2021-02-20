using System;
using UnityEngine;

namespace CityBuilder.Game
{
    public class PlayerResource : MonoBehaviour
    {
        [SerializeField]
        private string _name;
        [SerializeField]
        private int _current;
        [SerializeField]
        private int _max;

        public event EventHandler<int> CurrentValueChanged;
        public event EventHandler<int> MaxValueChanged;

        public string Name { get => _name; }

        public int Current
        {
            get => _current;
            private set
            {
                if (_current != value)
                {
                    _current = value;
                    CurrentValueChanged?.Invoke(this, _current);
                }
            }
        }

        public int Max
        {
            get => _max;
            private set
            {
                if (_max != value)
                {
                    _max = value;
                    MaxValueChanged?.Invoke(this, _max);
                }
            }
        }

        public void OnGather(object sender, int value) => Current += value;
        public void OnSpent(object sender, int value) => Current -= value;
        public void OnVaultBuilded(object sender, int value) => Max += value;
    }
}