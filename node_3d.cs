using Godot;
using Godot.Collections;
using Godot.NativeInterop;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
//https://www.youtube.com/watch?v=OtfxxY4AeVQ
//https://www.youtube.com/watch?v=8wy_dH9RLI4
//https://www.youtube.com/watch?v=EEo5cuwjYhA

[Tool]
public partial class node_3d : Node3D
{
    private int _rings = 50;
    private int _radialSegments = 50;
    private int _height = 1;
    private int _radius = 1;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
		var camera = new Camera3D();
		camera.Name = "Camera 2";
		AddChild(camera);



		var testObject = new Node3D();
        testObject.Name = "test node";
        var scene = (PackedScene)ResourceLoader.Load("res://art/mob.glb");
        Node3D sceneInst = (Node3D)scene.Instantiate();
        testObject.AddChild(sceneInst);
        AddChild(testObject);

        var testObject2 = new Node3D();
        testObject2.Name = "test node2";
        var scene2 = (PackedScene)ResourceLoader.Load("res://art/mob.glb");
        Node3D sceneInst2 = (Node3D)scene2.Instantiate();
        testObject2.AddChild(sceneInst2);
        AddChild(testObject2);
        /*
        var surfaceArray = new Godot.Collections.Array();
        surfaceArray.Resize((int)ArrayMesh.ArrayType.Max);

        var verts = new Godot.Collections.Array<Vector3>();
        var uvs = new Godot.Collections.Array<Vector2>();
        var normals = new Godot.Collections.Array<Vector3>();
        var indices = new Godot.Collections.Array<int>();

        var currentRow = 0;
        var previousRow = 0;
        var point = 0;

        for (int i = 0; i < _rings + 1; i++)
        {
            var v = i / (float)_rings;
            var w = Mathf.Sin(Mathf.Pi * v);
            var y = Mathf.Cos(Mathf.Pi * v);

            for (int j = 0; j < _radialSegments; j++)
            {
                var u = j / (float)_radialSegments;
                var x = Mathf.Sin(Mathf.Pi * u * 2.0f);
                var z = Mathf.Cos(Mathf.Pi * u * 2.0f);
                var vert = new Vector3(x * _radius * w, y, z * _radius * w);

                verts.Add(vert);
                normals.Add(vert.Normalized());
                uvs.Add(new Vector2(u, v));
                point += 1;

                if (i > 0 && j > 0)
                {
                    indices.Add(previousRow + j - 1);
                    indices.Add(previousRow + j);
                    indices.Add(currentRow + j - 1);

                    indices.Add(previousRow + j);
                    indices.Add(currentRow + j);
                    indices.Add(currentRow + j - 1);
                }
            }

            if (i > 0)
            {
                indices.Add(previousRow + _radialSegments - 1);
                indices.Add(previousRow);
                indices.Add(currentRow + _radialSegments - 1);
                indices.Add(previousRow);
                indices.Add(previousRow + _radialSegments);
                indices.Add(currentRow + _radialSegments - 1);
            }

            previousRow = currentRow;
            currentRow = point;
        }

        surfaceArray[(int)Mesh.ArrayType.Vertex] = verts;
        surfaceArray[(int)Mesh.ArrayType.TexUV] = uvs;
        surfaceArray[(int)Mesh.ArrayType.Normal] = normals;
        surfaceArray[(int)Mesh.ArrayType.Index] = indices;

        var arrayMesh = new ArrayMesh();
        arrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, surfaceArray);
        */
        //Mesh = arrayMesh;
        /*
        //var customMesh = new GeneratedMesh();
        var a_mesh = new ArrayMesh();
        var vertices = new List<Vector3>();
        vertices.Add(new Vector3(0, 0, 0));
        vertices.Add(new Vector3(1, 0, 0));
        vertices.Add(new Vector3(1, 0, 1));
        var indices = new List<int>();
        indices.Add(0);
        indices.Add(1);
        indices.Add(2);

        var arrays = [];
        arrays.resize(Mesh.ARRAY_MAX)
        arrays[Mesh.ARRAY_VERTEX] = vertex_array
        arrays[Mesh.ARRAY_NORMAL] = normal_array
        arrays[Mesh.ARRAY_TEX_UV] = uv_array
        arrays[Mesh.ARRAY_INDEX] = index_array
        a_mesh.AddSurfaceFromArrays(vertices, indices);

        surfaceArray[(int)Mesh.ArrayType.Vertex] = verts.ToArray();
        surfaceArray[(int)Mesh.ArrayType.TexUv] = uvs.ToArray();
        surfaceArray[(int)Mesh.ArrayType.Normal] = normals.ToArray();
        surfaceArray[(int)Mesh.ArrayType.Index] = indices.ToArray();

        var arrayMesh = new ArrayMesh();
        arrayMesh.AddSurfaceFromArrays(Mesh.PrimitiveType.Triangles, surfaceArray);
        Mesh = arrayMesh;*/

        /*
        var customMesh = new MeshInstance3D();
        customMesh.Name = "testMesh";
        customMesh.Mesh = arrayMesh;
        //customMesh.Mesh = new BoxMesh();
        AddChild(customMesh);
        */
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
