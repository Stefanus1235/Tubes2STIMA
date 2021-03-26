using System;
using System.Collections.Generic;
using System.IO;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes_2
{
   
    public partial class Form1 : Form
    {
        private graph a = new graph();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            NamaFile.Text = openFileDialog1.FileName;
            string[] lines = System.IO.File.ReadAllLines(NamaFile.Text);
            a.nodes.Clear();
            foreach (string line in lines)
            {
                string[] y = line.Split(" ");
                if (!a.contain(y[0]))
                {
                    node temp = new node(y[0]);
                    a.addNode(temp);
                    if (!a.contain(y[1]))
                    {
                        node temp1 = new node(y[1]);
                        a.addNode(temp1);
                        temp.addAdj(temp1);
                    }
                    else
                    {
                        foreach (node i in a.nodes)
                        {
                            if (i.vertex == y[1])
                            {
                                temp.addAdj(i);
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < a.nodes.Count; i++)
                    {
                        if (a.nodes[i].vertex == y[0])
                        {
                            if (!a.contain(y[1]))
                            {
                                node temp1 = new node(y[1]);
                                a.addNode(temp1);
                                a.nodes[i].addAdj(temp1);
                            }
                            else
                            {
                                foreach (node j in a.nodes)
                                {
                                    if (j.vertex == y[1])
                                    {
                                        a.nodes[i].addAdj(j);
                                    }
                                }
                            }

                        }
                    }
                }

            }
            richTextBox1.Text = File.ReadAllText(NamaFile.Text);
            Awal.Items.Clear();
            Akhir.Items.Clear();
            Awal.Items.Add("NONE");
            Akhir.Items.Add("NONE");
            Awal.Text = "NONE";
            Akhir.Text = "NONE";
            foreach (node i in a.nodes)
            {
                Awal.Items.Add(i.vertex);
                Akhir.Items.Add(i.vertex);
            }

            GraphPanel.Controls.Clear();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            foreach(node i in a.nodes)
            {
                foreach(node j in a.nodes[a.searchIdxNode(i.vertex)].adjacent)
                {
                    graph.AddEdge(i.vertex, j.vertex);
                }
            }
            //bind the graph to the viewer 
            viewer.Graph = graph;

            //associate the viewer with the form 
            GraphPanel.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            GraphPanel.Controls.Add(viewer);
            GraphPanel.ResumeLayout();
            //show the form 
            GraphPanel.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if(Awal.Text == Akhir.Text || Awal.Text == "" || Awal.Text == "NONE")
            {} 
            else if (Akhir.Text == "NONE")
            {
                if (BFSrb.Checked)
                {
                    
                    a.friendRecommendation(Awal.Text, "BFS", richTextBox1);
                }
                else if (DFSrb.Checked)
                {

                    a.dfsrecommend(Awal.Text,richTextBox1);
                }
            }
            else
            {
                if (BFSrb.Checked)
                {
                    a.friendExplore(Awal.Text, Akhir.Text, "BFS", richTextBox1);
                }
                else if (DFSrb.Checked)
                {
                    a.friendExplore(Awal.Text, Akhir.Text, "DFS", richTextBox1);
                }
            }
        }
    }



    public static class flag
    {
        public static bool ketemu = false;
    }
    class graph
    {
        public List<node> nodes;
        public graph()
        {
            this.nodes = new List<node>();
        }

        public void addNode(node x)
        {
            Boolean isada = false;
            foreach(node i in this.nodes)
            {
                if (i.vertex == x.vertex)
                {
                    isada = true;
                }
            }
            if (!isada)
            {
                this.nodes.Add(x);
            }
        }

        public bool contain(string s)
        {
            if (this.nodes.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (node i in this.nodes)
                {
                    if (i.vertex == s)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public void Info()
        {
            foreach (node i in this.nodes)
            {
                Console.WriteLine(i.vertex);
            }
        }

        public void AllInfo(RichTextBox rtb)
        {
            foreach (node i in this.nodes)
            {
                i.printInfo(rtb);
            }
        }
        public void AllVertex()
        {
            Console.Write("[");
            for (int i = 0; i < this.nodes.Count; i++)
            {
                Console.Write(this.nodes[i].vertex);
                if (i != this.nodes.Count - 1)
                {
                    Console.Write(", ");
                }
            }
            Console.Write("]\n\n");
        }
        public void AllVertexWithArrow(RichTextBox rtb)
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                rtb.AppendText(this.nodes[i].vertex);
                if (i != this.nodes.Count - 1)
                {
                    rtb.AppendText(" -> ");
                }
            }
            rtb.AppendText("\n");
        }

        public int searchIdxNode(string s)
        {
            if (this.nodes.Count == 0)
            {
                return -1;
            }
            else
            {
                int j = -1;
                foreach (node i in this.nodes)
                {
                    j++;
                    if (i.vertex == s)
                    {
                        return j;
                    }
                }
                return -1;
            }
        }


        public graph bfs(string vertexawal, string vertextujuan)
        {
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

        public void bfsRekurs(int idxTrav, node tujuan, graph travelledNodes)
        {
            if (travelledNodes.contain(tujuan.vertex) || idxTrav == travelledNodes.nodes.Count)
            { }
            else
            {
                foreach (node i in travelledNodes.nodes[idxTrav].adjacent)
                {
                    if (travelledNodes.contain(tujuan.vertex))
                    {
                        break;
                    }
                    else if (travelledNodes.contain(i.vertex))
                    {
                        // Nothing
                    }
                    else
                    {
                        travelledNodes.addNode(i);
                    }
                }
                bfsRekurs(idxTrav + 1, tujuan, travelledNodes);
            }
        }


        public graph bfs(string vertexawal, string vertextujuan, graph strippedGraph)
        {
            node awal = this.nodes[searchIdxNode(vertexawal)];
            node tujuan = this.nodes[searchIdxNode(vertextujuan)];
            graph travelledNodes = new graph();
            graph parentsGraph = new graph();
            int idxTrav;
            if (awal.adjCount() != 0)
            // Kalau tidak trigger, return list node isi node awal saja
            {
                travelledNodes.addNode(awal);
                parentsGraph.addNode(this.nodes[searchIdxNode(vertexawal)]);
                idxTrav = 0;
                bfsRekurs(idxTrav, tujuan, travelledNodes, parentsGraph);

                int i = travelledNodes.nodes.Count - 1;
                while (i > 0)
                {
                    strippedGraph.nodes.Insert(0, travelledNodes.nodes[i]);
                    i = travelledNodes.searchIdxNode(parentsGraph.nodes[i].vertex);
                }
            }
            strippedGraph.nodes.Insert(0, travelledNodes.nodes[0]);
            return travelledNodes;
        }

        public void bfsRekurs(int idxTrav, node tujuan, graph travelledNodes, graph parentsGraph)
        {
            if (idxTrav == travelledNodes.nodes.Count || travelledNodes.contain(tujuan.vertex))
            { }
            else
            {
                foreach (node i in travelledNodes.nodes[idxTrav].adjacent)
                {
                    if (travelledNodes.contain(tujuan.vertex))
                    {
                        break;
                    }
                    else if (travelledNodes.contain(i.vertex))
                    {
                        // Nothing
                    }
                    else
                    {
                        travelledNodes.addNode(i);
                        parentsGraph.nodes.Add(travelledNodes.nodes[idxTrav]);
                    }
                }
                bfsRekurs(idxTrav + 1, tujuan, travelledNodes, parentsGraph);

            }
        }

        public graph bfs(string vertexawal, int dist)
        {
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
        public void bfsRekurs(int idxTrav, graph nodesOnDepth, graph travelledNodes, int dist, List<int> distList)
        {
            if (idxTrav == travelledNodes.nodes.Count || dist == 0)
            { }
            else
            {
                foreach (node i in travelledNodes.nodes[idxTrav].adjacent)
                {
                    if (travelledNodes.contain(i.vertex))
                    {
                        // Nothing
                    }
                    else if (distList[idxTrav] + 1 < dist)
                    {
                        travelledNodes.addNode(i);
                        distList.Add(distList[idxTrav] + 1);
                    }
                    else
                    {
                        nodesOnDepth.addNode(i);
                    }
                }
                bfsRekurs(idxTrav + 1, nodesOnDepth, travelledNodes, dist, distList);
            }
        }


        public graph dfs(string awal, string tujuan)
        {
            flag.ketemu = false;
            node node_awal = this.nodes[searchIdxNode(awal)];
            node node_tujuan = this.nodes[searchIdxNode(tujuan)];
            graph travelled_node = new graph();
            graph result = new graph();
            travelled_node.addNode(node_awal);
            dfs_rek(node_awal, node_tujuan, travelled_node, result);
            return result;
        }

        public void dfs_rek(node aktif, node tujuan, graph trav, graph result)
        {
            if (aktif == tujuan)
            {

                flag.ketemu = true;

                foreach (node i in trav.nodes)
                {
                    result.addNode(i);
                }
            }

            else if (flag.ketemu == false)
            {
                if (aktif.adjCount() == 0 || aktif.AllAdjVisited(trav))
                {
                    Console.WriteLine("Dead End");
                }
                else
                {
                    if (!trav.contain(tujuan.vertex))
                    {

                        foreach (node i in aktif.adjacent)
                        {
                            if (!flag.ketemu)
                            {
                                graph travelled = new graph();
                                foreach (node j in trav.nodes)
                                {
                                    travelled.addNode(j);
                                }

                                if (!travelled.contain(i.vertex))
                                {
                                    travelled.addNode(i);
                                    dfs_rek(i, tujuan, travelled, result);
                                    if (travelled.contain(tujuan.vertex))
                                    {
                                        return;
                                    }

                                }
                            }
                        }
                    }
                }
            }
        }

        public void dfsrecommend(string s, RichTextBox rtb)
        {
            graph g = new graph();
            foreach (node i in this.nodes)
            {
                g.addNode(i);
            }
            int aktif = g.searchIdxNode(s);
            node node_aktif = g.nodes[aktif];
            //copy adj
            graph adj_aktif = new graph();
            foreach (node i in node_aktif.adjacent)
            {
                adj_aktif.addNode(i);
            }
            graph friend_recommend = new graph();
            foreach (node i in g.nodes)
            {
                node temp = new node(i.vertex);
                if (temp.vertex != node_aktif.vertex && (!adj_aktif.contain(temp.vertex)))
                {
                    friend_recommend.addNode(temp);
                }
                foreach (node j in i.adjacent)
                {
                    int num = adj_aktif.searchIdxNode(j.vertex);
                    if (num != -1)
                    {
                        temp.addAdj(adj_aktif.nodes[num]);
                    }
                }
            }
            rtb.AppendText("Daftar rekomendasi teman untuk akun " + s + ":\n");
            Boolean HasRecom = false;
            foreach (node i in friend_recommend.nodes)
            {
                if (i.adjCount() > 0)
                {
                    HasRecom = true;
                }
            }
            if (HasRecom) {
                friend_recommend.sortGraphDescAdjCount();
                friend_recommend.AllInfo(rtb);
            }
            else
            {
                rtb.AppendText("Tidak ada yang cocok.\n");
            }

        }






        public graph getAllNodesWithMutualAdj(string nodeName, string method)
        {
            // METHOD INI SUDAH TERMASUK SORTING.

            // Cari node dengan nama nodeName
            node TheNode = this.nodes[searchIdxNode(nodeName)];

            // Graf yang akan direturn.
            graph nodesWithMutualAdjacent = new graph();
            if (method == "BFS")
            {
                nodesWithMutualAdjacent = this.bfs(nodeName, 2);
            }
            // DFS DIPISAH DI DFSREC

            // Sort
            for (int i = 0; i < nodesWithMutualAdjacent.nodes.Count; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < nodesWithMutualAdjacent.nodes.Count; j++)
                {
                    if (nodesWithMutualAdjacent.nodes[maxIdx].countMutualAdjacent(TheNode) < nodesWithMutualAdjacent.nodes[j].countMutualAdjacent(TheNode))
                    {
                        maxIdx = j;
                    }
                }
                node swap = nodesWithMutualAdjacent.nodes[i];
                nodesWithMutualAdjacent.nodes[i] = nodesWithMutualAdjacent.nodes[maxIdx];
                nodesWithMutualAdjacent.nodes[maxIdx] = swap;
            }
            return nodesWithMutualAdjacent;
        }

        public void friendRecommendation(string nodename, string method, RichTextBox rtb)
        {
            graph friendRec = new graph();
            friendRec = this.getAllNodesWithMutualAdj(nodename, method);
            rtb.AppendText("Daftar rekomendasi teman untuk akun " + nodename + ":\n");
            for (int i = 0; i < friendRec.nodes.Count; i++)
            {
                rtb.AppendText("Nama akun: "+friendRec.nodes[i].vertex+"\n");
                rtb.AppendText(friendRec.nodes[i].countMutualAdjacent(this.nodes[searchIdxNode(nodename)]) + " mutual friend");
                if (friendRec.nodes[i].countMutualAdjacent(this.nodes[searchIdxNode(nodename)]) > 1)
                {
                    rtb.AppendText("s");
                }
                rtb.AppendText(":\n");
                List<node> mutualFriends = friendRec.nodes[i].getAllMutualAdjacent(this.nodes[searchIdxNode(nodename)]);
                foreach (node j in mutualFriends)
                {
                    rtb.AppendText(j.vertex+"\n");
                }
                rtb.AppendText("\n");
            }
            if(friendRec.nodes.Count()==0)
            {
                rtb.AppendText("Tidak ada yang cocok.\n");
            }
        }

        public void friendExplore(string namaNodeAwal, string namaNodeTujuan, string method, RichTextBox rtb)
        {
            graph ExploreResult = new graph();
            if (method == "BFS")
            {
                graph dummy = this.bfs(namaNodeAwal, namaNodeTujuan, ExploreResult);
            }
            else if (method == "DFS")
            {
                ExploreResult = this.dfs(namaNodeAwal, namaNodeTujuan);
            }
            rtb.AppendText("Nama akun: "+namaNodeAwal+" dan "+ namaNodeTujuan+"\n");
            if (!ExploreResult.contain(namaNodeTujuan))
            {
                rtb.AppendText("Tidak ada jalur koneksi yang tersedia\n");
                rtb.AppendText("Anda harus memulai koneksi baru itu sendiri.\n");
            }
            else
            {
                rtb.AppendText((ExploreResult.nodes.Count-2).ToString());
                if (ExploreResult.nodes.Count - 2 == 1)
                {
                    rtb.AppendText("st");
                }
                else if (ExploreResult.nodes.Count - 2 == 2)
                {
                    rtb.AppendText("nd");
                }
                else if (ExploreResult.nodes.Count - 2 == 3)
                {
                    rtb.AppendText("rd");
                }
                else
                {
                    rtb.AppendText("th");
                }
                rtb.AppendText("-degree connection\n");
                ExploreResult.AllVertexWithArrow(rtb);
            }

        }

        public void sortGraphDescAdjCount ()
        {
            for (int i = 0; i < this.nodes.Count; i++)
            {
                int maxIdx = i;
                for (int j = i + 1; j < this.nodes.Count; j++)
                {
                    if (this.nodes[maxIdx].adjCount() < this.nodes[j].adjCount())
                    {
                        maxIdx = j;
                    }
                }
                if (maxIdx != i) { 
                    node swap = this.nodes[i];
                    this.nodes[i] = this.nodes[maxIdx];
                    this.nodes[maxIdx] = swap;
                }
            }
        }


    }

    class node
    {
        public string vertex;
        public List<node> adjacent;

        public node(string v)
        {
            this.vertex = v;
            this.adjacent = new List<node>();
        }

        public node(node x)
        {
            this.vertex = x.vertex;
            this.adjacent = new List<node>();
            foreach (node i in x.adjacent)
            {
                this.adjacent.Add(i);
            }
        }

        public bool AllAdjVisited(graph g)
        {
            foreach (node i in this.adjacent)
            {
                if (!g.contain(i.vertex))
                {
                    return false;
                }
            }
            return true;

        }

        public void printInfo(RichTextBox rtb)
        {
            
            if (this.adjacent.Count == 0)
            {
            }
            else
            {
                rtb.AppendText("Nama Akun : " + this.vertex + "\n");
                rtb.AppendText(this.adjacent.Count.ToString()+" mutual friend");
                if (this.adjacent.Count > 1)
                {
                    rtb.AppendText("s");
                }
                rtb.AppendText(":\n");
                foreach (node i in this.adjacent)
                {
                    rtb.AppendText(i.vertex+"\n");
                }
                rtb.AppendText("\n");
            }
        }

        public void addAdj(node x)
        {
            if (!this.containAdj(x)) { 
                this.adjacent.Add(x);
                if (!x.containAdj(this)) { 
                    x.adjacent.Add(this);
                }
            }
        }
        public int adjCount()
        {
            return this.adjacent.Count;
        }
        public bool containAdj(node x)
        {
            if (this.adjacent.Count == 0)
            {
                return false;
            }
            else { 
                foreach (node i in this.adjacent)
                {
                    if (i == x)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public List<node> getAllMutualAdjacent(node x)
        {
            List<node> mutualAdjacent = new List<node>();
            foreach (node i in x.adjacent)
            {
                foreach (node j in this.adjacent)
                {
                    if (i == j)
                    {
                        mutualAdjacent.Add(i);
                    }
                }
            }
            return mutualAdjacent;
        }
        public int countMutualAdjacent(node x)
        {
            int count = 0;
            foreach (node i in x.adjacent)
            {
                foreach (node j in this.adjacent)
                {
                    if (i == j)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
