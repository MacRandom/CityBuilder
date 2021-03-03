using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceGatherer : MonoBehaviour
{
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
                if (hit.transform.CompareTag("Building"))
                {
                    var mine = hit.transform.GetComponentInParent<MineUI>();
                    if (mine != null)
                        mine.Click();
                }
        }
    }
}
