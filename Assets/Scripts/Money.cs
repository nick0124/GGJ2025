using UnityEngine;

public class Money : MonoBehaviour
{
    public Transform _target;
    public float _speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
        }

        if (transform.position == _target.position)
        {
            Destroy(gameObject);
        }

        var step = _speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, _target.position, step);
    }
}
