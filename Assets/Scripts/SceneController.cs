using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void Room1Task(){
        SceneManager.LoadScene("Room1Challenge");
    }

    public void InformationScene(){
        SceneManager.LoadScene("InformationScene");
    }

    public void HomeScene(){
        SceneManager.LoadScene("HomeScene");
    }

    public void FindTask1(){
        SceneManager.LoadScene("FindTask1");
    }

    public void FindChallenge1(){
        Debug.Log("CLICKED");
        SceneManager.LoadScene("FindChallenge1");
    }

    public void Maze(){
        Debug.Log("CLICKED");
        SceneManager.LoadScene("Maze");
    }

    public void WinScreen(){
        Debug.Log("CLICKED");
        SceneManager.LoadScene("WinScreen");
    }

}
