using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    public class SnapPoint : MonoBehaviour
    {
        public GameObject snappedObject;
        public bool taken;

        private void OnTriggerStay(Collider other)
        {
            // check if collided objcet is a draggable by looking for draggable script
            if (other.gameObject.GetComponent<Drag>() && !taken)
            {
                Drag client = other.gameObject.GetComponent<Drag>();
                client.snapped = true;
                client.snapPoint = this;
                taken = true;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<Drag>())
            {
                Drag client = other.gameObject.GetComponent<Drag>();
                client.snapped = false;
                client.snapPoint = null;
                taken = false;
            }
        }
    }
}
