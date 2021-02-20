using System;
using CityBuilder.Data;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CityBuilder.Game
{
    public class Mine : MonoBehaviour
    {
        [SerializeField]
        private MineData _mineData;
        [SerializeField]
        private MineUI _mineUI;
        private ResourceManager _resourceManager;
        private bool _isGathered;

        public bool IsGathered 
        { 
            get => _isGathered;
            private set
            {
                if (_isGathered != value)
                {
                    _isGathered = value;
                    _mineUI.SetShow(_isGathered);
                }
            }
        }

        private void Awake()
        {
            _resourceManager = FindObjectOfType<ResourceManager>();
            StartGather();
        }

        private void OnEnable()
        {
            _mineUI.Clicked += OnMineClick;
        }

        private void OnDisable()
        {
            _mineUI.Clicked -= OnMineClick;
        }

        public async void StartGather()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_mineData.GatherPeriod), ignoreTimeScale: true);

            IsGathered = true;
        }

        private void OnMineClick(object sender, EventArgs e)
        {
            if (IsGathered)
            {
                if (_resourceManager.TryGatherResource(_mineData.Resource, _mineData.GatherValue))
                {
                    IsGathered = false;

                    StartGather();
                }
            }

        }
    }
}
