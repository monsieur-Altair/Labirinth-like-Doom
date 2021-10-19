using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 1.0f;
    public float radius = 0.75f;
    public bool isAlive;

    [SerializeField] private GameObject fireballPrefab;
    private GameObject fireball;
    
    void Start()
    {
        isAlive = true;
    }

    void Update()
    {
        if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);

            Ray ray = new Ray(transform.position, transform.forward);
            Ray rayRight = new Ray(transform.position, transform.right);
            //Ray rayLeft = new Ray(transform.position, (transform.right*-1));
            RaycastHit hit;

            if (Physics.SphereCast(ray, radius, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.GetComponent<PlayerCharacter>())
                {
                    if (!fireball)
                    {
                        fireball = Instantiate(fireballPrefab) as GameObject;
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(0, 4);
                    transform.Rotate(0, angle*90f, 0);
                }
            }

            //if (Physics.SphereCast(rayRight, radius, out hitLeft))
            //{
            //    GameObject hitObjectLeft = hitLeft.transform.gameObject;
            //    if (hitLeft.distance > 7f)
            //        transform.Rotate(0, -90f, 0);
            //}

        }
    }

    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }
}
