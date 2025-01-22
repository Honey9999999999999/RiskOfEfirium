using System.Collections;
using System.Collections.Generic;
using MyTimer;
using UnityEngine;

public class DropAnimator : MonoBehaviour
{
    public Vector2 boxSize;
    public Vector3 targetPosition;
    public AnimationCurve curve;
    [Min(0)] public float timeAnimation;

    private Rect Box => new(targetPosition.x - boxSize.x / 2, targetPosition.z - boxSize.y / 2, boxSize.x, boxSize.y);
    private Matrix4x4 Rotation => transform.localToWorldMatrix;

    public void AnimateObject(MonoBehaviour obj)
    {
        AnimateObjectAsync(obj.transform);
    }
    private Coroutine AnimateObjectAsync(Transform transform)
    {
        return StartCoroutine(AnimationRoutine(transform));
    }
    private IEnumerator AnimationRoutine(Transform target)
    {
        Rect rect = Box;
        Vector3 startPos = target.position;
        Vector3 endPos = Rotation.MultiplyPoint(new Vector3(Random.Range(rect.min.x, rect.max.x), targetPosition.y, Random.Range(rect.min.y, rect.max.y)));

        float distance = Vector3.Distance(startPos, endPos);

        Timer animationTimer = new();
        animationTimer.Start(timeAnimation);

        Collider[] colliders = target.GetComponents<Collider>();
        TurnColliders(false);

        while (animationTimer.IsStarted)
        {
            float index = 1 - animationTimer.GetValue() / timeAnimation;
            Vector3 height = new(0, curve.Evaluate(index) * distance, 0);

            target.position = Vector3.Lerp(startPos + height, endPos + height, index);

            yield return null;
        }

        TurnColliders(true);

        void TurnColliders(bool enabled)
        {
            foreach (Collider collider in colliders)
            {
                collider.enabled = enabled;
            }
        }
    }

    #if UNITY_EDITOR

    private void OnDrawGizmosSelected()
    {
        DrawRect();
        DrawPoint();

        Rect rect = Box;
        Vector3 endPos = Rotation.MultiplyPoint(new Vector3(Random.Range(rect.min.x, rect.max.x), targetPosition.y, Random.Range(rect.min.y, rect.max.y)));

        Drawer.DrawDiamondPoint(endPos, 0.4f, Color.red, false);
    }

    private void DrawRect()
    {
        List<Vector3> boxPoints;
        Rect rect = Box;

        boxPoints = new()
        {
            Rotation.MultiplyPoint(new Vector3(rect.x, targetPosition.y, rect.y)),
            Rotation.MultiplyPoint(new Vector3(rect.x + rect.width, targetPosition.y, rect.y)),
            Rotation.MultiplyPoint(new Vector3(rect.x + rect.width, targetPosition.y, rect.y + rect.height)),
            Rotation.MultiplyPoint(new Vector3(rect.x, targetPosition.y, rect.y + rect.height))
        };     

        Drawer.DrawPolyhedralFigure(boxPoints, Vector3.zero, Color.yellow);
    }

    private void DrawPoint()
    {
        Vector3 targetPos = Rotation.MultiplyPoint(targetPosition);

        Drawer.DrawDiamondPoint(targetPos, 0.4f, Color.yellow, false);
        List<Vector3> vectors = new()
        {
            transform.position,
            targetPos
        };
        Drawer.DrawCurve(vectors, Vector3.zero, Color.yellow);
    }

    #endif

}