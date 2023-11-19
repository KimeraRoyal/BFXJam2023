using UnityEngine;

namespace BFX
{
    public class LevelLoader : MonoBehaviour
    {
        private Pattern[] m_patterns;
        
        [SerializeField] private PatternData[] m_patternData;

        [SerializeField] private Pattern m_patternPrefab;
        
        private void Start()
        {
            m_patterns = new Pattern[m_patternData.Length];
            for (var i = 0; i < m_patternData.Length; i++)
            {
                var pattern = Instantiate(m_patternPrefab, transform);
                pattern.Load(m_patternData[i]);
                m_patterns[i] = pattern;
            }
        }
    }
}
