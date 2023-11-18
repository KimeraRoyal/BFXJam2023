using System;
using UnityEngine;

namespace BFX
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private string m_label = "window";
        private string m_lastLabel;
        
        [SerializeField] private Vector2 m_size = Vector2.one;
        private Vector2 m_lastSize;

        public Action<string> OnLabelUpdated;
        public Action<Vector2> OnSizeUpdated;

        public string Label
        {
            get => m_label;
            set => m_label = value;
        }
        
        public Vector2 Size
        {
            get => m_size;
            set => m_size = value;
        }

        private void Start()
        {
            CheckValuesChanged();
        }

        private void Update()
        {
            CheckValuesChanged();
        }

        private void CheckValuesChanged()
        {
            CheckLabelChanged();
            CheckSizeChanged();
        }

        private void CheckLabelChanged()
        {
            if (m_label == m_lastLabel) { return; }
            OnLabelUpdated?.Invoke(m_label);
            m_lastLabel = m_label;
        }

        private void CheckSizeChanged()
        {
            if(m_size == m_lastSize) { return; }
            OnSizeUpdated?.Invoke(m_size);
            m_lastSize = m_size;
        }
    }
}
