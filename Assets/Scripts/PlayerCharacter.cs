using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class PlayerCharacter : MonoBehaviour
{
    //public Text numberOfHearts;
    private int health;
    public GameObject HPValue;
    private Text numberOfHearts;

    void Start()
    {
        health = 5;
        numberOfHearts = HPValue.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //HPValue.GetComponent<Text>().text = health.ToString();
        numberOfHearts.text = health.ToString();
    }

    public void Hurt(int damage)
    {
        health -= damage;
        Debug.Log("health: " + health);
        if (health <= 0)
        {
            SceneManager.LoadScene("deathscreen");
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            health = 5;
        }
    }
}
