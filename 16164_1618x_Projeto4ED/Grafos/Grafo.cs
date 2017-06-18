using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace _16164_16187_Projeto4ED
{
    class Grafo
    {
        public const int NUM_VERTICES = 20;
        protected VerticeCidade[] vertices;
        protected int[,] adjMatrix;
        protected int numVerts;
        DataGridView dgv; // para exibir a matriz de adjacência num formulário

        public Grafo(DataGridView dgv)
        {
            this.dgv = dgv;
            vertices = new VerticeCidade[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            for (int j = 0; j < NUM_VERTICES; j++) // zera toda a matriz
                for (int k = 0; k < NUM_VERTICES; k++)
                    adjMatrix[j, k] = 0;
        }

        public void NovoVertice(string label, Cidade info)
        {
            vertices[numVerts] = new VerticeCidade(label, info);
            numVerts++;
            if (dgv != null) // se foi passado como parâmetro um dataGridView para exibição
            { // se realiza o seu ajuste para a quantidade de vértices
                dgv.RowCount = numVerts + 1;
                dgv.ColumnCount = numVerts + 1;
                dgv.Columns[numVerts].Width = 45;
            }
        }

        public void NovaAresta(int start, int eend)
        {
            adjMatrix[start, eend] = 1;
            // adjMatrix[eend, start] = 1; ISSO GERA CICLOS!!!
        }

        public void ExibirVertice(int v)
        {
            Console.Write(vertices[v].rotulo + " ");
        }

        public int SemSucessores() // encontra e retorna a linha de um vértice sem sucessores
        {
            bool temAresta;
            for (int linha = 0; linha < numVerts; linha++)
            {
                temAresta = false;
                for (int col = 0; col < numVerts; col++)
                    if (adjMatrix[linha, col] > 0)
                    {
                        temAresta = true;
                        break;
                    }
                if (!temAresta)
                    return linha;
            }
            return -1;
        }

        public void removerVertice(int vert)
        {
            if (dgv != null)
            {
            //    MessageBox.Show("Matriz de Adjacências antes de remover vértice " +
            //    Convert.ToString(vert));
                exibirAdjacencias();
                Thread.Sleep(1000);
                Application.DoEvents();
            }
            if (vert != numVerts - 1)
            {
                for (int j = vert; j < numVerts - 1; j++) // remove vértice do vetor
                    vertices[j] = vertices[j + 1];
                // remove vértice da matriz
                for (int row = vert; row < numVerts; row++)
                    moverLinhas(row, numVerts - 1);
                for (int col = vert; col < numVerts; col++)
                    moverColunas(col, numVerts - 1);
            }
            numVerts--;
            if (dgv != null)
            {
             //   MessageBox.Show("Matriz de Adjacências após remover vértice " +
             //   Convert.ToString(vert));
                exibirAdjacencias();
                Thread.Sleep(1000);
                Application.DoEvents();
             //   MessageBox.Show("Retornando à ordenação");
            }
        }
        private void moverLinhas(int row, int length)
        {
            if (row != numVerts - 1)
                for (int col = 0; col < length; col++)
                    adjMatrix[row, col] = adjMatrix[row + 1, col]; // desloca para excluir
        }
        private void moverColunas(int col, int length)
        {
            if (col != numVerts - 1)
                for (int row = 0; row < length; row++)
                    adjMatrix[row, col] = adjMatrix[row, col + 1]; // desloca para excluir
        }
        public void exibirAdjacencias()
        {
            dgv.RowCount = numVerts + 1;
            dgv.ColumnCount = numVerts + 1;
            for (int j = 0; j < numVerts; j++)
            {
                dgv.Rows[j + 1].Cells[0].Value = vertices[j].rotulo;
                dgv.Rows[0].Cells[j + 1].Value = vertices[j].rotulo;
                for (int k = 0; k < numVerts; k++)
                    dgv.Rows[j + 1].Cells[k + 1].Value = Convert.ToString(adjMatrix[j, k]);
            }
        }

        public String OrdenacaoTopologica()
        {
            Stack<String> gPilha = new Stack<String>(); // para guardar a sequência de vértices
            int origVerts = numVerts;
            while (numVerts > 0)
            {
                int currVertex = SemSucessores();
                if (currVertex == -1)
                    return "Erro: grafo possui ciclos.";
                gPilha.Push(vertices[currVertex].rotulo); // empilha vértice
                removerVertice(currVertex);
            }
            String resultado = "Sequência da Ordenação Topológica: ";
            while (gPilha.Count > 0)
                resultado += gPilha.Pop() + " "; // desempilha para exibir
            return resultado;
        }

        private int ObterVerticeAdjacenteNaoVisitado(int v)
        {
            for (int j = 0; j <= numVerts - 1; j++)
                if ((adjMatrix[v, j] == 1) && (!vertices[j].foiVisitado))
                    return j;
            return -1;
        }
        
        public void PercursoEmProfundidade(ref string saida)
        {
            vertices[0].foiVisitado = true;

            if (dgv != null)
            {
                exibirAdjacencias();
                dgv.CurrentCell = dgv.Rows[0+1].Cells[0];
                // MessageBox.Show("Vértice atual : " + part);
                Thread.Sleep(1000);
                Application.DoEvents();
            }
            saida = vertices[0].rotulo+" ";
            Stack<int> gPilha = new Stack<int>();
            gPilha.Push(0);
            int v;
            while (gPilha.Count > 0)
            {
                v = ObterVerticeAdjacenteNaoVisitado(gPilha.Peek());
                if (v == -1)
                    gPilha.Pop();
                else
                {
                    vertices[v].foiVisitado = true;

                    if (dgv != null)
                    {
                        exibirAdjacencias();
                        dgv.CurrentCell = dgv.Rows[v+1].Cells[0];
                        // MessageBox.Show("Vértice atual : " + part);
                        Thread.Sleep(1000);
                        Application.DoEvents();
                    }
                    saida += vertices[v].rotulo+" ";
                    gPilha.Push(v);
                }
            }
            for (int j = 0; j <= numVerts - 1; j++)
                vertices[j].foiVisitado = false;
        }

        public void PercursoEmLargura(ref string saida)
        {
            Queue<int> gQueue = new Queue<int>();
            vertices[0].foiVisitado = true;
            saida = vertices[0].rotulo;  // vértice inicial
            gQueue.Enqueue(0);           // enfileirar
            int vert1, vert2;
            while (gQueue.Count > 0)    // não está vazia
            {
                vert1 = gQueue.Dequeue();  // retirar
                vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
                while (vert2 != -1)
                {
                    vertices[vert2].foiVisitado = true;

                    if (dgv != null)
                    {
                        exibirAdjacencias();
                        dgv.CurrentCell = dgv.Rows[vert2 + 1].Cells[0];
                        // MessageBox.Show("Vértice atual : " + part);
                        Thread.Sleep(1000);
                        Application.DoEvents();
                    }

                    saida += " "+vertices[vert2].rotulo;
                    gQueue.Enqueue(vert2);
                    vert2 = ObterVerticeAdjacenteNaoVisitado(vert1);
                }
            }
            for (int i = 0; i < numVerts; i++)
                vertices[i].foiVisitado = false;
        }

        public void ArvoreGeradoraMinima(int primeiro, ref string saida)
        {
            saida = "";
            Stack<int> gPilha = new Stack<int>();
            vertices[primeiro].foiVisitado = true;
            gPilha.Push(primeiro);
            int currVertex, ver;
            while (gPilha.Count > 0)
            {
                currVertex = gPilha.Peek();
                ver = ObterVerticeAdjacenteNaoVisitado(currVertex);
                if (ver == -1)
                    gPilha.Pop();
                else
                {
                    vertices[ver].foiVisitado = true;
                    gPilha.Push(ver);
                    saida += " "+ vertices[currVertex].rotulo +"-->"+ vertices[ver].rotulo;

                    if (dgv != null)
                    {
                        exibirAdjacencias();
                        dgv.CurrentCell = dgv.Rows[ver + 1].Cells[0];
                        // MessageBox.Show("Vértice atual : " + part);
                        Thread.Sleep(1000);
                        Application.DoEvents();
                    }
                }
            }
            for (int j = 0; j <= numVerts - 1; j++)
                vertices[j].foiVisitado = false;
        }
        void processarNo(int i)
        {
            Console.Write(vertices[i].rotulo);
        }
        void PercursoEmProfundidadeRec(int part, ref string saida)
        {
            int i;
            saida += vertices[part].rotulo+" ";  // processarNo(part, saida);

            if (dgv != null)
            {
                exibirAdjacencias();
                dgv.CurrentCell = dgv.Rows[part + 1].Cells[0];
                // MessageBox.Show("Vértice atual : " + part);
                Thread.Sleep(1000);
                Application.DoEvents();
            }
            
            vertices[part].foiVisitado = true;
            for (i = 0; i < numVerts; ++i)
                if (adjMatrix[part, i] == 1 && !vertices[i].foiVisitado)
                    PercursoEmProfundidadeRec(i, ref saida);
        }

        public void PercursoProfundidadeRecursivo(ref string saida)
        {
            PercursoEmProfundidadeRec(0, ref saida);
        }
    }
}
