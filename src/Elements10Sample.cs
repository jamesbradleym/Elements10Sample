using Elements;
using Elements.Geometry;
using System.Collections.Generic;

namespace Elements10Sample
{
    public static class Elements10Sample
    {
        /// <summary>
        /// The Elements10Sample function.
        /// </summary>
        /// <param name="model">The input model.</param>
        /// <param name="input">The arguments to the execution.</param>
        /// <returns>A Elements10SampleOutputs instance containing computed results and the model with any new elements.</returns>
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

            output.Model.AddElements(lineworks);

            foreach (var lw in lineworks)
            {
                foreach (var segment in lw.Polyline.Segments())
                {
                    var point = segment.PointAt(0.5);
                    var direction = segment.Direction();
                    var size = 1;
                    var mass = new Mass(Polygon.Rectangle(size, size), size);
                    var center = mass.Bounds.Center() + new Vector3(0, 0, mass.Height / 2);
                    // mass.Transform.Move(point - mass.Bounds.Center());
                    mass.Transform = new Transform(new Plane(point, direction));//.Concatenated(new Transform(point - center));
                    output.Model.AddElement(mass);
                }
            }

            return output;
        }
    }
}