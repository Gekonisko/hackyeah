using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanvasController : MonoBehaviour {
    [SerializeField] private float dialogShowTime;
    [SerializeField] private TextMeshProUGUI dialogText;
    // Start is called before the first frame update

    public void newDialog(string dialog){
        StopAllCoroutines();
        StartCoroutine(showDialog(dialog));
    }

    IEnumerator showDialog(string dialog){
        dialogText.SetText(dialog);
        yield return new WaitForSecondsRealtime(dialogShowTime);
        dialogText.SetText("");
    }
}
