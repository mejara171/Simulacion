using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trees : MonoBehaviour
{

    [SerializeField] private GameObject BranchPrefab;
    [SerializeField] public int MaxDepth = 3;

    private Queue<GameObject> frontier = new Queue<GameObject>();
    private Queue<GameObject> NewBranches = new Queue<GameObject>();

    private int CurrentDepth = 0;

    
    void Start()
    {
       GameObject root = Instantiate(BranchPrefab, transform);
        root.name = "Branch [root]";
        frontier.Enqueue(root);
        GenerateTree();
    }


    

    private void GenerateTree()
    {
        if (CurrentDepth >= MaxDepth)
        {
            return;
        }

        CurrentDepth++;

        while (frontier.Count > 0)
        {
            var PrevRoot = frontier.Dequeue();

            var LeftBranch = CreateBranch(PrevRoot, Random.Range(10f, 40));
            var RightBranch = CreateBranch(PrevRoot, -Random.Range(10f, 40));

            NewBranches.Enqueue(LeftBranch);
            NewBranches.Enqueue(RightBranch);

        }

        int Branches = NewBranches.Count;
        for (int i = 0; i < Branches; i++)
        {
            frontier.Enqueue(NewBranches.Dequeue());
        }
        

        GenerateTree();

    }

    private GameObject CreateBranch(GameObject PrevBranch, float OffSetAngle)
    {
        GameObject Branch = Instantiate(BranchPrefab, transform);

        Branch.transform.position = PrevBranch.transform.position + PrevBranch.transform.up;
        Quaternion Rotation = PrevBranch.transform.rotation;

        Branch.transform.rotation = Rotation * Quaternion.Euler(0f, 0f, OffSetAngle);

        return Branch;
            
    }


}
