using UnityEngine;
using Vector2 = UnityEngine.Vector2;

namespace BFX
{
    public class NoteRegionFittedSprite : MonoBehaviour
    {
        private NoteRegion m_noteRegion;
        
        private SpriteRenderer m_sprite;

        [SerializeField] private Vector2 m_anchor = Vector2.one * 0.5f;
        [SerializeField] private Vector2 m_pivot = Vector2.one * 0.5f;

        [SerializeField] private Vector2 m_offset = Vector2.zero;
        [SerializeField] private Vector2 m_padding = Vector2.zero;

        [SerializeField] private bool m_trackWidth = true;
        [SerializeField] private bool m_trackHeight = true;
        
        private void Awake()
        {
            m_noteRegion = GetComponentInParent<NoteRegion>();
            
            m_sprite = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            if(m_noteRegion) { m_noteRegion.OnSizeUpdated += OnSizeUpdated; }
        }

        private void OnDisable()
        {
            if(m_noteRegion) { m_noteRegion.OnSizeUpdated -= OnSizeUpdated; }
        }

        private void OnSizeUpdated(Vector2 _size)
        {
            var newSize = m_sprite.size;
            if (m_trackWidth) { newSize.x = _size.x; }
            if (m_trackHeight) { newSize.y = _size.y; }
            m_sprite.size = newSize + m_padding;

            var pivotOffset = -(Vector2.one - m_pivot * 2.0f) * m_sprite.size * 0.5f;
            var anchoredPosition = -(Vector2.one - m_anchor * 2.0f) * _size * 0.5f;
            transform.localPosition = anchoredPosition - pivotOffset + m_offset;
        }
    }
}
