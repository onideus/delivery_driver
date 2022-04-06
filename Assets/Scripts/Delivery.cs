using UnityEngine;

// ReSharper disable InvertIf

public class Delivery : MonoBehaviour
{
    [SerializeField] private Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] private float destroyDelay = .5f;

    private bool _packageHeld = false;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Package") && !_packageHeld)
        {
            _packageHeld = true;
            _spriteRenderer.color = hasPackageColor;
            Debug.Log("Package has been picked up!");
            Destroy(col.gameObject, destroyDelay);
        }

        if (_packageHeld && col.CompareTag("Customer"))
        {
            _packageHeld = false;
            _spriteRenderer.color = noPackageColor;
            Debug.Log("Package has been delivered!");
        }
    }
}