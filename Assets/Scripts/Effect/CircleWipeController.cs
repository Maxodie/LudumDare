using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Place this script on the Main Camera in the scene. This script controls the circle wipe
/// shader that is placed over the entire screen.
/// 
/// See the example scripts in this package for example on how to use it.
/// </summary>
public class CircleWipeController : MonoBehaviour
{
    public static CircleWipeController instance;

    [SerializeField] Material material;

    [Range(0, 1f)]
    [SerializeField] float radius = 0f;

    [SerializeField] Vector2 offset;
    [SerializeField] float duration;

    void Awake()
    {
        if(!instance) instance = this;
        else Destroy(gameObject);

        UpdateShader();
    }

    public void FadeOut(Action callback = null)
    {
        StartCoroutine(DoFade(1f, 0f, callback));
    }

    public void FadeIn(Action callback = null)
    {
        StartCoroutine(DoFade(0, 1f, callback));
    }

    IEnumerator DoFade(float start, float end, Action callback = null)
    {
        radius = start;
        UpdateShader();

        var time = 0f;
        while (time < 1f)
        {
            radius = Mathf.Lerp(start, end, time);
            time += Time.deltaTime / duration;
            UpdateShader();
            yield return null;
        }

        radius = end;
        UpdateShader();
        callback?.Invoke();
    }

    public void UpdateShader()
    {
        material.SetFloat("_Progress", radius);
        material.SetVector("_Offset", offset);
    }
}
