using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawner : MonoBehaviour
{
    bool canSpawn;
    [SerializeField]
    List<Currency> currenciesToSpawn;
    float timer;
    float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        timer = 0f;
        maxTime = Random.Range(2, 5);
        //colors = new List<Currency>();
        //Currency c = new Currency();
        //c.color = Currencies.Orange;
        //colors.Add(c);
        //c.color = Currencies.Yellow;
        //colors.Add(c);
        //c.color = Currencies.Blue;
        //colors.Add(c);
        //c.color = Currencies.Green;
        //colors.Add(c);
        //c.color = Currencies.White;
        //colors.Add(c);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime)
        {
            Spawn();
            timer = 0f;
            maxTime = Random.Range(2, 5);
        }
    }

    public void Spawn()
    {
        Vector2 pos = new Vector3(Random.Range(-8f, 8f), transform.position.y);
        Instantiate(currenciesToSpawn[Random.Range(0, currenciesToSpawn.Count)], pos, transform.rotation);
    }
}
