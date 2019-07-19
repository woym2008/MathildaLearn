#region 描述
//-----------------------------------------------------------------------------
// 类 名 称: MapTileEditor
// 作    者：zhangfan
// 创建时间：2019/7/19 15:46:40
// 描    述：
// 版    本：
//-----------------------------------------------------------------------------
// Copyright (C) 2017-2019 零境科技有限公司
//-----------------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;

[CustomEditor(typeof(MapTile))]
public class MapTileEditor : Editor
{
    MapTile maptile;
    const string TileNumStr = "Tile Num";

    private void OnEnable()
    {
        maptile = (MapTile)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();

        var numTile = EditorGUILayout.IntField(TileNumStr, maptile.NumTile);
        if (numTile != maptile.NumTile|| maptile.TileNames == null || maptile.TileIndex == null)
        {
            maptile.TileNames = new string[numTile];

            maptile.TileIndex = new int[numTile];

            maptile.NumTile = numTile;
        }

        for(int i=0;i< numTile;++i)
        {
            EditorGUILayout.BeginHorizontal();
            maptile.TileNames[i] = EditorGUILayout.TextField(maptile.TileNames[i]);
            maptile.TileIndex[i] = EditorGUILayout.IntField(maptile.TileIndex[i]);
            EditorGUILayout.EndHorizontal();
        }
        EditorGUILayout.EndVertical();
    }
}
