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

    public Sprite Dairy;
    public Sprite Meat;
    public Sprite Sweet;
    public Sprite Detergents;
    public Sprite Grains;
    public Sprite ToiletSupplies;
    public Sprite Vegies;
    public Sprite Fruits;

    private void Start()
    {
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
        StartCoroutine(NeighborhoodManager.instance.SpawnOrdersForFamilies());
    }

    public void LoseGame()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void handleFader()
    {
        fader.GetComponent<Animation>().wrapMode = WrapMode.Once;
        fader.GetComponent<Animation>().Play("FadeOut");
        fader.GetComponent<Animation>().Play("FadeIn");
        //while (fader.GetComponent<Animation>().IsPlaying("FadeIn"))
        //{
        //    yield return null;
        //}
        //fader.GetComponent<Animation>().wrapMode = WrapMode.Once;
        //fader.GetComponent<Animation>().Play("FadeIn");
        //while (fader.GetComponent<Animation>().IsPlaying("FadeIn"))
        //{
        //    yield return null;
        //}
    }
}
