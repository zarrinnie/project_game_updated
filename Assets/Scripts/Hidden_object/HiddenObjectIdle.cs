using System.Collections;
using System.Collections.Generic;
using Core;
using Unity.VisualScripting;
using UnityEngine;

public class HiddenObjectIdle: State<HiddenObjectManager> 
{
    public override void EnterState(HiddenObjectManager item)
    {
    }

    public override void UpdateState(HiddenObjectManager item)
    {
        // Cast a Ray on left click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // To see where the ray goes
            Debug.DrawRay(ray.origin, ray.direction * 10);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            // Collider has been hit
            if (hit.collider != null && hit.collider.Equals(item.gameObject.GetComponent<BoxCollider2D>())){
                item.SwitchState(item.transitionState);
            }
        }
    }
}
