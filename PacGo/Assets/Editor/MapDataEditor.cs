using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapData))]
public class MapDataEditor : Editor
{
    MapData mapdata;
    public string test;

    public MapTile tile;
    
    private void OnEnable()
    {
        mapdata = (MapData)target;

        tile = Resources.Load<MapTile>("tile/" + mapdata.tilename);
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.BeginVertical();
        EditorGUILayout.Space();

        tile = EditorGUILayout.ObjectField(tile,typeof(MapTile),false,null) as MapTile;
        if(tile != null)
            mapdata.tilename = tile.name;

        //mapdata.datastr = EditorGUILayout.TextArea(mapdata.datastr);
        int row = mapdata.row;
        int column = mapdata.column;
        row = EditorGUILayout.IntField("Row:", mapdata.row);
        column = EditorGUILayout.IntField("Column:", mapdata.column);
        if (mapdata.data == null || row != mapdata.row || column != mapdata.column)
        {
            mapdata.data = new int[row * column];
        }
        mapdata.row = row;
        mapdata.column = column;

        for (int i=0;i< mapdata.row; ++i)
        {
            EditorGUILayout.BeginHorizontal();
            for (int j = 0; j < mapdata.column; ++j)
            {
                mapdata.data[i * column + j] = EditorGUILayout.IntField(mapdata.data[i* column + j]);
            }
            EditorGUILayout.EndHorizontal();
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        if (tile != null)
        {
            for (int i = 0; i < mapdata.row; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                for (int j = 0; j < mapdata.column; ++j)
                {
                    mapdata.data[i * column + j] = EditorGUILayout.IntField(mapdata.data[i * column + j]);


                    mapdata.data[i * column + j] = EditorGUILayout.IntPopup(mapdata.data[i * column + j], tile.TileNames, tile.TileIndex);
                }
                EditorGUILayout.EndHorizontal();
            }
        }
        

        EditorGUILayout.EndVertical();
    }
}
