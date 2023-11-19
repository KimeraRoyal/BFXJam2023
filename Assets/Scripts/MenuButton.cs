using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BFX
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private int m_id;
        
        public void Button()
        {
            SceneManager.LoadScene(m_id);
        }
    }
}
