using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter.GUI
{
    public class Window : MonoBehaviour
    {

        // Use this for initialization
        public void Open()
        {
            gameObject.SetActive(true);
        }

        // Update is called once per frame
        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}
