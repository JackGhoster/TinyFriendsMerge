using Scellecs.Morpeh;
using Scellecs.Morpeh.Systems;
using Unity.IL2CPP.CompilerServices;
using UnityEngine;

namespace Grid
{
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    [Il2CppSetOption(Option.DivideByZeroChecks, false)]
    [CreateAssetMenu(menuName = "ECS/Systems/" + nameof(CellMoveSystem))]
    public class CellMoveSystem : UpdateSystem{
        private Filter _cellsFilter;
        
        public override void OnAwake()
        {
            this._cellsFilter = this.World.Filter.With<Cell>().With<UnityTransform>().With<Movable>().With<MoveDirection>().Build();
        }

        public override void OnUpdate(float deltaTime)
        {
            foreach (var entity in this._cellsFilter)
            {
                // ref var cell = ref entity.GetComponent<Cell>();
                // ref var unityTransform = ref entity.GetComponent<UnityTransform>();
                // ref var movable = ref entity.GetComponent<Movable>();
                // ref var md = ref entity.GetComponent<MoveDirection>();
                //
                // movable.position += md.direction * deltaTime;
                //
                // unityTransform.transform.position += movable.position * deltaTime;
                //
                // if (unityTransform.transform.position.x > 5)
                // {
                //     entity.RemoveComponent<MoveDirection>();
                //     entity.RemoveComponent<Movable>();
                //     cell.finished = true;
                // }
            }
        }
    }
}