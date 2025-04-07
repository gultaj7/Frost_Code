using UnityEngine;

public enum Wrapper   { None, Green, Blue, Pink, Purple }
public enum Base      { None, Vanilla, Strawberry, Choco }
public enum Frosting  { None, Normal, Strawberry, Choco }

public class CupcakeBuilder : MonoBehaviour
{
    [Header("Sprites  (index 0 = null)")]
    public Sprite[] wrapperSprites = new Sprite[5];
    public Sprite[] baseSprites    = new Sprite[4];
    public Sprite[] frostingSprites= new Sprite[4];

    [Header("Renderers")]
    public SpriteRenderer wrapperR;
    public SpriteRenderer baseR;
    public SpriteRenderer frostingR;

    [Header("Button Groups")]
    public GameObject baseButtonsGroup;
    public GameObject frostingButtonsGroup;

    private Wrapper  curWrap  = Wrapper.None;
    private Base     curBase  = Base.None;

    /* ---- public methods called by buttons ---- */
    public void SetWrapper(int id)
    {
        curWrap = (Wrapper)id;
        wrapperR.sprite = wrapperSprites[id];
        baseButtonsGroup.SetActive(id != 0);
    }

    public void SetBase(int id)
    {
        if (curWrap == Wrapper.None) return;
        curBase = (Base)id;
        baseR.sprite = baseSprites[id];
        frostingButtonsGroup.SetActive(id != 0);
    }

    public void SetFrosting(int id)
    {
        if (curBase == Base.None) return;
        frostingR.sprite = frostingSprites[id];
    }
}