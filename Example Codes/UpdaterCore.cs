using UnityEngine;
using System.Collections;

/* 
 * This script basicly check for new updates.
 * Read the latest version of the game on a web page that includes just version number like 2016.9.1
 * And then, read a local file for the installed version name like 2016.8.15
 * And then, compare the strings. If they are equal, do nothing, game starts.
 * If they are not equal, download the new folders from server.
 * 
 * This script is worked every time once the player open the game.
 */
public class UpdaterCore : MonoBehaviour {

    public string localFileName = "localFile";
    
    public string url = "http://www.extreme.com";

    IEnumerator Start () {
        // Read the newest version of the game
        WWW www = new WWW(url);
        yield return www;
        

        // Take current version installed on this device
        TextAsset localFile = (TextAsset)Resources.Load(localFileName);

        // Update if not our game has newer version
        if (www.text != "")
        {
            if (www.text == localFile.text)
            {
                // Do nothing, game's version is newer. Start the game
                Debug.Log("Already updated.");
            }
            else
            {
                Debug.Log("Update is starting..");
                // Update the game
                // Download new stuff
            }
        }
        else
        {
            // No internet connection to the server
            Debug.Log("No internet connection to the server!");
        }
        Debug.Log(www.text);

    }

}