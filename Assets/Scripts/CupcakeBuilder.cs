using UnityEngine;
using System.Collections;

public enum Wrapper { None, Green, Blue, Pink, Purple }
public enum Base { None, Vanilla, Strawberry, Choco }
public enum Frosting { None, Normal, Strawberry, Choco }

public class CupcakeBuilder : MonoBehaviour
{
    [Header("Sprites  (index 0 = null)")]
    public Sprite[] wrapperSprites = new Sprite[5];
    public Sprite[] baseSprites = new Sprite[4];
    public Sprite[] frostingSprites = new Sprite[4];

    [Header("Renderers")]
    public SpriteRenderer wrapperR;
    public SpriteRenderer baseR;
    public SpriteRenderer frostingR;

    [Header("Button Groups")]
    public GameObject baseButtonsGroup;
    public GameObject frostingButtonsGroup;

    private Wrapper curWrap = Wrapper.None;
    private Base curBase = Base.None;

    public CupcakeGenerator generatedCupcake;

    public AudioClip wrongChoice;
    public AudioClip correctChoice;
    public AudioClip winSound;

    public Animator animController;

    public CupcakeGenerator tele;

    private int frostingSelect = -1;

    private float waitFor = 0.3f;

    /* ---- public methods called by buttons ---- */
    public void SetWrapper(int id)
    {
        animController.SetTrigger("cone1");
        StartCoroutine(SetWrapperEnum(id));
    }

    private IEnumerator SetWrapperEnum(int id)
    {
        yield return new WaitForSeconds(waitFor);
        curWrap = (Wrapper)id;
        wrapperR.sprite = wrapperSprites[id];
        baseButtonsGroup.SetActive(id != 0);
        id--;
        if (id != generatedCupcake.wrappingIndex)
            GetComponent<AudioSource>().clip = wrongChoice;
        else
            GetComponent<AudioSource>().clip = correctChoice;

        GetComponent<AudioSource>().Play();
    }

    public void SetBase(int id)
    {
        if (curWrap == Wrapper.None) return;
        animController.SetTrigger("cone2");
        StartCoroutine(SetBaseEnum(id));
    }

    private IEnumerator SetBaseEnum(int id)
    {
        yield return new WaitForSeconds(waitFor);
        curBase = (Base)id;
        baseR.sprite = baseSprites[id];
        frostingButtonsGroup.SetActive(id != 0);


        id--;
        if (id != generatedCupcake.baseIndex)
            GetComponent<AudioSource>().clip = wrongChoice;
        else
            GetComponent<AudioSource>().clip = correctChoice;

        GetComponent<AudioSource>().Play();
    }

    public void SetFrosting(int id)
    {
        if (curBase == Base.None) return;
        animController.SetTrigger("cone3");
        StartCoroutine(SetFrostingEnum(id));
    }

    private IEnumerator SetFrostingEnum(int id)
    {
        yield return new WaitForSeconds(waitFor);
        frostingR.sprite = frostingSprites[id];

        frostingSelect = id - 1;
        if (frostingSelect != generatedCupcake.frostingIndex)
            GetComponent<AudioSource>().clip = wrongChoice;
        else
            GetComponent<AudioSource>().clip = correctChoice;

        GetComponent<AudioSource>().Play();}

    public void CheckItAll()
    {
        if (frostingSelect != generatedCupcake.frostingIndex
        || (int)curBase != generatedCupcake.baseIndex + 1
        || (int)curWrap != generatedCupcake.wrappingIndex + 1)
            GetComponent<AudioSource>().clip = wrongChoice;
        else
            GetComponent<AudioSource>().clip = winSound;

        GetComponent<AudioSource>().Play();

        StartCoroutine(RestartGame());
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(waitFor + 0.2f);

        wrapperR.sprite = wrapperSprites[0];
        baseR.sprite = baseSprites[0];
        frostingR.sprite = frostingSprites[0];

        tele.GenerateRandomCupcake();
    }
}