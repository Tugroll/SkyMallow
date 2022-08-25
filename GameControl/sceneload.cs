using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class sceneload : MonoBehaviour
{

    public Text score;
    //private void Start()
    //{
    //    //score.text = "Score" + " " + ((int)(cameramovement.pointamount)).ToString();
    //    //intersad.RequestBanner();
    //}
    public void LoadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void backToTheMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
