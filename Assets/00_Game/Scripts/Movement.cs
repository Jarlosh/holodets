using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private ClickInput input;
    [SerializeField] private Transform controlled;
       
    private void Start()
    {
        input.OnClickEvent += OnClick;
        input.OnFailClickEvent += OnFailClick;
    }


    private void OnDestroy()
    {
        input.OnClickEvent -= OnClick;
        input.OnFailClickEvent -= OnFailClick;
    }


    private void OnFailClick()
    {
        agent.ResetPath();
    }

    private void OnClick(Vector3 target)
    {
        // var path = new NavMeshPath();
        // var pos = controlled.position;
        agent.SetDestination(target);
        print("hit");
        // NavMesh.CalculatePath(pos, target, path)
    }

    private void Update()
    {
        
    }
}
