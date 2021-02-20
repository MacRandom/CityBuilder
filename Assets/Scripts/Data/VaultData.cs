using UnityEngine;

namespace CityBuilder.Data
{
    [CreateAssetMenu(fileName = "Vault Data", menuName = "Game Data/Vault Data")]
    public class VaultData : ScriptableObject
    {
        public string Resource;
        public int Capacity;
    }
}