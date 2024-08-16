using UnityEngine;
using UnityEngine.UI;

public class FoundObjectsPaneController : MonoBehaviour
{
    [SerializeField]
    private SaveDataManager saveDataManager;
    [SerializeField]
    private GameObject foundObjectPanePrefab;
    [SerializeField]
    private Material notFoundMaterial;
    // Start is called before the first frame update
    void Start()
    {
        foreach(SerializedHiddenObject hiddenObject in saveDataManager.save.serializedHiddenObjects){
            GameObject instantiatedPane = Instantiate(foundObjectPanePrefab, transform);
            instantiatedPane.transform.GetChild(0).GetComponent<Image>().sprite = hiddenObject.sprite;

            if(!hiddenObject.found){
                instantiatedPane.transform.GetChild(0).GetComponent<Image>().material = notFoundMaterial; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
