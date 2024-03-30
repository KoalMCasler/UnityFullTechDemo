using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStartColor : MonoBehaviour
{
    public Material matOption1;
    public Material matOption2;
    public Material matOption3;
    public Material matOption4;
    // Start is called before the first frame update
    void Awake()
    {
        this.GetComponent<MeshRenderer>().SetMaterials(RandomColor());
    }
    List<Material> RandomColor()
    {
        int colorRoll = Random.Range(1,5);
        List<Material> matList = new List<Material>();
        if(colorRoll == 1)
        {
            matList.Clear();
            matList.Add(matOption1);
        }
        if(colorRoll == 2)
        {
            matList.Clear();
            matList.Add(matOption2);
        }
        if(colorRoll == 3)
        {
            matList.Clear();
            matList.Add(matOption3);
        }
        if(colorRoll == 4)
        {
            matList.Clear();
            matList.Add(matOption4);
        }
        return matList;
    }
}
