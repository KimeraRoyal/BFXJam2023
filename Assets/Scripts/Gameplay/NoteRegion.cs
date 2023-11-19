using System;
using UnityEngine;

namespace BFX
{
    public class NoteRegion : MonoBehaviour
    {
        [SerializeField] private Vector2 m_size = Vector2.one;
        private Vector2 m_lastSize;
        
        public Action<Vector2> OnSizeUpdated;
        
        public Vector2 Size
        {
            get => m_size;
            set => m_size = value;
        }

        private void Start()
        {
            CheckSizeChanged();
        }

        private void Update()
        {
            CheckSizeChanged();
        }

        private void CheckSizeChanged()
        {
            if(m_size == m_lastSize) { return; }
            OnSizeUpdated?.Invoke(m_size);
            m_lastSize = m_size;
        }
    }
}
