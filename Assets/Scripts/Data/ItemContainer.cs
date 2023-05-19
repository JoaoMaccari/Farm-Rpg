using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]


//script que cria o inventário do game

public class ItemSlot { // total de slots do inventario
    public Item item; // item 
    public int count;

    public void Copy(ItemSlot slot) {
        item = slot.item;
        count = slot.count;
    }

    public void Set(Item item, int count) {
        this.item = item;
        this.count = count; 
    }
    public void Clear() {
        item = null;
        count = 0;
    }
}

//permite criar um objeto scriptavel diretamente por um sub-menu da unity
[CreateAssetMenu(menuName = "Data/Item Container")]
public class ItemContainer : ScriptableObject
{
   public List<ItemSlot> slots;


    //adiciona item stackavel ao inventario
    public void Add(Item item, int count = 1) {//recebe o Item como parametro e a quantidade

        

        if (item.stackable == true) {
            ItemSlot itemSlot = slots.Find(x => x.item = item);

            if (itemSlot != null) {
                itemSlot.count += count;
            }
            else {
                itemSlot = slots.Find(x => x.item == null); 

                if (itemSlot != null) {
                    itemSlot.item = item;
                    itemSlot.count = count;
                }
            }


        }
        else {
            //add item não estackavel ao inventario

            ItemSlot itemSlot = slots.Find(x => x.item == null);
            if (itemSlot != null) {
                itemSlot.item = item;
            }

        }
    }
}
