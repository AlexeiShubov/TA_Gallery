using UnityEngine;

namespace MyLibs
{
    public abstract class BasePoolObject : MonoBehaviour, IPoolObject
    {
        private IPool<IPoolObject> _pool;

        public virtual void Initialize(IPool<IPoolObject> pool)
        {
            _pool = pool;
        }

        public virtual void Return()
        {
            _pool.ReturnObject(this);
        }
    }
}