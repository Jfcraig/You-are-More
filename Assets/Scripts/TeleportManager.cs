using System.Collections;
using System.Collections.Generic;
using Liminal.Core.Fader;
using Liminal.Platform.Experimental.App.Experiences;
using Liminal.SDK.Core;
using Liminal.SDK.VR;
using Liminal.SDK.VR.Avatars;
using Liminal.SDK.VR.Input;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public GameObject teleportTo;
    public GameObject player;
    public float speed = 1.0f;
    public bool teleportWalkToggle = false;

    private void Update()
    {
        var avatar = VRAvatar.Active;
        if (avatar == null)
            return;

        var rightInput = GetInput(VRInputDeviceHand.Right);
        var leftInput = GetInput(VRInputDeviceHand.Left);

        // Input Examples
        if (rightInput != null)
        {
            if (rightInput.GetButtonDown(VRButton.Back))
                Debug.Log("Back button pressed");

            if (rightInput.GetButtonDown(VRButton.One))
                Debug.Log("Trigger button pressed");
        }

        if (leftInput != null)
        {
            if (leftInput.GetButtonDown(VRButton.Back))
                Debug.Log("Back button pressed");

            if (leftInput.GetButtonDown(VRButton.One))
                Debug.Log("Trigger button pressed");
        }

        // Any input
        // VRDevice.Device.GetButtonDown(VRButton.One);
    }

    private IVRInputDevice GetInput(VRInputDeviceHand hand)
    {
        var device = VRDevice.Device;
        return hand == VRInputDeviceHand.Left ? device.SecondaryInputDevice : device.PrimaryInputDevice;
    }

    /// <summary>
    /// End will only close the application when you're within the platform
    /// </summary>
    public void End()
    {
        ExperienceApp.End();
    }

    //public void FadeToBlack()
    //{
    //    StartCoroutine(FadeToBlackRoutine());
    //}

    //private IEnumerator FadeToBlackRoutine()
    //{
    //    ScreenFader.Instance.FadeTo(Color.black, duration: 1);
    //    yield return ScreenFader.Instance.WaitUntilFadeComplete();
    //    ScreenFader.Instance.FadeToClear(duration: 1);
    //}

    //public void ChangeCubeSize()
    //{
    //    Cube.localScale = Vector3.one * Random.Range(0.1f, 0.35F);
    //}

    //private RaycastHit lastRaycastHit;
    public AudioClip audioClip;
    public float range = 1000;

    //private GameObject GetLookedAtObject()
    //{
    //    Vector3 origin = transform.position;
    //    Vector3 direction = Camera.main.transform.forward;
    //    if (Physics.Raycast(origin, direction, out lastRaycastHit, range))
    //    {
    //        return lastRaycastHit.collider.gameObject;
    //    }
    //    else
    //    {
    //        return null;
    //    }
    //}

    public void TeleportToLookAt()
    {
        if (teleportWalkToggle == true)
        {
            Vector3 hitNorm = teleportTo.GetComponent<Interactable>().hitPointNorm;
            Vector3 hitPos = teleportTo.GetComponent<Interactable>().hitPoint;
            player.transform.position = hitPos + hitNorm * 1.5f;
            if (audioClip != null)
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
        else
        {
          // Move our position a step closer to the target.
            Vector3 hitNorm = teleportTo.GetComponent<Interactable>().hitPointNorm;
            Vector3 hitPos = teleportTo.GetComponent<Interactable>().hitPoint;
            Vector3 target = hitPos;
            float step = speed * Time.deltaTime; // calculate distance to move
            player.transform.position = Vector3.MoveTowards(transform.position, target, step);
            if (audioClip != null)
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }


    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))
    //        if (GetLookedAtObject() != null)
    //            TeleportToLookAt();
    //}
}