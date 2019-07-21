using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData
{
    public GameObject TileObj;
    public int TileType;
}
public class MapController : MonoBehaviour
{
    //地图文件
    public MapData mapdata;
    private MapTile _maptile;

    public GameObject BeanPrefab;

    [SerializeField]
    public List<TileData> _tiles = new List<TileData>();
    public List<GameObject> _beans = new List<GameObject>();

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
        _maptile = Resources.Load<MapTile>("tile/" + mapdata.tilename);

        if(_maptile == null)
        {
            Debug.LogError("Invalid Tile Data");

            return;
        }

        _tiles.Clear();

        var numrow = mapdata.row;
        var numcolumn = mapdata.column;
        float rowoffset = 0;
        if(numrow % 2 != 0)
        {
            rowoffset = 0.5f * wallsize.y;
        }
        float columnoffset = 0;
        if (numcolumn % 2 != 0)
        {
            columnoffset = 0.5f * wallsize.x;
        }

        for (int i=0; i< numrow; ++i)
        {
            for(int j=0;j<numcolumn; ++j)
            {
                var tileobjprefab = LoadTile(mapdata[i, j], _maptile);
                if(tileobjprefab != null)
                {
                    var tileobj = GameObject.Instantiate(tileobjprefab, transform);
                    tileobj.transform.localPosition =
                    new Vector3(-numcolumn * 0.5f * wallsize.x + columnoffset, 0, -numrow * 0.5f * wallsize.y + rowoffset)
                    + new Vector3(j * wallsize.x, 0, (numrow - i - 1) * wallsize.y);
                    //因为编辑器中显示的最上面的行是最先被读进来的，所以此时显示的顺序是最下面是第一行，所以需要反着读取一下。numrow - i - 1

                    var tdata = new TileData();
                    tdata.TileObj = tileobj;
                    tdata.TileType = _maptile.TileIndex[mapdata[i, j]];
                    _tiles.Add(tdata);
                }
                else
                {
                    var tdata = new TileData();
                    tdata.TileObj = new GameObject();
                    tdata.TileObj.transform.position = new Vector3(-numcolumn * 0.5f * wallsize.x + columnoffset, 0, -numrow * 0.5f * wallsize.y + rowoffset)
                    + new Vector3(j * wallsize.x, 0, (numrow - i - 1) * wallsize.y);
                    tdata.TileType = _maptile.TileIndex[mapdata[i, j]];
                    _tiles.Add(tdata);
                }

            }
        }

        CreateBeans();
    }

    GameObject LoadTile(int index,MapTile tiles)
    {
        if(tiles.NumTile > index)
        {
            var tileindex = tiles.TileIndex[index];
            var tname = tiles.TileNames[index];

            var tileobject = Resources.Load<GameObject>("floor/"+tname);
            //var wallobject = GameObject.Instantiate(WallPrefab, transform);

            return tileobject;
        }

        return null;
    }

    private void CreateBeans()
    {
        foreach(var empty in _tiles)
        {
            if(empty.TileType == 0)
            {
                var rnd = Random.Range(0, 2);
                if(rnd == 1)
                {
                    var bean = CreateBean();
                    bean.transform.position = empty.TileObj.transform.position;
                }
            }
        }
    }

    private GameObject CreateBean()
    {
        return GameObject.Instantiate(BeanPrefab) as GameObject;
    }

    private void OnDestroy()
    {
        //tiledata = null;
    }

    public void DestroyMap()
    {
        foreach(var t in _tiles)
        {
            GameObject.Destroy(t.TileObj);
        }
        _tiles.Clear();
        foreach(var b in _beans)
        {
            if(b != null)
            {
                Destroy(b);
            }
        }
        _beans.Clear();
    }
}
