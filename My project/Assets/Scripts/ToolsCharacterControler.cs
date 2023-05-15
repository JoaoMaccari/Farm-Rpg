using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterControler : MonoBehaviour
{
    
    CharacterMovement character;
    Rigidbody2D rgbd2d;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractavleArea  = 1.2f;

    private void Awake() {
        character = GetComponent<CharacterMovement>();
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
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractavleArea);

        foreach (Collider2D c in colliders) {

            ToolHit hit = c.GetComponent<ToolHit>();
            if (hit != null) {
                hit.Hit();
                break;
            }
        }
    }
}
