using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Load : MonoBehaviour
{
    public void LoadSceneByBuildIndex(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }
}
