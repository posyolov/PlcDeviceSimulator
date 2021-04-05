using System;
using System.Collections.Generic;
using System.Text;

namespace SoDevices
{
    public class SoDevice <TFromPlcTags, TToPlcTags>
    {
        public string Name { get; set; }
        public TFromPlcTags FromPlcTags { get; set; }
        public TToPlcTags ToPlcTags { get; set; }
    }
}
