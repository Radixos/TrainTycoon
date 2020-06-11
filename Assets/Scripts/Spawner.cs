using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] clouds;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMaxWait;
    public float spawnMinWait;
    public int startWait;
    public bool stop;
    //public Vector3 scaleFactor;

    int randCloud;

    private void Start()
    {
        StartCoroutine(WaitSpawner());
    }

    private void Update()
    {
        spawnWait = Random.Range(spawnMinWait, spawnMaxWait);
    }

    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randCloud = Random.Range(0, clouds.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(clouds[randCloud], spawnPosition + transform.TransformPoint(1, 0, 0), /*spawnRotation **/ gameObject.transform.rotation);

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
