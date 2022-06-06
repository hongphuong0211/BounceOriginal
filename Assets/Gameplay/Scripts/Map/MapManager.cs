using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private static MapManager instance;
    public static MapManager Instance
    {
        get { 
            if(instance == null)
            {
                instance = FindObjectOfType<MapManager>();
            }
            return instance; }
    }

    private Grid currentLevel;

    public void StartLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    private IEnumerator LoadLevel(int level)
    {
        if(currentLevel != null)
        {
            Destroy(currentLevel.gameObject);
        }
        currentLevel = Instantiate(Resources.Load<Grid>("Level/Levels_" + level.ToString()), transform);
        yield return new WaitForSeconds(5f);
    }
}
