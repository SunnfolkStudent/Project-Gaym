using UnityEngine;

namespace System
{
    public class Transition : MonoBehaviour
    {
        public SceneController sceneController;
        public void LoadLoadLevel()
        {
            sceneController.LoadScene("Test 2");
        }
    }
}
