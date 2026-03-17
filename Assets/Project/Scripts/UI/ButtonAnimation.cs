using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoverAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Animator _animator;
    private float _progress = 0f;
    private bool _isHovering = false;
    
    [SerializeField] private float _animationSpeed = 1f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _animator.speed = 0f;
    }

    void Update()
    {
        if (_isHovering)
            _progress += Time.deltaTime * _animationSpeed;
        else
            _progress -= Time.deltaTime * _animationSpeed;
        _progress = Mathf.Clamp01(_progress);
        _animator.Play("ButtonHover", 0, _progress);
    }

    public void OnPointerEnter(PointerEventData eventData) => _isHovering = true;
    public void OnPointerExit(PointerEventData eventData) => _isHovering = false;
}