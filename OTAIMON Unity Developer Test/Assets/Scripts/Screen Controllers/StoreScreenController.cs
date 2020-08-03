using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StoreScreenController : ADialogController
{
    [SerializeField]
    ProductsList completeProductsList;
    List<Product> storeProducts;
    [SerializeField]
    GameObject productTemplate;
    [SerializeField]
    GameEventEmitter closeStoreEmitter;
    [SerializeField]
    Transform productsContainer;

    private void Awake()
    {
        storeProducts = new List<Product>();
        int nProducts = Random.Range(3, 6);
        List<Product> tempList = new List<Product>(completeProductsList.productsPrefabs);
        for (int i = 0; i < nProducts; i++)
        {
            int n = Random.Range(0, tempList.Count - 1);
            storeProducts.Add(tempList[n]);
            tempList.RemoveAt(n);
        }

        foreach (Product p in storeProducts)
        {
            GameObject product = Instantiate(productTemplate);
            product.transform.SetParent(productsContainer, false);
            product.GetComponent<StoreProductTemplate>().FillProductTemplate(p);
        }
    }

    private void OnEnable()
    {
        if (storeProducts != null)
        {
            EventSystem.current.SetSelectedGameObject(productsContainer.GetChild(0).gameObject);
            productsContainer.GetChild(0).GetComponent<Button>().Select();
            productsContainer.GetChild(0).GetComponent<Button>().OnSelect(null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            closeStoreEmitter.EmitEvent();
        }
    }
}
