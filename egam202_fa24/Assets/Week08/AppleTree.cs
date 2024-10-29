using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;
using UnityEngine.SceneManagement;

public class AppleTree : MonoBehaviour
{
    public float durationBetweenFallsMinimum = 1f;
    public float durationBetweenFallsMaximum = 2f;

    public CinemachineVirtualCamera camWin;
    public CinemachineVirtualCamera camLose;

    public TextMeshProUGUI textStatus;

    int counter = 0;

    public AppleClicker clicker = null;

    void Start()
    {
        // Find the click logic and turn it off
        clicker = FindObjectOfType<AppleClicker>();
        clicker.enabled = false;

        StartCoroutine(ExecuteGamePlay());
    }

    public void OnAppleCollected()
    {
        counter++;
    }

    IEnumerator ExecuteGamePlay()
    {
        // Wait for the intro to finsih
        yield return StartCoroutine(ExecuteWaitForIntro());

        // Countdown
        yield return StartCoroutine(ExecuteCountdown());

        // Fall gameplay
        yield return StartCoroutine(ExecuteFallSequence());

        // Conclusion
        if (counter >= 2)
        {
            yield return StartCoroutine(ExecuteWin());
        }
        else
        {
            yield return StartCoroutine(ExecuteLose());
        }

        // Restart screen
        yield return StartCoroutine(ExecuteRestart());
    }

    IEnumerator ExecuteWaitForIntro()
    {
        textStatus.text = "Click to start";

        // Wait until we get a mouse click
        while (Input.GetMouseButtonDown(0) == false)
        {
            // Waits a single frame
            yield return null;
        }
    }

    IEnumerator ExecuteCountdown()
    {
        textStatus.text = "3";
        yield return new WaitForSeconds(1f);

        textStatus.text = "2";
        yield return new WaitForSeconds(1f);

        textStatus.text = "1";
        yield return new WaitForSeconds(1f);

        textStatus.text = "GO!!";
        yield return new WaitForSeconds(1f);

        textStatus.text = string.Empty;
    }

    IEnumerator ExecuteFallSequence()
    {
        clicker.enabled = true;

        AppleScript[] allApples = GetComponentsInChildren<AppleScript>();

        foreach (AppleScript apple in allApples)
        {
            float waitTime = Random.Range(durationBetweenFallsMinimum, durationBetweenFallsMaximum);
            yield return new WaitForSeconds(waitTime);

            // Make sure the apple is still around (may have self destructed)
            if (apple != null)
            {
                apple.Fall();
            }
        }

        clicker.enabled = false;
    }

    IEnumerator ExecuteWin()
    {
        camWin.Priority = 1000;
        textStatus.text = "You won!";

        yield return new WaitForSeconds(2f);
    }

    IEnumerator ExecuteLose()
    {
        camLose.Priority = 1000;
        textStatus.text = "You lose...";

        yield return new WaitForSeconds(2f);
    }

    IEnumerator ExecuteRestart()
    {
        textStatus.text = "Click to restart";

        // Wait until we get a mouse click
        while (Input.GetMouseButtonDown(0) == false)
        {
            // Waits a single frame
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
