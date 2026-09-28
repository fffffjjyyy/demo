using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;
public class Demo : MonoBehaviour
{
    public TextMeshProUGUI demo;

    public void OnClick()
    {
        demo.text = "Hello World!";
    }
}
