using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public Animator playerAnimator; // Referencja do komponentu Animator postaci
    public CameraFollow cameraFollow; // Referencja do skryptu obs�uguj�cego pod��anie kamery za postaci�
    public float playerSpeed = 5f; // Pr�dko�� poruszania si� postaci

    private bool isRunning = false; // Zmienna przechowuj�ca informacj�, czy posta� biegnie

    // Metoda wywo�ywana po klikni�ciu przycisku
    public void OnButtonClick()
    {
        // Zmie� flag�, aby w��czy� lub wy��czy� bieg postaci
        isRunning = !isRunning;

        // Zaktualizuj stan animacji postaci na podstawie flagi biegania
        playerAnimator.SetBool("IsRunning", isRunning);

        // Sprawd�, czy posta� biegnie, je�li tak, ustaw pr�dko�� kamery, aby pod��a�a za postaci�
        if (isRunning)
        {
            cameraFollow.followSpeed = playerSpeed;
        }
        else
        {
            // Je�li posta� przestaje biec, ustaw pr�dko�� kamery na zero, aby zatrzyma� pod��anie
            cameraFollow.followSpeed = 0f;
        }
    }
}

