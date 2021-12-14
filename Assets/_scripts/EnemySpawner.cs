using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] npcPrefab;
    public int numOfEnemies;
    [Header("X Axis")]
    [SerializeField]
    public float xStart;
    [SerializeField]
    public float xEnd;

    [Header("Z Axis")]
    [SerializeField]
    public float zStart;
    [SerializeField]
    public float zEnd;

    [Header("Y Axis")]
    [SerializeField]
    public float yAxis;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numOfEnemies; i++)
        {
            float x = Random.Range(xStart, xEnd);
            float z = Random.Range(zStart, zEnd);

            float rot_y = Random.Range(0, 100);

            var spawnPos = new Vector3(x, yAxis, z);
            var spawnRot = Quaternion.Euler(0, rot_y, 0);

            int randEnemy = Random.Range(0, npcPrefab.Length);

            Instantiate(npcPrefab[randEnemy], spawnPos, spawnRot);
        }
        
    }

}
