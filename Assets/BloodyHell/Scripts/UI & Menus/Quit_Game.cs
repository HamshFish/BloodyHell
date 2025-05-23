using UnityEngine;

public class Quit_Game : MonoBehaviour
{
    public void Quit()
    {
        Debug.Log("Leaving This Dimension.");
        Application.Quit();
    }
}
