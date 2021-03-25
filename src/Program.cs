using System;
using System.Collections.Generic;
using System.Linq;


namespace Tubes_2
{
    public static class flag{
        public static bool ketemu = false;
    }
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
            Console.Write("]\n\n");
        }
        public void AllVertexWithArrow(){
            for(int i=0; i<this.nodes.Count; i++){
                Console.Write(this.nodes[i].vertex);
                if (i != this.nodes.Count-1){
                    Console.Write(" -> ");
                }
            }
            Console.WriteLine();
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
            // graph parentGraph = new graph();
            int idxTrav;
            if (awal.adjCount() != 0)
            // Kalau tidak trigger, return list node isi node awal saja
            {
                travelledNodes.addNode(awal);
                // parentGraph.Add(awal);
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


        public graph bfs(string vertexawal, string vertextujuan, graph strippedGraph){
            node awal = this.nodes[searchIdxNode(vertexawal)];
            node tujuan = this.nodes[searchIdxNode(vertextujuan)];
            graph travelledNodes = new graph();
            graph parentsGraph = new graph();
            int idxTrav;
            if (awal.adjCount() != 0)
            // Kalau tidak trigger, return list node isi node awal saja
            {
                travelledNodes.addNode(awal);
                parentsGraph.nodes.Add(this.nodes[searchIdxNode(vertexawal)]);
                idxTrav = 0;
                bfsRekurs(idxTrav, tujuan, travelledNodes, parentsGraph);


                int i = travelledNodes.nodes.Count-1;
                while (i > 0){
                    strippedGraph.nodes.Insert(0,travelledNodes.nodes[i]);
                    i = travelledNodes.searchIdxNode(parentsGraph.nodes[i].vertex);
                }
            }
            strippedGraph.nodes.Insert(0,travelledNodes.nodes[0]);
            return travelledNodes;
        }

        public void bfsRekurs(int idxTrav, node tujuan, graph travelledNodes, graph parentsGraph){
            if (idxTrav == travelledNodes.nodes.Count || travelledNodes.contain(tujuan.vertex))
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
                        parentsGraph.nodes.Add(travelledNodes.nodes[idxTrav]);
                    }
                }
                bfsRekurs(idxTrav+1, tujuan, travelledNodes, parentsGraph);

            }
        }

        public graph bfs(string vertexawal, int dist){
            node awal = this.nodes[searchIdxNode(vertexawal)];
            graph nodesOnDepth = new graph();
            
            int idxTrav = 0;
            if (awal.adjCount() != 0)
            // Kalau tidak trigger, return list node isi node awal saja
            {
                
                graph travelledNodes = new graph();
                travelledNodes.addNode(awal);
                List<int> distList = new List<int>();
                distList.Add(0);
                bfsRekurs(idxTrav, nodesOnDepth, travelledNodes, dist, distList);
            }
            return nodesOnDepth; 
        }
        public void bfsRekurs(int idxTrav, graph nodesOnDepth, graph travelledNodes, int dist, List<int> distList){
            if (idxTrav == travelledNodes.nodes.Count || dist == 0)
            {}
            else{
                foreach(node i in travelledNodes.nodes[idxTrav].adjacent){
                    if(travelledNodes.contain(i.vertex)){
                        // Nothing
                    }
                    else if (distList[idxTrav]+1 < dist){
                        travelledNodes.addNode(i);
                        distList.Add(distList[idxTrav]+1);
                    }
                    else {

                        nodesOnDepth.addNode(i);
                    }
                }
                bfsRekurs(idxTrav+1, nodesOnDepth, travelledNodes, dist, distList);
            }
        }



        public graph dfs(string awal,string tujuan){
            flag.ketemu = false;
            node node_awal = this.nodes[searchIdxNode(awal)];
            node node_tujuan = this.nodes[searchIdxNode(tujuan)];
            graph travelled_node = new graph();
            travelled_node.addNode(node_awal);
            dfs_rek(node_awal,node_tujuan,travelled_node);
            return (travelled_node);
        }

        

        public void dfs_rek(node aktif,node tujuan,graph trav){
            if (aktif == tujuan){
            
                Console.WriteLine("ketemu");
                flag.ketemu = true;
                
                trav.AllVertex();
            }
            
            else {
                if (aktif.adjCount() == 0 || aktif.AllAdjVisited(trav)){
                    Console.WriteLine("Dead End");
                }
                else {
                    if (!trav.contain(tujuan.vertex)){

                        foreach (node i in aktif.adjacent ){
                            if (!flag.ketemu){
                                graph travelled = new graph();
                                foreach (node j in trav.nodes){
                                    travelled.addNode(j);
                                }

                                if (!travelled.contain(i.vertex))
                                {
                                    travelled.addNode(i);
                                    dfs_rek(i,tujuan,travelled);
                                    if (travelled.contain(tujuan.vertex)){
                                        Console.WriteLine("cok");
                                        return;    
                                    }
                                    
                                }
                            }
                        }
                    }
                }
            }
        }

        public void dfsrecommend(string s){
            int aktif = this.searchIdxNode(s);
            node node_aktif = this.nodes[aktif];
            //copy adj
            graph adj_aktif = new graph();
            foreach (node i in node_aktif.adjacent){
                adj_aktif.addNode(i);
            }
            graph friend_recommend = new graph();
            foreach (node i in this.nodes){
                node temp = new node(i.vertex);
                if (temp.vertex != node_aktif.vertex && (!adj_aktif.contain(temp.vertex))){
                    friend_recommend.addNode(temp);
                }
                foreach (node j in i.adjacent){
                    int num = adj_aktif.searchIdxNode(j.vertex);
                    if(num != -1){
                        temp.addAdj(adj_aktif.nodes[num]);
                    }
                }
            }
            friend_recommend.AllInfo();
        }
        

    



        public graph getAllNodesWithMutualAdj(string nodeName, string method){
            // METHOD INI SUDAH TERMASUK SORTING.

            // Cari node dengan nama nodeName
            node TheNode = this.nodes[searchIdxNode(nodeName)];

            // Graf yang akan direturn.
            graph nodesWithMutualAdjacent = new graph();

            if (method == "BFS"){
                nodesWithMutualAdjacent = this.bfs(nodeName,2);
            }
            else if (method == "DFS"){
                // nodesWithMutualAdjacent = this.dfs(nodeName,2);
                // Kode untuk DFS dengan 2 node dari node dengan nama 'nodeName'
            }

            // Sort
            for(int i=0; i < nodesWithMutualAdjacent.nodes.Count; i++){
                int maxIdx = i;
                for (int j=i+1; j< nodesWithMutualAdjacent.nodes.Count; j++){
                    if (nodesWithMutualAdjacent.nodes[maxIdx].countMutualAdjacent(TheNode) < nodesWithMutualAdjacent.nodes[j].countMutualAdjacent(TheNode)){
                        maxIdx = j;
                    }
                }
                node swap = nodesWithMutualAdjacent.nodes[i];
                nodesWithMutualAdjacent.nodes[i] = nodesWithMutualAdjacent.nodes[maxIdx];
                nodesWithMutualAdjacent.nodes[maxIdx] = swap;
            }
            return nodesWithMutualAdjacent;
        }
        
        public void friendRecommendation(string nodename, string method){
            graph friendRec = new graph();
            friendRec = this.getAllNodesWithMutualAdj(nodename,method);

            Console.WriteLine("Daftar rekomendasi teman untuk akun {0}:", nodename);
            for (int i=0; i < friendRec.nodes.Count; i++){
                Console.WriteLine("Nama akun: {0}", friendRec.nodes[i].vertex); 
                Console.WriteLine("{0} mutual friends:", friendRec.nodes[i].countMutualAdjacent(this.nodes[searchIdxNode(nodename)]));
                List<node> mutualFriends = friendRec.nodes[i].getAllMutualAdjacent(this.nodes[searchIdxNode(nodename)]);
                foreach(node j in mutualFriends){
                    Console.WriteLine("{0}", j.vertex);
                }
                Console.WriteLine();
            }
        }

        public void friendExplore(string namaNodeAwal, string namaNodeTujuan, string method){
            graph ExploreResult = new graph();
            if (method == "BFS"){
                graph dummy =  this.bfs(namaNodeAwal,namaNodeTujuan,ExploreResult);
            }
            else if (method == "DFS"){
                ExploreResult = this.dfs(namaNodeAwal,namaNodeTujuan);
            }
            Console.WriteLine("Nama akun: {0} dan {1}", namaNodeAwal, namaNodeTujuan);
            if(ExploreResult.nodes.Count <= 2){
                Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
                Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
            }
            else{
                Console.Write("{0}", ExploreResult.nodes.Count-2);
                if (ExploreResult.nodes.Count-2 == 1){ 
                    Console.Write("st");
                }
                else if (ExploreResult.nodes.Count-2 == 2){ 
                    Console.Write("nd");
                }
                else if (ExploreResult.nodes.Count-2 == 3){ 
                    Console.Write("rd");
                }
                else {
                    Console.Write("th");
                }
                Console.Write("-degree connection\n");
                ExploreResult.AllVertexWithArrow();
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

        public bool AllAdjVisited(graph g){
            foreach (node i in this.adjacent){
                if (!g.contain(i.vertex)){
                    return false;
                }
            }
            return true;
            
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

        public List<node> getAllMutualAdjacent(node x){
            List<node> mutualAdjacent = new List<node>();
            foreach(node i in x.adjacent){
                foreach(node j in this.adjacent){
                    if(i == j){
                        mutualAdjacent.Add(i);
                    }
                }
            }
            return mutualAdjacent;
        }
        public int countMutualAdjacent(node x){
            int count = 0;
            foreach(node i in x.adjacent){
                foreach(node j in this.adjacent){
                    if(i == j){
                        count++;
                    }
                }
            }
            return count;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            graph a = new graph();
            // Untuk Read File
            string[] lines = System.IO.File.ReadAllLines(@"E:\ITB\Semester_4\Stima\Tubes2STIMA\src\tes1.txt");
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
            // Console.Write("This is the nodes in graph.\n");

            // a.AllVertex();
            // string vawal = "G";
            // string vtujuan = "H";
            // graph x = a.bfs(vawal,vtujuan);
            // Console.Write("This is the BFS from {0} to {1}\n" ,vawal,vtujuan);
            // x.AllVertex();

            // int dist = 3;
            // Console.Write("This is the BFS from {0} to {1} node away from it\n",vawal,dist);
            // graph b = a.bfs("G", dist);
            // b.AllVertex();

            // graph empty = new graph();
            // graph w = a;
            // w.friendRecommendation("G","BFS");
            // w.friendExplore("A","G","BFS");
            a.nodes.Sort((x, y) => x.vertex.CompareTo(y.vertex));
            foreach(node i in a.nodes){
                i.adjacent.Sort((x, y) => x.vertex.CompareTo(y.vertex));
            }
            a.AllInfo();
            //udah ke sort semua, jadi ngga bingung tentang alphabetical order dalam search
        }
    }
}
