using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private GameObject itemGetEffectPrefabs;
    private GameController gameController;
    private float rotateSpeed;

    public void Setup(GameController gameController)
    {
        this.gameController = gameController;
        itemGetEffectPrefabs = Instantiate(itemGetEffectPrefabs, transform.position, Quaternion.identity);
        itemGetEffectPrefabs.SetActive(false);
    }
    private void OnEnable()
    {
        rotateSpeed = Random.Range(0.1f, 0.5f);
    }
    private void Update()
    {
        transform.Rotate(new Vector3(1, 0, 1)*rotateSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            itemGetEffectPrefabs.transform.position = transform.position;
            itemGetEffectPrefabs.SetActive(true);
            gameController.IncreaseScore(5);
            gameObject.SetActive(false);
        }
    }

}
