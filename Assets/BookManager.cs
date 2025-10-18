using UnityEngine;

public class BookManager : MonoBehaviour
{
    public GameObject[] pages;
    public GameObject bookPanel;

    private int currentPageIdx;
    private GameObject currentPage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.currentPage = pages[0];
        for (int i = 0; i < this.pages.Length; i++) {
            this.pages[i].SetActive(false);
        }
        this.setPage(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void nextPage() {
        if (this.currentPageIdx == pages.Length - 1) return;
        setPage(this.currentPageIdx + 1);
    }

    public void prevPage() {
        if (this.currentPageIdx == 0) return;
        setPage(this.currentPageIdx - 1);
    }

    public void setPage(int newPageIdx) {
        this.currentPageIdx = newPageIdx;
        this.currentPage.SetActive(false);
        this.currentPage = pages[currentPageIdx];
        this.currentPage.SetActive(true);
    }
}
