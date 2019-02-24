using UnityEngine;
using System.Collections;

public class Ef_WaterWave : MonoBehaviour {

    public Material[] Mtrl_Waterwaves;
    public float Fps = 10F;
    private Renderer mRenderer;
    private int mCurTexIdx = 0;
    private static int MtrlUnitTileX = 4;//一个场景材质的Tile

    void Start()
    {
        foreach (Material m in Mtrl_Waterwaves)
        {
            Vector2 texScale = m.mainTextureScale;
            texScale.x = MtrlUnitTileX * GameMain.Singleton.ScreenNumUsing;
            m.mainTextureScale = texScale;
        }

        Vector3 ls = transform.localScale;
        ls.x *= GameMain.Singleton.ScreenNumUsing;

        gameObject.isStatic = false;
        transform.localScale = ls;
        transform.position = new Vector3(0F, 0F, Defines.GlobleDepth_WaterWave);
        gameObject.isStatic = true;
        
        mRenderer = GetComponent<Renderer>();
    }
    
    void Update()
    {
        int texIdxNew = (int)(Time.time * Fps) % Mtrl_Waterwaves.Length;
        if (texIdxNew != mCurTexIdx)
        {
            mCurTexIdx = texIdxNew;
            mRenderer.material = Mtrl_Waterwaves[mCurTexIdx];
        }
        
    }
}
