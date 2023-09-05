
using UnityEngine;public abstract class AbstractFactory<T> where T : IProduct
{
    protected T _product;
    public abstract T CreateProduct();
    
    public AbstractFactory(T productToProduce)
    {
        _product = productToProduce;
    }
}

public class Bullet : MonoBehaviour, IProduct
{
    public GameObject MyGameObject
    { get; }
    
    public IProduct Clone()
    {
        print("");
        return Instantiate(this);
    }
    
}
// public BulletFactory : AbstractFactory<BasicBullet>
// {
//     return 
// }
