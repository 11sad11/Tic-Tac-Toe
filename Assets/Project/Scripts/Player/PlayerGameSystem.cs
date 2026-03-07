using UnityEngine;
using UnityEngine.UI;

public class PlayerGameSystem : Singleton <PlayerGameSystem>
{
    public GameObject prefab = null;
    public GameObject parent = null;
    public RectTransform[] buttons = null;
    public Sprite sprite1 = null;
    public Sprite sprite2 = null;

    private Sprite _sprite;


    void Start()
    {
        if (sprite1 == null && sprite2 == null) return;

        _sprite = sprite1;
    }

    public void OnClick(int indexButton)
    {
        if (buttons[indexButton] == null) return;

        //Create
        GameObject gameObject = Instantiate(prefab);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        gameObject.transform.SetParent(parent.transform, false);

        //Set position
        rectTransform.anchoredPosition = buttons[indexButton].anchoredPosition;
        Destroy(buttons[indexButton].gameObject);

        //Set sptite 
        Image image = gameObject.GetComponent<Image>();
        image.sprite = _sprite;
        Switch();
    }

    private void Switch()
    {
        _sprite = _sprite == sprite1 ? sprite2 : sprite1;
    }
}