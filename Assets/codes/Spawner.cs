using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawnPos;
    bool direction = false;
    [SerializeField] Vector2 range;
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject buff;

    void Start()
    {
        StartCoroutine(Spawn());
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        Vector2 pos = spawnPos.position + new Vector3(0, Random.Range(-range.y, range.y));
        Instantiate(enemy, pos, Quaternion.identity);
        Vector2 poss = spawnPos.position + new Vector3(Random.Range(-1, 0), Random.Range(-range.y, range.y) + 2);
        Instantiate(buff, poss, Quaternion.identity);
        Repeat();
    }

    void Repeat()
    {
        StartCoroutine(Spawn());
    }
   
}
