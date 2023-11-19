using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BFX
{
    [RequireComponent(typeof(NoteRegion))]
    public class Pattern : MonoBehaviour
    {
        private NoteRegion m_noteRegion;

        public NoteRegion NoteRegion => m_noteRegion;

        private void Awake()
        {
            m_noteRegion = GetComponentInChildren<NoteRegion>();
        }
    }
}
