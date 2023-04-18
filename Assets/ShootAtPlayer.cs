using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootAtPlayer : MonoBehaviour
{

    Vector3 currentMovement;
    CharacterController characterController;

    [SerializeField]
    private Transform bulletPrefab;
    [SerializeField]
    private Transform bulletPosition;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform playerLookAt;

    public int maxHealth = 100;
    public int health;

    public float timeBetweenBullets = 0.5f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        health = maxHealth;
        InvokeRepeating("shoot", 0f, 1f);
    }

    void shoot()
    {
        StartCoroutine(shootCoroutine());
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet"){
            health -= 8;
            if (health <= 0){
                Destroy(gameObject);
                SceneManager.LoadScene("Win");
            }
        }
    }

    void handleGravity()
    {
        if (characterController.isGrounded){
            float groundedGravity = -0.05f;
            currentMovement.y = groundedGravity;
        }
        else{
            float gravity = -9.8f;
            currentMovement.y = gravity;
        }
    }

    void Update()
    {
        handleGravity();
        characterController.Move(currentMovement * Time.deltaTime);

        transform.LookAt(playerLookAt);
    }

    IEnumerator shootCoroutine()
    {
        Vector3 bulletDirectionRay = player.position - bulletPosition.position;
        // bulletPosition = transform.TransformDirection(bulletPosition);
        // Debug.Log(bulletPosition.position);
        Instantiate(bulletPrefab, bulletPosition.position, Quaternion.LookRotation(bulletDirectionRay, Vector3.up));
        yield return new WaitForSeconds(timeBetweenBullets);
    }
}
