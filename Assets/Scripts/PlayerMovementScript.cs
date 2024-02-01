using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    [SerializeField] ShowelWeaponScript sWS;
    [SerializeField] ArrowScript aS;
    float mouseSmoothTime = 0.05f;
    float mouseSensitivity = 3.5f;
    float speed = 6f;
    float moveSmoothTime = 0.05f;
    float cameraCap;
    float velocityY;
    float gravity = -30f;
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity;
    Vector2 currentDir;
    Vector2 currentDirVelocity;
    Vector3 velocity;
    bool isGrounded;
    CharacterController controller;
    public float health;
    float maxHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        updateMove();
        updateMouse();
        if (health <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene(1);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }
    void updateMove()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);
        velocityY += gravity * 2f * Time.deltaTime;
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * speed + Vector3.up * velocityY;
        controller.Move(velocity * Time.deltaTime);
        if (isGrounded! && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }

    }
    void updateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
        cameraCap = Mathf.Clamp(cameraCap, -90, 90);
        playerCamera.localEulerAngles = Vector3.right * cameraCap;
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Eye"))
        {
            sWS.damage++;
            aS.damage++;
            health += 5;
            Destroy(collision.gameObject);
        }
    }

}
