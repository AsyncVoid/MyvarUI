using System.Diagnostics;

namespace MyvarUI.Mudle
{
    [DebuggerDisplay("{Name}: {Value}")]  
    public class MudlePropertie
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}