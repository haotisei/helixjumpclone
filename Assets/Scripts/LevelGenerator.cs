using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public GameObject FirstPlatformPrefab;
    public int MinimumPlatform;
    public int MaxPlatform;
    public float DistanceBeetweenPlatform;
    public Transform FinishPlatform;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;
    public Game Game;

    private void Awake()
    {
        int platformsCount = Random.Range(MinimumPlatform, MaxPlatform + 1);

        for (int i = 0; i < platformsCount; i++)
        {
           int prefabIndex = Random.Range(0, PlatformPrefabs.Length);

            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefabs[prefabIndex];
            GameObject platform = Instantiate(platformPrefab, transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
            platform.transform.localRotation = Quaternion.Euler(0, Random.Range( 0, 360f), 0);
        }

        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);

        CylinderRoot.localScale = new Vector3(1, platformsCount * DistanceBeetweenPlatform + ExtraCylinderScale, 1);
    }

    

    private Vector3 CalculatePlatformPosition (int platformIndex)
    {
        return new Vector3(0, -DistanceBeetweenPlatform * platformIndex, 0);
    }
}
