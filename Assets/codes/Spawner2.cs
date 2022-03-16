using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public Transform spawnPos;

    [SerializeField] Vector2 range;
    [SerializeField] GameObject enemy;
 

    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3);
        Vector2 pos = spawnPos.position + new Vector3( Random.Range(-range.x, range.x), 0);
        Instantiate(enemy, pos, Quaternion.identity);
       
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(Spawn());
    }

}
