using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public GameObject[] _lives;

    public int _sceneNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            _lives[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            LoadScene();
        }
    }

    public void LoadScene(){
        SceneManager.LoadScene(_sceneNumber);
    }
}
