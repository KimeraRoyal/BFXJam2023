using UnityEngine;

namespace BFX
{
    public class OffscreenCheck : MonoBehaviour
    {
        private bool hasBeenOnScreen = false;

        private void OnBecameVisible()
        {
            hasBeenOnScreen = true;
        }

        private void OnBecameInvisible()
        {   
            if (hasBeenOnScreen)
            // Checks whether the object has gone offscreen and destroys it
            Destroy(gameObject);
        }
    }
}