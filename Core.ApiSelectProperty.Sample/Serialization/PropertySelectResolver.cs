using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.ApiSelectProperty.Sample.Serialization
{
    public class PropertySelectResolver : DefaultContractResolver
    {
        private List<string> _desiredProperties = new List<string>();

        public PropertySelectResolver(StringValues properties)
        {
            var extracted = properties.SingleOrDefault()?.Split(',');

            if (extracted != null && extracted.Any())
                _desiredProperties.AddRange(extracted);
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var originalProperties = base.CreateProperties(type, memberSerialization);

            if (!_desiredProperties.Any())
                return originalProperties;

            return originalProperties
                .Where(p => _desiredProperties.Contains(p.PropertyName, StringComparer.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
