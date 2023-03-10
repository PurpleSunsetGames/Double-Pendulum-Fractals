using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainShad : MonoBehaviour
{
    public ComputeShader computeShader;
    public Image image;
    public Sprite sprite;

    public Texture2D texture2d;
    public RenderTexture renderTexture;
    public int rendertextureresolution;

    public Vector2 startvel;
    public Vector2 lengs;
    public Vector2 masses;
    public float g = 1;
    public float friction;
    public float time;
    public float timestep = 0.06f;

    public int xAxisType;
    public int yAxisType;

    public GameObject xOption;
    public GameObject yOption;
    public GameObject timeSlider;
    public GameObject resSlider;
    public int unload;
    public int unloadwhen;
    Rect rec;

    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        renderTexture = new RenderTexture(rendertextureresolution, rendertextureresolution, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        computeShader.SetTexture(0, "Result", renderTexture);
        computeShader.Dispatch(0, renderTexture.width/8, renderTexture.height/8, 1);
    }

    void Update()
    {
        if (unload > unloadwhen)
        {
            Resources.UnloadUnusedAssets();
            Destroy(renderTexture);
            unload = 0;
        }
        unload++;

        xAxisType = xOption.GetComponent<TMP_Dropdown>().value;
        yAxisType = yOption.GetComponent<TMP_Dropdown>().value;
        time = timeSlider.GetComponent<Slider>().value;
        rendertextureresolution = (int)resSlider.GetComponent<Slider>().value;
        renderTexture = new RenderTexture(rendertextureresolution, rendertextureresolution, 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        computeShader.SetFloat("Time", time);
        computeShader.SetFloat("Timestep", timestep);

        computeShader.SetTexture(0, "Result", renderTexture);

        computeShader.SetFloat("Resolutionx", renderTexture.width);
        computeShader.SetFloat("Resolutiony", renderTexture.height);

        computeShader.SetFloat("StartVel1", startvel[0]);
        computeShader.SetFloat("StartVel2", startvel[1]);
        computeShader.SetFloat("Leng1", lengs[0]);
        computeShader.SetFloat("Leng2", lengs[1]);
        computeShader.SetFloat("Mass1", masses[0]);
        computeShader.SetFloat("Mass2", masses[1]);
        computeShader.SetFloat("g", g);
        computeShader.SetFloat("Friction", friction);

        computeShader.SetInt("XAxisType", xAxisType);
        computeShader.SetInt("YAxisType", yAxisType);
        computeShader.Dispatch(0, renderTexture.width/8, renderTexture.height/8, 1);

        texture2d = toTexture2D(renderTexture);
        rec = new Rect(0, 0, renderTexture.width, renderTexture.height);
        sprite = Sprite.Create(texture2d, rec, new Vector2(0, 0), 10f, 1);
        image.sprite = sprite;
    }
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rendertextureresolution, rendertextureresolution, TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
