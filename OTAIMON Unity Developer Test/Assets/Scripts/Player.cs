using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed;
    bool facingRight;
    Vector3 scale;
    [SerializeField]
    GameEventEmitter openStoreEmitter, currencyCollectedEmitter;
    bool canMove;
    bool canInteractWithNPC;
    bool canInteractWithCurrency;
    Currency lastCurrencyFound;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        facingRight = true;
        scale = transform.localScale;
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            Move();
        }
        if (canInteractWithNPC && Input.GetKeyDown(KeyCode.Space))
        {
            if (canMove)
            {
                canMove = false;
                openStoreEmitter.EmitEvent();
            }
        }
        if (canInteractWithCurrency && Input.GetKeyDown(KeyCode.Space))
        {
            currencyCollectedEmitter.EmitEvent(lastCurrencyFound.color);
            Destroy(lastCurrencyFound.gameObject);
        }
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && facingRight)
        {
            facingRight = false;
            transform.localScale = new Vector3(-scale.x, scale.y, scale.z);
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && !facingRight)
        {
            facingRight = true;
            transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left * speed  * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            canInteractWithNPC = true;
        }
        else if (collision.tag == "Currency")
        {
            canInteractWithCurrency = true;
            lastCurrencyFound = collision.gameObject.GetComponent<Currency>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "NPC")
        {
            canInteractWithNPC = false;
        }
        else if (collision.tag == "Currency")
        {
            canInteractWithCurrency = false;
            lastCurrencyFound = null;
        }
    }

    public void RegainControl()
    {
        canMove = true;
    }
}
