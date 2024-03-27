using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public bool IsActiveCheckpoint;
    public Material mat1;
    public Material mat2;
    public List<Material> MList1;
    public List<Material> MList2;
    void Start()
    {
        IsActiveCheckpoint = false;
        MList1.Add(mat1);
        MList2.Add(mat2);
    }

    void Update()
    {
        if(IsActiveCheckpoint)
        {
            this.GetComponent<MeshRenderer>().SetMaterials(MList1);
        }
        if(!IsActiveCheckpoint)
        {
            this.GetComponent<MeshRenderer>().SetMaterials(MList2);
        } 
    }
}
