#region 描述
//-----------------------------------------------------------------------------
// 类 名 称: MapTile
// 作    者：zhangfan
// 创建时间：2019/7/19 15:43:10
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
using UnityEngine;

//tile配置表
[CreateAssetMenu()]
public class MapTile : ScriptableObject
{
    //提供name和index两个list
    //List用来做暂存和访问，name用来方便的显示在编辑器中以及在游戏中通过name加载prefab
    [SerializeField]
    public string[] TileNames;
    [SerializeField]
    public int[] TileIndex;

    public int NumTile;
}
