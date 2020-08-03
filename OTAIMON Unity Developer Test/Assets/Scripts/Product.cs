using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Currencies
{
    Red,
    Yellow,
    Blue,
    Green,
    Grey
}

public class Product : MonoBehaviour
{
    [SerializeField]
    string productName;
    [SerializeField]
    Sprite img;
    [SerializeField]
    int cost;
    [SerializeField]
    Currencies currency;

    public string _productName
    {
        get
        {
            return productName;
        }
    }

    public Sprite _img
    {
        get
        {
            return img;
        }
    }

    public int _cost
    {
        get
        {
            return cost;
        }
    }

    public Currencies _currency
    {
        get
        {
            return currency;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
