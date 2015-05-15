using System;
using System.IO;
using System.Collections.Generic;

using lab10.GraphStructure;

namespace lab10
{
    class Program
    {
        #region Constants

        const string TASK_1_INPUT_FILE = "Resources/GraphBinary.in";
        const string TASK_2_INPUT_FILE = "Resources/GraphDegree.in";

        const int flowSource = 0;
        const int flowDest = 12;

        const int NONE = -1;

        #endregion

        #region Do Your Magic

        public static List<int> DoBFS(Graph graph, int source, int sink)
        {
            /* Ne vom folosi de vectorul de parinti pentru 
             * a spune daca un nod a fost adaugat sau nu in coada. */
            var parent = new List<int>(graph.Size);

            for (int i = 0; i < graph.Size; i++)
                parent.Add(NONE);

            var queue = new List<int>();
            queue.Add(source);

            while (parent[sink] == NONE && queue.Count > 0)
            {
                var node = queue[0];
                queue.RemoveAt(0);

                for (int i = 0; i < graph.Size; i++)
                    if (graph.capacityMatrix[node][i] > 0 && parent[i] == NONE)
                    {
                        parent[i] = node;
                        queue.Add(i);
                    }
            }

            /* Daca nu s-a atins destinatia, atunci nu mai exista drumuri de crestere. */
            if (parent[sink] == NONE)
                return new List<int>(0);

            /* Reconstituim drumul de la destinatie spre sursa. */
            var path = new List<int>();

            for (int node = sink; ; node = parent[node])
            {
                /* 
                 * TODO
                 * 
                 * Adaugati nodul la drumul curent si verificati conditia de oprire 
                 */
            }
        }

        public static int SaturatePath(Graph graph, List<int> path)
        {
            /* Determinam fluxul maxim prin drum. */
            var flow = graph.capacityMatrix[path[0]][path[1]];

            for (int i = 0; i < path.Count - 1; i++)
            {
                var u = path[i];
                var v = path[i + 1];

                /* 
                 * TODO
                 * 
                 * Determinati fluxul in functie de capacitata muchiei (u, v) 
                 */
            }

            /* Si il saturam in graf. */
            for (int i = 0; i < path.Count - 1; i++)
            {
                var u = path[i];
                var v = path[i + 1];

                /* 
                 * TODO
                 * 
                 * Modificati fluxul in functie de capacitatea muchiei (u, v)
                 */
            }

            return flow;
        }

        public static int MaxFlow(Graph graph, int source, int sink)
        {
            var maxFlow = 0;

            /* Vom incerca in mod repetat sa determinam drumuri de crestere folosind BFS
             * si sa le saturam pana cand nu mai putem determina un astfel de drum in graf. */
            while (true)
            {
                /* Determina drum de crestere. */
                var newPath = DoBFS(graph, source, sink);

                /* 
                 * TODO
                 * 
                 * In functie de new_path determinati daca fluxul 
                 * trebuie marit sau trebuie iesit din while 
                 */
            }
        }

        public static void MinCut(Graph graph, int source, List<Pair> edgeSet)
        {
            /* Facem o parcurgere BFS din nodul sursa */
            var inQueue = new List<bool>();

            for (int i = 0; i < graph.Size; i++)
                inQueue.Add(false);

            var queue = new List<int>();

            queue.Add(source);
            inQueue[source] = true;

            /* Rulam BFS din sursa si marcam nodurile atinse. */
            while (queue.Count > 0)
            {
                var node = queue[0];
                queue.RemoveAt(0);

                for (int i = 0; i < graph.Size; ++i)
                    if (inQueue[i] == false && graph.capacityMatrix[node][i] > 0)
                    {
                        inQueue[i] = true;
                        queue.Add(i);
                    }
            }

            /* 
             * TODO
             * 
             * In functie de marcajele obtinute de la BFS-ul anterior 
             * determinati muchiile ce fac parte din taietura minima 
             */
        }

        static void ComputePath(Graph graph, int currentNode, bool[][] usedEdge, List<int> path)
        {
            path.Add(currentNode);

            /* 
             * TODO
             * 
             * Selctati o posibila urmatoare muchie care sa faca parte din
             * drumul curent si apelati recursiv ComputePath() 
             */
        }

