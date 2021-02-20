using System;
using CityBuilder.Game;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CityBuilder.BuildingSystem
{
    public class BuildStructure : MonoBehaviour
    {
        public event EventHandler Builded;

        private Structure _structure;

        private void Awake()
        {
            _structure = GetComponent<Structure>();
            StartBuilding();
        }

        private async void StartBuilding()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_structure.BuildingTime), ignoreTimeScale: true);

            Builded?.Invoke(this, EventArgs.Empty);
        }
    }
}