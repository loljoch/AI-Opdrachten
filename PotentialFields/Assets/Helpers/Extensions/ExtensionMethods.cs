using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    /// <summary>
    /// Lerps rectTransform to target position
    /// </summary>
    /// <param name="rectTransform">Rect transform of the object</param>
    /// <param name="targetPosition">End position of the Lerp</param>
    /// <param name="time">Time in seconds</param>
    /// <param name="owner">Class to run the lerp on</param>
    public static RectTransform LerpRectTransform(this RectTransform rectTransform, Vector3 targetPosition, float time, MonoBehaviour owner)
    {
        return ActivateCoroutineLerpRectTransformPositions(rectTransform, owner, targetPosition, time);
    }

    /// <summary>
    /// Lerps world space position to targeted position within speed (seconds)
    /// </summary>
    /// <param name="currentTransform">Transform with the starting position</param>
    /// <param name="targetPosition">End position of the lerp</param>
    /// <param name="time">Time in seconds</param>
    /// <param name="owner">Class to run the lerp on</param>
    /// <returns></returns>
    public static Transform LerpPosition(this Transform currentTransform, Vector3 targetPosition, float time, MonoBehaviour owner)
    {
        return ActivateCoroutineLerpTransformPositions(currentTransform, owner, targetPosition, time);
    }

    public static List<T> ToList<T>(this T[] array) where T : class
    {
        List<T> output = new List<T>();
        output.AddRange(array);
        return output;
    }

    public static bool HasComponent<T>(this Component obj)
    {
        return obj.GetComponent(typeof(T)) != null;
    }

    public static bool HasComponent<T>(this GameObject obj)
    {
        return obj.GetComponent(typeof(T)) != null;
    }

    public static Vector3 GetDirectionTo(this Vector3 from, Vector3 lookAt)
    {
        return lookAt - from;
    }

    static RectTransform ActivateCoroutineLerpRectTransformPositions(RectTransform rectTransform, MonoBehaviour owner, Vector3 targetPosition, float speed)
    {
        if (rectTransform == null) return null;

        if (owner != null)
        { 
            owner.StartCoroutine(ExtensionHelpers.LerpRectTransformPositions(rectTransform, targetPosition, speed));
            return rectTransform;
        }
        else
        {
            Debug.Log("Our Owner is null");
            return null;
        }
    }

    static Transform ActivateCoroutineLerpTransformPositions(Transform currentTransform, MonoBehaviour owner, Vector3 targetPosition, float speed)
    {
        if (currentTransform == null) return null;

        if (owner != null)
        {
            owner.StartCoroutine(ExtensionHelpers.LerpTransformPositions(currentTransform, targetPosition, speed));
            return currentTransform;
        }
        else
        {
            Debug.Log("Our Owner is null");
            return null;
        }
    }
}




