using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryProductTemplate : MonoBehaviour
{
    [SerializeField]
    Image productImage;

    public void FillProductTemplate(Product p)
    {
        productImage.rectTransform.sizeDelta = new Vector2(p._img.texture.width, p._img.texture.height);
        productImage.rectTransform.localScale = new Vector3(0.9f, 0.9f, 0.9f);
        productImage.sprite = p._img;
    }
}
