using System.Collections;
using TMPro;
using UnityEngine;


/// <summary>
/// To manage freespins.
/// </summary>
public class Freespins : MonoBehaviour
{
    public GameObject openBook;
    public GameObject spinExpandingReelButton;
    public GameObject bookOfPaideHeader;
    public GameObject freespinsLeftText;
    public GameObject congratsPage;
    public GameObject expandingSymbolSprite;
    public GameObject freespinsText;
    public GameObject retriggerText;

    public GameManager gameManager;
    public ReelManager reelManager;

    public bool freespinSequenceActivated = false;

    private int randomExpandingReelPos;


    // Continue with start of freespins after expanding reel has stopped spinning.
    private void OnEnable()
    {
        gameManager.reelSpinner.expandingReelStopped += FinishExpandingReelSpin;
    }

    private void OnDisable()
    {
        gameManager.reelSpinner.expandingReelStopped -= FinishExpandingReelSpin;
    }

    // Starting sequence for freespins.
    public IEnumerator StartFreespins(int randomExpandingReelPos)
    {
        // Stop from spinning while sequence is activated.
        freespinSequenceActivated = true;

        // Set up expanding reel background.
        openBook.SetActive(true);
        yield return ChangeScale(openBook);

        // Set up expanding reel position for spinning.
        this.randomExpandingReelPos = randomExpandingReelPos;

        // Activate expanding reel spin button and wait for player to press it.
        spinExpandingReelButton.SetActive(true);
    }

    // Finish freespins sequence.
    public void FinishFreespins(TextMeshProUGUI congratzText)
    {
        StartCoroutine(ShowCongratsPage(congratzText));
        reelManager.ClearReels();
        reelManager.MakeBaseReels(gameManager.gameSymbols);
    }

    // Spin expanding reel and hide start button.
    public void StartExpandingReelSpinButton()
    {
        gameManager.reelSpinner.SpinExpandingReel(randomExpandingReelPos);
        spinExpandingReelButton.SetActive(false);
    }

    // Show retrigger message page
    public IEnumerator ShowRetriggerMessage()
    {
        congratsPage.SetActive(true);
        retriggerText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        congratsPage.SetActive(false);
        retriggerText.SetActive(false);
    }

    // Once expanding reel finished spinning, disable expanding reel and background.
    private void FinishExpandingReelSpin()
    {
        reelManager.ClearExpandingReel();
        openBook.SetActive(false);
        openBook.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        // Set up bonus reels and reset spritemasks.
        reelManager.DisableFreespinMask();
        reelManager.MakeBonusReels(gameManager.gameSymbols);

        // Set up UI.
        bookOfPaideHeader.SetActive(false);
        freespinsLeftText.SetActive(true);
        expandingSymbolSprite.SetActive(true);
        freespinsText.SetActive(true);

        freespinSequenceActivated = false;
    }

    // Scale book object.
    private IEnumerator ChangeScale(GameObject scaledObject)
    {
        for (int i = 0; i < 18; i++)
        {
            scaledObject.transform.localScale += new Vector3(0.025f, 0.025f, 0.025f);
            yield return new WaitForSeconds(0.025f);
        }

        // Once book covers reels, clear base reels.
        reelManager.ClearReels();

        // Set up expanding reel.
        reelManager.EnableFreespinMask();
        reelManager.MakeExpandingReel(gameManager.gameSymbols);
    }

    // Show congrats page with text for some time. After that reset UI for base game.
    private IEnumerator ShowCongratsPage(TextMeshProUGUI congratzText)
    {
        congratsPage.SetActive(true);
        congratzText.enabled = true;
        yield return new WaitForSeconds(4f);
        congratzText.enabled = false;
        congratsPage.SetActive(false);

        // Turn off freespin UI stuff.
        bookOfPaideHeader.SetActive(true);
        expandingSymbolSprite.SetActive(false);
        freespinsText.SetActive(false);
    }
}
