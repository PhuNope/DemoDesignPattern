using UnityEngine;

public class ProductA : MonoBehaviour, IProduct {
    [SerializeField] private string productName = "ProductA";

    public string ProductName { get => productName; set => productName = value; }

    public void Initialize() {
        gameObject.name = productName;
    }
}