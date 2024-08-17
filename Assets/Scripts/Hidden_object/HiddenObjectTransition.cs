using System.Collections;
using Core;
using UnityEngine;

public class HiddenObjectTransition : State<HiddenObjectManager>
{
    public override void EnterState(HiddenObjectManager item)
    {
        item.StartCoroutine(jumpToDrawer(item, item.explanationManager.drawer.meshes[item.Index].transform.position));
    }

    public override void UpdateState(HiddenObjectManager item)
    {

    }

    public IEnumerator jumpToDrawer(HiddenObjectManager item, Vector3 textPos)
    {
        float t = 0;
        float timeToMove = 20f;
        float distance;

        // The middle position between the Item
        // and its label, rounded to 1 d.p for ease
        float middlePos = Mathf.Round(Vector2.Distance(item.transform.position, textPos) / 2) * 0.1f;
        while (t < 1)
        {
            item.transform.position = Vector2.Lerp(item.transform.position, textPos, t);
            t = t + Time.deltaTime / timeToMove;

            // Check the current distance between the Item 
            // and its label, rounded to 1 d.p for ease
            distance = Mathf.Round(Vector2.Distance(item.transform.position, textPos)) * 0.1f;
            bool toggled = false;

            // If we are at the middle point, toggle the 
            // explanation UI
            if (distance == middlePos && !item.Explained) yield return new WaitWhile(() =>
            {
                if (!toggled)
                {
                    item.explanationManager.item = item;
                    item.explanationManager.SwitchState(item.explanationManager.explaining);
                    toggled = true;

                    Debug.Log(toggled);

                    return true;
                }
                return item.currentState != item.disabled;

            });
            else
            {

                yield return new WaitForEndOfFrame();
            }
        }
        item.transform.position = textPos;

        yield break;
    }
}
