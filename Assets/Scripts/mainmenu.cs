using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("level1");
    }
    public void QuitGame(){
        Debug.Log("Game Quited");
        Application.Quit();
    }
}
