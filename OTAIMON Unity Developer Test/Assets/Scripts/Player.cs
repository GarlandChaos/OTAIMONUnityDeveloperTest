using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed;
    bool facingRight;
    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        speed = 3f;
        facingRight = true;
        scale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
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
}
