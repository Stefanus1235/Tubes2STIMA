using System;
using System.Collections.Generic; 
using System.IO; 


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

        public bool contain(string s){
        if (this.nodes.Count == 0){
                    return false;
                }
            else {
                foreach(node i in this.nodes){
                    if (i.vertex == s){
                        return true;
                        break;
                    }
                }
                return false;
            }
        }
        public void Info(){
            foreach(node i in this.nodes){
                Console.WriteLine(i.vertex);
            }
        }

        public void AllInfo(){
            foreach(node i in this.nodes){
                i.printInfo();
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

        public node(node x){
            this.vertex = x.vertex;
            this.adjacent = new List<node>();
            foreach(node i in x.adjacent){
                this.adjacent.Add(i);
            }
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
        node searching(graph g,string s){
            node temp = new node("noval");
            foreach(node i in g.nodes){
                if (i.vertex == s){
                    temp = new node(i);
                }
            }
            return temp;
        }
        static void Main(string[] args)
        {
            graph a = new graph();
            // Untuk Read File
            string[] lines = System.IO.File.ReadAllLines(@"E:\ITB\Semester_4\Program\C#\tes.txt");
            foreach (string line in lines)
            {
                string[] x = line.Split(" ");
                if (!a.contain(x[0])){
                    node temp = new node(x[0]);
                    a.addNode(temp);
                    if (!a.contain(x[1])){
                        node temp1 = new node(x[1]);
                        a.addNode(temp1);
                        temp.addAdj(temp1);
                    }
                    else {
                        foreach(node i in a.nodes){
                            if(i.vertex == x[1]){
                                temp.addAdj(i);
                            }
                        }
                    }
                }
                else {
                    for (int i = 0 ; i<a.nodes.Count ; i++){
                        if (a.nodes[i].vertex == x[0]){
                            if (!a.contain(x[1])){
                                node temp1 = new node(x[1]);
                                a.addNode(temp1);
                                a.nodes[i].addAdj(temp1);
                            }
                            else {
                                foreach(node j in a.nodes){
                                    if(j.vertex == x[1]){
                                        a.nodes[i].addAdj(j);
                                    }
                                }
                            }
                        }
                    }   
                }

            }
            a.AllInfo();

        }
    }
}
