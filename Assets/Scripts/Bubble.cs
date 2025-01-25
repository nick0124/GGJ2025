using Unity.VisualScripting;
using UnityEngine;

public class Bubble : MonoBehaviour
{

    public float _increaseScale = 0.001f;
    public float _clickIncreaseScale = 0.1f;
    public float _destroyScale = 1;
    private Rigidbody2D _rb;
    public Vector2 _velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AddForceAtRandomDirection();

        _destroyScale = Random.Range(1f, 5f);
        _increaseScale = Random.Range(_increaseScale, _increaseScale * 5);

        float initialScale = Random.Range(0.5f, 1.2f);
        transform.localScale = new Vector3(initialScale, initialScale, initialScale);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.localScale += new Vector3(_increaseScale, _increaseScale, _increaseScale);
        if (transform.localScale.x > _destroyScale)
        {
            Destroy(gameObject);
        }

        _velocity = _rb.linearVelocity;

        if (Mathf.Abs(_rb.linearVelocity.x) < 0.02f || Mathf.Abs(_rb.linearVelocity.y) < 0.02f)
        {
            AddForceAtRandomDirection();
        }
    }

    void OnMouseDown()
    {
        transform.localScale += new Vector3(_clickIncreaseScale, _clickIncreaseScale, _clickIncreaseScale);
    }

    private void AddForceAtRandomDirection()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody2D>();

        float length = 1f;
        Vector2 randomVector = Random.insideUnitCircle.normalized * length;

        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(randomVector, ForceMode2D.Impulse);
    }
}
