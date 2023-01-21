using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainShad : MonoBehaviour
{
    public ComputeShader computeShader;
    public Image image;
    public Sprite sprite;

    public Texture2D texture2d;
    public RenderTexture renderTexture;
    public int[] rendertextureresolution;

    public Vector2 startvel;
    public Vector2 lengs;
    public Vector2 masses;
    public float g = 1;
    public float friction;

    public float timestep = 0.06f;
    // Start is called before the first frame update
    void Start()
    {
        image = gameObject.GetComponent<Image>();
        renderTexture = new RenderTexture(rendertextureresolution[0], rendertextureresolution[1], 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        computeShader.SetTexture(0, "Result", renderTexture);
        computeShader.Dispatch(0, renderTexture.width/8, renderTexture.height/8, 1);
    }

    void Update()
    {

        renderTexture = new RenderTexture(rendertextureresolution[0], rendertextureresolution[1], 24);
        renderTexture.enableRandomWrite = true;
        renderTexture.Create();

        computeShader.SetFloat("Time", Input.mousePosition.x);
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

        computeShader.Dispatch(0, renderTexture.width/8, renderTexture.height/8, 1);

        texture2d = toTexture2D(renderTexture);
        sprite = Sprite.Create(texture2d, new Rect(0, 0, renderTexture.width, renderTexture.height), new Vector2(0, 0), 10f, 1);
        image.sprite = sprite;
    }
    public void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (renderTexture == null)
        {
            renderTexture = new RenderTexture(256, 256, 24);
            renderTexture.enableRandomWrite = true;
            renderTexture.Create();
        }

        computeShader.SetTexture(0, "Result", renderTexture);
        computeShader.SetFloat("Resolution", Input.mousePosition.x);
        computeShader.Dispatch(0, renderTexture.width / 8, renderTexture.height / 8, 1);

        Graphics.Blit(renderTexture, dest);
    }
    Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rendertextureresolution[0], rendertextureresolution[1], TextureFormat.RGB24, false);
        // ReadPixels looks at the active RenderTexture.
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }
}
