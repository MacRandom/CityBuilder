using UnityEngine;

namespace CityBuilder.Data
{
    [CreateAssetMenu(fileName = "Mine Data", menuName = "Game Data/Mine Data")]
    public class MineData : ScriptableObject
    {
        public string Resource;
        public int GatherValue;
        public int GatherPeriod;
    }
}