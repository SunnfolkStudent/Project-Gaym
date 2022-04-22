using UnityEngine;

namespace Inputs
{
    public class InputManager : MonoBehaviour
    {
        private ActionInputs _inputs;
        public bool pause;
        public bool interact;
        public bool log;

        private void Awake()
        {
            _inputs = new ActionInputs();
        }

        private void Update()
        {
            pause = _inputs.Player.Pause.WasPressedThisFrame();
            interact = _inputs.Player.Interact.WasPressedThisFrame();
            log = _inputs.Player.Log.WasPressedThisFrame();
        }

        private void OnEnable()
        {
            _inputs.Enable();
        }

        private void OnDisable()
        {
            _inputs.Disable();
        }
    }
}
