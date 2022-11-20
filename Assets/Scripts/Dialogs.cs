using System.Collections;
using TMPro;
using UnityEngine;

public enum DialogType {
    Damage,
    Provocation
}

public class Dialogs : MonoBehaviour {
    [SerializeField] private float timeBetweenDialogs;
    
    [SerializeField] private AudioClip[] provocationClips;
    [SerializeField] private string[] provocationTexts;

    [SerializeField] private TextMeshProUGUI dialogText;
    
    [SerializeField] private short damageChance;
    [SerializeField] private short provocationChance;

    private float _timeOfLastDialog;
    private AudioSource _source;
    private bool _isSpeaking;

    private void Start(){
        _source = GetComponent<AudioSource>();
        _timeOfLastDialog = 0;
        _isSpeaking = false;
    }
    
    public void OnAction(DialogType typ){
        if (Time.time - _timeOfLastDialog < timeBetweenDialogs || _isSpeaking) {
            return;
        }
        
        // Z powodu zmian w planach, duża część switcha została usunięta, kiedyś naprawię resztę (może)
        int index;
        switch (typ) {
            case DialogType.Provocation:
                if (Random.Range(0, 1) == 0) {
                    index = Random.Range(0, provocationClips.Length);
                    Say(provocationClips[index], provocationTexts[index]);
                }
                break;
        }
    }

    void Say(AudioClip clip, string text){
        StartCoroutine(AsyncSay(clip, text));
    }

    IEnumerator AsyncSay(AudioClip clip, string text){
        _isSpeaking = true;
        dialogText.SetText(text);
        _source.clip = clip;
        _source.Play();
        while (_source.isPlaying) {
            yield return new WaitForSeconds(0.5f);
        }

        _isSpeaking = false;
        dialogText.SetText("");
    }
}
