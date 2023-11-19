using UnityEngine;

namespace BFX
{
    public class WindowCollider : MonoBehaviour
    {
        private Window m_window;
        
        private BoxCollider2D m_collider;

        [SerializeField] private Vector2 m_offset;
        [SerializeField] private Vector2 m_padding;
        
        private void Awake()
        {
            m_window = GetComponentInParent<Window>();
            
            m_collider = GetComponent<BoxCollider2D>();
        }

        private void OnEnable()
        {
            m_window.OnSizeUpdated += OnSizeUpdated;
        }

        private void OnDisable()
        {
            m_window.OnSizeUpdated -= OnSizeUpdated;
        }

        private void OnSizeUpdated(Vector2 _size)
        {
            m_collider.offset = m_offset;
            m_collider.size = _size + m_padding;
        }
    }
}
