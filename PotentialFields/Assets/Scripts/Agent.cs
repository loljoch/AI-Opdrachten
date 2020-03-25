using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public float speed = 1;
    public bool shouldWalk = false;
    private bool isWalking = false;

    private void Update()
    {
        if (!isWalking && shouldWalk)
        {
            Node newPos = MouseInput.potentialFields.GetLowestNeighbour(Vector2Int.FloorToInt(transform.position), Gridmaker.grid);
            if (newPos == null)
            {
                shouldWalk = false;
                return;
            }
            WalkTo(newPos.position);
        }
    }

    public void WalkTo(Vector2Int newPos)
    {
        StartCoroutine(LerpPos(new Vector3(newPos.x, newPos.y, transform.position.z), speed));
    }

    public IEnumerator LerpPos(Vector3 targetPosition, float speed)
    {
        isWalking = true;
        float time = Time.time;
        Vector3 transformOldPosition = transform.position;

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.Lerp(transformOldPosition, targetPosition, (Time.time - time) * speed);

            yield return new WaitForEndOfFrame();

        }

        isWalking = false;
        yield return new WaitForEndOfFrame();
    }
}
