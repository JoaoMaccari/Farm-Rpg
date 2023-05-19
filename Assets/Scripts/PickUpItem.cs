using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 10f;


    public Item item;//o item que for pego pelo personagem recebe a classe Item para ser inserida no invetario
    public int count = 1;

    // Start is called before the first frame update

    private void Start() {
        player = GerenciadorGame.instance.player.transform;
    }

    public void Set(Item item, int count) {
        this.item = item;
        this.count = count; 

        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        renderer.sprite = item.icon;
    }

    // Update is called once per frame
    void Update()
    {

        ttl -= Time.deltaTime;
        if (ttl < 0) { Destroy(gameObject); }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > pickUpDistance) {
            return;
        }
        else {//se a distancia entre o player e o item for menor que a pickupdistance o objeto é jogado para o player
        transform.position = Vector3.MoveTowards(
            transform.position,
            player.position,
            speed * Time.deltaTime
            );

            if (distance < 0.1f) {

                //quando a distancia for menor que 0.1 chama o inventory container
                if (GerenciadorGame.instance.inventoryContainer != null) {//se 
                    GerenciadorGame.instance.inventoryContainer.Add(item, count);// método do itemcontainer
                }
                else {
                    Debug.LogWarning("no inventory container atached");
                }
                Destroy(gameObject);
            }

        }

    }
}
