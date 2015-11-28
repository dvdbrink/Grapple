using UnityEngine;

namespace Grapple.Cameras
{
    public class FreeRoamCamera : MonoBehaviour
    {
        public float speed = 15f;
        public float mouseSensitivity = 50f;

        void Update()
        {
            HandleKeyboard();
            HandleMouse();
        }

        private void HandleKeyboard()
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward.normalized * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.position -= transform.forward.normalized * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.position -= transform.right.normalized * speed * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right.normalized * speed * Time.deltaTime;
            }
        }

        private void HandleMouse()
        {
            if (Input.GetMouseButton(1))
            {
                UpdateCursor(CursorLockMode.Locked, false);

                var yaw = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
                var pitch = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

                transform.eulerAngles += new Vector3(-pitch, yaw, 0);
            }
            else
            {
                UpdateCursor(CursorLockMode.None, true);
            }
        }

        private void UpdateCursor(CursorLockMode lockMode, bool visibility)
        {
            Cursor.lockState = lockMode;
            Cursor.visible = visibility;
        }
    }
}