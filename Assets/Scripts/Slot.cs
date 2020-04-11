using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    [HideInInspector] public bool isEmpty;
    public GameObject productSprite;
    public TextMesh textAmountOfProduct;
    [HideInInspector]public int currentAmountOfProduct = 0;
    [HideInInspector]public Product productType;

    private void Start()
    {
        isEmpty = true;
        textAmountOfProduct.text = currentAmountOfProduct.ToString();
    }

    public void IncreaseAmountOfProduct()
    {
        currentAmountOfProduct += 1;
        textAmountOfProduct.text = currentAmountOfProduct.ToString();
    }

    public void DecreaseAmountOfProduct()
    {
        if (currentAmountOfProduct <= 0) return;
        currentAmountOfProduct -= 1;
        textAmountOfProduct.text = currentAmountOfProduct.ToString();
        if(currentAmountOfProduct <= 0)
        {
            RemoveImageProduct();
            isEmpty = true;
            productType = Product.None;
            textAmountOfProduct.text = "0";
        }
    }

    public void AddImage(Sprite productImage)
    {
        productSprite.GetComponent<SpriteRenderer>().sprite = productImage;
    }

    private void RemoveImageProduct()
    {
        productSprite.GetComponent<SpriteRenderer>().sprite = null;
    }


}
