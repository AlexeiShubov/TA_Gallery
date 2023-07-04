using UnityEngine;

namespace MyLibs
{
    public class BaseMonoPool<T> : ObjectPool<T> where T : BasePoolObject
    {
        private readonly Transform _container;

        public BaseMonoPool(PoolMonoFactory<T> factory, Transform container) : base(factory)
        {
            _container = container;
        }

        public override void ReturnObject(T obj)
        {
            obj.transform.SetParent(_container);

            base.ReturnObject(obj);
        }
    }
}
