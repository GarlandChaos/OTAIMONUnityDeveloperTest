using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ADialogController : MonoBehaviour, IDialogController
{
    public string screenID { get; set; }
    public bool isVisible { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public virtual void Show()
    {
        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            gameObject.transform.SetAsLastSibling();
            isVisible = true;
        }
    }

    public virtual void Hide()
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            isVisible = false;
        }
    }
}
