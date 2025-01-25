using Unity.Mathematics;
using UnityEngine;

public class MoneySpawner : MonoBehaviour
{
    public Money _moneyPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnMoney(Transform target){
        Money moneyObj = Instantiate(_moneyPrefab,transform.position, quaternion.identity);
        moneyObj._target = target;
    }
}
