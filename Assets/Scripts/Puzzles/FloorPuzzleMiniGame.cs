using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Linq;

namespace Puzzles
{
    public class FloorPuzzleMiniGame : MonoBehaviour
    {
        #region Variables

        [SerializeField] private UnityEvent OnWin;
        [SerializeField, Range(0f, 5f)] private float resetTimerAfterWin = 3.0f;

        [SerializeField] private List<FloorPuzzlePiece> startTiles;

        #endregion

        #region Unity Callbacks
        private void OnEnable()
        {
            foreach (Transform child in transform)
            {
                FloorPuzzlePiece tile = child.GetComponent<FloorPuzzlePiece>();

                if (tile != null)
                    tile.OnTileActivate += CheckIfWon;
            }
        }

        private void OnDisable()
        {
            foreach (Transform child in transform)
            {
                FloorPuzzlePiece tile = child.GetComponent<FloorPuzzlePiece>();

                if (tile != null)
                    tile.OnTileActivate -= CheckIfWon;
            }
        }
        private void Awake()
        {
            startTiles = new List<FloorPuzzlePiece>();

            foreach (Transform child in transform)
            {
                startTiles.Add(child.GetComponent<FloorPuzzlePiece>());
            }
        }
        #endregion

        #region Public Methods

        public void CheckIfWon(int id)
        {
            if (startTiles.All(tile => tile.GetIsOn()))
            {
                Win();
            }
        }
        #endregion

        #region Private Methods

        private void Win()
        {
            OnWin?.Invoke();

            foreach (FloorPuzzlePiece tile in startTiles)
            {
                tile.LockTile();
            }

            Invoke(nameof(ResetAllTiles), resetTimerAfterWin);
        }

        private void ResetAllTiles()
        {
            foreach (FloorPuzzlePiece tile in startTiles)
            {
                tile.ResetTile();
            }
        }

        #endregion
    }
}

