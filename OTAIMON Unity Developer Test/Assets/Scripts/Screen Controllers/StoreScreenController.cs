using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScreenController : ADialogController
{
    [SerializeField]
    ProductsList completeProductsList;
    List<Product> storeProducts;
    [SerializeField]
    GameObject productTemplate;

    // Start is called before the first frame update
    void Start()
    {
        storeProducts = new List<Product>();
        int nProducts = Random.Range(3, 5);
        List<Product> tempList = completeProductsList.productsPrefabs;
        for (int i = 0; i < nProducts; i++)
        {
            int n = Random.Range(0, tempList.Count);
            storeProducts.Add(tempList[n]);
            tempList.RemoveAt(n);
        }

        foreach(Product p in storeProducts)
        {
            GameObject product = Instantiate(productTemplate, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
