using System;
using Scellecs.Morpeh;
using Scellecs.Morpeh.Providers;
using Unity.VisualScripting;

namespace Grid
{
    public class TransformProvider : MonoProvider<UnityTransform>
    {
        private void Awake()
        {
            ref var ut = ref GetData();
            ut.transform = transform;
        }

    }
   
    
}