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
    }

    private void HandleTableInteraction()
    {
        if (playerIsOnTable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                productTablePlayerIsOn.TakeProduct();
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                productTablePlayerIsOn.ThrowProductBack();
            }
        }
    }

    private bool isHoldingSameProduct()
    {


        return false;
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

    public void playerTakeDamae(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }
}
