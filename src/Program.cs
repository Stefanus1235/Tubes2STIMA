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
        public void AllVertex(){
            Console.Write("[");
            for(int i=0; i<this.nodes.Count; i++){
                Console.Write(this.nodes[i].vertex);
                if (i != this.nodes.Count-1){
                    Console.Write(", ");
                }
            }
            Console.Write("]\n");
        }

        public int searchIdxNode(string s){
            if (this.nodes.Count == 0){
                return -1;
            }
            else {
                int j  = -1;
                foreach(node i in this.nodes){
                    j++;
                    if (i.vertex == s){
                        return j;
                    }
                }
                return -1;
            }
        }

        public graph bfs(string vertexawal, string vertextujuan){
            node awal = this.nodes[searchIdxNode(vertexawal)];
            node tujuan = this.nodes[searchIdxNode(vertextujuan)];
            graph travelledNodes = new graph();
            int idxTrav;
            Console.Write(awal.adjCount() == 0);
            if (awal.adjCount() != 0)
            // Kalau tidak trigger, return list node isi node awal saja
            {
                travelledNodes.addNode(awal);
                idxTrav = 0;
                bfsRekurs(idxTrav, tujuan, travelledNodes);
            }
            return travelledNodes; 
        }
        public void bfsRekurs(int idxTrav, node tujuan, graph travelledNodes){
            if (travelledNodes.contain(tujuan.vertex) || idxTrav == travelledNodes.nodes.Count)
            {}
            else{
                foreach(node i in travelledNodes.nodes[idxTrav].adjacent){
                    if (travelledNodes.contain(tujuan.vertex)) {
                        break;
                    }
                    else if(travelledNodes.contain(i.vertex)){
                        // Nothing
                    }
                    else {
                        travelledNodes.addNode(i);
                    }
                }
                bfsRekurs(idxTrav+1, tujuan, travelledNodes);
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
        public int adjCount(){
            return this.adjacent.Count;
        }
        public bool containAdj(node x){
            foreach (node i in this.adjacent){
                if (i == x){
                    return true;
                }
            }
            return false;
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
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Jeremy\Documents\Backup Jeremy 5 Sep 20\Kuliah\Semester 4\Strategi Algoritma\Tubes2\Tubes2STIMA\src\tes.txt");
            foreach (string line in lines)
            {
                string[] y = line.Split(" ");
                if (!a.contain(y[0])){
                    node temp = new node(y[0]);
                    a.addNode(temp);
                    if (!a.contain(y[1])){
                        node temp1 = new node(y[1]);
                        a.addNode(temp1);
                        temp.addAdj(temp1);
                    }
                    else {
                        foreach(node i in a.nodes){
                            if(i.vertex == y[1]){
                                temp.addAdj(i);
                            }
                        }
                    }
                }
                else {
                    for (int i = 0 ; i<a.nodes.Count ; i++){
                        if (a.nodes[i].vertex == y[0]){
                            if (!a.contain(y[1])){
                                node temp1 = new node(y[1]);
                                a.addNode(temp1);
                                a.nodes[i].addAdj(temp1);
                            }
                            else {
                                foreach(node j in a.nodes){
                                    if(j.vertex == y[1]){
                                        a.nodes[i].addAdj(j);
                                    }
                                }
                            }
                        }
                    }   
                }

            }
            // a.AllInfo();
            a.AllVertex();
            graph x = a.bfs("A","U");
            x.AllVertex();

        }
    }
}
