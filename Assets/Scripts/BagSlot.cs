using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BagSlot : MonoBehaviour
{

    [HideInInspector] public int amountOfProductHolding = 0;
    public List<Slot> bag;

    public static BagSlot instance = null;

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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToBag(Product typeOfProductSelected, Sprite productImage)
    {
        Debug.Log("Test" + typeOfProductSelected);
        for (int i = 0; i < bag.Count; i++)
        {
            if (bag[i].isEmpty)
            {
                Debug.Log("Added product");
                //assign Image
                bag[i].AddImage(productImage);
                //increment number
                bag[i].isEmpty = false;
                bag[i].productType = typeOfProductSelected;
                bag[i].IncreaseAmountOfProduct();
                break;
            }
            else if(bag[i].productType == typeOfProductSelected)
            {
                Debug.Log("increased product");
                //incrementNumber
                bag[i].IncreaseAmountOfProduct();
                break;
            }
           
        }
    }
}



