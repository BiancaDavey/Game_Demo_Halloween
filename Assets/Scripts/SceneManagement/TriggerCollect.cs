using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TriggerCollect : MonoBehaviour {
    [HideInInspector] public bool triggerOn = false;
    [SerializeField] public string key;
    [SerializeField] public bool removeOnCollect;
    [HideInInspector] public Dictionary<string, int> playerInventory = new Dictionary<string, int>();

    public void UpdateObject(){
        if (removeOnCollect){
            Destroy(this.gameObject);
        }
    }
    
    public void CollectItem(string key){
        //  TODO: fix key match.
        if (playerInventory.ContainsKey(key)){
            playerInventory[key] = playerInventory[key]+1;
        }
        else {
            playerInventory.Add(key, 1);
        }
        TestPrint();
        UpdateObject();
    }

    public void TestPrint(){
        foreach (var element in playerInventory){
            Debug.Log($"Key: {element.Key}, value: {element.Value}");
        }
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            triggerOn = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            triggerOn = false;
        }
    }

    public void Update(){
        if (triggerOn && Input.GetKeyDown(KeyCode.E)){
            CollectItem(key);
        }
    }
}
