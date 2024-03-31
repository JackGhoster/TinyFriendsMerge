using System;
using Scellecs.Morpeh;
using UnityEngine;

namespace Grid
{
   [Serializable]
   public struct Cell : IComponent
   {
      public int index;
      public Vector2 size;
      public float gap;
      public bool finished;

   }
}