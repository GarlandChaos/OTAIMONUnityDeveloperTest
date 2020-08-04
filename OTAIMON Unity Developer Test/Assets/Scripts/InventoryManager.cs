using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    List<Product> purchasedProducts;
    Dictionary<Currencies, int> money;
    public int nBlue { get { return money[Currencies.Blue]; } }
    public int nGreen { get { return money[Currencies.Green]; } }
    public int nGrey { get { return money[Currencies.Grey]; } }
    public int nRed { get { return money[Currencies.Red]; } }
    public int nYellow { get { return money[Currencies.Yellow]; } }
    [SerializeField]
    GameEventEmitter successfulPurchaseEmitter, failedPurchaseEmitter, updateUIEmitter;

    // Start is called before the first frame update
    void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        purchasedProducts = new List<Product>();
        money = new Dictionary<Currencies, int>();
        money.Add(Currencies.Blue, 0);
        money.Add(Currencies.Green, 0);
        money.Add(Currencies.Grey, 0);
        money.Add(Currencies.Red, 0);
        money.Add(Currencies.Yellow, 0);
    }

    public void OnCurrencyCollected(Currencies c)
    {
        money[c]++;
        updateUIEmitter.EmitEvent(c);
    }

    public void OnBuyProduct(Product p)
    {
        if(money[p._currency] >= p._cost)
        {
            money[p._currency] -= p._cost;
            purchasedProducts.Add(p);
            successfulPurchaseEmitter.EmitEvent(p);
            updateUIEmitter.EmitEvent(p._currency);
        }
        else
        {
            failedPurchaseEmitter.EmitEvent();
        }
    }
}
