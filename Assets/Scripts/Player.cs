using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private Vector2 m_moveAmt;

    public float WalkSpeed;
    public Transform arma;
    public Weapon armaSpawn;
    public int vida = 3;
    public GameObject gameOverUI;
    public void OnMove(InputAction.CallbackContext ctx)
    {
        m_moveAmt = ctx.ReadValue<Vector2>();
    }

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        HandleMovement();
        RotateWeapon();
    }
    private void HandleMovement()
    {
        Vector3 move = new Vector3(m_moveAmt.x, 0, m_moveAmt.y);
        move = transform.TransformDirection(move);
        m_Rigidbody.MovePosition(transform.position + move * WalkSpeed * Time.deltaTime);
    }
    private void RotateWeapon()
    {
        Vector3 moveDirection = new Vector3(m_moveAmt.x, 0, m_moveAmt.y);

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            Vector3 targetDirection;
            if (Mathf.Abs(moveDirection.z) > Mathf.Abs(moveDirection.x))
            {
                targetDirection = moveDirection.z > 0 ? Vector3.up : Vector3.down;
            }
            else
            {
                targetDirection = new Vector3(moveDirection.x, 0, 0);
            }
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            Quaternion rotationOffset = Quaternion.Euler(0f, 90f, 0f);
            Quaternion finalRotation = targetRotation * rotationOffset;

            arma.rotation = Quaternion.Slerp(arma.rotation, finalRotation, Time.deltaTime * 10f);
        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            armaSpawn.Shoot();
        }
    }
    public void RecibirDanio()
    {
        vida -= 1;
        Debug.Log("Vida restante: " + vida);

        if (vida <= 0)
        {
            vida = 0;
            GameOver();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            RecibirDanio();
        }
    }
    void GameOver()
    {
        gameOverUI.SetActive(true);
        Debug.Log("¡Game Over!");
        Time.timeScale = 0f;
    }
}