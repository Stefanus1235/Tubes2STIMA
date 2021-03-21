using System;
using System.Collections; 
using System.Collections.Generic; 


namespace Tubes_2
{
    class graph {
        public List<node> nodes;

        public graph(){
            this.nodes = new List<node>();
        }

        public void addNode(node x){
            if (!this.nodes.Contains(x)){
                this.nodes.Add(x);
            }
        }
        public void Info(){
            foreach(node i in this.nodes){
                Console.WriteLine(i.vertex);
            }
        }
        

    }
    class node {
        public string vertex;
        public List<node> adjacent;

        public node(string v){
            this.vertex = v;
            this.adjacent = new List<node>();
        }

        public void printInfo(){
            Console.WriteLine("Vertices : {0}",this.vertex);
            if (this.adjacent.Count == 0){
                Console.WriteLine("Adjacent : Kosong");
            }
            else {
                Console.WriteLine("Adjacent : ");
                foreach(node i in this.adjacent){
                    Console.WriteLine(i.vertex);
                }
            }
        }

        public void addAdj(node x){
            this.adjacent.Add(x);
            x.adjacent.Add(this);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            node tes = new node("A");
            node temp = new node("B");
            graph a = new graph();
            a.addNode(tes);
            a.addNode(temp);
            a.addNode(tes);
            a.Info();
            tes.addAdj(temp);
            temp.printInfo();
            tes.printInfo();
        }
    }
}
