using TMPro;
using UnityEngine;

namespace BFX
{
    public class WindowLabel : MonoBehaviour
    {
        private Window m_window;
        private NoteRegion m_noteRegion;
        
        private RectTransform m_rectTransform;
        private TMP_Text m_text;

        [SerializeField] private float m_canvasScale = 10;

        private void Awake()
        {
            m_window = GetComponentInParent<Window>();
            m_noteRegion = GetComponentInParent<NoteRegion>();
            
            m_rectTransform = GetComponent<RectTransform>();
            m_text = GetComponentInChildren<TMP_Text>();
        }

        private void OnEnable()
        {
            if(m_window) { m_window.OnLabelUpdated += OnLabelUpdated; }
            if(m_noteRegion) { m_noteRegion.OnSizeUpdated += OnSizeUpdated; }
        }

        private void OnDisable()
        {
            if(m_window) { m_window.OnLabelUpdated -= OnLabelUpdated; }
            if(m_noteRegion) { m_noteRegion.OnSizeUpdated -= OnSizeUpdated; }
        }

        private void OnSizeUpdated(Vector2 _size)
        {
            m_rectTransform.sizeDelta = _size * m_canvasScale;
            m_rectTransform.localScale = Vector2.one / m_canvasScale;
        }

        private void OnLabelUpdated(string _label)
        {
            m_text.text = _label;
        }
    }
}
