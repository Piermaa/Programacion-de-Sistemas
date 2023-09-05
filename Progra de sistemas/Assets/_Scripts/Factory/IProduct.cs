using UnityEngine;

public interface IProduct
{
    IProduct Clone();
    GameObject MyGameObject { get; }
}