using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField]
    private float fallDownTime = 2f;
    private new Rigidbody rigidbody;
    private TileSpawner tileSpawner = null;
    public void Setup(TileSpawner tileSpawner)
    {
        this.tileSpawner = tileSpawner;
    }
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            StartCoroutine("FallDownAndRespawnTile");
        }
    }
    private IEnumerator FallDownTile()
    {
        yield return new WaitForSeconds(0.1f);
        rigidbody.isKinematic = false;
        yield return new WaitForSeconds(fallDownTime);
        rigidbody.isKinematic = true;
    }
    private IEnumerator FallDownAndRespawnTile()
    {
        yield return new WaitForSeconds(0.1f);
        rigidbody.isKinematic = false;
        yield return new WaitForSeconds(fallDownTime);
        rigidbody.isKinematic = true;
        if(tileSpawner != null)
        {
            tileSpawner.SpawnTile(this.transform);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
