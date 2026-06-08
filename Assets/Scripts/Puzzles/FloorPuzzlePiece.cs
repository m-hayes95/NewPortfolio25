using Player;
using UnityEngine;

namespace Puzzles
{
    public class FloorPuzzlePiece : MonoBehaviour
    {
        [SerializeField] private FloorPuzzleScriptableObject floorData;

        private bool isOn = false;
        private bool isLocked = false; // locked when won
        private Renderer _renderer;
        

        private void Awake()
        {
            _renderer = gameObject.GetComponent<Renderer>();
        }

        private void Start()
        {
            UpdateMaterial();
        }

        public int GetFloorID()
        {
            return floorData.iD;
        }

        public bool GetIsOn()
        {
            return isOn;
        }

        public void ResetTile()
        {
            if (isLocked) return;
            isOn = false;
            _renderer.material = floorData.offMaterial;
        }
        public void LockTile()
        {
            isLocked = true;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>() && !isLocked)
            {
                SwitchTileStatus();
            }
        }

        private void SwitchTileStatus()
        {
            if(isLocked) return;
            isOn = !isOn;
            Invoke(nameof(UpdateMaterial), 0f);
        }

        private void UpdateMaterial()
        {
            if(isLocked) return;
            _renderer.material = isOn ? floorData.onMaterial : floorData.offMaterial;
            // play click sound
        }
    }
}

