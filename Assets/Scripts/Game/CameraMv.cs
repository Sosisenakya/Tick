using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraMv : MonoBehaviour
{
    public Transform target;
    public Player plrScript;

    void LateUpdate()
    {
        if (target != null && plrScript.isPlayerAlive == true)
        {
            transform.position = new Vector3(target.position.x, target.position.y, -10);
        }
    }
    public void CameraDeath() {
        StartCoroutine(RotateCamera());
        ShakeCamera(0.4f, 0.6f);
    }
    void ShakeCamera(float duration, float strength)
    {
        Camera.main.transform.DOShakePosition(duration, strength)
            .SetEase(Ease.OutQuad);
    }
    private IEnumerator RotateCamera()
    {
        transform.rotation = Quaternion.Euler(0, 0, 25);
        yield return new WaitForSeconds(0.05f);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
