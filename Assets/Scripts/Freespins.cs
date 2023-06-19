using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freespins : MonoBehaviour
{
    public GameObject openBook;
    public GameManager gameManager;
    public ReelManager reelManager;


    private void OnEnable()
    {
        gameManager.reelSpinner.expandingReelStopped += ClearExpandingReel;
    }

    private void OnDisable()
    {
        gameManager.reelSpinner.expandingReelStopped -= ClearExpandingReel;
    }

    public void StartFreespins(int randomExpandingReelPos)
    {
        openBook.SetActive(true);
        ScaleOpenBook();
        reelManager.EnableFreespinMask();
        reelManager.MakeExpandingReel(gameManager.gameSymbols);
        gameManager.reelSpinner.SpinExpandingReel(randomExpandingReelPos);
    }

    public void ScaleOpenBook()
    {
        StartCoroutine(ChangeScale(openBook));
    }

    private void ClearExpandingReel()
    {
        reelManager.ClearExpandingReel();
        openBook.SetActive(false);
        openBook.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        reelManager.DisableFreespinMask();
        reelManager.MakeBonusReels(gameManager.gameSymbols);
    }

    private IEnumerator ChangeScale(GameObject scaledObject)
    {
        for (int i = 0; i < 18; i++)
        {
            scaledObject.transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);
            yield return new WaitForSeconds(0.02f);
        }


        reelManager.ClearReels();
    }
}
