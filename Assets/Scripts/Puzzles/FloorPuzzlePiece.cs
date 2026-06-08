using Player;
using UnityEngine;

namespace Puzzles
{
    public class FloorPuzzlePiece : MonoBehaviour
    {
        [SerializeField] private FloorPuzzleScriptableObject floorData;

        private bool isOn = false;
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

        private void OnTriggerEnter(Collider other)
        {
            if (other.GetComponent<PlayerController>())
            {
                SwitchTileStatus();
            }
        }

        private void SwitchTileStatus()
        {
            isOn = !isOn;
            Invoke(nameof(UpdateMaterial), 0f);
        }

        private void UpdateMaterial()
        {
            _renderer.material = isOn ? floorData.onMaterial : floorData.offMaterial;
            // play click sound
        }
    }
}

