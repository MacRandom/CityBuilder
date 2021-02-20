using UnityEngine;
using CityBuilder.Data;
using CityBuilder.Game;

namespace CityBuilder.BuildingSystem
{
    public class StructureBuilder : MonoBehaviour
    {
        [SerializeField]
        private ResourceManager _resourceManager;

        private GameObject _buildingPrefab;
        private GameObject _placeholder;
        private float _xMin = -20f;
        private float _xMax = 19f;
        private float _zMin = -20f;
        private float _zMax = 19f;
        private BuildingPossibility _buildingPossibility;
        private Structure _structure;

        public void BuildingStart(BuildingData buildingData)
        {
            if (_placeholder != null)
                Destroy(_placeholder);

            _placeholder = Instantiate(buildingData.PlaceholderPrefab);
            _buildingPossibility = _placeholder.GetComponentInChildren<BuildingPossibility>();
            _buildingPrefab = buildingData.BuildingPrefab;
            _structure = _buildingPrefab.GetComponent<Structure>();
        }

        private void FixedUpdate()
        {
            if (_placeholder != null)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                    if (hit.transform.CompareTag("Ground"))
                    {
                        _placeholder.transform.position = new Vector3(
                            Mathf.Clamp(Mathf.Round(hit.point.x), _xMin, _xMax),
                            0,
                            Mathf.Clamp(Mathf.Round(hit.point.z), _zMin, _zMax));
                    }
            }
        }

        private void Update()
        {
            if (_placeholder != null && _buildingPrefab != null)
                if (Input.GetMouseButtonDown(0))
                    if (_buildingPossibility.IsPossible && _resourceManager.IsEnoughResources(_structure.BuildingCostData))
                    {
                        _resourceManager.SpentResource(_structure.BuildingCostData);
                        Instantiate(_buildingPrefab, _placeholder.transform.position, Quaternion.identity);
                        Destroy(_placeholder);
                    }
        }
    }
}