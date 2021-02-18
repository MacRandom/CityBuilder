using UnityEngine;

namespace CityBuilder.BuildingSystem
{
    public class PlaceholderMaterialChanger : MonoBehaviour
    {
        [SerializeField]
        private Material _acceptedMaterial;
        [SerializeField]
        private Material _deniedMaterial;
        private MeshRenderer _meshRenderer;
        private BuildingPossibility _buildingPossibility;

        private void Awake()
        {
            _meshRenderer = GetComponent<MeshRenderer>();
            _buildingPossibility = GetComponent<BuildingPossibility>();
        }

        private void OnEnable()
        {
            _buildingPossibility.PossibilityChanged += OnBuildingPossibilityChanged;
        }

        private void OnDisable()
        {
            _buildingPossibility.PossibilityChanged -= OnBuildingPossibilityChanged;
        }

        private void OnBuildingPossibilityChanged(object sender, bool isPossible)
        {
            if (isPossible)
                _meshRenderer.material = _acceptedMaterial;
            else
                _meshRenderer.material = _deniedMaterial;
        }
    }
}