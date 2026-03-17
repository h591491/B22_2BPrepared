using UnityEngine;

public class OwnSafetyController : MonoBehaviour
{
    public void GaUtAvBilen()
    {
        Debug.Log("Spilleren gikk ut av bilen.");

        if (!GameManager.Instance.harRefleksvest ||
            !GameManager.Instance.harNodblink ||
            !GameManager.Instance.harHandbrekk)
        {
            GameManager.Instance.danger += 20;
            Debug.Log("Spilleren gikk ut uten å sikre egen bil godt nok.");
        }

        GameManager.Instance.LoadScene("gameover");
    }

    public void TaPaRefleksvest()
    {
        GameManager.Instance.harRefleksvest = true;
        Debug.Log("Refleksvest tatt på.");
    }

    public void SlaPaNodblink()
    {
        GameManager.Instance.harNodblink = true;
        Debug.Log("Nødblink slått på.");
    }

    public void SettPaHandbrekk()
    {
        GameManager.Instance.harHandbrekk = true;
        Debug.Log("Håndbrekk satt på.");
    }

    public void VarsleNodetater()
    {
        GameManager.Instance.harVarsletNodetat = true;
        Debug.Log("Nødetater varslet.");
    }
}