using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class StoreScreenController : ADialogController
{
    [SerializeField]
    ProductsList completeProductsList;
    List<Product> storeProducts;
    [SerializeField]
    GameObject productTemplate;
    [SerializeField]
    GameEventEmitter closeStoreEmitter, buyEmitter, allProductsPurchasedEmitter;
    [SerializeField]
    Transform productsContainer;
    [SerializeField]
    TMP_Text purchaseFeedbackText;
    [SerializeField]
    RectTransform selector;

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
            product.GetComponent<Button>().onClick.AddListener(delegate { BuyProduct(p); });
        }
    }

    private void OnEnable()
    {
        if (storeProducts.Count != 0)
        {
            StartCoroutine(SelectFirstProduct());
            purchaseFeedbackText.text = "";
        }
        else
        {
            purchaseFeedbackText.text = "Wow, you bought everything! Come back another day!";
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

    public void OnSelectedButton()
    {
        selector.position = EventSystem.current.currentSelectedGameObject.GetComponent<RectTransform>().position;
    }

    public void BuyProduct(Product p)
    {
        buyEmitter.EmitEvent(p);
    }

    public void OnSuccesfulPurchase(Product p)
    {
        foreach(Product prod in storeProducts)
        {
            if(prod == p)
            {
                storeProducts.Remove(prod);
                if(storeProducts.Count == 0)
                {
                    selector.gameObject.SetActive(false);
                }
                break;
            }
        }
        foreach(StoreProductTemplate template in productsContainer.GetComponentsInChildren<StoreProductTemplate>())
        {
            if(template.productName == p._productName)
            {
                Destroy(template.gameObject);
                break;
            }
        }
        StartCoroutine(SelectFirstProduct());
        purchaseFeedbackText.text = "Thanks! Enjoy your product!";
        if(storeProducts.Count == 0)
        {
            allProductsPurchasedEmitter.EmitEvent();
        }
    }

    public void OnFailedPurchase()
    {
        purchaseFeedbackText.text = "Sorry, you don't have enough money...";
    }

    IEnumerator SelectFirstProduct()
    {
        if (storeProducts != null)
        {
            yield return new WaitForEndOfFrame();
            Transform firstProduct = productsContainer.GetChild(0);
            EventSystem.current.SetSelectedGameObject(firstProduct.gameObject);
            firstProduct.GetComponent<Button>().Select();
            firstProduct.GetComponent<Button>().OnSelect(null);
            yield return new WaitForEndOfFrame();
            selector.position = firstProduct.GetComponent<RectTransform>().position;
        }
    }
}
