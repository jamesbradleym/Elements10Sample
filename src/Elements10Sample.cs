using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace Elements10Sample
{
    public static class Elements10Sample
    {
        /// <summary>
        /// The Elements20Sample function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A Elements20SampleOutputs instance containing computed results and the model with any new elements.</returns>
        public static Elements10SampleOutputs Execute(Dictionary<string, Model> inputModels, Elements10SampleInputs input)
        {
            var output = new Elements10SampleOutputs();

            var lineworks = input.Overrides.Lines.CreateElements(
                input.Overrides.Additions.Lines,
                input.Overrides.Removals.Lines,
                (add) => new Linework(add),
                (linework, identity) => linework.Match(identity),
                (linework, edit) => linework.Update(edit)
            );

            var polylineworks = input.Overrides.Polylines.CreateElements(
              input.Overrides.Additions.Polylines,
              input.Overrides.Removals.Polylines,
              (add) => new Polylinework(add),
              (polylinework, identity) => polylinework.Match(identity),
              (polylinework, edit) => polylinework.Update(edit)
            );

            var bezierworks = input.Overrides.Beziers.CreateElements(
              input.Overrides.Additions.Beziers,
              input.Overrides.Removals.Beziers,
              (add) => new Bezierwork(add),
              (bezierwork, identity) => bezierwork.Match(identity),
              (bezierwork, edit) => bezierwork.Update(edit)
            );

            if (polylineworks.Count == 0 && bezierworks.Count == 0)
            {
                var offset = 0;
                foreach (var letter in "HYPAR")
                {
                    if (HyparFont.LetterShapes.ContainsKey(letter))
                    {
                        foreach (var shape in HyparFont.LetterShapes[letter])
                        {
                            if (shape is Polyline _linework)
                            {
                                var lw = new Polylinework(_linework.TransformedPolyline(new Transform(new Vector3(offset, 0, 0))));
                                polylineworks.Add(lw);
                            }
                            else if (shape is Bezier _bezierwork)
                            {
                                var bw = new Bezierwork(_bezierwork.TransformedBezier(new Transform(new Vector3(offset, 0, 0))));
                                bezierworks.Add(bw);
                            }
                        }
                        offset += 10;
                    }
                }
            }

            output.Model.AddElements(lineworks);
            output.Model.AddElements(polylineworks);
            output.Model.AddElements(bezierworks);

            List<object> curves = new List<object>();

            /// CIRCLE
            var circle = new Circle(new Vector3(-10, 5, 0), 4);
            var circlework = new Circlework(circle);
            output.Model.AddElement(circlework);

            /// ARC
            var arc = new Arc(new Vector3(15, -10, 0), 4, 0.0, 270.0);
            var arcwork = new Arcwork(arc);
            output.Model.AddElement(arcwork);

            /// POLYLINE
            var polyline = new Polyline(
                new List<Vector3>()
                {
                    new Vector3(62.5, 10, 0),
                    new Vector3(60, 6.5, 0),
                    new Vector3(61, 6.5, 0),
                    new Vector3(58, 4, 0),
                    new Vector3(59, 4, 0),
                    new Vector3(56, 0, 0),
                    new Vector3(61.5, 4.5, 0),
                    new Vector3(60.5, 4.5, 0),
                    new Vector3(63.5, 7, 0),
                    new Vector3(62.5, 7, 0),
                    new Vector3(65, 10, 0),
                }
            );
            var polylinework = new Polylinework(polyline);
            polylineworks.Add(polylinework);
            output.Model.AddElement(polylinework);

            /// LINE
            var line = new Line(new Vector3(35, 15, 0), new Vector3(35, 25, 0));
            var linework = new Linework(line);
            lineworks.Add(linework);
            output.Model.AddElement(linework);

            /// BEZIER
            var bezier = new Bezier(
                new List<Vector3>()
                {
                    new Vector3(10, 20, 0),
                    new Vector3(15, 30, 0),
                    new Vector3(15, 10, 0),
                    new Vector3(20, 20.01, 0),
                }
            );
            var bezierwork = new Bezierwork(bezier);
            output.Model.AddElement(bezierwork);
            bezierworks.Add(bezierwork);


            curves.AddRange(lineworks);
            curves.AddRange(polylineworks);
            curves.AddRange(bezierworks);
            curves.Add(circlework);
            curves.Add(arcwork);

            var parameter = input.Parameter;
            var directionMod = 0.01;
            var size = 1.0;
            var subsize = 0.5;
            foreach (var curve in curves)
            {
                if (curve is Polylinework _polylinework)
                {
                    var point = _polylinework.Polyline.PointAt(parameter);
                    var direction = _polylinework.Polyline.PointAt(parameter) - _polylinework.Polyline.PointAt(parameter + directionMod);
                    var mass = MassAtPointAndOrientation(size, point, direction);
                    output.Model.AddElement(mass);

                    if (_polylinework.Polyline.Segments().Count() > 1)
                    {
                        foreach (var segment in _polylinework.Polyline.Segments())
                        {
                            var subpoint = segment.PointAt(parameter);
                            var subdirection = segment.Direction();
                            var submass = MassAtPointAndOrientation(subsize, subpoint, subdirection);
                            output.Model.AddElement(submass);
                        }
                    }

                }
                else if (curve is Linework _linework)
                {
                    var point = _linework.Line.PointAt(parameter);
                    var direction = _linework.Line.Direction();
                    var mass = MassAtPointAndOrientation(size, point, direction);
                    output.Model.AddElement(mass);
                }
                else if (curve is Bezierwork _bezierwork)
                {
                    var point = _bezierwork.Bezier.PointAt(parameter);
                    var direction = _bezierwork.Bezier.PointAt(parameter) - _bezierwork.Bezier.PointAt(parameter + directionMod);
                    var mass = MassAtPointAndOrientation(size, point, direction);
                    output.Model.AddElement(mass);
                }
                else if (curve is Circlework _circlework)
                {
                    var point = _circlework.Circle.PointAt(parameter);
                    var direction = _circlework.Circle.PointAt(parameter) - _circlework.Circle.PointAt(parameter + directionMod);
                    var mass = MassAtPointAndOrientation(size, point, direction);
                    output.Model.AddElement(mass);
                }
                else if (curve is Arcwork _arcwork)
                {
                    var point = _arcwork.Arc.PointAt(parameter);
                    var direction = _arcwork.Arc.PointAt(parameter) - _arcwork.Arc.PointAt(parameter + directionMod);
                    var mass = MassAtPointAndOrientation(size, point, direction);
                    output.Model.AddElement(mass);
                }
            }

            return output;
        }


        public static Mass MassAtPointAndOrientation(Double size, Vector3 point, Vector3 direction)
        {
            var mass = new Mass(Polygon.Rectangle(size, size), size);
            var center = mass.Bounds.Center() + new Vector3(0, 0, size / 2.0) + mass.Transform.Origin;
            mass.Transform = new Transform(-1 * center).Concatenated(new Transform(new Plane(point, direction)));
            return mass;
        }
    }
}