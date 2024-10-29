using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    public Transform shakeHandle;
    public float shakeStrength;
    Coroutine shakeRoutine;

    public Rigidbody rb;

    public float appleFallDuration;
    public float appleTellDuration;

    public Renderer myRenderer;
    public Material flashMaterial;

    bool isClickable = false;
    bool canFall = true;

    public float launchPower = 1f;

    public Material failMaterial;

    void Start()
    {
        rb.isKinematic = true;

        //StartCoroutine(CoroutineFall());
    }

    public void Fall()
    {
        if (canFall)
        {
            StartCoroutine(CoroutineFall());
        }
    }

    IEnumerator CoroutineFall()
    {
        //float timeUntilFall = Random.Range(0, appleFallDuration);
        //timeUntilFall -= appleTellDuration;

        //Debug.Log(timeUntilFall);

        //// This will LITERALLY pause the code for this amount of time
        //yield return new WaitForSeconds(timeUntilFall);


        // Warn players somethign it about to happen
        Material currentMaterial = myRenderer.material;

        // Switch to the flashing material
        myRenderer.material = flashMaterial;
        isClickable = true;

        if (shakeRoutine == null)
        {
            shakeRoutine = StartCoroutine(ExecuteShake());
        }

        // Wiat x seconds
        yield return new WaitForSeconds(appleTellDuration);

        // Then go back to the original
        myRenderer.material = currentMaterial;
        isClickable = false;

        StopShake();

        // Finally FALL
        rb.isKinematic = false;
    }

    public void Click()
    {
        StopAllCoroutines();

        canFall = false;
        if (isClickable)
        {
            isClickable = false;
            StartCoroutine(ExecuteLaunch());
        }
        else
        {
            StartCoroutine(ExecuteFail());
        }
    }

    IEnumerator ExecuteLaunch()
    {
        AppleTree tree = FindObjectOfType<AppleTree>();
        if (tree != null)
        {
            tree.OnAppleCollected();
        }


        rb.isKinematic = false;
        rb.AddForce(transform.forward * launchPower, ForceMode.Impulse);

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }

    IEnumerator ExecuteFail()
    {
        myRenderer.material = failMaterial;

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }

    IEnumerator ExecuteShake()
    {
        while (true)
        {
            yield return new WaitForSeconds(1 / 15f);

            shakeHandle.localPosition = new Vector3(
                Random.Range(-shakeStrength, shakeStrength),
                Random.Range(-shakeStrength, shakeStrength),
                Random.Range(-shakeStrength, shakeStrength)
            );
        }
    }

    void StopShake()
    {
        if (shakeRoutine != null)
        {
            StopCoroutine(shakeRoutine);
            shakeHandle.localPosition = Vector3.zero;
        }
    }
}
