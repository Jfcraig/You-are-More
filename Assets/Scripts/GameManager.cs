using System.Collections;
using System.Collections.Generic;
using Liminal.Core.Fader;
using Liminal.Platform.Experimental.App.Experiences;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ScreenFader.Instance.FadeToClearFromBlack(duration: 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End()
    {
        StartCoroutine(EndRoutine());
    }

    public void FadeToBlack()
    {
        StartCoroutine(FadeToBlackRoutine());
    }

    private IEnumerator FadeToBlackRoutine()
    {
        ScreenFader.Instance.FadeTo(Color.black, duration: 1);
        yield return ScreenFader.Instance.WaitUntilFadeComplete();
        ScreenFader.Instance.FadeToClear(duration: 1);
    }

    private IEnumerator EndRoutine()
    {
        ScreenFader.Instance.FadeTo(Color.black, duration: 2);
        AudioManager.Instance.FadeOut();
        yield return ScreenFader.Instance.WaitUntilFadeComplete();
        ExperienceApp.End();
    }
}
