using UnityEngine;

namespace MyLibs
{
    public abstract class BaseServiceManager : MonoBehaviour
    {
        protected ServiceLocator<IService> _serviceLocator;

        protected void Awake()
        {
            _serviceLocator = new ServiceLocator<IService>();
            
            _serviceLocator.ServiceRegister(CoroutineService.Instance);
            _serviceLocator.ServiceRegister(new TextureBaseDataHolder());
        }

        public abstract T GetService<T>() where T : IService;
        public abstract void ServiceRegister(IService service);
        public abstract void UnRegisterService<T>() where T : IService;
    }
}