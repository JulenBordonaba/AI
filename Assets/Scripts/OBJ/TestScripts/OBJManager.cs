using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Obj;
using AI.Pathfinding;
using ExtraUnityEvents;
using System.Reflection;

public class OBJManager : MonoBehaviour
{
    public static OBJFile file;

    public OBJFile model;
    public string path;

    [Header("Prefabs")]
    public GameObject vertexPrefab;
    public GameObject sidePrefab;

    public List<TestNode> fastestPath;


    private List<TestNode> nodes;

    [SerializeField]
    private AStarPathfinder pathfinder;

    private TestGraph graph;

    [SerializeField]
    string objAsString;

    

    private void Start()
    {
        LoadModel();
        pathfinder = new AStarPathfinder();
        file = model;
        InstantiateModel(model);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
#if UNITY_EDITOR
            ClearLog();
#endif
            graph.SetDestination(TestNode.DestinationNode);
            bool pathExists = false;
            pathfinder.GeneratePath(TestNode.StartNode, TestNode.DestinationNode, graph,out pathExists);
            graph.ResetView();
            if (pathExists)
            {
                StartCoroutine(GetPath(TestNode.StartNode, TestNode.DestinationNode));
            }
        }
    }

    private void DrawPath(List<TestNode> _path)
    {
        for (int i = 0; i < _path.Count-1; i++)
        {
            _path[i].view.SetAsPath();
            TestConnection aux = (TestConnection)_path[i].ConnectionDictionary[_path[i + 1]];
            aux.isPath.Value = true;
        }
    }
#if UNITY_EDITOR
    public void ClearLog() //you can copy/paste this code to the bottom of your script
    {
        var assembly = Assembly.GetAssembly(typeof(UnityEditor.Editor));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }
#endif

    private IEnumerator GetPath(TestNode start, TestNode destination)
    {
        yield return null;
        TestNode aux = destination;

        List<TestNode> _path = new List<TestNode>();

        _path.Add(aux);
        
        while (aux.Parent!=null)
        {
            print(aux + " " + aux.Parent);

            TestNode aux2 = (TestNode)aux.Parent;

            aux = aux2;
            _path.Add(aux);
            
        }
        
        _path.Reverse();

        foreach(TestNode n in _path)
        {
            print(n);
        }

        fastestPath = _path;


        DrawPath(fastestPath);

    }
    
    public void LoadModel()
    {
        model = new OBJFile();
        model.LoadFromString(objAsString);
    }
#if UNITY_EDITOR
    [ContextMenu("Save Model")]
    public void LoadModelAsJson()
    {
        model = new OBJFile();
        objAsString = model.GetGetDataAsString(path);
        model = null;
    }
#endif
    public void InstantiateModel(OBJFile model)
    {
        nodes = new List<TestNode>();
        foreach (Vector3 v in model.vertexPositions)
        {
            GameObject vertex = Instantiate(vertexPrefab, v, Quaternion.identity);

            VertexView ver = vertex.GetComponent<VertexView>();

            TestNode testNode = new TestNode(ver);

            nodes.Add(testNode);
        }

        foreach (Face tri in model.faces)
        {
            GameObject connection1 = Instantiate(sidePrefab, Vector3.zero, Quaternion.identity);
            GameObject connection2 = Instantiate(sidePrefab, Vector3.zero, Quaternion.identity);
            GameObject connection3 = Instantiate(sidePrefab, Vector3.zero, Quaternion.identity);

            ConnectionView conn1 = connection1.GetComponent<ConnectionView>();
            ConnectionView conn2 = connection2.GetComponent<ConnectionView>();
            ConnectionView conn3 = connection3.GetComponent<ConnectionView>();

            conn1.SetConection(tri.vertices[0].position, tri.vertices[1].position);
            conn2.SetConection(tri.vertices[0].position, tri.vertices[2].position);
            conn3.SetConection(tri.vertices[1].position, tri.vertices[2].position);

        }

        graph = new TestGraph(nodes, ConnectionView.conections);
        graph.GenerateGraphConections();

    }


    public void DrawFace(GameObject vertexObject, GameObject sideObject)
    {

    }

    public static Vector3 modelCenter
    {
        get
        {
            return file.Center;
        }
    }

}

