using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {

    private PilotController pilot;

    public uint tileHeight;

    GameObject[] tiles;

	// Use this for initialization
	void Start ()
    {
        float nextTileYPos = 0;
        Vector2 colliderSize;

        pilot = FindObjectOfType<PilotController>();
        GameObject ladderTile = Resources.Load("Materials/LadderTile", typeof(GameObject)) as GameObject;
        tiles = new GameObject[tileHeight];
        
        //generate all the ladder tiles needed
        for (uint i = 0; i < tileHeight; i++)
        {
            tiles[i] = GameObject.Instantiate(ladderTile) as GameObject;
            tiles[i].transform.parent = gameObject.transform;
            Vector3 tilePosition = new Vector3(gameObject.transform.position.x, (gameObject.transform.position.y + nextTileYPos), gameObject.transform.position.z);
            tiles[i].transform.SetPositionAndRotation(tilePosition, gameObject.transform.rotation);
            nextTileYPos += tiles[i].GetComponent<SpriteRenderer>().size.y;
        }
        //remove the height of one tile (that was not added because we exited the cycle)
        nextTileYPos -= tiles[0].GetComponent<SpriteRenderer>().size.y;
        // make collider width 1/3 of the actual width of the ladder to reduce the "floating on ladder" effect
        float colliderWidth = tiles[0].GetComponent<SpriteRenderer>().size.x / 3;
        
        colliderSize = new Vector2(colliderWidth, nextTileYPos);
        //create the collider
        BoxCollider2D ladderCollider = gameObject.AddComponent<BoxCollider2D>();
        ladderCollider.size = colliderSize;
        ladderCollider.isTrigger = true;
        //offset the collider to center it vertically
        ladderCollider.offset = new Vector2(0, (nextTileYPos / 2));
    }

    // Update is called once per frame
    void OnTriggerEnter2D (Collider2D other)
    {
		if(other.name == pilot.name)
        {
            pilot.SetIsOnLadder(true);
        }
	}

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == pilot.name)
        {
            pilot.SetIsOnLadder(false);
        }
    }
}
