using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bullet;
    private CharacterController playerController;
    private Vector3 movmenet = Vector3.zero;

    void Start()
    {
        playerController = GetComponent<CharacterController>();
    }

    void Update()
    {
        movmenet = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        movmenet = transform.TransformDirection(movmenet);
        playerController.Move(movmenet * Time.deltaTime * 50);
        if (Input.GetKeyDown("space"))
        {
            GameObject newBullet = ObjectPool.SharedInstance.GetPooledObject();
            if (newBullet != null)
            {
                newBullet.transform.position = bullet.transform.position;
                newBullet.transform.rotation = bullet.transform.rotation;
                newBullet.SetActive(true);
            }
            newBullet.GetComponent<Rigidbody>().AddForce(Vector3.up * 200);

        
        // Destroy(newBullet, 3);
        gameObject.SetActive(false);
    }
    }
}
