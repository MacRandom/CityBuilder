using System.Collections;
using System.Collections.Generic;
using CityBuilder.BuildingSystem;
using CityBuilder.Data;
using UnityEngine;

namespace CityBuilder.Game
{
    public class Vault : MonoBehaviour
    {
        [SerializeField]
        private VaultData _vaultData;
        private BuildStructure _buildStructure;
        private ResourceManager _resourceManager;

        private void Awake()
        {
            _resourceManager = FindObjectOfType<ResourceManager>();
            _buildStructure = GetComponent<BuildStructure>();
            _buildStructure.Builded += OnBuilded;
        }

        private void OnBuilded(object sender, System.EventArgs e)
        {
            _resourceManager.VaultBuilded(_vaultData.Resource, _vaultData.Capacity);
        }
    }
}