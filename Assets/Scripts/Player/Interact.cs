using Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(Collider))]
    public class Interact : MonoBehaviour
    {
        [Range(0f, 20f)] public float interactableRange = 5.0f;
        public LayerMask interactLayer;
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }
        
        //Change to Unity New Input system and add this stuff
        //public void InteractWithObject(InputAction.CallbackContext context)
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                var interacted = FindClosestGameObject();
                if(interacted == null) return;
                var canInteract = interacted.GetComponent<IInteractable>();
                canInteract?.Interact();
            }
            
        }

        private GameObject FindClosestGameObject()
        {
            GameObject objectFound = null;

            if (Physics.BoxCast(_collider.bounds.center, transform.localScale * 0.5f, 
                    transform.forward, out var hit, transform.rotation, interactLayer, interactLayer))
            {
                objectFound = hit.transform.gameObject;
                Debug.DrawLine(_collider.bounds.center, transform.forward * interactableRange, Color.green);
            }
            else
                Debug.DrawLine(_collider.bounds.center, transform.forward * interactableRange, Color.red);

            return objectFound;
        }
    }
}
