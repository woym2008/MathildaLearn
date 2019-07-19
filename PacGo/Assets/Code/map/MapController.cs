using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    //地图文件
    public MapData mapdata;

    //每个格子的size
    public Vector2 wallsize = new Vector2(1,1);

    //public GameObject WallPrefab;
    //public MapTile TileData;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            CreateMap();
        }
    }

    public void CreateMap()
    {
        if(mapdata == null)
        {
            Debug.LogError("Null Map Data");

            return;
        }
        if(mapdata.tilename == "")
        {
            Debug.LogError("Null Tile Data");

            return;
        }
        var tiledata = Resources.Load<MapTile>("tile/" + mapdata.tilename);
        if(tiledata == null)
        {
            Debug.LogError("Invalid Tile Data");

            return;
        }

        var numrow = mapdata.row;
        var numcolumn = mapdata.column;
        float rowoffset = 0;
        if(numrow % 2 == 0)
        {
            rowoffset = 0.5f * wallsize.y;
        }
        float columnoffset = 0;
        if (columnoffset % 2 == 0)
        {
            columnoffset = 0.5f * wallsize.x;
        }

        for (int i=0; i< numrow; ++i)
        {
            for(int j=0;j<numcolumn; ++j)
            {
                var tileobjprefab = LoadTile(mapdata[i, j], tiledata);
                if(tileobjprefab != null)
                {
                    var tileobj = GameObject.Instantiate(tileobjprefab, transform);
                    tileobj.transform.localPosition =
                    new Vector3(-numcolumn * 0.5f * wallsize.x + columnoffset, 0, -numrow * 0.5f * wallsize.y + rowoffset)
                    + new Vector3(j * wallsize.x, 0, (numrow - i - 1) * wallsize.y);
                    //因为编辑器中显示的最上面的行是最先被读进来的，所以此时显示的顺序是最下面是第一行，所以需要反着读取一下。numrow - i - 1
                }

            }
        }
    }

    GameObject LoadTile(int index,MapTile tiles)
    {
        if(tiles.NumTile > index)
        {
            var tileindex = tiles.TileIndex[index];
            var name = tiles.TileNames[index];

            var tileobject = Resources.Load<GameObject>("floor/"+name);
            //var wallobject = GameObject.Instantiate(WallPrefab, transform);

            return tileobject;
        }

        return null;
    }
}
