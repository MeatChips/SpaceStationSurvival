using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateAsteroidField : MonoBehaviour
{
    public Transform asteroidPrefab;
    public int fieldRadius = 100000;
    public int asteroidCount = 500;

    // Start is called before the first frame update
    void Start()
    {
        for (int loop = 0; loop < asteroidCount; loop++)
        {
            Transform temp = Instantiate(asteroidPrefab, Random.insideUnitSphere * fieldRadius, Random.rotation);
            temp.localScale = temp.localScale * Random.Range(0.5f, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
