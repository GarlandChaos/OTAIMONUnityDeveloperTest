using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StoreProductTemplate : MonoBehaviour
{
    [SerializeField]
    TMP_Text productNameText, costText;
    [SerializeField]
    Image productImage, currencyImage;
    [SerializeField]
    CurrencyList currencies;

    public string productName
    {
        get { return productNameText.text; }
    }

    public void FillProductTemplate(Product p)
    {
        if(p != null)
        {
            productNameText.text = p._productName;
            costText.text = p._cost.ToString() + " x ";
            productImage.rectTransform.sizeDelta = new Vector2(p._img.texture.width, p._img.texture.height);
            productImage.sprite = p._img;
            foreach(Currency c in currencies.currencyPrefabs)
            {
                if(c.color == p._currency)
                {
                    currencyImage.sprite = c.sprt;
                    break;
                }
            }
        }
    }
}
