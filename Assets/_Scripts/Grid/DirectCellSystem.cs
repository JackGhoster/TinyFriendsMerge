using Grid;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(DirectCellSystem))]
public sealed class DirectCellSystem : UpdateSystem
{
    private Filter _cellFilter;
    
    public override void OnAwake()
    {
        _cellFilter = World.Filter.With<Cell>().Without<Movable>().Without<MoveDirection>().Build();
    }

    public override void OnUpdate(float deltaTime)
    {
        // foreach (var entity in _cellFilter)
        // {
        //     ref var cell = ref entity.GetComponent<Cell>();
        //     
        //     entity.AddComponent<Movable>();
        //     entity.AddComponent<MoveDirection>();
        //     ref var md = ref entity.GetComponent<MoveDirection>();
        //     md.direction = Vector3.right;
        //     
        //     
        // }
        //
    }
}