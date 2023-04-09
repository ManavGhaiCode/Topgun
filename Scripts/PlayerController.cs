using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;

    [SerializeField] private KeyBindings KeyBinds;
    [SerializeField] private float health;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isRunning;
    private Animator anim;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        moveInput.x = GetXInput();
        moveInput.y = GetYInput();
    }

    private void FixedUpdate() {
        float forceX = moveInput.normalized.x * speed * Time.fixedDeltaTime;
        float forceY = moveInput.normalized.y * speed * Time.fixedDeltaTime;

        rb.MovePosition(rb.position + new Vector2 (forceX, forceY));

        if (moveInput.x != 0 || moveInput.y != 0) {
            isRunning = true;
            anim.SetBool("isRunning", isRunning);
        } else {
            isRunning = false;
            anim.SetBool("isRunning", isRunning);
        }
    }

    private float GetXInput() {
        if (Input.GetKey(KeyBinds.GetKey("MoveRight"))) {
            return 1;
        } else if (Input.GetKey(KeyBinds.GetKey("MoveLeft"))) {
            return -1;
        }
        
        return 0;
    }

    private float GetYInput() {
        if (Input.GetKey(KeyBinds.GetKey("MoveUp"))) {
            return 1;
        } else if (Input.GetKey(KeyBinds.GetKey("MoveDown"))) {
            return -1;
        }
        
        return 0;
    }

    public void TakeDamge (int Damage) {
        health -= Damage;
    }
}
