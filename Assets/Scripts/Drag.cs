using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    public class Drag : MonoBehaviour
    {
        // Variables for dragging
        private bool dragging = false;
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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("2DCEnter");
        }
        private void OnCollisionStay2D(Collision2D collision)
        {
            Debug.Log("2DCStay");
        }
        private void OnCollisionExit2D(Collision2D collision)
        {
            Debug.Log("2DCExit");
        }

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("CEnter");
        }
        private void OnCollisionStay(Collision collision)
        {
            Debug.Log("CStay");
        }
        private void OnCollisionExit(Collision collision)
        {
            Debug.Log("CExit");
        }
    }
}
