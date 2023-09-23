using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterDetection
{
   string PlayerTag { get; }
   void OnPlayerCharacterTriggerEnter();
}
