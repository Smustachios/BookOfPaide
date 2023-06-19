using System;
using System.Collections;
using UnityEngine;

public class ReelSpinner : MonoBehaviour
{
    public ReelManager reelManager;
    public Action reelsStopped;
    public Action expandingReelStopped;

    private int preSpinLenght = 45;


    public void SpinReels(int[] randomReelPos)
    {
        foreach (GameObject reel in reelManager.reels)
        {
            StartCoroutine(MoveReel(randomReelPos, reel.transform));
        }
    }

    public void SpinExpandingReel(int randomPos)
    {
        StartCoroutine(MoveExpandingReel(randomPos, reelManager.expandingReel.transform));
    }

    private IEnumerator MoveReel(int[] randomReelPos, Transform reelTransform)
    {
        ReelConstructor reelData = reelTransform.GetComponent<ReelConstructor>();

        for (int i = 0; i < preSpinLenght * 4; i++)
        {
            reelTransform.position -= new Vector3(0, 0.25f);
            yield return new WaitForSeconds(0.002f);
        }

        Vector3 finalPos = new (reelTransform.position.x, -(randomReelPos[reelData.reelId] * 3) + 3);
        Vector3 startPos = finalPos - new Vector3(0, -reelData.animationOffset);

        reelTransform.position = startPos;

        for (int i = 0; i < reelData.animationOffset * 4; i++)
        {
            reelTransform.position -= new Vector3(0, 0.25f);
            yield return new WaitForSeconds(0.005f);
        }

        if (reelData.reelId == 4)
        {
            reelsStopped.Invoke();
        }
    }

    private IEnumerator MoveExpandingReel(int randomPosition, Transform reelTransform)
    {
        Vector3 finalPos = new Vector3(reelTransform.position.x, -(randomPosition * 5) + 5);
        Vector3 startPos = finalPos - new Vector3(0, -(12 * 5));

        reelTransform.position = startPos;

        for (int i = 0; i <= 12;  i++)
        {
            reelTransform.position += new Vector3(0, -5);
            yield return new WaitForSeconds(0.5f);
        }

        yield return new WaitForSeconds(2.0f);

        expandingReelStopped.Invoke();
    }
}
