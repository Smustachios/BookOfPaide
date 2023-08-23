using System;
using System.Collections;
using UnityEngine;

public class ReelSpinner : MonoBehaviour
{
    public ReelManager reelManager;
    public Action reelsStopped;
    public Action expandingReelStopped;

    private readonly int preSpinLenght = 45;
    private Vector3 offset = new Vector3(0, 1f);
    private float prespinDelay = 0.01f;
    private float spinDelay = 0.02f;

    public void SpinExpandingReel(int randomPos)
    {
        StartCoroutine(MoveExpandingReel(randomPos, reelManager.expandingReel.transform));
    }

    // Spin expanding reel
    private IEnumerator MoveExpandingReel(int randomPosition, Transform reelTransform)
    {
        // Setup positions for animation.
        Vector3 finalPos = new (reelTransform.position.x, -(randomPosition * 5) + 5);
        Vector3 startPos = finalPos - new Vector3(0, -(12 * 5));

        reelTransform.position = startPos;

        // "Spin" expanding reel.
        for (int i = 0; i <= 12;  i++)
        {
            reelTransform.position += new Vector3(0, -5);
            yield return new WaitForSeconds(0.4f);
        }

        yield return new WaitForSeconds(2.0f);

        // Let freespins know expanding reel has finished to continue with the sequence.
        expandingReelStopped.Invoke();
    }
}
