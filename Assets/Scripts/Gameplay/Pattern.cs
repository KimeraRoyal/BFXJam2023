using System;
using UnityEngine;

namespace BFX
{
    [RequireComponent(typeof(LabelledRegion), typeof(NoteRegion))]
    public class Pattern : MonoBehaviour
    {
        private LabelledRegion m_labelledRegion;
        private NoteRegion m_noteRegion;

        private PatternData m_data;

        private PatternType m_lastType;

        public Action<PatternData> OnDataLoaded;

        public Action<PatternType> OnTypeUpdated;

        public LabelledRegion LabelledRegion => m_labelledRegion;
        public NoteRegion NoteRegion => m_noteRegion;

        public PatternData Data => m_data;

        private void Awake()
        {
            m_labelledRegion = GetComponentInChildren<LabelledRegion>();
            m_noteRegion = GetComponentInChildren<NoteRegion>();
        }

        private void Start()
        {
            CheckTypeChanged();
        }

        public void Load(PatternData _data)
        {
            if(!_data) { Debug.LogError("Tried to load Pattern Data that doesn't exist."); }

            m_data = _data;
            
            m_labelledRegion.Label = _data.Label;

            m_noteRegion.Size = new Vector2Int(_data.Bars, 1);

            OnDataLoaded?.Invoke(_data);

            CheckTypeChanged();
        }

        private void CheckTypeChanged()
        {
            if(m_data && m_data.Type == m_lastType) { return; }
            OnTypeUpdated?.Invoke(m_data.Type);
            m_lastType = m_data.Type;
        }
    }
}
