using UnityEngine;
using System.Collections;
// Include Facebook namespace
using Facebook.Unity;

public class FBUtil
{

    public static void init()
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
    }

    private static void InitCallback()
    {
        if (FB.IsInitialized)
        {
            // Signal an app activation App Event
            FB.ActivateApp();
            // Continue with Facebook SDK
            // ...
        }
        else
        {
            Debug.Log("Failed to Initialize the Facebook SDK");
        }
    }

    public static void Share(Level level)
    {
        FB.FeedShare(
          link: new System.Uri("https://example.com/myapp/?storyID=thelarch"),
          linkName: "Reached level " + level.GetIndex() + " on Kana Shooter",
          linkCaption: "I had learned some japanese character",
          linkDescription: "Wanna learn with me and try to beat me?",
          picture: new System.Uri("https://example.com/myapp/assets/1/larch.jpg"),
          callback: ShareCallback
        );
    }

    private static void ShareCallback(IShareResult result)
    {
        if (result.Cancelled || !string.IsNullOrEmpty(result.Error))
        {
            Debug.Log("ShareLink Error: " + result.Error);
        }
        else if (!string.IsNullOrEmpty(result.PostId))
        {
            // Print post identifier of the shared content
            Debug.Log(result.PostId);
        }
        else
        {
            // Share succeeded without postID
            Debug.Log("ShareLink success!");
        }
    }

    private static void OnHideUnity(bool isGameShown)
    {
        if (!isGameShown)
        {
            // Pause the game - we will need to hide
            Time.timeScale = 0;
        }
        else
        {
            // Resume the game - we're getting focus again
            Time.timeScale = 1;
        }
    }
}
