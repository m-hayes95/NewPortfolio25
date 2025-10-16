using Interface;
using UnityEngine;
using UnityEngine.Events;

namespace Arcade
{
    public class ArcadeMachineController : MonoBehaviour, IInteractable
    {
        [SerializeField] private UnityEvent onOpenScreen;
        
        public void Interact()
        {
            Use();
        }

        private void Use()
        {
            onOpenScreen?.Invoke();
            Debug.Log($"Player used machine {gameObject.name}, open screen");
        }
    }
}
