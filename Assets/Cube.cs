using UnityEngine;
using Discord;
using System;

public class Cube : MonoBehaviour
{
    public int jumpAmount = 0;

    Discord.Discord discord;
    Discord.ActivityManager activityManager;

    private void Start()
    {
        discord = new Discord.Discord(834754357056634880, (UInt64)Discord.CreateFlags.Default);
        activityManager = discord.GetActivityManager();
        UpdatePresence();
    }

    void Update()
    {
        discord.RunCallbacks();
        if (Input.GetKeyDown(KeyCode.E))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 250f);
            jumpAmount++;
            UpdatePresence();
        }
    }

    void UpdatePresence()
    {
        activityManager.UpdateActivity(new Discord.Activity {
            Details = "Küp zıplatılıyor...",
            State = jumpAmount.ToString() + " defa zıplatıldı.",
            Assets = {
                LargeImage = "potato",
                LargeText = "Potato uwu :>"
            }
        }, (res) => { });
    }
}
