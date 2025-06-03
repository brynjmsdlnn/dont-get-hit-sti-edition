using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 gameplayPosition = new Vector3(0, 11, -60);
    private Quaternion gameplayRotation = Quaternion.Euler(15, 0, 0);
    private Vector3 previewPosition = new Vector3(36, 10, 102);
    private Quaternion previewRotation = Quaternion.Euler(10, 0, 0);

    public void SetGameplayState()
    {
        transform.position = gameplayPosition;
        transform.rotation = gameplayRotation;
    }

    public void SetPreviewState()
    {
        transform.position = previewPosition;
        transform.rotation = previewRotation;
    }
}
