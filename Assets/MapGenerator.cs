using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    
    [SerializeField] private MapManager manager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

public class TreeNode
{
    public Container self;
    public TreeNode leftChild;
    public TreeNode rightChild;
    public TreeNode parent;
    public TreeNode(Container self)
    {
        this.self = self;
        this.leftChild = null;
        this.rightChild = null;
    }

    public List<Container> GetLeafs()
    {
        List<Container> result = default(List<Container>);

        if (this.leftChild == null && this.rightChild == null)
        {
            result.Add(this.self);
        }
        else
        {
            result.AddRange(this.leftChild.GetLeafs());
            result.AddRange(this.leftChild.GetLeafs());
        }
        return result;
    }

}
public class Container
{
    private int x, y, w, h;
    private Vector2 center;

    Container(int x, int y, int w, int h)
    {
        this.x = x;
        this.y = y;
        this.w = w;
        this.h = h;
        this.center = new Vector2
        {
            x = this.x + Mathf.RoundToInt(this.w * 0.5f),
            y = this.y + Mathf.RoundToInt(this.h * 0.5f)
        };
    }

    TreeNode SplitContainer(Container container, int count)
    {
        TreeNode root = new TreeNode(container);
        if (count != 0)
        {
            Container[] sr = RandomSplit(container);
            root.leftChild = SplitContainer(sr[0], count - 1);
            root.rightChild = SplitContainer(sr[1], count - 1);
        }
        return root;
    }

    Container[] RandomSplit(Container container)
    {
        Container[] result = new Container[2];

        Container r1, r2;

        int randomNumber = Mathf.RoundToInt(Random.Range(0, 1));
        if (randomNumber == 0)
        {
            // 난수가 0 이면 수직 분할
            r1 = new Container(
                container.x, container.y,
                Mathf.RoundToInt(Random.Range(1, (float)container.w)), container.h
            );
            r2 = new Container(
                container.x + r1.w, container.y,
                container.w - r1.w, container.h
            );
            result[0] = r1;
            result[1] = r2;
        }
        else
        {
            // 난수가 0이 아니면 수평 분할
            r1 = new Container(
                container.x, container.y,
                container.w, Mathf.RoundToInt(Random.Range(1, (float)container.h))
            );
            r2 = new Container(
                container.x, container.y + r1.h,
                container.w, container.h - r1.h
            );
            result[0] = r1;
            result[1] = r2;
        }

        return result;
    }
}
