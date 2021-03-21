using System;
using System.Collections; 
using System.Collections.Generic; 


namespace Tubes_2
{
    class node {
        public string vertex;
        public List<graph> adjacent;

        public node(string v){
            this.vertex = v;
            this.adjacent = new List<graph>();
        }

        public void printInfo(){
            Console.WriteLine("Vertices = {0}",this.vertices);
            if (this.adjacent.Count == 0){
                Console.WriteLine("kosong");
            }
        }

        public addAdj(node x){
            this.adjacent.Add(x);
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // List<int> coba = new List<int>();
            // coba.Add(1);
            // coba.Add(2);
            // coba.Add(3);
            // foreach (int i in coba){
            //     Console.WriteLine("Elemen = {0}",i);
            // }
            node tes = new node("A");
            node temp = new node("B");
            tes.addAdj(temp);
            tes.printInfo();
        }
    }
}
