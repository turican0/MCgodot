using Godot;
using System;
using System.Text.RegularExpressions;
//https://www.youtube.com/watch?v=OtfxxY4AeVQ
public partial class node_3d : Node3D
{
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

        //var customMesh = new GeneratedMesh();
        var customMesh = new MeshInstance3D();
        customMesh.Name = "testMesh";
        customMesh.Mesh = new BoxMesh();
        AddChild(customMesh);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
