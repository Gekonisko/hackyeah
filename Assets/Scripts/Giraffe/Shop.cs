using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shop : MonoBehaviour {

    public int currency;
    public int currencyNeeded;
    public AudioClip[] giraffe;
    public AudioClip[] lemur;
    public GameObject shop;
    public TextMeshProUGUI moneyText;
    [Header("Costs")] 
    public int dmgCost;
    public int speedCost;
    public int healthCost;
    
    private Movement _movement;
    private Fighting _fight;
    private AudioSource _audio;

    void Start(){
        _movement = GetComponent<Movement>();
        _audio = GetComponent<AudioSource>();
        _fight = GetComponent<Fighting>();
        ShowMoney();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 15f);
            foreach (var collider in colliders) {
                if (collider.CompareTag("Lemur")) {
                    OpenShop();
                }
            }
        }
    }

    public void OpenShop(){
        _audio.clip = giraffe[Random.Range(0, giraffe.Length)];
        _audio.Play();
        _movement._canPlayerMove = false;
        shop.SetActive(true);
    }

    public void CloseShop(){
        _audio.clip = lemur[Random.Range(0, lemur.Length)];
        _audio.Play();
        _movement._canPlayerMove = true;
        shop.SetActive(false);
    }

    private void ShowMoney(){
        moneyText.SetText("Posiadasz " + currency + " kredytów");
    }

    public void BuyDmg(){
        if(currency < dmgCost) return;
        currency -= dmgCost;
        ShowMoney();
        _fight.ApplyDmgMultiplier(1);
    }

    public void BuySpeed(){
        if(currency < speedCost) return;
        currency -= speedCost;
        ShowMoney();
        _fight.ApplySpeedMultiplier(-0.1f);
    }

    public void BuyHealth(){
        if(currency < healthCost) return;
        currency -= healthCost;
        ShowMoney();
        _fight.AddHealth(50);
    }
}
