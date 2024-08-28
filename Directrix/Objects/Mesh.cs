/*********************************
 * Author(s): Thomas Applegate
 * Created: August 28, 2024
 * Last Updated: August 28, 2024
 ********************************/

using System.Numerics;
using System.Collections;

namespace Directrix.Objects;

public class Mesh
{
	private List<Vector3> m_verts;
	
	public List<Vector3> Verticies
	{
		get { return m_verts; }
		set { m_verts = new List<Vector3>(value); }
	}
	
	public Mesh()
	{
		m_verts = new();
	}
	
	public Mesh(List<Vector3> verts)
	{
		m_verts = new(verts);
	}
}
