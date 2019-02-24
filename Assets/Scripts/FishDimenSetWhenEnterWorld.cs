using UnityEngine;
using System.Collections;

public class FishDimenSetWhenEnterWorld : MonoBehaviour {

    public Swimmer mSwimmer;
	// Use this for initialization
	void Start () {
        mSwimmer = GetComponent<Swimmer>();
	}

    void Update()
    {
        if (mSwimmer.IsInWorld())//������������
        {
            mSwimmer.SetLiveDimension(Defines.ClearFishRadius);
            Destroy(this);
        }
    }
}