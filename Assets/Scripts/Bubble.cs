using UnityEngine;

public class Bubble : MonoBehaviour
{
    private float _clickIncreaseScale = 0.5f;
    public float _baseScaleFactor = -0.0012f;
    public float _destroyIncreaseScale;
    public float _destroyDecreaseScale;
    private bool isColorChanged = false;
    private Rigidbody2D _rb;
    public Vector2 _velocity;
    private SpriteRenderer _spriteRenderer;
    //public MoneySpawner _moneySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_moneySpawner = FindAnyObjectByType<MoneySpawner>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        AddForceAtRandomDirection();

        // Случайный размер для лопания
        _destroyDecreaseScale = Random.Range(0.7f, 1.1f); 
        _destroyIncreaseScale = Random.Range(4.2f, 5.2f); 

        // Начальный масштаб пузыря
        SetScale(Random.Range(0.5f, 1.7f));
    }

    private void FixedUpdate()
    {
        SetScale(_baseScaleFactor);

        // Если размер большой и цвет еще не изменен, меняем на красный, меняем скорость роста
        if (transform.localScale.x >= _destroyIncreaseScale && !isColorChanged)
        {           
            ChangeColor(Color.red);
            _baseScaleFactor = 0.003f; 
        }

        // Проверяем, если пузырь стал слишком маленьким / большим
        if (transform.localScale.x <= _destroyDecreaseScale || transform.localScale.x >= _destroyIncreaseScale)
        {
            PopBubble();
        }

        // Проверка на движение пузыря
        _velocity = _rb?.linearVelocity ?? Vector2.zero;

        // Если скорость пузыря очень мала, задаем случайный импульс
        if (_velocity.magnitude < 0.02f)
        {
            AddForceAtRandomDirection();
        }
    }

    // Увеличение при клике
    void OnMouseDown()
    {
        SetScale(_clickIncreaseScale);
        if (transform.localScale.x >= _destroyIncreaseScale)
        {
            User user = FindFirstObjectByType<User>();
            if (user) user.decreaseLife();
        }
        //_moneySpawner.SpawnMoney(transform);
    }

    // Рандомный импульс
    private void AddForceAtRandomDirection()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody2D>();
        Vector2 randomVector = Random.insideUnitCircle.normalized * 2.5f;
        _rb.AddForce(randomVector, ForceMode2D.Impulse);
    }

    //Изменить цвет
    private void ChangeColor(Color newColor)
    {
        _spriteRenderer.color = newColor;
        isColorChanged = true;
    }


    //Меняем масштаб
    private void SetScale(float coefficient)
    {
        transform.localScale += new Vector3(coefficient, coefficient, coefficient);
    }

    // Лопаем пузырь
    private void PopBubble()
    {
        Destroy(gameObject);
    }
}
