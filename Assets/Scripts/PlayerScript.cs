using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerScript : MonoBehaviour
{
    [SerializeField]
    private float forceFactor = 1.0f;

    private InputAction moveAction;
    private Rigidbody rb;
    private Vector3 correctedForward;
    private AudioSource hitlSound;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        rb = GetComponent<Rigidbody>();
        hitlSound = GetComponent<AudioSource>();
        GameState.Subscribe(nameof(GameState.effectsVolume), OnVolumeChanged);
        OnVolumeChanged();
    }


    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();
        correctedForward = Camera.main.transform.forward;
        correctedForward.y = 0.0f;
        correctedForward.Normalize();
        Vector3 forceValue = forceFactor *
// new Vector3(moveValue.x, 0.Of, moveValue.y); - Big
(Camera.main.transform.right * moveValue.x +
correctedForward * moveValue.y);
        rb.AddForce(forceValue);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))

        {
            if (!hitlSound.isPlaying)
            {

                hitlSound.volume = GameState.effectsVolume;
                hitlSound.Play();
            }
        }
    }

    private void OnVolumeChanged()
    {
        hitlSound.volume = GameState.effectsVolume;
    }


    private void OnDestroy()
    {
        GameState.UnSubscribe(nameof(GameState.effectsVolume), OnDestroy);
    }
}