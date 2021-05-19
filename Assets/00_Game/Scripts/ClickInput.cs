using System;
using UnityEngine;

public class ClickInput : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float maxDist = 100;
    
    public event Action<Vector3> OnClickEvent;
    public event Action OnFailClickEvent;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0))
            return;

        Raycast();
    }

    private void Raycast()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hitInfo, maxDist, mask))
            OnClickEvent?.Invoke(hitInfo.point);
        else 
            OnFailClickEvent?.Invoke();
    }
}