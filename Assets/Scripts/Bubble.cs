using UnityEngine;

public class Bubble : MonoBehaviour
{
    [SerializeField] public float _baseDecreaseScale = -0.005f; // Базовая скорость уменьшения
    [SerializeField] public float _clickIncreaseScale = 0.2f;   // Увеличение при клике
    [SerializeField] public float _destroyScale;                // Размер, при котором пузырь лопается
    private Rigidbody2D _rb;                                    // Rigidbody2D для физики
    private bool isColorChanged = false;                        // Флаг изменения цвета
    public Vector2 _velocity;                                   // Скорость пузыря
    private SpriteRenderer _spriteRenderer;                     // Для изменения цвета

    void Start()
    {
        // Получаем компонент SpriteRenderer для изменения цвета
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        AddForceAtRandomDirection();

        // Случайный размер для лопания
        _destroyScale = Random.Range(4.5f, 5.2f); 

        // Начальный масштаб пузыря
        float initialScale = Random.Range(3.5f, 4.2f);
        transform.localScale = new Vector3(initialScale, initialScale, initialScale);

        // Скорость уменьшения зависит от начального масштаба (чем больше, тем быстрее)
        //_baseDecreaseScale = Mathf.Lerp(-0.001f, -0.002f, initialScale / 1.2f);
    }

    private void FixedUpdate()
    {
        // Если пузырь красный, он всегда растет медленно и лопается, иначе уменьшается
        if (isColorChanged && _spriteRenderer.color == Color.red)
        {
            // Замедленный рост для красного пузыря
            float scaleFactor = 0.001f;  // Рост для красного пузыря
            transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
        else
        {
            // Уменьшаем размер пузыря, если он не 
            float scaleFactor = _baseDecreaseScale * transform.localScale.x;
            transform.localScale += new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }

        // Проверяем, если пузырь стал слишком маленьким (меньше или равно 0.7), схлопываем
        if (transform.localScale.x <= 0.7f)
        {
            PopBubble();
        }

        // Проверка на движение пузыря
        _velocity = _rb?.linearVelocity ?? Vector2.zero;  // Если _rb null, то используем Vector2.zero

        // Если скорость пузыря очень мала, задаем случайный импульс
        if (_velocity.magnitude < 0.02f)
        {
            AddForceAtRandomDirection();
        }

        // Если размер больше 4 и цвет еще не изменен, меняем на красный
        if (transform.localScale.x > 4 && !isColorChanged)
        {
            ChangeColor(Color.red);
        }
    }

    // Метод для изменения цвета пузыря
    private void ChangeColor(Color newColor)
    {
        _spriteRenderer.color = newColor;
        isColorChanged = true;

        // Если пузырь стал красным, замедляем его рост
        if (newColor == Color.red)
        {
            _baseDecreaseScale = 0f; // Убираем уменьшение
            _clickIncreaseScale = 0f;  // Убираем увеличение при клике
        }
    }

    // Увеличение при клике
    void OnMouseDown()
    {
        // Если пузырь красный, он всегда растет
        if (_spriteRenderer.color == Color.red)
        {
            transform.localScale += new Vector3(0.001f, 0.001f, 0.001f);  // Медленный рост
        }
        else
        {
            // Увеличиваем размер пузыря при клике
            transform.localScale += new Vector3(_clickIncreaseScale, _clickIncreaseScale, _clickIncreaseScale);
        }

        // Если размер пузыря превысил лимит, лопаем пузырь
        if (transform.localScale.x >= _destroyScale)
        {
            PopBubble();
        }
    }

    // Рандомный импульс
    private void AddForceAtRandomDirection()
    {
        if (_rb == null) _rb = GetComponent<Rigidbody2D>();
        Vector2 randomVector = Random.insideUnitCircle.normalized * 1f;
        _rb.AddForce(randomVector, ForceMode2D.Impulse);
    }

    // Лопаем пузырь
    private void PopBubble()
    {
        Destroy(gameObject);
    }
}
