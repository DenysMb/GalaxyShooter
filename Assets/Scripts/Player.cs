using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 5;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    private float _nextFire = 0.0f;

    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    void Update()
    {
        Movement();
        Shoot();
    }

    private void Movement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3((_speed * xInput), (_speed * yInput), 0) * Time.deltaTime);

        float xPosition = transform.position.x;
        float yPosition = transform.position.y;
        float limitX = xPosition >= 8 ? 8 : xPosition <= -8 ? -8 : xPosition;
        float limitY = yPosition >= 4 ? 4 : yPosition <= -4 ? -4 : yPosition;

        if(xPosition >= 8 || xPosition <= -8 || yPosition >= 4 || yPosition <= -4)
        {
            transform.position = new Vector3(limitX, limitY, 0);
        }
    }

    private void Shoot()
    {
        float xPosition = transform.position.x;
        float yPosition = transform.position.y;
        bool isFiring = Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0);

        if (isFiring && Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, new Vector3(xPosition, yPosition + 0.9f, 0), Quaternion.identity);
        }
    }
}
