using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace _16164_16187_Projeto4ED
{
    class GrafoCidades
    {
        public const int NUM_VERTICES = 100;
        protected VerticeCidade[] vertices;
        protected int[,] adjMatrix;
        protected int numVerts;
        DataGridView dgv; // para exibir a matriz de adjacência num formulário

        public GrafoCidades(DataGridView dgv)
        {
            this.dgv = dgv;
            vertices = new VerticeCidade[NUM_VERTICES];
            adjMatrix = new int[NUM_VERTICES, NUM_VERTICES];
            numVerts = 0;
            for (int j = 0; j < NUM_VERTICES; j++) // zera toda a matriz
                for (int k = 0; k < NUM_VERTICES; k++)
                    adjMatrix[j, k] = 0;
        }

        /// <summary>
        /// Percorre todas as cidades e as desenha na posição correta do Panel passado por parâmetro
        /// </summary>
        /// <param name="panel">Panel a ser desenhado</param>
        public void ExibirCidades (Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < numVerts; i++)
            {
                Cidade atual = vertices[i].Info;
                g.DrawEllipse(new Pen(Color.Black, 5F), (float)atual.RazaoX * panel.Width - 2.5F, (float)atual.RazaoY * panel.Height - 2.5F, 5F, 5F);
                SizeF tamanhoF = g.MeasureString(atual.ToString(), new Font(FontFamily.GenericSansSerif, 12F));
                g.DrawString(atual.ToString(), new Font(FontFamily.GenericSansSerif, 12F), Brushes.Black, (float)atual.RazaoX * panel.Width - tamanhoF.Width / 2, (float)atual.RazaoY * panel.Height - tamanhoF.Height);
            }
        }

        /// <summary>
        /// Desenha os caminhos entre as cidades e indica suas distâncias
        /// </summary>
        /// <param name="panel">Panel a ser desenhado</param>
        public void ExibirCaminhos(Panel panel)
        {
            Graphics g = panel.CreateGraphics();
            g.Clear(Color.White);
            Pen p = new Pen(Color.Gray, 3);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(5, 5); // Desenha as linhas com uma seta no final
            p.CustomEndCap = bigArrow;
            for (int i = 0; i < numVerts; i++)
                for (int j = 0; j < numVerts; j++)
                {
                    if (adjMatrix[i, j] != 0)
                    {
                        float x1 = (float)vertices[i].Info.RazaoX * panel.Width;
                        float y1 = (float)vertices[i].Info.RazaoY * panel.Height;
                        float x2 = (float)vertices[j].Info.RazaoX * panel.Width;
                        float y2 = (float)vertices[j].Info.RazaoY * panel.Height;
                        g.DrawLine(p, x1, y1, x2, y2);
                        g.DrawString(adjMatrix[i, j].ToString(), new Font(FontFamily.GenericSansSerif, 12F, FontStyle.Bold), Brushes.Black, (x1 + x2) / 2, (y1 + y2) / 2);
                    }
                }
            
            for (int i = 0; i < numVerts; i++) // Desenha as cidades por cima dos caminhos
            {
                Cidade atual = vertices[i].Info;
                g.DrawEllipse(new Pen(Color.Black, 5F), (float)atual.RazaoX * panel.Width - 2.5F, (float)atual.RazaoY * panel.Height - 2.5F, 5F, 5F);
                SizeF tamanhoF = g.MeasureString(atual.ToString(), new Font(FontFamily.GenericSansSerif, 12F));
                g.DrawString(atual.ToString(), new Font(FontFamily.GenericSansSerif, 12F), Brushes.Black, (float)atual.RazaoX * panel.Width - tamanhoF.Width / 2, (float)atual.RazaoY * panel.Height - tamanhoF.Height);
            }
        }

        /// <summary>
        /// Retorna o indíce de uma cidade no vetor de vértices a partir de seu nome
        /// </summary>
        /// <param name="nomeCidade">Nome da cidade a ser procurada</param>
        /// <returns>O indíce da cidade no vetor de vértices, se ela já tiver sido incluída, e -1 caso ainda não tenha sido incluída</returns>
        protected int IndiceDe(String nomeCidade)
        {
            nomeCidade = nomeCidade.Trim();
            for (int i = 0; i < numVerts; i++)
                if (vertices[i].rotulo == nomeCidade)
                    return i;

            return -1;
        }

        /// <summary>
        /// Retorna a distância da conexão direta entre duas cidades
        /// </summary>
        /// <param name="cid1">Cidade de partida</param>
        /// <param name="cid2">Cidade destino</param>
        /// <returns>A distância entre as duas cidades ou -1 se alguma das cidades não estiver cadastrada</returns>
        public int ConexaoDiretaEntre (String cid1, String cid2)
        {
            int cidade1 = IndiceDe(cid1);
            int cidade2 = IndiceDe(cid2);
            if (cidade1 < 0 || cidade2 < 0)
                return -1;
            return adjMatrix[cidade1, cidade2];
        }

        /// <summary>
        /// Busca o melhor caminho possível entre duas cidades usando Backtracking iterativo
        /// </summary>
        /// <param name="cidadeOrigem">Cidade de partida</param>
        /// <param name="cidadeDestino">Cidade destino</param>
        /// <returns>Pilha com todos os trajetos necessários para chegar de uma cidade a outra. Se retornar nula, não existe caminho entre as duas cidades</returns>
        public Stack<Movimento> BacktrackingMelhorCaminho(string cidadeOrigem, string cidadeDestino)
        {
            for (int i = 0; i < numVerts; i++)
                vertices[i].foiVisitado = false;
            Stack<Movimento> result = new Stack<Movimento>();

            Stack<Movimento> p = new Stack<Movimento>();
            bool achou = false;
            int cidadeAtual;
            int saidaAtual = 0;
            cidadeAtual = IndiceDe(cidadeOrigem);
            while (!(cidadeAtual == IndiceDe(cidadeOrigem) && saidaAtual == numVerts && p.Count <= 0))
            { // só sai do while quando tiver tentado todos os caminhos
                while (saidaAtual < numVerts && !achou)
                {
                    if (adjMatrix[cidadeAtual, saidaAtual] == 0) // se não houver conexão entre a cidadeAtual e a saidaAtual
                        saidaAtual++; // tenta a próxima saída
                    else
                        if (vertices[saidaAtual].foiVisitado) // Se já tentamos a saidaAtual
                            saidaAtual++; // tenta a próxima saída
                    else
                        if (saidaAtual == IndiceDe(cidadeDestino)) // Se chegamos aonde queríamos
                        {
                            Movimento movim = new Movimento();
                            movim.setValores(cidadeAtual, saidaAtual);
                            p.Push(movim);
                            achou = true; // achamos uma das possíveis rotas
                        }
                        else
                        {
                            Movimento movim = new Movimento();
                            movim.setValores(cidadeAtual, saidaAtual);
                            p.Push(movim); // adicionamos o último movimento
                            vertices[cidadeAtual].foiVisitado = true;
                            cidadeAtual = saidaAtual; // vamos para a saidaAtual
                            saidaAtual = 0; // procuramos novamente por novas saídas
                        }
                }
                if (!achou)
                {
                    if (p.Count > 0)
                    {
                        Movimento movim = (Movimento)p.Pop();
                        saidaAtual = movim.getSaida();
                        cidadeAtual = movim.getCidade();
                        movim = null;
                        saidaAtual++;
                    }
                }
                else // se achou um novo caminho, mede sua eficiência e se for melhor, o coloca na pilha de resultado
                {
                    Stack<Movimento> aux = new Stack<Movimento>();
                    double distanciaI = 0;
                    if (result.Count == 0)
                        distanciaI = double.MaxValue;
                    while (result.Count > 0)
                    {
                        Movimento mov = result.Pop();
                        distanciaI += adjMatrix[mov.getCidade(), mov.getSaida()];
                        aux.Push(mov);
                    }
                    while (aux.Count > 0)
                        result.Push(aux.Pop());
                    double criterioNovo = 0;
                    while (p.Count > 0)
                    {
                        Movimento mov = p.Pop();
                        criterioNovo += adjMatrix[mov.getCidade(), mov.getSaida()];
                        aux.Push(mov);
                    }
                    while (aux.Count > 0)
                        p.Push(aux.Pop());

                    if (criterioNovo <= distanciaI)
                    {
                        aux = new Stack<Movimento>();
                        result = new Stack<Movimento>();
                        while (p.Count > 0)
                            aux.Push(p.Pop());
                        while (aux.Count > 0)
                        {
                            Movimento mov = aux.Pop();
                            result.Push(mov);
                            p.Push(mov);
                        }
                    }

                    if (p.Count > 0)
                    {
                        Movimento movim = (Movimento)p.Pop();
                        saidaAtual = movim.getSaida();
                        cidadeAtual = movim.getCidade();
                        movim = null;
                        saidaAtual++;
                    }
                    achou = false;
                }
            }
            return result;
        }

        /// <summary>
        /// Busca o melhor caminho possível entre duas cidades usando recursão
        /// </summary>
        /// <param name="cidadeOrigem">Cidade de partida</param>
        /// <param name="cidadeDestino">Cidade destino</param>
        /// <returns>Pilha com todos os trajetos necessários para chegar de uma cidade a outra. Se retornar vazia, não existe caminho entre as duas cidades</returns>
        public Stack<Movimento> RecursaoMelhorCaminho(string cidadeOrigem, string cidadeDestino)
        {
            // Prepara para a recursão
            for (int i = 0; i < numVerts; i++)
                vertices[i].foiVisitado = false;

            return RecursaoMelhorCaminho(IndiceDe(cidadeOrigem), IndiceDe(cidadeDestino));
        }

        /// <summary>
        /// Overload utilizada por sua versão pública para encontrar recursivamente o melhor caminho
        /// </summary>
        /// <param name="cidadeOrigem">Índice da cidade de partida</param>
        /// <param name="cidadeDestino">Índice da cidade de destino</param>
        /// <returns>Pilha com todos os trajetos necessários para chegar de uma cidade a outra. Se retornar vazia, não existe caminho entre as duas cidades</returns>
        protected Stack<Movimento> RecursaoMelhorCaminho(int cidadeOrigem, int cidadeDestino)
        {
            double custo = double.MaxValue;
            Stack<Movimento> ret = new Stack<Movimento>();

            vertices[cidadeOrigem].foiVisitado = true; // Evita que suas chamadas filhas voltem de cidade e entrem em loop

            // Caso haja conexão direta entre a cidade atual e a cidade de destino e esta conexão for melhor que o melhor caminho até agora,
            // a consideramos o melhor caminho
            if (adjMatrix[cidadeOrigem, cidadeDestino] != 0)
            {
                Movimento m = new Movimento();
                m.setValores(cidadeOrigem, cidadeDestino);
                ret.Push(m);

                custo = adjMatrix[cidadeOrigem, cidadeDestino];
            }
                

            for (int saidaAtual = 0; saidaAtual < numVerts; saidaAtual++) // Testa o melhor caminho por todas as saídas
            {
                if (adjMatrix[cidadeOrigem, saidaAtual] == 0) // Não há saída da cidade de origem pela saidaAtual
                    continue;

                // Nunca passa duas vezes pelo mesmo local. Serve como condição de saída, já que, caso todas as saídas já tenham sido visitadas,
                // o método não se chama novamente.
                if (vertices[saidaAtual].foiVisitado)
                    continue;

                if (saidaAtual == cidadeDestino) // Esta condição já fora tratada fora do for
                    continue;

                Stack<Movimento> caminhoEncontrado = RecursaoMelhorCaminho(saidaAtual, cidadeDestino);

                if (caminhoEncontrado.Count <= 0) // Caso não encontrou caminho, a saída nem precisa ser avaliada
                    continue;

                // Avalia a eficácia do caminho
                Stack<Movimento> aux = new Stack<Movimento>();
                double custoAtual = 0;
                while (caminhoEncontrado.Count > 0)
                {
                    Movimento m = caminhoEncontrado.Pop();
                    custoAtual += adjMatrix[m.getCidade(), m.getSaida()];
                    aux.Push(m);
                }

                custoAtual += adjMatrix[cidadeOrigem, saidaAtual];

                // Se o caminho encontrado for o melhor até agora, o armazenamos
                if (custoAtual < custo) 
                {
                    ret.Clear();

                    // Adiciona o trajeto da cidade de origem ate a saída onde se inicia o caminho
                    Movimento m = new Movimento();
                    m.setValores(cidadeOrigem, saidaAtual);
                    ret.Push(m);

                    while (aux.Count > 0) // Restaura o caminho encontrado, em ordem, na pilha de retorno
                        ret.Push(aux.Pop());

                    custo = custoAtual;
                }
            }

            vertices[cidadeOrigem].foiVisitado = false; // Faz isso para permitir que outras chamadas (anteriores) utilizem aquele vértice

            return ret;
        }

        /// <summary>
        /// Busca o melhor caminho possível entre duas cidades usando o algorítmo iterativo de Dijkstra
        /// </summary>
        /// <param name="cidadeOrigem">Cidade de origem</param>
        /// <param name="cidadeDestino"> Cidade destino</param>
        /// <returns>Pilha com todos os trajetos necessários para chegar de uma cidade a outra. Se retornar vazia, não existe caminho entre as duas cidades</returns>
        public Stack<Movimento> DijkstraMelhorCaminho(string cidadeOrigem, string cidadeDestino)
        {
            Dictionary<int, int> trajeto = new Dictionary<int, int>(); // Cidade atual, cidade anterior
            int iCidadeDestino = IndiceDe(cidadeDestino);

            double[] distancias = new double[numVerts];

            for (int i=0; i< numVerts; i++) // Inicializa todas as distâncias com infinito
            {
                distancias[i] = double.MaxValue;
                vertices[i].foiVisitado = false;
            }

            int cidadeAtual = IndiceDe(cidadeOrigem);

            distancias[cidadeAtual] = 0; // A distância do início até ele mesmo é 0

            for (int visitados = 0; visitados < numVerts; visitados++) // Visita todos os vértices
            {
                // Seleciona o próximo vértice a ser processado, pelo critério de menor distância
                int custoAtual = int.MaxValue;
                for (int i=0; i < numVerts; i++)
                {
                    if (vertices[i].foiVisitado)
                        continue;

                    if (distancias[i] < custoAtual)
                        cidadeAtual = i;
                }

                vertices[cidadeAtual].foiVisitado = true;

                for (int saidaAtual = 0; saidaAtual < numVerts; saidaAtual++) // Percorre as conexões da cidade atual
                {
                    if (adjMatrix[cidadeAtual, saidaAtual] == 0) // Caso não haja conexão entre as duas cidades
                        continue;

                    double dist = distancias[cidadeAtual] + adjMatrix[cidadeAtual, saidaAtual];

                    if (dist < distancias[saidaAtual]) // Se encontrar um caminho ainda mais curto do atual, atualiza no vetor
                    {
                        distancias[saidaAtual] = dist;
                        trajeto[saidaAtual] = cidadeAtual; // A cidade anterior à saidaAtual é cidadeAtual
                    }
                }
            }

            // Interpreta o vetor de trajeto
            Movimento m;
            Stack<Movimento> ret = new Stack<Movimento>();
            
            cidadeAtual = iCidadeDestino;
            while (trajeto.ContainsKey(cidadeAtual))
            {
                m = new Movimento();
                m.setValores(trajeto[cidadeAtual], cidadeAtual);
                ret.Push(m);

                cidadeAtual = trajeto[cidadeAtual];
            }

            return new Stack<Movimento>(ret);
        }

        public void NovoVertice(Cidade info)
        {
            vertices[numVerts] = new VerticeCidade(info);
            numVerts++;
            if (dgv != null) // se foi passado como parâmetro um dataGridView para exibição
            { // se realiza o seu ajuste para a quantidade de vértices
                dgv.RowCount = numVerts + 1;
                dgv.ColumnCount = numVerts + 1;
                dgv.Columns[numVerts].Width = 45;
            }
        }

        /// <summary>
        /// Adiciona uma nova conexão entre as cidades indicadas com a distância recebida
        /// </summary>
        /// <param name="start">Indíce da cidade de partida</param>
        /// <param name="eend">Indíce da cidade destino</param>
        /// <param name="distancia">Distância entre as duas cidades</param>
        public void NovaAresta(int start, int eend, int distancia)
        {
            if (distancia <= 0)
                throw new Exception("Distância inválida!");

            adjMatrix[start, eend] = distancia;
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
                dgv.CurrentCell = dgv.Rows[0 + 1].Cells[0];
                // MessageBox.Show("Vértice atual : " + part);
                Thread.Sleep(1000);
                Application.DoEvents();
            }
            saida = vertices[0].rotulo + " ";
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
                        dgv.CurrentCell = dgv.Rows[v + 1].Cells[0];
                        // MessageBox.Show("Vértice atual : " + part);
                        Thread.Sleep(1000);
                        Application.DoEvents();
                    }
                    saida += vertices[v].rotulo + " ";
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

                    saida += " " + vertices[vert2].rotulo;
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
                    saida += " " + vertices[currVertex].rotulo + "-->" + vertices[ver].rotulo;

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
            saida += vertices[part].rotulo + " ";  // processarNo(part, saida);

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
