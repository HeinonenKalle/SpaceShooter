using UnityEngine;

namespace SpaceShooter.GUI
{
    public class GlobalGUI : MonoBehaviour
    {

        // Use this for initialization
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
