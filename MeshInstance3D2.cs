using Godot;
using System;

public partial class MeshInstance3D2 : MeshInstance3D
{
	// Called when the node enters the scene tree for the first time.
	public bool update = false;

    [Export] public float minColorHeight = -1f, maxColorHeight = 10f;
    [Export]
    Color[] heightsColors = {
        new  Color(0.1f, 0.1f, 1f),//on inspector change colors: ocean dark blue to montain white snow
        new  Color(0.1f, 0.9f, 0.1f),
        new  Color(05f, 0.4f, 0.1f),
        new  Color(0.8f, 0.8f, 0.8f),
        new  Color(0.8f, 0.8f, 0.8f),
        new  Color(0.8f, 0.8f, 0.8f),
        new  Color(0.8f, 0.8f, 0.8f),
        new  Color(0.8f, 0.8f, 0.8f),
        new  Color(0.8f, 0.8f, 0.8f),
        new  Color(0.8f, 0.8f, 0.8f),
    };
    public override void _Ready()
	{
		gen_mesh();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (update)
		{
			gen_mesh();
			update = true;
		}
	}

    private Color heightToColor(float height)
    {

        //get color
        int colorsCount = heightsColors.Length;
        float value = Mathf.InverseLerp(minColorHeight, maxColorHeight, height);
        int indexColor = Mathf.Clamp(Mathf.RoundToInt(Mathf.Lerp(0, colorsCount - 1, value)), 0, colorsCount - 1);

        return heightsColors[indexColor];
    }

    private void gen_mesh()
    {
        ArrayMesh a_mesh = new ArrayMesh();

        SurfaceTool st = new SurfaceTool();
        /*
        Vector3 v1 = new Vector3(0, 0, 0);
        Vector3 v2 = new Vector3(1, 0, 0);
        Vector3 v3 = new Vector3(1, 0, 1);

        //tri1
        st.SetUV(new Vector2(0, 0));
        st.SetColor(heightToColor(v1.Y));// active albedoVertexColors on material
        st.AddVertex(v1);


        st.SetUV(new Vector2(0, 1));
        st.SetColor(heightToColor(v2.Y));
        st.AddVertex(v2);


        st.SetUV(new Vector2(1, 1));
        st.SetColor(heightToColor(v3.Y));
        st.AddVertex(v3);

        st.GenerateNormals();
        st.Commit(a_mesh);
        this.Mesh = a_mesh;*/

        //PhysicsRayQueryParameters3D p = new PhysicsRayQueryParameters3D();
        //var result = spaceState.IntersectRay(p);

        Vector3 v1 = new Vector3(0, 0, 0);
        Vector3 v2 = new Vector3(1, 0, 0);
        Vector3 v3 = new Vector3(1, 0, 1);

        a_mesh.ClearSurfaces();
        st.Clear();

        st.Begin(Mesh.PrimitiveType.Triangles);
        
        st.SetUV(new Vector2(0, 0));
        st.AddVertex(v1);

        st.SetUV(new Vector2(0, 1));
        st.AddVertex(v2);

        st.SetUV(new Vector2(1, 1));
        st.AddVertex(v3);

        st.Commit(a_mesh);

        this.Mesh = a_mesh;
    }
}
