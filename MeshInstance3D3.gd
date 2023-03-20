extends MeshInstance3D


# Called when the node enters the scene tree for the first time.
func _ready():
	var arr = []
	arr.resize(Mesh.ARRAY_MAX)
	
	var verts = PackedVector3Array()
	var uvs = PackedVector2Array()
	var normals = PackedVector3Array()
	var indices = PackedInt32Array()
	var vert
	
	vert=Vector3(1.0,1.0,1.0)
	verts.append(vert)
	normals.append(vert.normalized())
	
	# Assign arrays to mesh array.
	arr[Mesh.ARRAY_VERTEX] = verts
	arr[Mesh.ARRAY_TEX_UV] = uvs
	arr[Mesh.ARRAY_NORMAL] = normals
	arr[Mesh.ARRAY_INDEX] = indices

	# Create mesh surface from mesh array.
	var tempmesh = Mesh.new()
	tempmesh.add_surface_from_arrays(Mesh.PRIMITIVE_TRIANGLES, arr) # No blendshapes or compression used.
	mesh = tempmesh
	pass



# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
