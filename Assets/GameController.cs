using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public EventManagerController eventManager;
    // public GameOverPanelController gameOverPanelController;
    //
    // private float _oldTimeScale;
    //
    // // Start is called before the first frame update
    // void Start()
    // {
    //     gameOverPanelController.gameObject.SetActive(false);
    //     eventManager.PlayerDied += OnPlayerDied;
    //     eventManager.RestartGame += OnRestartGame;
    // }
    //
    // private void OnRestartGame()
    // {
    //     gameOverPanelController.gameObject.SetActive(false);
    //     Time.timeScale = _oldTimeScale;
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
    //
    // private void OnPlayerDied()
    // {
    //     _oldTimeScale = Time.timeScale;
    //     Time.timeScale = 0;
    //     gameOverPanelController.gameObject.SetActive(true);
    // }
}
