using UnityEngine;

public class BookOpener : MonoBehaviour
{

    public GameObject book;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() {
        book.SetActive(true);
    }
}
