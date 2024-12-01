using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public class DoorScript : MonoBehaviour
    {
        private bool isOpen;
        private bool isLocked;
        private float inTimeTimeout = 2.0f;
        private float outTimeTimeout = 5.0f;
        private float timeout;
        private float openTime;
        private AudioSource hitSound;
        private AudioSource openSound;

        void Start()
        {
            isLocked = true;
            isOpen = false;
            openTime = 0.0f;
            hitSound = GetComponent<AudioSource>();
            AudioSource[] audioSources = GetComponents<AudioSource>();
            hitSound = audioSources[0];
            openSound = audioSources[1];
        }

        void Update()
        {
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Player")
            {

                if (GameState.collectedKeys.Keys.Contains("1"))
                {

                    bool isInTime = GameState.collectedKeys["1"];
                    timeout = isInTime ? inTimeTimeout : outTimeTimeout;
                    openTime = timeout;
                    isLocked = false;
                    ToastScript.ShowToast("Ключ \"1\" застосовано" +
                    (isInTime ? "вчасно" : "He вчасно"));


                    openSound.Play();
                }

                else

                    ToastScript.ShowToast("Для відкриття двері потрібен ключ \"1\"");
            }

            hitSound.Play();
        }

    }
}
