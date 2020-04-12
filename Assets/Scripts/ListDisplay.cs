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

    public void AddProductToBag()
    {
        List<Order> currentOrders = NeighborhoodManager.instance.currentOrders;
        for (int i = 0; i < currentOrders.Count; i++)
        {

            Order order = currentOrders[i];
            Debug.Log("Test1" + slots[i].productType);
            Debug.Log("Test2" + order.productOrdered);
            Slot slot = slots[i];
            if (slot.isSatisfied == false)
            {
                if (slot.productType == order.productOrdered)
                {
                    slots[i].IncreaseAmountOfProduct();
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
        for (int i = 0; i < slots.Count; i++)
        {
            Slot slot = slots[i];
            slot.AddImage(productSprite);
            slot.SetAmountOfProduct(amoutOfProductOrdered);
            if(NeighborhoodManager.instance.currentOrders.Count <= i)
            {
                break;
            }
        }
    }
}
