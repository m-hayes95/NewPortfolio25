using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        // Using the generated C# file from input asset file
        private InputActions input;

        #region Unity Callbacks
        private void Awake()
        {
            input = new InputActions();
            input.Enable();
        }
        private void OnDisable()
        {
            input.Disable();
        }
        #endregion
        public Vector2 GetMovementVector()
        {
            Vector2 inputVector = input.Player.Move.ReadValue<Vector2>();
            // input is normalized in the input system file.

            //Debug.Log($"player input vector = {inputVector}");

            return inputVector;
        }
    }
}

