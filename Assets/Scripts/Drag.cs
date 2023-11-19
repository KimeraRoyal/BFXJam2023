using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    public class Drag : MonoBehaviour
    {
        // Variables for dragging
        public bool dragging = false;
        private Vector3 offset;
        // Variables for snapping to snap points
        public SnapPoint snapPoint;
        public bool snapped = false;

        void Update()
        {
            if (dragging)
            {
                transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
            }
            if (!dragging && snapped)
            {
                if (snapPoint != null)
                {
                    transform.position = snapPoint.transform.position;
                }
            }
        }

        private void OnMouseDown()
        {
            offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dragging = true;
            if (snapped)
            {
                snapPoint.taken = false;
                snapPoint.snappedObject = null;
            }
        }

        private void OnMouseUp()
        {
            dragging = false;
        }
    }
}
