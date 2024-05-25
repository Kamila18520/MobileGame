using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    public float baseSpeed = 2f; // Podstawowa pr�dko�� biegu
    private float currentSpeed;
    public float speedIncrement = 0.1f; // Wzrost pr�dko�ci na klikni�cie
    public float speedDecrement = 0.05f; // Zmniejszenie pr�dko�ci z czasem
    private float timeSinceLastClick = 0f;
    public float clickCooldown = 0.1f; // Minimalny czas mi�dzy klikni�ciami
    private Rigidbody2D rb;
    public Button runButton; // Odno�nik do przycisku UI
    public float fixedYPosition = 0f; // Sta�a wysoko�� postaci

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = baseSpeed;

        // Dodaj listener do przycisku
        runButton.onClick.AddListener(OnRunButtonClick);
    }

    void Update()
    {
        // Zmniejsz pr�dko�� z czasem
        currentSpeed = Mathf.Max(baseSpeed, currentSpeed - (speedDecrement * Time.deltaTime));

        // Przesu� posta� i utrzymuj sta�� wysoko��
        rb.velocity = new Vector2(currentSpeed, 0); // Ustaw pr�dko�� pionow� na 0

        // Utrzymuj sta�� pozycj� Y
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


