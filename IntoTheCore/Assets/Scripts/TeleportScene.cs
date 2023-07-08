using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TeleportScene : MonoBehaviour
{
    public void Teleport(string name)
    {
        SceneManager.LoadScene(name);
    }
}
