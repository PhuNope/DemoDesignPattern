using UnityEngine;

public class ConcreteFactoryA : Factory {
    [SerializeField] private ProductA productPrefab;

    public override IProduct GetProduct(Vector3 position) {
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        ProductA newProduct = instance.GetComponent<ProductA>();

        newProduct.Initialize();

        return newProduct;
    }
}