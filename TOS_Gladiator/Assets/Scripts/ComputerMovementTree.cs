using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerMovementTree : MonoBehaviour
{
    public ComputerMovement computerMovement;
    class TreeNode<T>
    {
        List<TreeNode<T>> Children = new List<TreeNode<T>>();

        T Item { get; set; }

        public TreeNode(T item)
        {
            Item = item;
        }

        public TreeNode<T> AddChild(T item)
        {
            TreeNode<T> nodeItem = new TreeNode<T>(item);
            Children.Add(nodeItem);
            return nodeItem;
        }
    }


    void Update()
    {
        
    }
    public void AddValuetoTree()
    {
        string root = "root";
        TreeNode<string> Root = new TreeNode<string>(root);

        if (computerMovement.PlayerWalkLeftBool==true)
        {
            var Left = Root.AddChild("ToLeft");
        }
        if (computerMovement.PlayerWalkRightBool == true)
        {
            var Right = Root.AddChild("ToRight");
        }
        if (computerMovement.PlayerAttackBool == true)
        {
            var QuickAttack = Root.AddChild("QuickAttack");
            var NormalAttack = Root.AddChild("NormalAttack");
            var HardAttack = Root.AddChild("HardAttack");
        }



    }
   

}




