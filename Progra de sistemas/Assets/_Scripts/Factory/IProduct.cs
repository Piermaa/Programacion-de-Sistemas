using UnityEngine;

public interface IProduct
{
    IProduct Clone(); //TODO: QUE TODOS LOS PRODUCT LLAMEN A OBJECT POOLER Y SE DEVUELVAN A ELLOS
    GameObject MyGameObject { get; }
}