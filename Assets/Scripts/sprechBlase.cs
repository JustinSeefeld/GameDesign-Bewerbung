using UnityEngine;
using TMPro;

public class SprechBlase : MonoBehaviour
{
    public TextMeshProUGUI uiText;
    public GameObject panelObject;
    public float showTime = 5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelObject.SetActive(false);
    }

    public void ShowText(string text)
    {
        uiText.text = text;
        panelObject.SetActive(true);
        CancelInvoke();
        Invoke("HideText", showTime);
    }

    void HideText()
    {
        panelObject.SetActive(false);
    }
}
