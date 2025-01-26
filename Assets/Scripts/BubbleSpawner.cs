using UnityEngine;

public class BubbleSpwner : MonoBehaviour
{
    public GameObject _bubblePrefab;              // Префаб пузыря
    public const int _maxBubbleCount = 10;        // Максимальное количество пузырей на сцене

    void Start()
    {
        for (int i = 0; i < _maxBubbleCount; i++)
        {
            SpawnBubble();
        }
    }

    void Update()
    {
        int currentBubbleCount = GameObject.FindGameObjectsWithTag("Bubble").Length;
        
        // Если пузырей меньше, чем максимум, создаем новый пузырь
        if (currentBubbleCount < _maxBubbleCount)
        {
            SpawnBubble();
        }
    }

    private void SpawnBubble()
    {
        // Случайная позиция
        Vector3 randomPosition = new Vector3(Random.Range(-9f, 9f), Random.Range(-5f, 5f), 0);

        // Создаем пузырь
        GameObject newBubble = Instantiate(_bubblePrefab, randomPosition, Quaternion.identity);

        // Устанавливаем тег Bubble
        newBubble.tag = "Bubble";
    }
}