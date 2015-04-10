using System.Collections.Generic;
using ViagogoWatcher.Model.Connector.Dto;

namespace ViagoWatcher.Model.Connector.Dto
{
    public class ContentDto
    {
        public IEnumerable<ProductDto> Items { get; set; }
    }
}