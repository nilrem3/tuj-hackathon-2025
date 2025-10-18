using UnityEngine;

public class ObjectViewer : MonoBehaviour {
    
    [SerializeField] private Transform o_Axis;
    [SerializeField] private Transform o_Rotation;
    [SerializeField] private Transform o_Object;
    [SerializeField] private RenderTexture source;
    [SerializeField] private MeshFilter meshFilter;
    [SerializeField] private MeshRenderer meshRenderer;
    [SerializeField] private Material material;

    private float rotation_speed = 0.1f;
    private float rotation = 0f;
    private Texture2D[] textures = new Texture2D[10];
    private float[] brightness_values = new float[10];
    private int currentTexture = 0;
    private bool capturing = false;

    public bool Capturing {
        get { return this.capturing; }
    }

    void Start() {
        for (int i = 0; i < textures.Length; i++)
            textures[i] = new Texture2D(source.width, source.height);
        
        BeginCaptureSequence();
    }

    void Update() {
        o_Rotation.Rotate(0f, rotation_speed * Time.deltaTime * 360f, 0f);
        rotation += rotation_speed * Time.deltaTime * 360f;
        if (rotation >= 36f) {
            rotation -= 36f;
            if (capturing)
                captureImage();
        }

        if (!capturing) {
            Debug.Log("Begin Brightness Values");
            for (int i = 0; i < this.brightness_values.Length; i++) {
                Debug.Log(this.brightness_values[i]);
            }
        }
    }

    private void captureImage() {
        Graphics.CopyTexture(source, 0, 1, textures[currentTexture], 0, 1);
        brightness_values[currentTexture] = 
        currentTexture++;
        if (currentTexture >= textures.Length) {
            currentTexture = 0;
            capturing = false;
        }
    }

    private float get_average(Texture2D texture) {
        Color[] pixels = texture.GetPixels();
        float sum = 0f;
        foreach (Color pixel in pixels) {
            sum += pixel.r + pixel.g + pixel.b;
        }

        return sum / pixels.Length / 3f;
    }

    public void SetMesh(Mesh mesh) {
        meshFilter.mesh = mesh;
    }

    public void SetMaterial(Material material) {
        meshRenderer.material = material;
    }

    public void SetObjectScale(float scale) {
        o_Object.localScale = new Vector3(scale, scale, scale);
    }

    public void SetObjectDistance(float distance) {
        o_Axis.localPosition = new Vector3(0, 0, distance);
    }

    public void BeginCaptureSequence() {
        if (capturing) return;
        capturing = true;
        rotation = 0f;
    }

    public int[] GetValues() {
        float max = Mathf.Max(brightness_values);
        float min = Mathf.Min(brightness_values);
        
        int[] remapped_values = new int[brightness_values.Length];
        for (int i = 0; i < brightness_values.Length; i++)
            remapped_values[i] = (int)Mathf.Lerp(0f, 100f, Mathf.InverseLerp(min, max, brightness_values[i]));
        
        return remapped_values;
    }
}
