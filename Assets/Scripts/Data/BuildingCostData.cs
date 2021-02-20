using System;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.Data
{
    [CreateAssetMenu(fileName = "Building Cost Data", menuName = "Game Data/Building Cost Data")]
    public class BuildingCostData : ScriptableObject
    {
        [SerializeField]
        public List<Cost> Costs;
    }

    [Serializable]
    public class Cost
    {
        public string Name;
        public int Value;
    }
}