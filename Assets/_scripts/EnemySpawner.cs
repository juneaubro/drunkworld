using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] npcPrefab;
    public int numOfEnemies;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numOfEnemies; i++)
        {
            float x = Random.Range(82, 148);
            float z = Random.Range(83, 152);

            float rot_y = Random.Range(0, 100);

            var spawnPos = new Vector3(x, -990, z);
            var spawnRot = Quaternion.Euler(0, rot_y, 0);

            int randEnemy = Random.Range(0, npcPrefab.Length);

            Instantiate(npcPrefab[randEnemy], spawnPos, spawnRot);
        }
        
    }

}
