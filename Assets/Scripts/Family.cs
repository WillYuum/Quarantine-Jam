using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public enum FamilyType
{
    None,
    WangFamily,
    JohnsFamily,
    AbouSharafFamily,
    KawasFamily
}
public class Family : MonoBehaviour
{
    public int amountOfOrders = 3;
    [HideInInspector] public bool familyOrdered = false; 

    public FamilyType familytype;
    public List<Order> list;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = Random.Range(0, i);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    public Order[] CreateOrder()
    {
        int[] array = { 1, 2, 3, 4, 5, 6, 7 };
        ShuffleArray<int>(array);
        List<int> productToSelect = new List<int>(array);
        productToSelect.ForEach(delegate (int num)
        {
            Debug.Log(num);
        });
            Debug.Log("Done");
        Order[] temp_order = new Order[amountOfOrders];
        for (int i = 0; i < amountOfOrders; i++)
        {
            //roduct selectedProduct = (Product)Random.Range(1, productToSelect.Count-1);
            Product selectedProduct = (Product)productToSelect[i];
            productToSelect.RemoveAt(i);
            Order order = new Order(familytype, selectedProduct, AssignImageToProduct(selectedProduct));
            ListDisplay.instance.slots[i].productType = order.productOrdered;
            temp_order[i] = order;
        }
        productToSelect.ForEach(delegate (int num)
        {
            Debug.Log(num);
        });
        return temp_order;
    }

    public Sprite AssignImageToProduct(Product productType)
    {
        switch (productType)
        {
            case Product.Dairy:
                return GameManager.instance.Dairy;
            case Product.Meat_Poltry:
                return GameManager.instance.Meat;
            case Product.Sweet:
                return GameManager.instance.Sweet;
            case Product.Detergents:
                return GameManager.instance.Detergents;
            case Product.Grains:
                return GameManager.instance.Grains;
            case Product.ToiletSupplies:
                return GameManager.instance.ToiletSupplies;
            case Product.Vegies:
                return GameManager.instance.Vegies;
            case Product.Fruits:
                return GameManager.instance.Fruits;
            default:
                return GameManager.instance.Dairy;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player is entering house");
            other.GetComponent<Player>().PlayerEnterHouse(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Debug.Log("Player left house");
            other.GetComponent<Player>().PlayerLeaveHouse();
        }
    }

    public void DeliverOrder()
    {
        //increment value of how much people delivered
    }
}

public class Order
{
    public Order(FamilyType familyWhoOrdered, Product productType, Sprite productSprite)
    {
        this.productSprite = productSprite;
        this.familyWhoOrdered = familyWhoOrdered;
        this.productOrdered = productType;
        this.amountOfProductOrdered = RandomizeAmountOfProductWanted();
    }
    public FamilyType familyWhoOrdered;
    public Product productOrdered;
    public Sprite productSprite;
    public int amountOfProductOrdered;
    public bool orderIsReached;

    public void deductAmountOfOrder(int amount)
    {
        amountOfProductOrdered -= amount;
    }

    private int RandomizeAmountOfProductWanted()
    {
        if(productOrdered == Product.ToiletSupplies)
        {
            int[] amountOfToiletSupplies = { 15, 18, 25 };
            int random = Random.Range(0, amountOfProductOrdered-1);
            return amountOfToiletSupplies[random];
        }
        else
        {
            int[] randomAmount = { 5, 7, 15 };
            int random = Random.Range(0, randomAmount.Length - 1);
            return randomAmount[random];
        }
    }
}
