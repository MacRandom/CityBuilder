using CityBuilder.BuildingSystem;
using CityBuilder.Data;
using UnityEngine;

namespace CityBuilder.Game
{
    public class Vault : MonoBehaviour
    {
        [SerializeField]
        private VaultData _vaultData;
        private BuildingTimer _buildingTimer;
        private ResourceManager _resourceManager;

        private void Awake()
        {
            _resourceManager = FindObjectOfType<ResourceManager>();
            _buildingTimer = GetComponent<BuildingTimer>();
            _buildingTimer.Builded += OnBuilded;
        }

        private void OnBuilded(object sender, System.EventArgs e)
        {
            _resourceManager.VaultBuilded(_vaultData.Resource, _vaultData.Capacity);
        }
    }
}