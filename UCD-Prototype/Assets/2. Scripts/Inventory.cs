using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public buyableItem[] inventory = new buyableItem[14];
    public int money;
    public Text moneytext;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    
    void showItems(){
        for (int i =0; i<inventory.Length; i++){
            if (inventory[i].bought){
                inventory[i].GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void buyItem(buyableItem item){
        if (item.cost < money){
            money -= item.cost;
            moneytext.text = ""+money;
            item.bought = true;
            showItems();
        }
    }
}
