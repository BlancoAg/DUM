using UnityEngine;

public class AscensorController : MonoBehaviour
{
    [Tooltip("Velocidad de movimiento de la plataforma")]
    public float LeverSpeed = 1f;  // Ajusta la velocidad de movimiento
    [Tooltip("Primera ubicación de la plataforma")]
    public Transform Ubicacion1;
    [Tooltip("Segunda ubicación de la plataforma")]
    public Transform Ubicacion2;
    [Tooltip("Objeto de la plataforma que se moverá")]
    public Transform Platform;
    [Tooltip("Techo que se activará al mover el ascensor")]
    public GameObject Roof;

    public AudioSource leverSound;
    public AudioClip LeverPull;
    public AudioSource elevatorSoundSource;
    public AudioClip elevatorSound;
    public AudioClip elevatorEnd;

    Animator anim;
    bool isMovingToUbicacion2 = false;
    bool isAtUbicacion1 = true;
    bool isLeverPulled = false;
    bool isMoving = false;
    bool isPlayerOnPlatform = false;
    Transform playerTransform;
    Vector3 startPosition;
    Vector3 targetPosition;
    float startTime;
    float journeyLength;

    void Start()
    {
        anim = GetComponent<Animator>();

        // Colocar la plataforma en Ubicacion1 al inicio
        if (Platform != null && Ubicacion1 != null)
        {
            Platform.position = Ubicacion1.position;
        }

        // Desactivar Roof al inicio
        if (Roof != null)
        {
            Roof.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && IsNearView())
        {
            // Alternar el estado de la palanca
            isLeverPulled = !isLeverPulled;
            anim.SetBool("LeverUp", isLeverPulled);

            // Reproducir sonido de la palanca
            if (LeverPull != null)
            {
                leverSound.PlayOneShot(LeverPull);
            }

            // Determinar la posición objetivo de la plataforma
            if (isAtUbicacion1)
            {
                isMovingToUbicacion2 = true;
                isAtUbicacion1 = false;

                // Activar Roof solo durante el movimiento hacia Ubicacion2
                if (Roof != null)
                {
                    Roof.SetActive(true);
                }
            }
            else
            {
                isMovingToUbicacion2 = false;
                isAtUbicacion1 = true;
                // Desactivar Roof al llegar a Ubicacion1 o detenerse
                if (Roof != null)
                {
                    Roof.SetActive(false);
                }
            }

            // Inicializar movimiento
            if (Platform != null)
            {
                startPosition = Platform.position;
                targetPosition = isMovingToUbicacion2 ? Ubicacion2.position : Ubicacion1.position;
                startTime = Time.time;
                journeyLength = Vector3.Distance(startPosition, targetPosition);
                isMoving = true;

                // Iniciar el sonido del elevador cuando empieza a moverse
                if (elevatorSound != null && elevatorSoundSource != null)
                {
                    elevatorSoundSource.clip = elevatorSound;
                    elevatorSoundSource.loop = true;
                    elevatorSoundSource.Play();
                }
            }
        }

        // Mover la plataforma gradualmente entre Ubicacion1 y Ubicacion2
        if (Platform != null && isMoving)
        {
            MovePlatform();
        }
    }

    void MovePlatform()
    {
        float distanceCovered = (Time.time - startTime) * LeverSpeed;
        float fractionOfJourney = distanceCovered / journeyLength;
        Platform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

        // Si el jugador está en la plataforma, moverlo con la plataforma
        if (isPlayerOnPlatform && playerTransform != null)
        {
            playerTransform.position += Platform.position - startPosition;
        }

        // Verificar si el elevador ha llegado a la posición objetivo y detener el sonido
        if (fractionOfJourney >= 1f)
        {
            isMoving = false;

            if (elevatorSoundSource != null && elevatorSoundSource.isPlaying)
            {
                elevatorSoundSource.Stop();
                // Reproducir el sonido de fin de movimiento solo una vez
                if (elevatorEnd != null)
                {
                    elevatorSoundSource.PlayOneShot(elevatorEnd);
                }
                
                // Desactivar Roof cuando el movimiento se detiene
                if (Roof != null)
                {
                    Roof.SetActive(false);
                }
            }
        }
    }

    bool IsNearView()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 direction = transform.position - Camera.main.transform.position;
        float angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return angleView < 45f && distance < 2f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = true;
            playerTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerOnPlatform = false;
            playerTransform = null;
        }
    }
}
