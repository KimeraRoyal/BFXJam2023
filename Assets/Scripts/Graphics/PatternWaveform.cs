using UnityEngine;

namespace BFX
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PatternWaveform : MonoBehaviour
    {
        private Pattern m_pattern;

        private SpriteRenderer m_spriteRenderer;
        
        private void Awake()
        {
            m_pattern = GetComponentInParent<Pattern>();
            
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            if(m_pattern) { m_pattern.OnDataLoaded += OnDataLoaded; }
        }

        private void OnDisable()
        {
            if(m_pattern) { m_pattern.OnDataLoaded -= OnDataLoaded; }
        }

        private void OnDataLoaded(PatternData _data)
        {
            m_spriteRenderer.sprite = _data.Waveform;
        }
    }
}
