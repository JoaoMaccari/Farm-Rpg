using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerenciadorGame : MonoBehaviour
{
 
    public static GerenciadorGame instance;

    private void Awake() {
        instance = this;    
    }

    public GameObject player;

}
