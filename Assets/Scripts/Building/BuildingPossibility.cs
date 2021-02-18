using System;
using UnityEngine;

namespace CityBuilder.BuildingSystem
{
    public class BuildingPossibility : MonoBehaviour
    {
        public event EventHandler<bool> PossibilityChanged;
        [SerializeField]
        private bool _isPossible = true;
        public bool IsPossible
        {
            get => _isPossible;
            private set
            {
                if (_isPossible != value)
                {
                    _isPossible = value;
                    PossibilityChanged.Invoke(this, _isPossible);
                }
            }
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Building"))
                IsPossible = false;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Building"))
                IsPossible = true;
        }
    }
}