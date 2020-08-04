using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreenController : APanelController
{
    [SerializeField]
    Transform productsContainer;
    [SerializeField]
    GameObject productTemplate;

    public void OnSuccessfulPurchase(Product p)
    {
        GameObject product = Instantiate(productTemplate);
        product.transform.SetParent(productsContainer, false);
        product.GetComponent<InventoryProductTemplate>().FillProductTemplate(p);
    }
}
