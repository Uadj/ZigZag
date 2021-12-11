using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float limitDeathY;
    private Movement Movement;
    [SerializeField]
    private GameController gameController;
    private void Awake()
    {
        Movement = GetComponent<Movement>();
        //Movement.MoveTo(Vector3.right);
        limitDeathY = transform.position.y - transform.localScale.y * 0.5f;
    }
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        if (gameController.IsGameOver) return;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction = Movement.MoveDirection == Vector3.forward ? Vector3.right : Vector3.forward;
            Movement.MoveTo(direction);
            gameController.IncreaseScore();
        }
        if(transform.position.y < limitDeathY)
        {
            //Debug.Log("Gameover");
            gameController.GameOver();
        }

    }
    private IEnumerator Start()
    {
        if (gameController.IsGameStart)
        {
            Movement.MoveTo(Vector3.right);
            yield break;
        }
        yield return null;
    }
}
