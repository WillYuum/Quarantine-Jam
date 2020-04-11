using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void CreateOrder()
    {
        for (int i = 0; i < amountOfOrders; i++)
        {
            Array values = Enum.GetValues(typeof(Product));
            System.Random random = new System.Random();
            Product selectedProduct = (Product)values.GetValue(random.Next(values.Length));
            Order order = new Order(familytype, selectedProduct);
            list.Add(order);
        }
    }
}

public class Order
{
    public Order(FamilyType familyWhoOrdered, Product productType)
    {
        this.familyWhoOrdered = familyWhoOrdered;
        this.productOrdered = productType;
    }
    public FamilyType familyWhoOrdered;
    public Product productOrdered;
    public int amountOfProductOrdered;
    public bool orderIsReached;

    public void detuctAmountOfOrder(int amount)
    {
        amountOfProductOrdered -= amount;
    }
}
