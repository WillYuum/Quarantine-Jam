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
  
    public void TakeProduct()
    {
        Debug.Log($"took product from {assignedProductTable}");
        ListDisplay.instance.AddProductToBag();
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
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player left table");
            other.GetComponent<Player>().PlayerLeaveTable();
        }   
    }



}
