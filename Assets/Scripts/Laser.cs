using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private int _yLimit = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float xPosition = transform.position.x;
        float yPosition = transform.position.y;

        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        if (yPosition > _yLimit)
        {
            Destroy(gameObject);
        }
    }
}
