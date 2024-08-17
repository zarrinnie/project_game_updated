using System;
using System.Collections;
using Core;
using UnityEngine;

[Serializable]
public class HiddenObjectHighlighted : State<HiddenObjectManager>
{
    public Material defaultMat;
    public Material highlightMat;
    public float speed = 4;
    public float size = 3;
    public float disappearDelay = 1;

    public override void EnterState(HiddenObjectManager item)
    {
        item.StartCoroutine(highlight(item));
    }

    public override void UpdateState(HiddenObjectManager item)
    {
    }

    public IEnumerator highlight(HiddenObjectManager item){
        float t = 0;
        SpriteRenderer spriteRenderer = item.GetComponent<SpriteRenderer>();
        spriteRenderer.material = highlightMat;

        while(t < 1){
            t = t + Time.deltaTime / speed;
            spriteRenderer.material.SetFloat("_OutlineSize", Mathf.Lerp(item.GetComponent<SpriteRenderer>().material.GetFloat("_OutlineSize"), size, t) );
            Debug.Log(t);

            yield return new WaitForEndOfFrame();
        }

        spriteRenderer.material.SetFloat("_OutlineSize", size);
        yield return new WaitForSeconds(disappearDelay);

        t = 0;
        while(t < 1){
            t = t + Time.deltaTime / speed;
            spriteRenderer.material.SetFloat("_OutlineSize", Mathf.Lerp(item.GetComponent<SpriteRenderer>().material.GetFloat("_OutlineSize"), 0, t) );
            Debug.Log(spriteRenderer.material.GetFloat("_OutlineSize"));

            yield return new WaitForEndOfFrame();
        }

        spriteRenderer.material = defaultMat; 

        yield break;
    }
}