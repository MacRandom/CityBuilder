using UnityEngine;

namespace CityBuilder.BuildingSystem
{
    public class StructureBuilder : MonoBehaviour
    {
        [SerializeField]
        private GameObject _buildingPrefab;
        [SerializeField]
        private GameObject _placeholderPrefab;
        private GameObject _placeholder;
        private float _xMin = -20f;
        private float _xMax = 19f;
        private float _zMin = -20f;
        private float _zMax = 19f;
        private BuildingPossibility _buildingPossibility;

        private void OnEnable()
        {
            _placeholder = Instantiate(_placeholderPrefab);
            _buildingPossibility = _placeholder.GetComponentInChildren<BuildingPossibility>();
        }

        private void OnDisable()
        {
            Destroy(_placeholder);
        }

        private void FixedUpdate()
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

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
                if (_buildingPossibility.IsPossible)
                    Instantiate(_buildingPrefab, _placeholder.transform.position, Quaternion.identity);
        }
    }
}