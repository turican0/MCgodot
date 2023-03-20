@tool
extends MeshInstance3D

@export var update = false

# Called when the node enters the scene tree for the first time.
func _ready():
	gen_mesh();


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta):
	if update:
		gen_mesh()
		update = false
		
func gen_mesh():
	var st = SurfaceTool.new();
	
	var a_mesh = ArrayMesh.new();
	
	var v1 = Vector3(0, 0, 0);
	var v2 = Vector3(1, 0, 0);
	var v3 = Vector3(1, 0, 1);
	var v4 = Vector3(0, 0, 1);

	st.set_uv(Vector2(0, 0));
	st.AddColor(heightToColor(v1.y));
	st.add_vertex(v1);
	
	st.set_uv(Vector2(0, 1));
	st.AddColor(heightToColor(v2.y));
	st.add_vertex(v2);
	
	st.set_uv(Vector2(1, 1));
	st.AddColor(heightToColor(v3.y));
	st.add_vertex(v3);
	
	st.generate_normals();
	st.commit(a_mesh);
	
	"""
	var vertices := PackedVector3Array([
		Vector3(0,0,0),
		Vector3(1,0,0),
		Vector3(1,0,1),
		Vector3(0,0,1),
		]
		)
	var indicies := PackedInt32Array(
	[
		0,1,2,
		0,2,3
	]
	)
	var array = []
	array.resize(Mesh.ARRAY_MAX)
	array[Mesh.ARRAY_VERTEX] = vertices
	array[Mesh.ARRAY_INDEX] = indicies
	a_mesh.add_surface_from_arrays(Mesh.PRIMITIVE_TRIANGLES,array)
	"""
	mesh = a_mesh
	
		
		
