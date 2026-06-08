using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        // Using the generated C# file from input asset file
        private InputActions input;

        #region Input Events
        [SerializeField] private UnityEvent OnDash;
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            input = new InputActions();
            input.Enable();

            // Subscribe to actions
            input.Player.Dash.performed += Dash_Input;
        }
        private void OnDisable()
        {
            input.Disable();
        }
        #endregion

        #region Public Methods
        public Vector2 GetMovementVector()
        {
            Vector2 inputVector = input.Player.Move.ReadValue<Vector2>();
            // input is normalized in the input system file.

            //Debug.Log($"player input vector = {inputVector}");

            return inputVector;
        }
        #endregion

        #region Input Methods
        private void Dash_Input(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                OnDash?.Invoke();
            }
        }

        #endregion
    }
}

