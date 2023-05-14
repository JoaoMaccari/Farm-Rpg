using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterControler : MonoBehaviour
{
    
    CharacterController characer;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractavleArea  = 1.2f;

    private void Awake() {
        characer = GetComponent<CharacterController>();
        rgbd2d = GetComponent<Rigidbody2D>();

       

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            UseTool();
        }
    }

    private void UseTool() {
       
    }
}
