using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour
{
    public Currencies color;
    float timer;
    float maxTime;
    public Sprite sprt;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        maxTime = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            Destroy(gameObject);
        }
    }
}
