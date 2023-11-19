using System;
using UnityEngine;

namespace BFX
{
    public class LabelledRegion : MonoBehaviour
    {
        [SerializeField] private string m_label = "window";
        private string m_lastLabel;

        public Action<string> OnLabelUpdated;

        public string Label
        {
            get => m_label;
            set => m_label = value;
        }

        private void Start()
        {
            CheckLabelChanged();
        }

        private void Update()
        {
            CheckLabelChanged();
        }

        private void CheckLabelChanged()
        {
            if (m_label == m_lastLabel) { return; }
            OnLabelUpdated?.Invoke(m_label);
            m_lastLabel = m_label;
        }
    }
}