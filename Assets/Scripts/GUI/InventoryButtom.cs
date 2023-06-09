using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//IpointerClick � uma biblio que alteras itens de GUI
public class InventoryButtom : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image icon;
    [SerializeField] Text text;

    int myIndex;

    public void SetIndex(int index) {
        myIndex = index;
    }

    public void Set(ItemSlot slot) {
        icon.gameObject.SetActive(true);
        icon.sprite = slot.item.icon;

        if (slot.item.stackable == true) {
            text.gameObject.SetActive(true);
            text.text = slot.count.ToString();
        }
        else {
            text.gameObject.SetActive(false);
        }
    }

    public void Clean() {
        icon.sprite = null;
        icon.gameObject.SetActive (false);

        text.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData) {
        ItemContainer inventory = GerenciadorGame.instance.inventoryContainer;
        GerenciadorGame.instance.dragAndDropController.OnClick(inventory.slots[myIndex]);
        transform.parent.GetComponent<InventoryPanel>().Show();
    }
}
