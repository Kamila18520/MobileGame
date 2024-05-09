using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public Animator playerAnimator; // Referencja do komponentu Animator postaci
    public CameraFollow cameraFollow; // Referencja do skryptu obs³uguj¹cego pod¹¿anie kamery za postaci¹
    public float playerSpeed = 5f; // Prêdkoœæ poruszania siê postaci

    private bool isRunning = false; // Zmienna przechowuj¹ca informacjê, czy postaæ biegnie

    // Metoda wywo³ywana po klikniêciu przycisku
    public void OnButtonClick()
    {
        // Zmieñ flagê, aby w³¹czyæ lub wy³¹czyæ bieg postaci
        isRunning = !isRunning;

        // Zaktualizuj stan animacji postaci na podstawie flagi biegania
        playerAnimator.SetBool("IsRunning", isRunning);

        // SprawdŸ, czy postaæ biegnie, jeœli tak, ustaw prêdkoœæ kamery, aby pod¹¿a³a za postaci¹
        if (isRunning)
        {
            cameraFollow.followSpeed = playerSpeed;
        }
        else
        {
            // Jeœli postaæ przestaje biec, ustaw prêdkoœæ kamery na zero, aby zatrzymaæ pod¹¿anie
            cameraFollow.followSpeed = 0f;
        }
    }
}

