using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerInput), typeof(CharacterController))]
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        [Header("Movement Settings")]
        [SerializeField, Range(5.0f, 20.0f)] private float moveSpeed = 12.0f;
        [SerializeField, Range(1.0f, 50.0f)] private float rotateSpeed = 20.0f;

        [Header("Sounds")]
        [SerializeField] private AudioClip[] footstepSounds;
        [SerializeField] private AudioSource audioSource;

        // Components
        private PlayerInput input;
        private CharacterController controller;
        //private Animator animator;

        // non-editable
        private float currentMoveSpeed;

        // Animation refs
        //private readonly int Speed = Animator.StringToHash("Speed");  
        #endregion

        #region Unity Callbacks
        private void Awake()
        {
            input = GetComponent<PlayerInput>();
            controller = GetComponent<CharacterController>();
        }
        private void Start()
        {
            currentMoveSpeed = moveSpeed;
        }

        private void Update()
        {
            HandleMovement();
        }
        #endregion

        #region Public Methods
        public void UpdateMoveSpeed(float newMoveSpeed, float duration)
        {
            currentMoveSpeed = newMoveSpeed;
            Invoke(nameof(ResetSpeed), duration);
        }

        public void PlayFootstepSounds()
        {
            // This method is called in the animation events
            AudioClip clip = footstepSounds[Random.Range(0, footstepSounds.Length)];
            audioSource.PlayOneShot(clip);
        }
        #endregion

        #region Movement
        private void HandleMovement()
        {
            Vector2 inputVector = input.GetMovementVector();
            //Debug.Log($"Handle movement = {inputVector}");

            Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
            moveDirection *= currentMoveSpeed;
            controller.SimpleMove(moveDirection);

            // Rotate character, only when moving 
            if (moveDirection != Vector3.zero)
            {
                Rotate(moveDirection);
            }

            UpdateAnimations();
        }

        private void Rotate(Vector3 moveDirection)
        {
            Vector3 currentRotation = transform.forward;
            Vector3 targetRotation = moveDirection;

            // Vector3.Slerp rotates our look at position from point a to point b
            transform.forward = Vector3.Slerp(currentRotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
        private void ResetSpeed()
        {
            currentMoveSpeed = moveSpeed;
        }
        #endregion

        #region Animations
        private void UpdateAnimations()
        {
            float animationSpeed = Mathf.Clamp01(controller.velocity.magnitude);
            //animator.SetFloat(Speed, animationSpeed);
        }
        #endregion

    }

}
