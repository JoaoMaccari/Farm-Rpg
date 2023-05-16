using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighLightController : MonoBehaviour
{
    //               SCRIPT RESPONSAVEL POR DESTACAR OBJETOS NA CENA COM UMA SETA

    //referencia da seta
    [SerializeField] GameObject highlighter;

    //referencia ao objeto que vai ser destacado
    GameObject currentTarget;


    //metodo que identifica o alvo a ser destacado
    //este metodo é chmado quano o player estiver poximo do objeto (chamado no characterInteractableControler)
    public void Highlight(GameObject target) {

        
        //se o atual objeto que esta destacado for igual ao que o estiver sendo passado no parametro nada acontece(continua sendo destacado)
        if (currentTarget == target) {

            return;
        }

        //caso contrario a variavel recebe o objeto que foi passado no parametro (verificado pelo metodo check)
        currentTarget = target;

        //Pega a posição do objeto
        Vector3 position = target.transform.position;

        //chama o metodo com outra sobrecarga passando a posição do objeto
        Highlight(position);
    }


    //vai fazer a seta aparecer em cena na posição do objeto
    public void Highlight(Vector3 position) {
        //ativa a seta na cena na mesma posicao do objeto
        highlighter.SetActive(true);
        highlighter.transform.position = position;
    }


    //desabilita a seta
    public void Hide() {

        currentTarget = null;
        highlighter.SetActive(false);
    }
}
