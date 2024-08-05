using TMPro;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public Item[] items;
    public AudioClip foundSoundEffect;
    public TextMeshProUGUI labelPrefab;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < items.Length; i++)
        {
            TextMeshProUGUI textLabel = Instantiate(labelPrefab, transform, false);
            textLabel.name = string.Format("{0}_label", items[i].Entity.name);
            items[i].TextLabel = textLabel;
            
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

            // Collider has been hit
            if (hit.collider != null)
            {
                // Iterate over every Item 
                // Find whether the game object is the same
                foreach (Item item in items)
                {
                    if (item.Entity.Equals(hit.collider.gameObject) && item.Hidden)
                    {
                        item.Hidden = false;
                        StartCoroutine(item.jumpToDrawer(item.Entity.transform.position, item.TextLabel.transform.position, 0.2f));
                    }
                }
            }
        }
    }
}
