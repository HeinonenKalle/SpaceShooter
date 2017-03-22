using UnityEngine;

namespace SpaceShooter.GUI
{
    public class GlobalGUI : MonoBehaviour
    {
        private LoadingIndicator _loader;

        // Use this for initialization
        void Awake()
        {
            DontDestroyOnLoad(gameObject);

            _loader = GetComponentInChildren<LoadingIndicator>(true);
            _loader.Init();
        }
    }
}
