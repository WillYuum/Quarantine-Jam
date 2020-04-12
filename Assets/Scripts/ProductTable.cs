using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Product
{
    None,
    Dairy,
    Meat_Poltry,
    Sweet,
    Detergents,
    Grains,
    ToiletSupplies,
    Vegies,
    Fruits
}

public class ProductTable : MonoBehaviour
{


    public Product assignedProductTable;
    public Sprite productSprite;

    public GameObject productDisplayer;


    private void Start()
    {
        Color tmp = productDisplayer.GetComponent<SpriteRenderer>().color;
        tmp.a = 0.5f;
        productDisplayer.GetComponent<SpriteRenderer>().color = tmp;
    }

    public void TakeProduct()
    {
        Debug.Log($"took product from {assignedProductTable}");
        ListDisplay.instance.AddProductToBag(assignedProductTable);
    }

    public void ThrowProductBack()
    {
        Debug.Log($"threw product from {assignedProductTable}");
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player is checking table");
            other.GetComponent<Player>().PlayerEnterTable(this);

            Color tmp = productDisplayer.GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            productDisplayer.GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player left table");
            other.GetComponent<Player>().PlayerLeaveTable();

            Color tmp = productDisplayer.GetComponent<SpriteRenderer>().color;
            tmp.a = 0.5f;
            productDisplayer.GetComponent<SpriteRenderer>().color = tmp;
        }   
    }



}
