using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public static GameManager instance = null;
    public Image fader;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    [HideInInspector] public Sprite Dairy;
    [HideInInspector] public Sprite Meat;
    [HideInInspector] public Sprite Sweet;
    [HideInInspector] public Sprite Detergents;
    [HideInInspector] public Sprite Grains;
    [HideInInspector] public Sprite ToiletSupplies;
    [HideInInspector] public Sprite Vegies;
    [HideInInspector] public Sprite Fruits;

    private void Start()
    {
        fader.canvasRenderer.SetAlpha(1f);
        StartGame();
    }

    public void WinGame()
    {

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool GameIsOn = false;
    public void StartGame()
    {
        GameIsOn = true;
        handleFadeOut();
        StartCoroutine(NeighborhoodManager.instance.SpawnOrdersForFamilies());
    }

    public void LoseGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void handleFadeIn()
    {
        fader.CrossFadeAlpha(0, 1, false);
    }

    public void handleFadeOut()
    {
        fader.CrossFadeAlpha(0,1, false);
    }
}
