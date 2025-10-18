using UnityEngine;

public class DebugObjectViewer : MonoBehaviour {
    [SerializeField] private ObjectViewer objectViewer;
    [SerializeField] private Body body;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        objectViewer.onBodyChange(body);
    }
}
