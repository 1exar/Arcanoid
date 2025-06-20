using UnityEngine;

namespace Arcanoid.Scripts.Common
{
    public class MainRoot : MonoBehaviour
    {
        void Start()
        {
            // Load Menu by default
            UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
        }
    }
}