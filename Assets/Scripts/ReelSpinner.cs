using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReelSpinner : MonoBehaviour
{
    public float animationOffset;

    private int preSpinLenght = 45;
    private int reelId;
    private ReelConstructor reelConstructor;


    private void Awake()
    {
        reelConstructor = GetComponent<ReelConstructor>();
        reelId = reelConstructor.reelId;
    }

    public void SpinReel(int[] randomReelPos)
    {
        StartCoroutine(MoveReel(randomReelPos));
    }

    private IEnumerator MoveReel(int[] randomReelPos)
    {
        for (int i = 0; i < preSpinLenght * 4; i++)
        {
            transform.position -= new Vector3(0, 0.25f);
            yield return new WaitForSeconds(0.002f);
        }

        Vector3 finalPos = new Vector3(transform.position.x, -(randomReelPos[reelId] * 3) + 3);
        Vector3 startPos = finalPos - new Vector3(0, -animationOffset);

        transform.position = startPos;

        for (int i = 0; i < animationOffset * 4; i++)
        {
            transform.position -= new Vector3(0, 0.25f);
            yield return new WaitForSeconds(0.005f);
        }
    }

    private void OnEnable()
    {
        reelConstructor.gameManager.StartSpin += SpinReel;
    }

    private void OnDisable()
    {
        reelConstructor.gameManager.StartSpin -= SpinReel;
    }
}
