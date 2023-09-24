using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class LoadScene : MonoBehaviour
{
   [SerializeField] private string _sceneName;
   public void Load()
   {
      EventsManager.Instance.ClearEvents();
      SceneManager.LoadScene(_sceneName);
   }
}
