using TMPro;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public Item[] items;
    public AudioClip foundSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            GameObject textbox = new GameObject(string.Format("{0}_text", items[i].Name));
            textbox.transform.SetParent(transform);
            TextMeshProUGUI textLabel = textbox.AddComponent<TextMeshProUGUI>();
            items[i].TextLabel = textLabel;
            textLabel.text = items[i].Name;
            items[i].Entity.AddComponent<BoxCollider2D>();
        }
    }

    void Update()
    {
        // Cast a Ray on left click
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            // To see where the ray goes
            Debug.DrawRay(ray.origin, ray.direction * 10);

            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                foreach (Item item in items)
                {
                    if (item.Entity.Equals(hit.collider.gameObject) && item.Hidden)
                    {
                        item.Hidden = false;
                        StartCoroutine(item.jumpToDrawer());
                    }
                }
            }
        }
    }
}
