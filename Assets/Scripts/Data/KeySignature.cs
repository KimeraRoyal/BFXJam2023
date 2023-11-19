using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BFX
{
    [Serializable]
    public struct KeySignature
    {
        [EnumToggleButtons]
        [SerializeField] private Note m_rootNote;
        
        [EnumToggleButtons]
        [SerializeField] private Scale m_scale;

        public Note RootNote => m_rootNote;
        public Scale Scale => m_scale;
    }
}