        public static void DisjointPaths(Graph graph, int source, List<List<int>> paths)
        {
            var usedEdge = new bool[graph.Size][];

            for (int i = 0; i < graph.Size; i++)
                usedEdge[i] = new bool[graph.Size];

            for (int i = 0; i < graph.Size; i++)
                for (int j = 0; j < graph.Size; j++)
                    usedEdge[i][j] = false;

            for (int i = 0; i < graph.Size; i++)
                if (graph.IsSaturated(source, i))
                {
                    var newPath = new List<int>(graph.Size);
                    newPath.Add(source);

                    /* Incercam sa determinam un drum ce pleaca 
                     * spre sink pe directia (source, i) */
                    ComputePath(graph, i, usedEdge, newPath);

                    paths.Add(newPath);
                }
        }

        #endregion

        static void Main(string[] args)
        {
            #region First Problem

            var graph = new Graph(TASK_1_INPUT_FILE, GraphType.Directed);

            /* Calculam fluxul maxim de date care 
             * poate fi suportat de retea intre nodurile 0 si 12. */
            var flow = MaxFlow(graph, flowSource, flowDest);

            /* Calculam si afisam o taietura minimala a grafului. */
            var edgeSet = new List<Pair>();

            MinCut(graph, flowSource, edgeSet);

            Console.WriteLine("The minimum cut associated with the flow yields: ");

            foreach (var pair in edgeSet)
                Console.WriteLine(pair);

            Console.WriteLine("Maximum number of disjoint paths from source to sink {0}", flow);
            Console.WriteLine("A list a maximum number of disjoint paths from source to sink");

            var paths = new List<List<int>>();

            DisjointPaths(graph, flowSource, paths);

            for (int i = 0; i < paths.Count; i++)
            {
                Console.Write("Path {0}: ", (i + 1));

                foreach (int node in paths[i])
                    Console.Write("{0] ", node);

                Console.WriteLine();
            }

            #endregion

            #region Second Problem

            try
            {
                var lines = File.ReadAllLines(TASK_2_INPUT_FILE);

                int nodesCount = int.Parse(lines[0]);

                /* 
                 * Vom forma urmatorul graf:
                 *           o1       i1
                 *           o2       i2
                 *           .        .
                 * source    .        .     sink
                 *           .        .
                 *           on       in

                 * In partea stanga vom controla gradul de iesire al fiecarui nod -
                 * capacitatea de la source la oi va fi numarul maxim de muchii ce pot iesi
                 * din oi, adica exact gradul de iesire pe care acel nod il poate avea
                 * 
                 * In partea stanga vom controla gradul de intrare al fiecarui nod -
                 * capacitatea de la ii la sink va fi numarul maxim de muchii ce pot intra
                 * in ii, adica exact gradul de intrare pe care acel nod il poate avea.

                 * Pompand flux maxim, vom umple capacitatile, deci vom satisface conditiile
                 * pentru gradele de intrare si de iesire.
                 */

                /* 
                 * TODO
                 * 
                 * Creati-va structura de graph cu un numar de noduri corespunzatoare 
                 */

                for (int i = 1; i <= nodesCount; i++)
                {
                    var inDegree = int.Parse(lines[i].Split(' ')[0]);
                    var outDegree = int.Parse(lines[i].Split(' ')[1]);

                    /* 
                     * TODO
                     * 
                     * Adaugati muchiile corespunzatoare care sa reliefeze 
                     * gradul de intrare si de iesire al nodului curent */
                }

                for (int i = 1; i <= nodesCount; i++)
                    for (int j = 1; j <= nodesCount; j++)
                    {
                        /* 
                         * TODO
                         * 
                         * Adaugati muchiile corespunzatoare intre noduri 
                         */
                    }

                /* 
                 * TODO
                 * 
                 * Calculati fluxul maxim in graful creat 
                 */

                Console.WriteLine("List of possible edges: ");

                for (int i = 1; i <= nodesCount; i++)
                    for (int j = 1; j <= nodesCount; j++)
                    {
                        /* 
                         * TODO
                         * 
                         * Afisati muchiile gasite in urma algoritmului de flux 
                         */
                    }
            }
            catch (Exception)
            {
                Console.WriteLine("Fisierul de date nu este in regula !!");
            }

            #endregion
        }
    }
}
