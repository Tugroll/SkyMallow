using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public Text cointext;
    public GameObject HowToPlay;
    //public GameObject ShoppingPanel;
    private void Start()
    {
        //cointext.text = PlayerPrefs.GetInt("Coin").ToString();
        //PlayerPrefs.DeleteAll();

    }
    public void gamestart()
    {
        //FindObjectOfType<AudioManagment>()._play("Button");
        SceneManager.LoadScene(1);

    }

    public void quitGame()
    {
        //FindObjectOfType<AudioManagment>()._play("Button");
        Application.Quit();
    }
    public void howopenpanel()
    {
        //FindObjectOfType<AudioManagment>()._play("Button");
        HowToPlay.SetActive(true);
    }
    public void howclosepanel()
    {
        HowToPlay.SetActive(false);
    }

    //public void ShoppingOpenPanel()
    //{
    //    FindObjectOfType<AudioManagment>()._play("Button");
    //    ShoppingPanel.SetActive(true);
    //}
    //public void ShoppingClosePanel()
    //{
    //    ShoppingPanel.SetActive(false);
    //}
}
