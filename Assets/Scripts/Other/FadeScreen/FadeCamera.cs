using UnityEngine;
using System.Collections;

public class FadeCamera : MonoBehaviour
{
    #region Singleton
    public static FadeCamera instance;

    void Awake()
    {
        instance = this;
    }
    #endregion

    [Range (0f, 1f)]
	public float opacity = 0;
	public Color color = Color.black;

	public Material material;
	private float startTime = 0;
	private float startOpacity = 1;
	private int endOpacity = 1;
	private float duration = 0;
	private bool isFading = false;

    void Start()
    {
        material = new Material(Shader.Find("Hidden/FadeCameraShader"));
    }

	public void FadeIn (float duration = 3)
	{
		this.duration = duration;
		this.startTime = Time.time;
		this.startOpacity = opacity;
		this.endOpacity = 1;
		this.isFading = true;
	}

    public void FadeOut(float duration = 3)
    {
        this.duration = duration;
        this.startTime = Time.time;
        this.startOpacity = opacity;
        this.endOpacity = 0;
        this.isFading = true;
    }

	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if (isFading && duration > 0) {
			opacity = Mathf.Lerp (startOpacity, endOpacity, (Time.time - startTime) / duration);
			isFading = opacity != endOpacity;
		}

		if (opacity == 1f) {
			Graphics.Blit (source, destination);
			return;
		}

		material.color = color;
		material.SetFloat ("_opacity", opacity);
		Graphics.Blit (source, destination, material);
	}
}
