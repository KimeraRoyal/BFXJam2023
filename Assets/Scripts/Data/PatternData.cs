using Sirenix.OdinInspector;
using UnityEngine;

namespace BFX
{
    [CreateAssetMenu(fileName = "New Pattern", menuName = "BFX/Pattern")]
    public class PatternData : ScriptableObject
    {
        [SerializeField] private string m_label = "pattern";

        [EnumToggleButtons]
        [SerializeField] private PatternType m_type;
        
        [SerializeField] private float m_tempo = 120;
        [SerializeField] private Vector2Int m_timeSignature = new Vector2Int(4, 4);

        [SerializeField] private int m_bars = 1;

        [SerializeField] private KeySignature m_keySignature;

        [SerializeField] private AudioClip m_source;
        [SerializeField] private Sprite m_waveform;

        public string Label => m_label;

        public PatternType Type => m_type;

        public float Tempo => m_tempo;
        public Vector2Int TimeSignature => m_timeSignature;

        public int Bars => m_bars;

        public KeySignature KeySignature => m_keySignature;

        public AudioClip Source => m_source;
        public Sprite Waveform => m_waveform;
    }
}
