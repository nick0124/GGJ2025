using UnityEngine;

public class Bubble : MonoBehaviour
{
    private float _clickIncreaseScale = 0.4f;
    public float _baseScaleFactor = 0f;
    public float _destroyScale = 0f; 
    public float _fastDecreasingScale = 0f;
    public float _initialScale = 0f; 
    private bool isColorChanged = false;
    private bool isActive = false;
    private int moneyCounter = 0;
    private Rigidbody2D _rb;
    public Vector2 _velocity;
    private SpriteRenderer _spriteRenderer;
    public User user;
    //public MoneySpawner _moneySpawner;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //_moneySpawner = FindAnyObjectByType<MoneySpawner>();
        user = FindAnyObjectByType<User>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        AddForceAtRandomDirection(2.2f);
        _fastDecreasingScale = Random.Range(3f, 3.7f);
        _destroyScale = Random.Range(4.2f, 5.2f); 
        _initialScale = Random.Range(1.2f, 1.5f); 
        SetScale(_initialScale);
        moneyCounter = Mathf.RoundToInt(user._moneyCoef[0]*_initialScale);
    }

    private void FixedUpdate()
    {
        if(isActive)
        {
            _baseScaleFactor = Mathf.Max(-0.005f, transform.localScale.x * -0.005f); 
        }

        if (transform.localScale.x >= _fastDecreasingScale)
        {
            _clickIncreaseScale = 0.8f;
        }

        if (transform.localScale.x < _fastDecreasingScale)
        {
            moneyCounter = Mathf.RoundToInt(user._moneyCoef[0]*transform.localScale.x);
        }

        if (transform.localScale.x >= _fastDecreasingScale && transform.localScale.x < _destroyScale)
        {
            moneyCounter = Mathf.RoundToInt(user._moneyCoef[1]*transform.localScale.x);
        }

        // Если размер большой и цвет еще не изменен, меняем на красный, меняем скорость роста
        if (transform.localScale.x >= _destroyScale && !isColorChanged)
        {           
            _baseScaleFactor = 0f; 
            ChangeColor(Color.red);
            AddForceAtRandomDirection(8f);
            Invoke(nameof(PopBubble), 1f);
            moneyCounter = -Mathf.RoundToInt(user._moneyCoef[2]*transform.localScale.x);
        }

        // Проверяем, если пузырь стал слишком маленьким
        if(transform.localScale.x <= _initialScale)
        {
            isActive = false;
            _baseScaleFactor = 0f;
        }

        // Проверка на движение пузыря. Если скорость пузыря очень мала, задаем случайный импульс
        _velocity = _rb?.linearVelocity ?? Vector2.zero;
        if (_velocity.magnitude < 0.02f)
        {
            AddForceAtRandomDirection(2.2f);
        }
        
        SetScale(_baseScaleFactor * transform.localScale.x);
    }

    // Увеличение при клике
    void OnMouseDown()
    {
        isActive = true;
        SetScale(_clickIncreaseScale);
        if (isColorChanged)
        {
            moneyCounter = -Mathf.RoundToInt(user._moneyCoef[2] * transform.localScale.x);
            user.decreaseLife();
            PopBubble();
        }
        user.increaseMoney(moneyCounter);
        //_moneySpawner.SpawnMoney(transform);
    }

    // Рандомный импульс
    private void AddForceAtRandomDirection(float coef)
    {
        if (_rb == null) _rb = GetComponent<Rigidbody2D>();
        Vector2 randomVector = Random.insideUnitCircle.normalized * coef;
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
