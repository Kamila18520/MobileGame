using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float baseSpeed = 2f; // Podstawowa prêdkoœæ biegu
    private float currentSpeed;
    public float speedIncrement = 0.1f; // Wzrost prêdkoœci na klikniêcie
    public float speedDecrement = 0.05f; // Zmniejszenie prêdkoœci z czasem
    private float timeSinceLastClick = 0f;
    public float clickCooldown = 0.1f; // Minimalny czas miêdzy klikniêciami
    private Rigidbody2D rb;
    public Button runButton; // Odnoœnik do przycisku UI
    public float fixedYPosition = 0f; // Sta³a wysokoœæ postaci

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = baseSpeed;

        // Dodaj listener do przycisku
        runButton.onClick.AddListener(OnRunButtonClick);
    }

    void Update()
    {
        // Zmniejsz prêdkoœæ z czasem
        currentSpeed = Mathf.Max(baseSpeed, currentSpeed - (speedDecrement * Time.deltaTime));

        // Przesuñ postaæ i utrzymuj sta³¹ wysokoœæ
        rb.velocity = new Vector2(currentSpeed, 0); // Ustaw prêdkoœæ pionow¹ na 0

        // Utrzymuj sta³¹ pozycjê Y
        transform.position = new Vector3(transform.position.x, fixedYPosition, transform.position.z);
    }

    void OnRunButtonClick()
    {
        if (Time.time - timeSinceLastClick > clickCooldown)
        {
            currentSpeed += speedIncrement;
            timeSinceLastClick = Time.time;
        }
    }
}


