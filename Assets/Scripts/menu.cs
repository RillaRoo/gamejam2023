using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [SerializeField] private GameObject startMenu;
    [SerializeField] private GameObject loreMenu; 
    [SerializeField] private GameObject controlsMenu;

    public void StartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        AudioManager.instance.PlaySound(25);
    }
    public void Lore()
    {
        startMenu.SetActive(false);
        loreMenu.SetActive(true);
        AudioManager.instance.PlaySound(25);
    }
    public void Controls()
    {
        startMenu.SetActive(false);
        controlsMenu.SetActive(true);
        AudioManager.instance.PlaySound(25);
    } 
    public void BackToMenu()
    {
        controlsMenu.SetActive(false);
        loreMenu.SetActive(false);
        startMenu.SetActive(true);
        AudioManager.instance.PlaySound(25);
    }
    public void ExitGame()
    {
        Application.Quit();
        AudioManager.instance.PlaySound(25);
    }
}
