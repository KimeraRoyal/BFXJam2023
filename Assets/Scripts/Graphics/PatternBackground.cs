using System;
using UnityEngine;

namespace BFX
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class PatternBackground : MonoBehaviour
    {
        private Pattern m_pattern;

        private SpriteRenderer m_spriteRenderer;

        [SerializeField] private Sprite[] m_backgrounds;
        
        private void Awake()
        {
            m_pattern = GetComponentInParent<Pattern>();
            
            m_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            if(m_pattern) { m_pattern.OnTypeUpdated += OnTypeUpdated; }
        }

        private void OnDisable()
        {
            if(m_pattern) { m_pattern.OnTypeUpdated -= OnTypeUpdated; }
        }

        private void OnTypeUpdated(PatternType _type)
        {
            var typeIndex = (int)_type;
            if (typeIndex >= m_backgrounds.Length) { typeIndex = 0; }
            m_spriteRenderer.sprite = m_backgrounds[typeIndex];
        }
    }
}
