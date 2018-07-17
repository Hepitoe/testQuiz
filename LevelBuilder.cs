using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    [SerializeField] private Texture2D map;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private PlayerExample playerExample;

    public void Awake()
    {
        BuildMap();
    }

    private void BuildMap()
    {
        var mapParent = new GameObject("Map");
        mapParent.transform.position = Vector3.zero;
        Debug.LogError(map.width + " " + map.height);
        for (int y = 0; y < map.height; y++)
        {
            for (int x = 0; x < map.width; x++)
            {
                var color = map.GetPixel(x, y);
                //Debug.LogError(color);
                if (color.a < 0.1f)
                {
                    continue;
                }
                if (color == Color.black)
                {
                    var block = Instantiate(blockPrefab);
                    block.name = blockPrefab.name + " " + x + " " + y;
                    block.transform.SetParent(mapParent.transform);
                    block.transform.position = new Vector3((float)x, (float)y, 0f);

                }
                if(color == Color.red)
                {
                    playerExample.transform.SetParent(mapParent.transform);
                    playerExample.transform.position = new Vector3((float)x, (float)y, 0f);
                }
            }
        }
    }
}
