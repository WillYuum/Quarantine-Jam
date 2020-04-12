using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketManager : MonoBehaviour
{
    public static MarketManager instance = null;

    [HideInInspector] public bool grabbedTheFullOrder;

    [HideInInspector] public bool playerCanGoOut;
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


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   

    public void PlayerGoesOut()
    {
        GameManager.instance.handleFadeIn();
        Debug.Log("You're outside");

    }
}
