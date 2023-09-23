using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICommand //orden que se hace
{
   // int Priority();
   bool CanUndo { get; set; } //para que el game manager chequee si puede hacer el memento
   float TimeToUndo { get; set; } //cuanto tiempo para mementear

   //por ejemplo recojer
    // ejecucion de la orden
    void Do();
    //quien quiera la capacidad de ser un comando, que ejecute un Do
    
    //por ejemplo tirar
    //Patron de Memento:
    //  Capacidad de deshacer algo
    void Undo(); // en base al do
}
//comandos concretos, que propiedades y que ejecucion a realizar
//commander, centralizador
//se puede ser tan 