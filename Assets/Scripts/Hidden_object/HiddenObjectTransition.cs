using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjectTransition: HiddenObjectBaseState 
{
    public override void EnterState(HiddenObjectManager item)
    {
        item.StartCoroutine(jumpToDrawer());
    }

    public override void UpdateState(HiddenObjectManager item)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerator jumpToDrawer(Vector3 textPos, ItemContainer container)
    {
        float t = 0;
        float timeToMove = 20f;
        float distance;

        // The middle position between the Item
        // and its label, rounded to 1 d.p for ease
        float middlePos = Mathf.Round(Vector2.Distance(Entity.transform.position, textPos) / 2) * 0.1f;
        while (t < 1)
        {
            Entity.transform.position = Vector2.Lerp(Entity.transform.position, textPos, t);
            t = t + Time.deltaTime / timeToMove;

            // Check the current distance between the Item 
            // and its label, rounded to 1 d.p for ease
            distance = Mathf.Round(Vector2.Distance(Entity.transform.position, textPos)) * 0.1f;

            bool toggled = false;

            // If we are at the middle point, toggle the 
            // explanation UI
            if (distance == middlePos && !explained) yield return new WaitWhile(() =>
            {
                Debug.Log(explained);
                if (!toggled)
                {
                    container.Toggle();
                    toggled = true;
                }

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    explained = true;
                    container.Toggle();

                    return false;
                }
                return true;

            });
            else
            {

                yield return new WaitForEndOfFrame();
            }
        }
        Entity.transform.position = textPos;

        // Object reached destination
        TextLabel.SetText(string.Format("<s>{0}</s>", TextLabel.text));

        yield return null;
    }
}
