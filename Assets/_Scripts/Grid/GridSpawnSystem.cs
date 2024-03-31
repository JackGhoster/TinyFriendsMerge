using System;
using Grid;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using Unity.Mathematics;
using Unity.VisualScripting;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(GridSpawnSystem))]
public sealed class GridSpawnSystem : UpdateSystem
{
    [SerializeField] private CellProvider _prefab;

    [SerializeField] private int _width = 7;
    [SerializeField] private int _height = 8;
    
    public override void OnAwake()
    {
        // SpawnCell(index: 0);
        SpawnGrid();
    }

    public override void OnUpdate(float deltaTime) {
    }

    public void SpawnGrid()
    {
        for (int vertical = 0; vertical < _height; vertical++)
        {
            for (int horizontal = 0; horizontal < _width; horizontal++)
            {
                int index = (vertical * _width) + horizontal; 
                SpawnCell(index: index);
            }
        }
    }
    
    private GameObject SpawnCell(int index)
    {
        var cp = Instantiate(_prefab.GameObject(), Vector2.zero, quaternion.identity).GetComponent<CellProvider>();

        var entity = cp.Entity;
        
        ref var cell = ref entity.GetComponent<Cell>();

        cell.index = index;
        cell.size = Vector2.one;
        cell.gap = 1;

        ref var mov = ref entity.AddComponent<Movable>();

        mov.position = CalculateOffset(cell.index, cell.gap);

        ref var ut = ref entity.GetComponent<UnityTransform>();
        ut.transform.position = mov.position;
        
        return cp.GameObject();
    }

    private Vector3 CalculateOffset(int index, float gapsize)
    {
        float indexF = (float)index;
        
        //vertical
        var verticalOffset = index + 1 % _width == 0 ? MathF.Floor(indexF / _width) - 1 : MathF.Floor( indexF / _width);
        //horizontal
        var horizontalOffset =  (indexF % _width) - 1;
        
        Vector3 offset = new(horizontalOffset * gapsize, verticalOffset * gapsize);
        
        return offset;
    }
    
}

    
    