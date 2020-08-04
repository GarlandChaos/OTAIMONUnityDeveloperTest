using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyCounterScreenController : APanelController
{
    [SerializeField]
    TMP_Text nBlueText, nGreenText, nGreyText, nRedText, nYellowText;

    public void OnUpdateUI(Currencies c)
    {
        switch (c)
        {
            case Currencies.Blue:
                nBlueText.text = " x " + InventoryManager.instance.nBlue.ToString();
                break;
            case Currencies.Green:
                nGreenText.text = " x " + InventoryManager.instance.nGreen.ToString();
                break;
            case Currencies.Grey:
                nGreyText.text = " x " + InventoryManager.instance.nGrey.ToString();
                break;
            case Currencies.Red:
                nRedText.text = " x " + InventoryManager.instance.nRed.ToString();
                break;
            case Currencies.Yellow:
                nYellowText.text = " x " + InventoryManager.instance.nYellow.ToString();
                break;
            default:
                break;
        }
    }
}
