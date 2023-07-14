// This code was generated by Hypar.
// Edits to this code will be overwritten the next time you run 'hypar init'.
// DO NOT EDIT THIS FILE.

using Elements;
using Elements.GeoJSON;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Elements.Validators;
using Elements.Serialization.JSON;
using Hypar.Functions;
using Hypar.Functions.Execution;
using Hypar.Functions.Execution.AWS;
using Hypar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Line = Elements.Geometry.Line;
using Polygon = Elements.Geometry.Polygon;

namespace Elements10Sample
{
    #pragma warning disable // Disable all warnings

    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public  class Elements10SampleInputs : S3Args
    
    {
        [Newtonsoft.Json.JsonConstructor]
        
        public Elements10SampleInputs(Overrides @overrides, string bucketName, string uploadsBucket, Dictionary<string, string> modelInputKeys, string gltfKey, string elementsKey, string ifcKey):
        base(bucketName, uploadsBucket, modelInputKeys, gltfKey, elementsKey, ifcKey)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<Elements10SampleInputs>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @overrides});
            }
        
            this.Overrides = @overrides ?? this.Overrides;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("overrides", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Overrides Overrides { get; set; } = new Overrides();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class Overrides 
    
    {
        public Overrides() { }
        
        [Newtonsoft.Json.JsonConstructor]
        public Overrides(OverrideAdditions @additions, OverrideRemovals @removals, IList<LinesOverride> @lines, IList<CurvesOverride> @curves)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<Overrides>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @additions, @removals, @lines, @curves});
            }
        
            this.Additions = @additions ?? this.Additions;
            this.Removals = @removals ?? this.Removals;
            this.Lines = @lines ?? this.Lines;
            this.Curves = @curves ?? this.Curves;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Additions", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public OverrideAdditions Additions { get; set; } = new OverrideAdditions();
    
        [Newtonsoft.Json.JsonProperty("Removals", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public OverrideRemovals Removals { get; set; } = new OverrideRemovals();
    
        [Newtonsoft.Json.JsonProperty("Lines", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<LinesOverride> Lines { get; set; } = new List<LinesOverride>();
    
        [Newtonsoft.Json.JsonProperty("Curves", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<CurvesOverride> Curves { get; set; } = new List<CurvesOverride>();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class OverrideAdditions 
    
    {
        public OverrideAdditions() { }
        
        [Newtonsoft.Json.JsonConstructor]
        public OverrideAdditions(IList<LinesOverrideAddition> @lines, IList<CurvesOverrideAddition> @curves)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<OverrideAdditions>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @lines, @curves});
            }
        
            this.Lines = @lines ?? this.Lines;
            this.Curves = @curves ?? this.Curves;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Lines", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<LinesOverrideAddition> Lines { get; set; } = new List<LinesOverrideAddition>();
    
        [Newtonsoft.Json.JsonProperty("Curves", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<CurvesOverrideAddition> Curves { get; set; } = new List<CurvesOverrideAddition>();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class OverrideRemovals 
    
    {
        public OverrideRemovals() { }
        
        [Newtonsoft.Json.JsonConstructor]
        public OverrideRemovals(IList<LinesOverrideRemoval> @lines, IList<CurvesOverrideRemoval> @curves)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<OverrideRemovals>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @lines, @curves});
            }
        
            this.Lines = @lines ?? this.Lines;
            this.Curves = @curves ?? this.Curves;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Lines", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<LinesOverrideRemoval> Lines { get; set; } = new List<LinesOverrideRemoval>();
    
        [Newtonsoft.Json.JsonProperty("Curves", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public IList<CurvesOverrideRemoval> Curves { get; set; } = new List<CurvesOverrideRemoval>();
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class LinesOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public LinesOverride(string @id, LinesIdentity @identity, LinesValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<LinesOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LinesIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LinesValue Value { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CurvesOverride 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CurvesOverride(string @id, CurvesIdentity @identity, CurvesValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CurvesOverride>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CurvesIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CurvesValue Value { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class LinesOverrideAddition 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public LinesOverrideAddition(string @id, LinesIdentity @identity, LinesOverrideAdditionValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<LinesOverrideAddition>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LinesIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LinesOverrideAdditionValue Value { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CurvesOverrideAddition 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CurvesOverrideAddition(string @id, CurvesIdentity @identity, CurvesOverrideAdditionValue @value)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CurvesOverrideAddition>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity, @value});
            }
        
            this.Id = @id;
            this.Identity = @identity;
            this.Value = @value;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CurvesIdentity Identity { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Value", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CurvesOverrideAdditionValue Value { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class LinesOverrideRemoval 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public LinesOverrideRemoval(string @id, LinesIdentity @identity)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<LinesOverrideRemoval>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity});
            }
        
            this.Id = @id;
            this.Identity = @identity;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public LinesIdentity Identity { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CurvesOverrideRemoval 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CurvesOverrideRemoval(string @id, CurvesIdentity @identity)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CurvesOverrideRemoval>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @id, @identity});
            }
        
            this.Id = @id;
            this.Identity = @identity;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string Id { get; set; }
    
        [Newtonsoft.Json.JsonProperty("Identity", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public CurvesIdentity Identity { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class LinesIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public LinesIdentity(string @addId)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<LinesIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @addId});
            }
        
            this.AddId = @addId;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Add Id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddId { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class LinesValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public LinesValue(Polyline @polyline)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<LinesValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @polyline});
            }
        
            this.Polyline = @polyline;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Polyline", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Polyline Polyline { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CurvesIdentity 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CurvesIdentity(string @addId)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CurvesIdentity>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @addId});
            }
        
            this.AddId = @addId;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Add Id", Required = Newtonsoft.Json.Required.DisallowNull, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public string AddId { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CurvesValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CurvesValue(Polyline @polyline)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CurvesValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @polyline});
            }
        
            this.Polyline = @polyline;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Polyline", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Polyline Polyline { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class LinesOverrideAdditionValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public LinesOverrideAdditionValue(Polyline @polyline)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<LinesOverrideAdditionValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @polyline});
            }
        
            this.Polyline = @polyline;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Polyline", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Polyline Polyline { get; set; }
    
    }
    
    [System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.1.21.0 (Newtonsoft.Json v13.0.0.0)")]
    
    public partial class CurvesOverrideAdditionValue 
    
    {
        [Newtonsoft.Json.JsonConstructor]
        public CurvesOverrideAdditionValue(Polyline @polyline)
        {
            var validator = Validator.Instance.GetFirstValidatorForType<CurvesOverrideAdditionValue>();
            if(validator != null)
            {
                validator.PreConstruct(new object[]{ @polyline});
            }
        
            this.Polyline = @polyline;
        
            if(validator != null)
            {
                validator.PostConstruct(this);
            }
        }
    
        [Newtonsoft.Json.JsonProperty("Polyline", Required = Newtonsoft.Json.Required.Default, NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore)]
        public Polyline Polyline { get; set; }
    
    }
}