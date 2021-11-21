using System;
namespace Decorator.Examples
{
    class MainApp
    {
        static void Main()
        {
            ChristmasTree tree = new ChristmasTree();
            PlasticDecoration spheres = new PlasticDecoration();
            LightsDecoration lights = new LightsDecoration();
            spheres.SetTree(tree);
            lights.SetTree(spheres);
            lights.Operation();

            Console.Read();
        }
    }
    abstract class Tree
    {
        public abstract void Operation();
    }

    class ChristmasTree : Tree
    {
        public override void Operation()
        {
            Console.WriteLine("Just a tree");
        }
    }
    abstract class Decorator : Tree
    {
        protected Tree tree;

        public void SetTree(Tree Tree)
        {
            this.tree = Tree;
        }
        public override void Operation()
        {
            if (tree != null)
            {
                tree.Operation();
            }
        }
    }

    class PlasticDecoration : Decorator
    {
        private string addedDecoration;

        public override void Operation()
        {
            base.Operation();
            addedDecoration = "Added plastic spheres";
            Console.WriteLine(addedDecoration);
        }
    }

    class LightsDecoration : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
        }
        void AddedBehavior()
        { 
            Console.WriteLine("Christmas tree is glowing");
        }
    }
}