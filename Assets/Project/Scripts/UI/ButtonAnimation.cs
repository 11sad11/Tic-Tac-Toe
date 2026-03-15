using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator animator;
    private float progress = 0f;
    private bool isHovering = false;
    
    [SerializeField] private float animationSpeed = 1f;

    void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = 0f;
    }

    void Update()
    {
        if (isHovering)
            progress += Time.deltaTime * animationSpeed;
        else
            progress -= Time.deltaTime * animationSpeed;
        progress = Mathf.Clamp01(progress);
        animator.Play("ButtonHover", 0, progress);
    }

    public void OnPointerEnter(PointerEventData eventData) => isHovering = true;
    public void OnPointerExit(PointerEventData eventData) => isHovering = false;
}