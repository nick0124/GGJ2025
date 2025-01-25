using UnityEngine;

public class BubbleSpwner : MonoBehaviour
{
    public GameObject _bubble;
    public int _maxBubbleCount = 1;
    public int _currentCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // for (int i = 0; i < _maxBubbleCount; i++)
        // {
        //     Instantiate(_bubble, new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 1), Quaternion.identity);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        _currentCount = GameObject.FindGameObjectsWithTag("Player").Length;
        if (_currentCount < _maxBubbleCount)
        {
            Instantiate(_bubble, new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 1), Quaternion.identity);
        }
    }
}
