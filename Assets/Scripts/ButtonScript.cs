using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonScript : MonoBehaviour
{
    public Button myButton;
    public TextMeshProUGUI myText;

    private void Start()
    {
        myButton.onClick.AddListener(ShowMessage);
        myText.gameObject.SetActive(false);
    }

    private void ShowMessage()
    {
        myText.gameObject.SetActive(true);
        myText.text = "Wrond Option....Additional 1min is added to your timer -->";
        StartCoroutine(HideMessageAfterDelay(2));
    }

    private IEnumerator HideMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        myText.gameObject.SetActive(false);
    }
}