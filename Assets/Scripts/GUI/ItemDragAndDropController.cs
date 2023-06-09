using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ItemDragAndDropController : MonoBehaviour
{
    //vai adicionar referencia aos itens que est�o sendo carregados pelo personagem

    //referencia ao slot selecionado
    [SerializeField] ItemSlot itemSlot;
    [SerializeField] GameObject itemIcon;
    RectTransform iconTransform;
    Image itemIconImage;


    private void Start() {
        //ao iniciar instancia um novo objeto da classe ItemSlot
        itemSlot = new ItemSlot();  
        iconTransform = itemIcon.GetComponent<RectTransform>();
        itemIconImage = itemIcon.GetComponent<Image>();
    }

    private void Update() {

        if (itemIcon.activeInHierarchy == true) { 
        
            iconTransform.position = Input.mousePosition;

            if (Input.GetMouseButtonDown(0)) {

                //verifica se esta clicando fora do inventario enquanto segura o item
                if (EventSystem.current.IsPointerOverGameObject() == false) {

                    Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    worldPosition.z = 0;

                    ItemSpawnerManager.Instance.SpawnItem(
                        worldPosition,
                        itemSlot.item,
                        itemSlot.count
                        );

                        itemSlot.Clear();
                        itemIcon.SetActive(false);
                }
            }

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
        UpdateIcon();
    }

    private void UpdateIcon() {
        if (itemSlot.item == null) {
            itemIcon.SetActive(false);
        }
        else {
            itemIcon.SetActive (true);
            itemIconImage.sprite = itemSlot.item.icon;
        }
    }
}
