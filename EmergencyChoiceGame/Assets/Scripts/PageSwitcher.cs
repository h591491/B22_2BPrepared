using UnityEngine;

public class PageSwitcher : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;

    private int currentPage = 1;

    public void NextPage()
    {
        if (currentPage == 1)
        {
            page1.SetActive(false);
            page2.SetActive(true);
            currentPage = 2;
        }
    }

    public void PreviousPage()
    {
        if (currentPage == 2)
        {
            page2.SetActive(false);
            page1.SetActive(true);
            currentPage = 1;
        }
    }
}