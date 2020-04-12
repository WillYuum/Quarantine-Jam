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


    public void AssignOrdersInSlot(int amoutOfProductOrdered, Sprite productSprite)
    {
        for (int i = 0; i < slots.Count; i++)
        {
            Slot slot = slots[i];
            if(slot.isEmpty)
            {
                slot.isEmpty = false;
                slot.AddImage(productSprite);
                slot.SetAmountOfProduct(amoutOfProductOrdered);
                break;
            }
        }
    }
}
