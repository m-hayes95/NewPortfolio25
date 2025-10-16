using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Time Events

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    
    #endregion
}
