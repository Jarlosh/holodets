using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private ClickInput input;
    [SerializeField] private Renderer renderer;
    private bool isVisible = false;

    private void Start()
    {
        input.OnClickEvent += OnClick;
        input.OnFailClickEvent += OnFailClick;
    }

    private void OnDestroy()
    {
        input.OnClickEvent -= OnClick;
        input.OnFailClickEvent += OnFailClick;
    }
    
    private void OnFailClick()
    {
        SetVisible(false);
    }
    
    void OnClick(Vector3 position)
    {
        if (!isVisible)
            SetVisible(true);
        transform.position = position;
    }

    private void SetVisible(bool state)
    {
        renderer.enabled = state;
    }
}