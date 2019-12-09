using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class MouseCursor : MonoBehaviour
    {
        [SerializeField] private float _hideTime;
        [SerializeField] private Image _cursorImage;
        private Camera _camera;
        private float _timeHidden;

        private void Awake()
        {
            _camera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }

        private void Update()
        {
            var mouseDelta = Mathf.Abs(Input.GetAxis("Mouse X")) + Mathf.Abs(Input.GetAxis("Mouse Y"));
            if (mouseDelta > 0)
            {
                _cursorImage.enabled = true;
                _timeHidden = 0;
            }
            else
            {
                _timeHidden += Time.deltaTime;
                if (_timeHidden >= _hideTime)
                {
                    _cursorImage.enabled = false;
                }
            }
            var mouseWorldPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
            mouseWorldPosition.z = 0;
            transform.position = mouseWorldPosition;
            // Disable normal cursor.
            Cursor.visible = false;
        }
    }
}
