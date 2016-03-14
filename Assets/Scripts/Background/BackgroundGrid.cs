//Author Jesse Stam
//Date 14-03-2016
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackgroundGrid : MonoBehaviour
{

    [SerializeField]
    float offSetY;

    [SerializeField]
    float lineWidth = 0.05f;

    [SerializeField]
    int linesX = 40;

    [SerializeField]
    float MaxZDepth = -10;

    [SerializeField]
    float MoveSpeed = 1;

    //need a better name
    [SerializeField]
    Vector2 GridDensity = new Vector2(1.5f,1.5f);

    [SerializeField]
    Material lineMaterial;

    List<Line> LinesOnX;
    List<Line> LinesOnZ;

    // Use this for initialization
    void Start()
    {
        transform.position = Vector3.zero;

        LinesOnX = new List<Line>();
        LinesOnZ = new List<Line>();

        Line lin;
        GameObject game;
        LineRenderer rndr;

        //creating Lines for the X Axis. They won't move
        for (int i = 0; i < linesX; i++)
        {
            game = new GameObject();
            game.name = "Line on X " + i.ToString();
            game.transform.SetParent(transform, false);
            rndr = game.AddComponent<LineRenderer>();
            rndr.materials = new Material[] { lineMaterial };

            lin = new Line(game.transform, rndr);

            lin.renderer.SetPosition(0, new Vector3((i - (linesX / 2f)) * GridDensity.x, offSetY, -100));
            lin.renderer.SetPosition(1, new Vector3((i - (linesX / 2f)) * GridDensity.x, offSetY, 100));
            lin.renderer.SetWidth(lineWidth, lineWidth);

            LinesOnX.Add(lin);
        }

        //creating lines for the Z Axis. They will be moving
        for (int i = 0; i < 40; i++)
        {
            game = new GameObject();
            game.name = "Line on Z " + i.ToString();
            game.transform.SetParent(transform, false);
            rndr = game.AddComponent<LineRenderer>();
            rndr.materials = new Material[] { lineMaterial };

            lin = new Line(game.transform, rndr);

            lin.renderer.SetPosition(0, new Vector3((linesX - 1) * GridDensity.x / -2f, offSetY, 0));
            lin.renderer.SetPosition(1, new Vector3((linesX - 1) * GridDensity.x / 2f, offSetY, 0));
            lin.renderer.SetWidth(lineWidth, lineWidth);
            lin.renderer.useWorldSpace = false;

            lin.transform.position = new Vector3(0,0, (i * GridDensity.y) + MaxZDepth);

            LinesOnZ.Add(lin);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //moves the lines over the screen
    void Move()
    {
        Line SelectedLine;
        for (int i = 0; i < LinesOnZ.Count; i++)
        {
            SelectedLine = LinesOnZ[i];

            if (SelectedLine.transform.localPosition.z < MaxZDepth)
                SelectedLine.transform.position += new Vector3(0, 0, (LinesOnZ.Count * GridDensity.y) + MaxZDepth);

            SelectedLine.transform.Translate(new Vector3(0, 0, MoveSpeed) * Time.deltaTime);
        }
    }

    [System.Serializable]
    struct Line
    {
        public Transform transform;
        public LineRenderer renderer;

        public Line(Transform transform, LineRenderer renderer)
        {
            this.transform = transform;
            this.renderer = renderer;
        }
    }
}
