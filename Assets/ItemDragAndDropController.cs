using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDragAndDropController : MonoBehaviour
{
    //vai adicionar referencia aos itens que estão sendo carregados pelo personagem

    //referencia ao slot selecionado
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;


    private void Start() {
        //ao iniciar instancia um novo objeto da classe ItemSlot
        itemSlot = new ItemSlot();  
        iconTransform = itemIcon.GetComponent<RectTransform>();
    }

    private void Update() {

        if (itemIcon.activeInHierarchy == true) { 
        
            iconTransform.position = Input.mousePosition;

        }
    }
    internal void OnClick(ItemSlot itemSlot) {

        if (this.itemSlot.item == null) {

            this.itemSlot.Copy(itemSlot);
            itemSlot.Clear();
        }
        else {
            Item item = itemSlot.item;
            int count = itemSlot.count;

            itemSlot.Copy(this.itemSlot);
            this.itemSlot.Set(item, count);
        }
    }
}
