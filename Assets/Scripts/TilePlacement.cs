using UnityEngine;

public class SpriteGridSpawner : MonoBehaviour
{
    public GameObject spritePrefab;  // The prefab with the tile that contains child objects (tile1, tile2, tile3, tile4, tile5)
    public float gridWidth;
    public float gridHeight;
    public float spacing; 

    void Start()
    {
        SpawnGrid();
    }

    // Method to spawn the grid of tiles
    void SpawnGrid()
    {
        for (int x = -(int)gridWidth/2; x <= gridWidth/2; x++)
        {
            for (int y = -(int)gridHeight/2; y <= gridHeight/2; y++)
            {
                
                Vector3 position = new Vector3(x * spacing, y * spacing, 0);

                // Instantiate a new tile GameObject at the calculated position
                GameObject newTile = Instantiate(spritePrefab, position, Quaternion.identity);

                // Randomly select one child to activate and deactivate others
                RandomlySelectChild(newTile);
            }
        }
    }

    // Method to randomly select one child (tile1 to tile5) and deactivate others
    void RandomlySelectChild(GameObject tile)
    {
        // Get all child objects
        Transform[] children = new Transform[tile.transform.childCount];
        for (int i = 0; i < tile.transform.childCount; i++)
        {
            children[i] = tile.transform.GetChild(i);  // Store all children in an array
        }

        // Generate a random index to select one child
        int randomIndex = Random.Range(0, children.Length);

        // Activate the selected child and deactivate the rest
        for (int i = 0; i < children.Length; i++)
        {
            if (i == randomIndex)
            {
                children[i].gameObject.SetActive(true);  // Activate the selected child
            }
            else
            {
                children[i].gameObject.SetActive(false); // Deactivate the others
            }
        }
    }
}
