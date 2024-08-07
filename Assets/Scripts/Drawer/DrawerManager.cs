using TMPro;
using UnityEngine;

public class DrawerManager : MonoBehaviour {
    public DrawerBaseState currentState;
    public DrawerIdleState idleState = new DrawerIdleState();
    public DrawerBlurState blurState = new DrawerBlurState();

    public HiddenObjectManager[] hiddenObjects;
    public GameObject textLabelPrefab;
    public TextMeshProUGUI[] meshes;

    void Start(){
        meshes = new TextMeshProUGUI[hiddenObjects.Length];

        for(int i = 0; i < hiddenObjects.Length; i++){
            GameObject label = Object.Instantiate(textLabelPrefab, gameObject.transform, false);
            TextMeshProUGUI textMesh = label.GetComponent<TextMeshProUGUI>();

            textMesh.name = string.Format("{0}_label", hiddenObjects[i].name);
            textMesh.SetText(hiddenObjects[i].name);

            meshes[i] = textMesh;
            hiddenObjects[i].Index = i;
        }

        currentState = idleState;
        currentState.EnterState(this);
    }

    void Update(){
        currentState.UpdateState(this);
    }

    public void SwitchState(DrawerBaseState state){
        currentState = state;
        currentState.EnterState(this);
    }
}