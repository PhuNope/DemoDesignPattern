using UnityEngine;
using UnityEngine.Pool;

public class RevisedProjectile : MonoBehaviour {
    private IObjectPool<RevisedProjectile> objectPool;

    public IObjectPool<RevisedProjectile> ObjectPool { set => objectPool = value; }
}