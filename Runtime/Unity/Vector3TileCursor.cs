using IDEK.Tools.WorldManagement.CoreLib.Tiles;
using UnityEngine;

namespace IDEK.Tools.WorldManagement.Unity
{
    // <summary>
    /// Represents a cursor position that operations should be done at/relative to
    /// </summary>
    public class Vector3TileCursor : TileCursor<Vector3, Vector3Int, Vector3GridTile>
    {
        public override void OnCursorUpdate(Vector3GridTile oldTile, Vector3GridTile newTile) { }
    }
}