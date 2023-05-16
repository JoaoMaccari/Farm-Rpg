using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteractableController : MonoBehaviour
{
    CharacterMovement characterController;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractavleArea = 1.2f;

    Character character;

    //posso acessar os metodos de destacar objetos
    [SerializeReference] HighLightController highLightController;

    private void Awake() {
        characterController = GetComponent<CharacterMovement>();
        rgbd2d = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
    }


    void Update() {

        //vai estar a todo monmento chamando o check para verificar se tem algum objeto a ser destacado
        Check();

        if (Input.GetMouseButtonDown(1)) {
           Interact();
        }
    }

    //o check vai criar um campo que verifica tudo o que estiver na frente do personagem
    private void Check() {

        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractavleArea);

       

        foreach (Collider2D c in colliders) {

            Interactable hit = c.GetComponent<Interactable>();

            //verifica se o algo entrou no physics2d
            if (hit != null) {
                highLightController.Highlight(hit.gameObject);//passa o objeto que estiver em contato como parametro para o metodo que vai destacar o objeto
                return;
            }
        }

        //caso não tenha nenhum objeto interagindo com o player o hide é chamado
        highLightController.Hide();

    }
    private void Interact() {
        Vector2 position = rgbd2d.position + characterController.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractavleArea);

        foreach (Collider2D c in colliders) {

            Interactable hit = c.GetComponent<Interactable>();
            if (hit != null) {
                hit.Interact(character);
                break;
            }
        }
    }
}
