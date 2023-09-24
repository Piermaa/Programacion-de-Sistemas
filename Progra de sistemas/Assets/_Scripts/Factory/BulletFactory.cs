public class BulletFactory : AbstractFactory<BasicBullet>
{
    public BulletFactory(BasicBullet productToProduce) : base(productToProduce)
    {
    }
    public override BasicBullet CreateProduct()
    {
        return (BasicBullet)_product.Clone();
    }
}
