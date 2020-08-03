using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLayer : ALayer<IPanelController>
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ShowScreen(string screenID)
    {
        screens[screenID].Show();
    }
}
