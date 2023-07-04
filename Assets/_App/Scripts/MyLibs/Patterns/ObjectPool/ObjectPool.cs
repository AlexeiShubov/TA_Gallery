using System.Collections.Generic;

namespace MyLibs
{
    public abstract class ObjectPool<T> : IPool<T> where T : IPoolObject
    {
        private readonly IFactory<T> _factory;
        private readonly Queue<T> _queue;

        protected ObjectPool(IFactory<T> factory)
        {
            _factory = factory;
            _queue = new Queue<T>();
        }

        public virtual T GetObject()
        {
            return _queue.Count > 0 ? _queue.Dequeue() : CreateObject();
        }

        public virtual void ReturnObject(T obj)
        {
            _queue.Enqueue(obj);
        }

        protected virtual T CreateObject()
        {
            var poolObject = _factory.Create();

            poolObject.Initialize(this as IPool<IPoolObject>);

            return poolObject;
        }
    }
}
