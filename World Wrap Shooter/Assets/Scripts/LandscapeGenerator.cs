using UnityEngine;

public class LandscapeGenerator : MonoBehaviour
{
    public int _width = 1280;
    public int _height = 180;
    public int _baseLandscapeY = 15;
    public float _pixelsPerUnit = 320;
    public float _multiplier = 20f;

    private SpriteRenderer _renderer;

    void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }


    void Start()
    {
        Texture2D tex = new Texture2D(_width, _height, TextureFormat.RGB565, false, false);
        ClearTex(tex);

        for (var x = 0; x < _width; x++)
        {
            // Colour of land - 204, 102, 51
            // See: https://docs.unity3d.com/ScriptReference/Mathf.PerlinNoise.html for details
            var perlin = Mathf.PerlinNoise((x * 1f) / _width, 0) * _multiplier;
            tex.SetPixel(x, _baseLandscapeY + (int)perlin, new Color(204 / 255f, 102 / 255f, 51 / 255f));
        }

        tex.Apply();
        _renderer.sprite = Sprite.Create(tex, new Rect(0, 0, _width, _height), new Vector2(0.5f, 0.5f), _pixelsPerUnit);
    }

    private void ClearTex(Texture2D tex)
    {
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                tex.SetPixel(x, y, Color.black);
            }
        }
    }

}
