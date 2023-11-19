using UnityEngine;

namespace BFX
{
    public class NoteRegionFittedCollider : MonoBehaviour
    {
        private NoteRegion m_noteRegion;
        
        private BoxCollider2D m_collider;

        [SerializeField] private Vector2 m_offset;
        [SerializeField] private Vector2 m_padding;
        
        private void Awake()
        {
            m_noteRegion = GetComponentInParent<NoteRegion>();
            
            m_collider = GetComponent<BoxCollider2D>();
        }

        private void OnEnable()
        {
            if(m_noteRegion) { m_noteRegion.OnSizeUpdated += OnSizeUpdated; }
        }

        private void OnDisable()
        {
            if (m_noteRegion) { m_noteRegion.OnSizeUpdated -= OnSizeUpdated; }
        }

        private void OnSizeUpdated(Vector2 _size)
        {
            m_collider.offset = m_offset;
            m_collider.size = _size + m_padding;
        }
    }
}
