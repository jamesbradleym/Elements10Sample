using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements10Sample;
using Newtonsoft.Json;

namespace Elements
{
    public class Linework : GeometricElement
    {

        public Polyline Polyline { get; set; }
        [JsonProperty("Add Id")]
        public string AddId { get; set; }

        public Linework(LinesOverrideAddition add)
        {
            this.Polyline = add.Value.Polyline;
            this.AddId = add.Id;

            SetMaterial();
        }
        public bool Match(LinesIdentity identity)
        {
            return identity.AddId == this.AddId;
        }

        public Linework Update(LinesOverride edit)
        {
            this.Polyline = edit.Value.Polyline;
            return this;
        }

        public void SetMaterial()
        {
            var materialName = this.Name + "_MAT";
            var materialColor = new Color(0.952941176, 0.360784314, 0.419607843, 1.0); // F15C6B with alpha 1
            var material = new Material(materialName);
            material.Color = materialColor;
            material.Unlit = true;
            this.Material = material;
        }

        public override void UpdateRepresentations()
        {
            var rep = new Representation();
            var solidRep = new Solid();

            // Define parameters for the extruded circle and spherical point
            var circleRadius = 0.1;
            var pointRadius = 0.2;

            // Create an extruded circle along each line segment of the polyline
            for (int i = 0; i < Polyline.Vertices.Count - 1; i++)
            {
                var start = Polyline.Vertices[i];
                var end = Polyline.Vertices[i + 1];
                var direction = Polyline.Segments()[i].Direction();
                var length = Polyline.Segments()[i].Length();

                var circle = Polygon.Circle(circleRadius, 10);
                circle.Transform(new Transform(new Plane(start, direction)));

                // Create an extruded circle along the line segment
                var extrusion = new Extrude(circle, length, direction, false);

                rep.SolidOperations.Add(extrusion);
            }

            // Add a spherical point at each vertex of the polyline
            foreach (var vertex in Polyline.Vertices)
            {
                var sphere = Mesh.Sphere(pointRadius, 10);


                HashSet<Geometry.Vertex> modifiedVertices = new HashSet<Geometry.Vertex>();
                // Translate the vertices of the mesh to center it at the origin
                foreach (var svertex in sphere.Vertices)
                {
                    if (!modifiedVertices.Contains(svertex))
                    {
                        svertex.Position += vertex;
                        modifiedVertices.Add(svertex);
                    }
                }

                // List<Polygon> polygons = new List<Polygon>();

                foreach (var triangle in sphere.Triangles)
                {
                    var vertices = new List<Vector3>();

                    foreach (var tvertex in triangle.Vertices)
                    {
                        // Convert Vector3D to Vector3
                        var vector3 = new Vector3(tvertex.Position.X, tvertex.Position.Y, tvertex.Position.Z);
                        vertices.Add(vector3);
                    }

                    // Create a Polygon from the triangle's vertices
                    var polygon = new Polygon(vertices);

                    // polygons.Add(polygon);
                    solidRep.AddFace(polygon);
                }

                // foreach (var face in sphere.Triangles)
                // {
                //     solidRep.AddFace(new Polygon(face.Vertices[0], face.Vertices[1], face.Vertices[2]);
                // }
            }

            var consol = new ConstructedSolid(solidRep);
            rep.SolidOperations.Add(consol);

            this.Representation = rep;
        }

        // public override void UpdateRepresentations()
        // {
        //     this.Representation = new Lamina(Polygon.Rectangle(10, 10));
        // }

        // public override bool TryToGraphicsBuffers(out List<GraphicsBuffers> graphicsBuffers, out string id, out glTFLoader.Schema.MeshPrimitive.ModeEnum? mode)
        // {
        //     id = $"{this.Id}_Polyline";
        //     mode = glTFLoader.Schema.MeshPrimitive.ModeEnum.LINES;
        //     graphicsBuffers = new List<GraphicsBuffers>();
        //     List<Vector3> points = new List<Vector3>();
        //     List<Geometry.Vertex> vertices = new List<Geometry.Vertex>();
        //     List<Color> colors = new List<Color>();
        //     Color lineColor = new Color(0, 0, 0, 1);

        //     foreach (var pt in Polyline.Vertices)
        //     {
        //         var gb = new GraphicsBuffers()
        //         points.Add(pt);
        //         var vert = new Geometry.Vertex(pt);
        //         vert.Color = lineColor;
        //         vertices.Add(vert);
        //         colors.Add(lineColor);
        //     }
        //     var gbs = points.ToGraphicsBuffers();
        //     // var gbs = vertices.ToGraphicsBuffer();
        //     gbs.Colors.AddRange(colors.SelectMany(c => new byte[] { (byte)(c.Red * 255), (byte)(c.Green * 255), (byte)(c.Blue * 255), (byte)(c.Alpha * 255) }));

        //     graphicsBuffers.Add(gbs);
        //     return true;
        // }
    }
}