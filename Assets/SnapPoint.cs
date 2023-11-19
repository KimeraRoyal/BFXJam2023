using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    public class SnapPoint : MonoBehaviour
    {
        public GameObject snappedObject;
        public bool taken;


        private void OnTriggerStay2D(Collider2D collision)
        {
            // check if collided objcet is a draggable by looking for draggable script
            if (collision.gameObject.GetComponent<Drag>() && !taken && collision.gameObject.GetComponent<Drag>().dragging)
            {
                Drag client = collision.gameObject.GetComponent<Drag>();
                client.snapped = true;
                client.snapPoint = this;
                taken = true;
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.GetComponent<Drag>())
            {
                Drag client = collision.gameObject.GetComponent<Drag>();
                client.snapped = false;
                client.snapPoint = null;
                taken = false;
            }
        }
    }
}
