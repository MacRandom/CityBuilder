using System.Collections.Generic;
using CityBuilder.Data;
using UnityEngine;

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

        public bool TryGatherResource(string name, int value)
        {
            _resources.TryGetValue(name, out PlayerResource resource);
            int newValue = resource.Current + value;

            if (newValue > resource.Max)
                return false;

            resource.Gather(value);

            return true;
        }
    }
}