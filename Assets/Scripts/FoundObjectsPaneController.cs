using UnityEngine;
using UnityEngine.UI;

public class FoundObjectsPaneController : MonoBehaviour
{
    private SaveDataManager saveDataManager;
    [SerializeField]
    private GameObject foundObjectPanePrefab;
    [SerializeField]
    private Material notFoundMaterial;
    private ExplanationManager explanationManager;
    // Start is called before the first frame update
    void Start()
    {
        saveDataManager = GameObject.Find("SaveDataManager").GetComponent<SaveDataManager>();

        foreach(SerializedHiddenObject hiddenObject in saveDataManager.save.serializedHiddenObjects){
            GameObject instantiatedPane = Instantiate(foundObjectPanePrefab, transform);
            Transform foundImage = instantiatedPane.transform.GetChild(0);

            foundImage.GetComponent<Image>().sprite = hiddenObject.sprite;
            instantiatedPane.GetComponent<Button>().onClick.AddListener(() => {


                explanationManager.SwitchState(explanationManager.explaining);

            });

            if(!hiddenObject.found){
                foundImage.GetComponent<Image>().material = notFoundMaterial; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
