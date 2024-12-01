using UnityEngine;

public class FlashScript : MonoBehaviour
{
    //private GameObject character;
    private Rigidbody playerRb;
    private float chargeTimeout = 5.0f;
    private Light spotLight;

    void Start()
    {
        //character = GameObject.Find("Character");
        playerRb = GameObject.Find("CharacterPlayer").GetComponent<Rigidbody>();
        spotLight = GetComponent<Light>();
        GameState.flashCharge = 1.0f;
    }

    void Update()
    {
        if (GameState.flashCharge > 0)
        {
            GameState.flashCharge -= Time.deltaTime / chargeTimeout;
            if (GameState.flashCharge < 0)
            {
                GameState.flashCharge = 0;
            }
            spotLight.intensity = GameState.flashCharge;
        }

        if (GameState.isFpv)
        {
            this.transform.rotation = Camera.main.transform.rotation;
        }
        else
        {
            if (playerRb.linearVelocity.magnitude > 0.01f)
                this.transform.forward = playerRb.linearVelocity.normalized;
        }
    }
}