using System;
using UnityEngine;

namespace BFX
{
    [RequireComponent(typeof(LabelledRegion), typeof(NoteRegion))]
    public class Window : MonoBehaviour
    {
        private LabelledRegion m_labelledRegion;
        private NoteRegion m_noteRegion;

        public LabelledRegion LabelledRegion => m_labelledRegion;
        public NoteRegion NoteRegion => m_noteRegion;

        private void Awake()
        {
            m_labelledRegion = GetComponentInChildren<LabelledRegion>();
            m_noteRegion = GetComponentInChildren<NoteRegion>();
        }
    }
}
