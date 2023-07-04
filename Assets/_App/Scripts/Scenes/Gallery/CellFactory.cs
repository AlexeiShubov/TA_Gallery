using MyLibs;
using UnityEngine;

public class CellFactory : GameObjectFactory<Cell>
{
    private Cell _prefab;
    private Transform _container;
    
    public CellFactory(Cell prefab, Transform container) : base(prefab)
    {
        _prefab = prefab;
        _container = container;
    }

    public override Cell Create()
    {
        return Object.Instantiate(_prefab, Vector3.zero, Quaternion.identity, _container);
    }
}
