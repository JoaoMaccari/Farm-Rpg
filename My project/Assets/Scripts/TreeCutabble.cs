using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCutabble : ToolHit
{
    public override void Hit() {
        
        Destroy(gameObject);
    }
}
