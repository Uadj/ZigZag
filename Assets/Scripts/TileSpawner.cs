using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefabs;
    [SerializeField]
    private Transform currentTile;
    [SerializeField]
    private int spawnTileCountAtStart = 100;
    [SerializeField]
    private GameController gameController;

    private void Awake()
    {
        for (int i = 0; i< spawnTileCountAtStart; i++){
            CreatTile();
        }
    }
    private void CreatTile()
    {
        GameObject clone = Instantiate(tilePrefabs);
        clone.transform.SetParent(transform);
        clone.GetComponent<Tile>().Setup(this);
        clone.transform.GetChild(1).GetComponent<Item>().Setup(gameController);
        SpawnTile(clone.transform);
        
    }
    public void SpawnTile(Transform tile)
    {
        tile.gameObject.SetActive(true);
        int index = Random.Range(0, 2);
        Vector3 addPosition = index == 0 ? Vector3.right : Vector3.forward;
        tile.position = currentTile.position + addPosition;

        currentTile = tile;
        int spawnItem = Random.Range(0, 100);
        if(spawnItem < 20)
        {
            tile.GetChild(1).gameObject.SetActive(true);
        }
    }
 
}
