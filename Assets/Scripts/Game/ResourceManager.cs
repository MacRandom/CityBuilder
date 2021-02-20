using System.Collections.Generic;
using UnityEngine;
using CityBuilder.Data;

namespace CityBuilder.Game
{
    public class ResourceManager : MonoBehaviour
    {
        private Dictionary<string, PlayerResource> _resources = new Dictionary<string, PlayerResource>();

        private void Awake()
        {
            var resources = GetComponentsInChildren<PlayerResource>();
            foreach (var resource in resources)
                _resources.Add(resource.Name, resource);
        }

        public bool IsEnoughResources(BuildingCostData buildingCost)
        {
            foreach (var cost in buildingCost.Costs)
            {
                _resources.TryGetValue(cost.Name, out PlayerResource resource);

                if (cost.Value > resource.Current)
                    return false;
            }

            return true;
        }

        public void SpentResource(BuildingCostData buildingCost)
        {
            foreach(var cost in buildingCost.Costs)
            {
                _resources.TryGetValue(cost.Name, out PlayerResource resource);
                resource.Spent(cost.Value);
            }
        }
    }
}