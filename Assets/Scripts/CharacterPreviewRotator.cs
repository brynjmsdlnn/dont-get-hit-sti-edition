using UnityEngine;

public class CharacterPreviewRotator : MonoBehaviour
{
    [SerializeField] private float baseSpeed = 20f;
    [SerializeField] private float hoverSpeed = 40f;
    [SerializeField] private float acceleration = 5f; // How fast speed changes
    private float currentSpeed;
    private float targetSpeed;

    void Start()
    {
        currentSpeed = baseSpeed;
        targetSpeed = baseSpeed;
    }

    void Update()
    {
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * acceleration);
        transform.Rotate(Vector3.up * currentSpeed * Time.deltaTime);
    }

    public void OnHoverEnter()
    {
        targetSpeed = hoverSpeed;
    }

    public void OnHoverExit()
    {
        targetSpeed = baseSpeed;
    }
}
