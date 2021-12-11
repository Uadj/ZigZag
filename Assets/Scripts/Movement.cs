using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed;
    private Vector3 moveDirection;
    [SerializeField]
    private float increaseAmount;
    [SerializeField]
    private float increaseCycleTime;
 
    public Vector3 MoveDirection => moveDirection;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(increaseCycleTime);
            moveSpeed += increaseAmount;
        }
    }
    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
   
    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }
}
