using UnityEngine;

namespace BFX
{
    public class WindowSprite : MonoBehaviour
    {
        private Window m_window;
        
        private SpriteRenderer m_sprite;

        [SerializeField] private Vector2 m_anchor = Vector2.one * 0.5f;
        [SerializeField] private Vector2 m_pivot = Vector2.one * 0.5f;

        [SerializeField] private bool m_trackWidth = true;
        [SerializeField] private bool m_trackHeight = true;
        
        private void Awake()
        {
            m_sprite = GetComponent<SpriteRenderer>();
            
            m_window = GetComponentInParent<Window>();
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
            var newSize = m_sprite.size;
            if (m_trackWidth) { newSize.x = _size.x; }
            if (m_trackHeight) { newSize.y = _size.y; }
            m_sprite.size = newSize;

            var offset = (Vector2.one - m_pivot * 2.0f) * m_sprite.size * 0.5f;
            transform.localPosition = (Vector2.one - m_anchor * 2.0f) * _size * 0.5f + offset;
        }
    }
}
