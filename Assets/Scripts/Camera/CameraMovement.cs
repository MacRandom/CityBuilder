using UnityEngine;

namespace CityBuilder.CameraSystem
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _xMinPosition;
        [SerializeField]
        private float _xMaxPosition;
        [SerializeField]
        private float _zMinPosition;
        [SerializeField]
        private float _zMaxPosition;


        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                var translateVector = new Vector3(-Input.GetAxis("Mouse X"), 0, -Input.GetAxis("Mouse Y")) * Time.deltaTime * _speed;
                transform.Translate(translateVector, Space.Self);

                transform.position = new Vector3(
                    Mathf.Clamp(transform.position.x, _xMinPosition, _xMaxPosition),
                    transform.position.y,
                    Mathf.Clamp(transform.position.z, _zMinPosition, _zMaxPosition));
            }
        }
    }
}
