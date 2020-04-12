using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListDisplay : MonoBehaviour
{

    public List<Slot> slots;

    public static ListDisplay instance = null;

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
    List<Order> currentOrders;
    public void AddProductToBag(Product productToAdd)
    {
        currentOrders = NeighborhoodManager.instance.currentOrders;
        for (int i = 0; i < currentOrders.Count; i++)
        {

            Order order = currentOrders[i];
            Debug.Log("Test1" + slots[i].productType);
            Debug.Log("Test2" + order.productOrdered);
            Slot slot = slots[i];
            if (slot.isSatisfied == false)
            {
                if (slot.productType == productToAdd)
                {
                    slots[i].IncreaseAmountOfProduct();
                    if(slot.currentAmountOfProduct >= currentOrders[i].amountOfProductOrdered)
                    {
                        slot.isSatisfied = true;
                    }
                }
            }
            else
            {
                //play done animation
            }
        }
    }

    public bool CheckIfAllOrdersForProductsIsDone()
    {

        return false;
    }


    public void AssignOrdersInSlot(int amoutOfProductOrdered, Sprite productSprite)
    {
        Debug.Log("DEBUG " + productSprite.name);
        for (int i = 0; i < slots.Count; i++)
        {
            Slot slot = slots[i];
            if (slot.isEmpty)
            {
                slot.isEmpty = false;
                slot.AddImage(productSprite);
                slot.SetAmountOfProduct(amoutOfProductOrdered);
                break;
            }
        }
    }
}
