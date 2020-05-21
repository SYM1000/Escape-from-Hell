using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused =false;
    public GameObject pauseMeniUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GameIsPaused){
                Resume();
            }else{
                Pause();
            }
        }
    }

    public void Resume(){
        pauseMeniUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }
    public void Pause(){
        pauseMeniUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;
    }

     public void LoadMenu(){
        SceneManager.LoadScene(0);
     }

     public void Quit(){
         Application.Quit();
     }
}
