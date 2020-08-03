using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    List<Product> purchasedProducts;
    Dictionary<Currencies, int> money;
    List<Product> storeProducts;

    // Start is called before the first frame update
    void Start()
    {
        money = new Dictionary<Currencies, int>();
        money.Add(Currencies.Blue, 0);
        money.Add(Currencies.Green, 0);
        money.Add(Currencies.Grey, 0);
        money.Add(Currencies.Red, 0);
        money.Add(Currencies.Yellow, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCurrencyCollected(Currencies c)
    {
        money[c]++;
        Debug.Log(c.ToString() + " " + money[c]);
        //foreach(KeyValuePair<Currencies, int> k in money)
        //{
        //    if(k.Key == c)
        //    {
        //        k.Value +=1;
        //    }
        //}
        //switch (c)
        //{
        //    case Currencies.Blue:
        //        //nBlue++;
        //        //nBlueText.text = " x " + nBlue.ToString();
        //        break;
        //    case Currencies.Green:
        //        //nGreen++;
        //        //nGreenText.text = " x " + nGreen.ToString();
        //        break;
        //    case Currencies.Grey:
        //        //nGrey++;
        //        //nGreyText.text = " x " + nGrey.ToString();
        //        break;
        //    case Currencies.Red:
        //        //nRed++;
        //        //nRedText.text = " x " + nRed.ToString();
        //        break;
        //    case Currencies.Yellow:
        //        //nYellow++;
        //        //nYellowText.text = " x " + nYellow.ToString();
        //        break;
        //    default:
        //        break;
        //}
    }
}
