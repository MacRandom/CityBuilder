using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CityBuilder.Data
{
    [CreateAssetMenu(fileName = "Building Data", menuName ="Game Data/Building Data")]
    public class BuildingData : ScriptableObject
    {
        public GameObject BuildingPrefab;
        public GameObject PlaceholderPrefab;
    }
}