using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductsStock : MonoBehaviour
{

    public int maxStockAmount = 100;
    [HideInInspector] public float currentStockAmount;

    public int amoutToReduceStock = 5;

    public float stockReductionDelay = 5.0f;
    private float currentTime = 0;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        currentStockAmount = maxStockAmount;
    }

    
    
    // Update is called once per frame
    void Update()
    {
        HandleDecreasingStockAmount();
    }

    private void HandleDecreasingStockAmount()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= stockReductionDelay)
        {
            DecreaseStockAmount(amoutToReduceStock);
            currentTime = 0;
        }
    }

    private void DecreaseStockAmount(int amount)
    {
        currentStockAmount -= amount;
        //decrease the slider 
        slider.value = currentStockAmount / maxStockAmount;
        //add color effect maybe

        if(currentStockAmount <= 0)
        {
            GameManager.instance.LoseGame();
        }
    }
}
