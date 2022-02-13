using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGenerator : MonoBehaviour
{
    #region Structs
    class TreeNode
    {
        TreeNode leaf;
        TreeNode leftChild;
        TreeNode rightChild;
        TreeNode(TreeNode leaf)
        {
            this.leaf = leaf;
            this.leftChild = null;
            this.rightChild = null;
        }

        List<TreeNode> GetLeafs()
        {
            List<TreeNode> result = default(List<TreeNode>);

            if(this.leftChild == null && this.rightChild == null)
            {
                result.Add(this.leaf);
            }
            else
            {
                result.Add(this.leftChild);
                result.Add(this.rightChild);
                this.leftChild.GetLeafs();
                this.leftChild.GetLeafs();

            }
            return result;
        }

    }
    class Container
    {
        int x, y, w, h;
        Vector2 center;

        Container(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
            this.center = new Vector2{
                x = this.x + Mathf.RoundToInt(this.w * 0.5f), 
                y = this.y + Mathf.RoundToInt(this.h * 0.5f)
            };
        }
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
