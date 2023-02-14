using UnityEngine;

namespace Parallax2D.Modules.Player.Code.PlayerController
{
    public class Controller2d : MonoBehaviour {

        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float jumpForce = 15;

        private Rigidbody2D rb;
        private Transform groundCheck;
        private float defaultGravity;
        private Animator animator;
        private float _radius = 0.2f;
        private bool hit;


        // Initialize the components
        void Start() { 
            animator = gameObject.GetComponent<Animator>();
            rb = gameObject.GetComponent<Rigidbody2D>();
            groundCheck = GameObject.Find("GroundCheck").transform;
        }

        void FixedUpdate()
        {
            float horizontal = getHorizontal();
            Vector2 velocity = new Vector2();
            hit = Physics2D.OverlapCircle(groundCheck.position, _radius, layerMask); // Check the object groundCheck of the earth with a given mask
            velocity = new Vector2(horizontal * moveSpeed, rb.velocity.y); // Responsible for the movement of the character

            // Check if we can jump or not
            if (IsJump() && hit) {
                velocity.y = jumpForce;
            }
            rb.velocity = velocity;
        }

        // We return to which direction we move
        public float getHorizontal() {
            bool touchLect = false;
            bool touchRight = false;

            // mobile control without jump
            foreach (Touch touch in Input.touches) {
                if (touch.position.x < Screen.width * 1 / 4 && touch.position.y < Screen.height * 1 / 2) {
                    touchLect = true;
                } else if (touch.position.x > Screen.width * 1 / 4 && touch.position.x < Screen.width * 2 / 4 && touch.position.y < Screen.height * 1 / 2) {
                    touchRight = true;
                }
            }
            return Input.GetAxis("Horizontal") + (touchLect ? -1f : 0f) + (touchRight ? 1f : 0f);
        }

        // Return the value we jumped or not
        public bool IsJump() {
            return Input.GetKey(KeyCode.Space);
        }
    }
}
