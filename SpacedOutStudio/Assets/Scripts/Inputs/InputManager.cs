using UnityEngine;

namespace Inputs
{
    public class InputManager : MonoBehaviour
    {
        private ActionInputs _inputs;
        [HideInInspector]public bool pause;
        [HideInInspector]public bool interact;
        [HideInInspector]public bool log;

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
