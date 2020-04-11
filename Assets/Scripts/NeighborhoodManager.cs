using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighborhoodManager : MonoBehaviour
{

    public static NeighborhoodManager instance = null;

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


    [HideInInspector] public int amountOfFamilyToSpawn = 1;
    public List<Family> families;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float spawnDelay = 4;

    // Update is called once per frame
    void Update()
    {
        
    }

    //select family to spawn
    public void FamilyWantToOrder()
    {
        for (int i = 0; i < amountOfFamilyToSpawn; i++)
        {
            if (families[i].familyOrdered == false)
            {
                families[i].CreateOrder();
            }

        }
        amountOfFamilyToSpawn += 1;
    }


    public IEnumerator SpawnOrdersForFamilies()
    {
        yield return new WaitForSeconds(spawnDelay);
        FamilyWantToOrder();

        //render showing the orders
    }
}
