using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using Facebook.Unity;

public class FacebookController : MonoBehaviour
{
    private static Level level;
    private static Text thankForShareText;
    // Awake function from Unity's MonoBehavior
    void Awake()
    {
        if (!FB.IsInitialized)
        {
            // Initialize the Facebook SDK
            FB.Init(InitCallback, OnHideUnity);
        }
        else
        {
            // Already initialized, signal an app activation App Event
            FB.ActivateApp();
        }
        level = new Level();
        thankForShareText = GameObject.Find("Thank").GetComponent<Text>();
    }

    private void InitCallback()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
        }
        else
        {
            // Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    private static void Login()
    {
        var perms = new List<string>() { "publish_actions" };
        FB.LogInWithPublishPermissions(perms, AuthCallback);
    }

    private static void AuthCallback(ILoginResult result)
    {
        if (FB.IsLoggedIn)
        {
            // AccessToken class will have session details
            var aToken = AccessToken.CurrentAccessToken;
            // Print current access token's User ID
            Debug.Log(aToken.UserId);
            // Print current access token's granted permissions
            foreach (string perm in aToken.Permissions)
            {
                Debug.Log(perm);
            }
            Share();
        }
        else
        {
            //Debug.Log("User cancelled login");
        }
    }

    public static void InitShare(Level currentLevel)
    {
        level = currentLevel;
        Share();
    }

    public static void Share()
    {
        FB.FeedShare(
         link: new System.Uri("http://play.google.com/store/apps/details?id=com.ctsoft.kanashooter"),
         linkName: "I had reached level " + level.GetIndex() + " on Kana Shooter",
         linkCaption: "I had learned some new Japanese character",
         linkDescription: "Wanna learn with me and try to beat me? Kana Shooter is the easy and funniest way to learn Japanese alphabet",
         picture: new System.Uri("http://noithatdream.com/kanashooter.png"),
         callback: ShareCallback
       );
    }

    private static void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
           // Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            DisplayThankForShareMessage();
            Debug.Log(result.PostId);
        }
        else
        {
            DisplayThankForShareMessage();
        }
    }

    private static void DisplayThankForShareMessage()
    {
        thankForShareText.text = "Thank you for sharing me!!!";
    }

    private void OnHideUnity(bool isGameShown)
    {
        Debug.Log(isGameShown);
        //if (!isGameShown)
        //{
        //    // Pause the game - we will need to hide
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    // Resume the game - we're getting focus again
        //    Time.timeScale = 1;
        //}
    }
}
