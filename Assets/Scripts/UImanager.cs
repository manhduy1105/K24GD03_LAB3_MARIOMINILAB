using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject Remuse;
    void Start()
    {
        Remuse.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pause()
    {
        Time.timeScale = 0;
        Remuse.SetActive(true);
    }
    public void remuse()
    {
        Time.timeScale = 1f;
        Remuse.SetActive(false);
    }
    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
