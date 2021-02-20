using UnityEngine;
using CityBuilder.Data;
using CityBuilder.Game;
using UnityEngine.EventSystems;

namespace CityBuilder.BuildingSystem
{
    public class StructureBuilder : MonoBehaviour
    {
        [SerializeField]
        private ResourceManager _resourceManager;

        private GameObject _buildingPrefab;
        private BuildStructure _buildStructure;
        private GameObject _placeholder;
        private float _xMin = -20f;
        private float _xMax = 19f;
        private float _zMin = -20f;
        private float _zMax = 19f;
        private BuildingPossibility _buildingPossibility;
        private Structure _structure;
        private bool _isCurrentlyBuilding = false;

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
            if (Input.GetMouseButtonDown(1) || Input.GetButtonDown("Cancel"))
                Destroy(_placeholder);

            if (EventSystem.current.IsPointerOverGameObject())
                return;

            if (_isCurrentlyBuilding)
                return;

            if (_placeholder == null || _buildingPrefab == null)
                return;

            if (Input.GetMouseButtonDown(0))
                if (_buildingPossibility.IsPossible && _resourceManager.IsEnoughResources(_structure.BuildingCostData))
                {
                    _isCurrentlyBuilding = true;

                    _resourceManager.SpentResource(_structure.BuildingCostData);
                    var structure = Instantiate(_buildingPrefab, _placeholder.transform.position, Quaternion.identity);

                    _buildStructure = structure.GetComponent<BuildStructure>();
                    _buildStructure.Builded += OnBuilded;

                    Destroy(_placeholder);
                }
        }

        private void OnBuilded(object sender, System.EventArgs e)
        {
            _isCurrentlyBuilding = false;
            _buildStructure.Builded -= OnBuilded;
        }
    }
}