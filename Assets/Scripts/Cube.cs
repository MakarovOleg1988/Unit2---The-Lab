using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer _renderer;

    public Material _newMaterial;
    private Material _startMaterial;

    [SerializeField]
    private float _startTimer;

    [SerializeField]
    private float _currentTimer;
    
    private void Start()
    {
        _currentTimer = _startTimer;

        var posX = Random.Range(0f, 5f);
        transform.position = new Vector3(posX, 4, 1);
        transform.localScale = Vector3.one * 1.3f;

        _startMaterial = _renderer.material;
        Material material = _startMaterial;
        
        material.color = new Color(0.5f, 1.0f, 0.3f, 0.4f);
    }
    
    private void Update()
    {
        transform.Rotate(10.0f * Time.deltaTime, 0.0f, 0.0f);

        ChangeColor();

    }

    private void ChangeColor()
    {
        if (_currentTimer >= 0)
        {
            _currentTimer -= Time.deltaTime;
        }
        
        if (_currentTimer <= _startTimer / 2)
        {
            _renderer.material = _newMaterial;
        }
        
        if (_currentTimer <= 0)
        {
            _currentTimer = _startTimer;
            _renderer.material = _startMaterial;
        }

    }
}
