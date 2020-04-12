using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 3.0f;
    public int maxHealth = 5;
    int currentHealth;
    Vector2 lookDirection = new Vector2(1, 0);

    public bool playerIsOnTable = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        HandlePlayerMovement();
        HandleTableInteraction();
        MakePlayerLookAtPointer();
    }

    private void HandleTableInteraction()
    {
        if (playerIsOnTable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                productTablePlayerIsOn.TakeProduct();
            }
        }

        if (playerIsInHouse)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //finish delivery
                familyVisited.DeliverOrder();
            }
        }
    }

    [HideInInspector] public ProductTable productTablePlayerIsOn = null;
    public void PlayerEnterTable(ProductTable typeOfTable)
    {
        playerIsOnTable = true;
        productTablePlayerIsOn = typeOfTable;
    }

    public void PlayerLeaveTable()
    {
        playerIsOnTable = false;
        productTablePlayerIsOn = null;
    }

    private void HandlePlayerMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 move = new Vector2(horizontal, vertical);

        if (!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        Vector2 position = rb.position;

        position = position + move * speed * Time.deltaTime;

        rb.MovePosition(position);
    }

    [HideInInspector] public bool playerIsInHouse = false;
    private Family familyVisited;
    public void PlayerEnterHouse(Family FamilyVisited)
    {
        playerIsInHouse = true;
        familyVisited = FamilyVisited;
    }

    public void PlayerLeaveHouse()
    {
        playerIsInHouse = false;
    }

    public void playerTakeDamae(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "Door")
        {
            Debug.Log("went through the door");
            MarketManager.instance.PlayerGoesOut();
        }
    }

    void MakePlayerLookAtPointer()
    {
        Vector2 mousePos = Input.mousePosition;
        Vector2 playerPos = Camera.main.WorldToScreenPoint(this.transform.position);
        Vector2 direction = new Vector2(mousePos.x, mousePos.y) - new Vector2(playerPos.x, playerPos.y);
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }
}
