using System.Collections.Generic;
using MyLibs;

public abstract class BaseDataHolder<T, TP> : IService
{
    protected Dictionary<T, TP> _dataMap;

    public BaseDataHolder()
    {
        _dataMap = new Dictionary<T, TP>();
    }

    public virtual void SetData(T key, TP data)
    {
        if (_dataMap.ContainsKey(key))
        {
            _dataMap[key] = data;
        }
        else
        {
            _dataMap.Add(key, data);
        }
    }

    public virtual TP GetData(T key)
    {
        return _dataMap.ContainsKey(key) ? _dataMap[key] : default;
    }
}