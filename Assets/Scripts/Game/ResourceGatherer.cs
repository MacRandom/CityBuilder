using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceGatherer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

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
