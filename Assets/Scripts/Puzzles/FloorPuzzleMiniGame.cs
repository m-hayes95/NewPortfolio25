using UnityEngine;
using UnityEngine.Events;

namespace Puzzles
{
    public class FloorPuzzleMiniGame : MonoBehaviour
    {
        [SerializeField] private GameObject[] tiles;
        [SerializeField] private UnityEvent OnWin;
        [SerializeField] private UnityEvent OnLose;

        private int currentOnTiles = 0;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                CheckIfWon();
            }
        }
        public void CheckIfWon()
        {
            CheckTiles();
            if(currentOnTiles == tiles.Length)
            {
                Win();
            }
            else
            {
                Lose();
                currentOnTiles = 0;
            }
        }
        private void CheckTiles()
        {
            // itterate through tiles and check each one returns on
            foreach(GameObject tile in tiles)
            {
                if (tile.GetComponent<FloorPuzzlePiece>().GetIsOn())
                {
                    currentOnTiles++;
                }
                else if (currentOnTiles > 0)
                {
                    currentOnTiles--;
                }
            }
            
        }

        private void Win()
        {
            foreach (GameObject tile in tiles)
            {
                FloorPuzzlePiece newTile = tile.GetComponent<FloorPuzzlePiece>();
                if (newTile != null)
                {
                    newTile.LockTile();
                }
            }
        }
        private void Lose()
        {
            foreach(GameObject tile in tiles)
            {
                FloorPuzzlePiece newTile = tile.GetComponent<FloorPuzzlePiece>();
                if(newTile != null)
                {
                    newTile.ResetTile();
                }
            }
        }
    }
}

