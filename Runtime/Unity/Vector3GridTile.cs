using IDEK.Tools.WorldManagement.CoreLib.Grid;
using System.Collections.Generic;
using UnityEngine;

namespace IDEK.Tools.WorldManagement.Unity
{
    //To not break the generics with further type inheritance, we do need to make both of these variants

    public class Vector3GridTile : Vector3GridTile<Vector3GridTile> { }
    public class Vector3GridTile<TRuntimeType> : GridTile3D<Vector3, Vector3Int, TRuntimeType>
        where TRuntimeType : Vector3GridTile<TRuntimeType>
    {
        public override TRuntimeType Above => World.TryGetTileAtIndex(TileIndex + Vector3Int.up, out TRuntimeType tile) ? tile : default;
        public override TRuntimeType Below => World.TryGetTileAtIndex(TileIndex + Vector3Int.down, out TRuntimeType tile) ? tile : default;
        public override TRuntimeType Right => World.TryGetTileAtIndex(TileIndex + Vector3Int.right, out TRuntimeType tile) ? tile : default;
        public override TRuntimeType Left => World.TryGetTileAtIndex(TileIndex + Vector3Int.left, out TRuntimeType tile) ? tile : default;
        public override TRuntimeType Ahead => World.TryGetTileAtIndex(TileIndex + Vector3Int.forward, out TRuntimeType tile) ? tile : default;
        public override TRuntimeType Behind => World.TryGetTileAtIndex(TileIndex + Vector3Int.back, out TRuntimeType tile) ? tile : default;

        public override bool IsValid => true; //revise if we end up with more conditions I guess?

        public override void RefreshNeighbors()
        {
            //3D tiles have 26 neighbors (3^3-1), if you include diagonals

            Vector3Int index = TileIndex;
            
            if(Neighbors != null) 
                Neighbors.Clear();
            else
                Neighbors = new HashSet<TRuntimeType>();

            TRuntimeType newNeighbor;

            for(int x = index.x - 1; x <= index.x + 1; x++)
            {
                for(int y = index.y - 1; y <= index.y + 1; y++)
                {
                    for(int z = index.z - 1; z <= index.z + 1; z++)
                    {
                        //skip center
                        if(x == index.x && y == index.y && z == index.z) continue;

                        //skip invalid indices
                        if(!World.TryGetTileAtIndex(new(x, y, z), out newNeighbor)) continue;

                        if(!Neighbors.Add(newNeighbor)) continue;
                    }
                }
            }
        }
    }
}