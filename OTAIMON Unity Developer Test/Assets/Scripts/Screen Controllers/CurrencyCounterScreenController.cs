using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CurrencyCounterScreenController : APanelController
{
    int nBlue, nGreen, nGrey, nRed, nYellow;
    [SerializeField]
    TMP_Text nBlueText, nGreenText, nGreyText, nRedText, nYellowText;

    // Start is called before the first frame update
    void Start()
    {
        nBlue = 0;
        nGreen = 0;
        nGrey = 0;
        nRed = 0;
        nYellow = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCurrencyCollected(Currencies c)
    {
        switch (c)
        {
            case Currencies.Blue:
                nBlue++;
                nBlueText.text = " x " + nBlue.ToString();
                break;
            case Currencies.Green:
                nGreen++;
                nGreenText.text = " x " + nGreen.ToString();
                break;
            case Currencies.Grey:
                nGrey++;
                nGreyText.text = " x " + nGrey.ToString();
                break;
            case Currencies.Red:
                nRed++;
                nRedText.text = " x " + nRed.ToString();
                break;
            case Currencies.Yellow:
                nYellow++;
                nYellowText.text = " x " + nYellow.ToString();
                break;
            default:
                break;
        }
    }
}
