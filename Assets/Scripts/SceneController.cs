using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;
    void Update()
    {
        if(!enemy)
        {
            enemy = Instantiate(enemyPrefab) as GameObject;//create new enemy
            enemy.transform.position = new Vector3(0, 2.5f, 0);
            //float angle = Random.Range(0, 4);
            //enemy.transform.Rotate(0, angle*90f, 0);
        }
    }
}
