using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace m
{
    public class PlayerController : MonoBehaviour
    {

        // Create public variables for player speed, and for the Text UI game objects
        public float speed;

        // Create private references to the rigidbody component on the player, and the count of pick up objects picked up so far
        private Rigidbody rb;
        public bool isKeyBoard, isAcceleration, isGyro, isButton;
        private bool isGrounded; // Check if the player is grounded
        public float jumpForce = 5f; // Force applied for the jump
        private Vector2 touchStart; // Store the starting position of a swipe
        public AudioSource _BallSound;
        public GameObject[] _myBody;
        public Renderer _DefaultBody;
        [HideInInspector]
        public float moveHorizontal;
        [HideInInspector]
        public float moveVertical;
       
        void Start()
        {
            // Assign the Rigidbody component to our private rb variable
            rb = GetComponent<Rigidbody>();

            FncCurrentBody();

        }



        // Each physics step..
        void FixedUpdate()
        {
            // Handle movement
            if (isKeyBoard)
            {
                // Keyboard input for movement
                moveHorizontal = Input.GetAxis("Horizontal");
                moveVertical = Input.GetAxis("Vertical");
            }

            if (isAcceleration)
            {
                // Accelerometer input for movement
                Vector3 acceleration = Input.acceleration;
                moveHorizontal = acceleration.x;
                moveVertical = acceleration.y;
            }

            if (isGyro)
            {
                if (SystemInfo.supportsGyroscope)
                {
                    Input.gyro.enabled = true;
                }

                if (Input.gyro.enabled)
                {
                    // Get the rotation rate from the gyroscope
                    Vector3 gyroRotation = Input.gyro.rotationRateUnbiased;

                    // Map the gyroscope's rotation rate to movement
                    moveHorizontal = gyroRotation.y; // Use gyroscope's Y-axis rotation for horizontal movement
                    moveVertical = -gyroRotation.x; // Use gyroscope's X-axis rotation for vertical movement

                }
            }

            if (isButton)
            {
                if (GameManager.instance.pnl_Buttons.activeSelf == false)
                {
                    GameManager.instance.pnl_Buttons.SetActive(true);
                }
            }


            // Create a Vector3 variable for movement
            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            if (movement.magnitude != 0)
            {
                _BallSound.enabled = true;
            }
            else
            {
                _BallSound.enabled = false;
            }
            // Apply movement force
            rb.AddForce(movement * speed);

            // Handle jumping
            HandleJump();
        }

        void HandleJump()
        {
            if (isKeyBoard && Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                // Jump with Space key
                Jump();
            }
            else if (isAcceleration || isGyro || isButton)
            {
                // Check for swipe gesture to trigger a jump
                DetectSwipeJump();
            }
        }

        void Jump()
        {
            if (isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                isGrounded = false; // Player is no longer grounded
            }
        }

        void DetectSwipeJump()
        {
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    touchStart = touch.position;
                }
                else if (touch.phase == TouchPhase.Ended)
                {
                    Vector2 touchEnd = touch.position;
                    Vector2 swipeDelta = touchEnd - touchStart;

                    if (swipeDelta.y > 100 && Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y))
                    {
                        Jump();
                    }
                }
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                isGrounded = true; // Reset grounded status when touching the ground
            }

            if (collision.gameObject.CompareTag("Laser"))
            {
                if (!GameManager.instance.isGameOver)
                {
                    AdsManager._instance.FncShowInitads();
                    rb.velocity = Vector3.zero;
                    SoundManager._instance._HFC.HeavyFeedback();

                    GameManager.instance._checkPoints = null;
                    GameManager.instance._checkPoints = collision.gameObject.GetComponent<CheckPoints>()._CheckPoint;
                    GameManager.instance.isGameOver = true;
                    Time.timeScale = 0;
                    SoundManager._instance.FncBlast();
                    StartCoroutine(FncFailed());
                }

            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                if (!GameManager.instance.isGameOver)
                {
                    SoundManager._instance._HFC.MediumFeedback();
                    if (GameManager.instance.NextLevel !=0)
                    {
                        PlayerPrefs.SetInt("SavedLevel", GameManager.instance.NextLevel);
                    }
                    AdsManager._instance.FncShowInitads();
                    GameManager.instance.isGameOver = true;
                    Time.timeScale = 0;
                    StartCoroutine(FnComplete());
                }

            }
        }

   
        public void ResetAll()
        {
            isKeyBoard = isAcceleration = isGyro = isButton = false;
        }

        IEnumerator FncFailed()
        {
            GameManager.instance.Btn_Reward.interactable = AdsManager._instance.isReward;

            yield return new WaitForSecondsRealtime(2f);
            SoundManager._instance.FncFailed();
            GameManager.instance.pnl_Failed.SetActive(true);
        }

        IEnumerator FnComplete()
        {

            if(PlayerPrefs.GetInt("CurrentLvl") == PlayerPrefs.GetInt("lvlLocked"))
            {
               PlayerPrefs.SetInt("lvlLocked", PlayerPrefs.GetInt("lvlLocked") + 1);
            }

            yield return new WaitForSecondsRealtime(2f);
            SoundManager._instance.FncWin();
            GameManager.instance.pnl_Complete.SetActive(true);
        }

        void FncCurrentBody()
        {
            if (PlayerPrefs.GetInt("SelectedBall") == 0)
            {
                for (int i = 0; i < _myBody.Length; i++)
                {
                    _myBody[i].SetActive(false);
                }
                _DefaultBody.enabled = true;
            }

            else
            {
                for (int i = 0; i < _myBody.Length; i++)
                {
                    _myBody[i].SetActive(false);
                }
                _DefaultBody.enabled = false;
                int id = PlayerPrefs.GetInt("SelectedBall") - 1;
                _myBody[id].SetActive(true);
            }
        }
    }
}