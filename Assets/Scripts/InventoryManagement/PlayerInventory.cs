using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerInventory : MonoBehaviour {
    public Dictionary<int, int> playerInventory = new Dictionary<int, int>(){};
    public static PlayerInventory instance { get; private set; }

    public void CollectItem(int key){
        Debug.Log("player inventory - collect item");
        if (playerInventory.ContainsKey(key)){
            playerInventory[key] = playerInventory[key]+1;
        }
        else {
            playerInventory.Add(key, 1);
        }
        TestPrint();
    }

    public void TestPrint(){
        foreach (var element in playerInventory){
            Debug.Log($"Key: {element.Key}, value: {element.Value}");
        }
    }
}
