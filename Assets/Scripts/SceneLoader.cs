using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public TMP_Text _score;

    public int _sceneNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_score != null)
            _score.text = PlayerPrefs.GetInt("BestScore", 0).ToString() + "$";
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
