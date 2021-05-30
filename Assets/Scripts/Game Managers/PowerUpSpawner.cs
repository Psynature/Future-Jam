using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> powerupPrefabs;
    [SerializeField] float spawnTimer;
    private float canSpawn;
    [SerializeField][Range(1,20)] float spawnRandomFactor, powerupSpeed;

    private float xMin, xMax;

    // Start is called before the first frame update
    void Start()
    {
        canSpawn = spawnTimer;
        xMin = Camera.main.ViewportToWorldPoint(new Vector3(0.1f,0,0)).x;
        xMax = Camera.main.ViewportToWorldPoint(new Vector3(0.9f,0,0)).x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > canSpawn)
        {
            StartCoroutine(SpawnPowerup(Random.Range(0, powerupPrefabs.Count - 1)));
        }
    }
    private IEnumerator SpawnPowerup(int count)
    {
        canSpawn = Time.time + spawnTimer;
        var xv = Random.Range(xMin, xMax);
        yield return new WaitForSeconds(Random.Range(0, spawnRandomFactor));
        var spawnedItem = Instantiate(
            powerupPrefabs[count],
            new Vector3(xv, Camera.main.ViewportToWorldPoint(new Vector3(0,1,0)).y, 0.0f),
            Quaternion.identity)
            as GameObject;
        AddForceToPowerup(spawnedItem);
    }
    private void AddForceToPowerup(GameObject spawnedItem)
    {
        spawnedItem.GetComponent<Rigidbody2D>().AddForce(Vector3.down * (Mathf.Max(1, powerupSpeed) * 10));
    }
}
