using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [HideInInspector] public bool isEmpty = true;
    [HideInInspector] public bool isSatisfied;
    public GameObject productSprite;
    public TextMesh currentProductAmount;
    public TextMesh textAmountOfProduct;
    [HideInInspector]public int currentAmountOfProduct = 0;
    [HideInInspector]public Product productType;

    public GameObject counter;

    private void Start()
    {
        counter.SetActive(false);
        isSatisfied = false;
        currentProductAmount.text = currentAmountOfProduct.ToString();
        textAmountOfProduct.text = currentAmountOfProduct.ToString();
    }

    public void IncreaseAmountOfProduct()
    {
        if (isSatisfied)
        {
            return;
        }
        currentAmountOfProduct += 1;
        currentProductAmount.text = currentAmountOfProduct.ToString();
    }

    public void DecreaseAmountOfProduct()
    {
        if (currentAmountOfProduct <= 0) return;
        currentAmountOfProduct -= 1;
        textAmountOfProduct.text = currentAmountOfProduct.ToString();
        if(currentAmountOfProduct <= 0)
        {
            RemoveImageProduct();
            productType = Product.None;
            textAmountOfProduct.text = "0";
        }
    }

    public void AddImage(Sprite productImage)
    {
        productSprite.GetComponent<SpriteRenderer>().sprite = productImage;
        counter.SetActive(true);
    }
    private void RemoveImageProduct()
    {
        productSprite = null;
    }

    public void SetAmountOfProduct(int amount)
    {
        textAmountOfProduct.text = amount.ToString();
    }


}
