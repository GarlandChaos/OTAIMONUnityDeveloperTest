using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencySpawner : MonoBehaviour
{
    bool canSpawn;
    [SerializeField]
    CurrencyList currenciesToSpawn;
    float timer;
    float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = true;
        timer = 0f;
        maxTime = Random.Range(2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn)
        {
            timer += Time.deltaTime;
            if (timer >= maxTime)
            {
                Spawn();
                timer = 0f;
                maxTime = Random.Range(2, 5);
            }
        }
    }

    public void Spawn()
    {
        Vector2 pos = new Vector3(Random.Range(-8f, 4.5f), transform.position.y);
        Instantiate(currenciesToSpawn.currencyPrefabs[Random.Range(0, currenciesToSpawn.currencyPrefabs.Count)], pos, transform.rotation);
    }

    public void OnOpenStore()
    {
        canSpawn = false;
    }

    public void OnCloseStore()
    {
        canSpawn = true;
    }

    public void OnAllProductsPurchased()
    {
        Destroy(gameObject);
    }
}
