using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ReactiveTarget : MonoBehaviour
{
    //BoxCollider collider;
    public bool Alive;
    private Rigidbody obj;

    public void ReactToHit()
    {
        if(Alive)
        {
            AI behavior = GetComponent<AI>();
            if (behavior)
                behavior.SetAlive(false);
            StartCoroutine(Die());
        }

    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-30, 0, 0);
        obj.freezeRotation = false;
        Alive = false;
        obj.mass *= 100;
        //collider.enabled = false;
        yield return new WaitForSeconds(3.5f);
        Destroy(this.gameObject);
    }

    void Start()
    {
        Alive = true;
        //collider = GetComponent<BoxCollider>();
        obj = GetComponent<Rigidbody>();
        obj.freezeRotation = true;
    }
}
