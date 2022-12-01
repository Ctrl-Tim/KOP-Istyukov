using PluginsConventionLibrary.Plugins;
using System.ComponentModel.DataAnnotations;

namespace PluginsConventionLibrary.MyPlugin
{
    public class MainPluginConventionElement : PluginsConventionElement
    {
        public string Title { get; set; }

        public string Shape { get; set; }

        public string Annotation { get; set; }

        public string Reader1 { get; set; }
        public string Reader2 { get; set; }
        public string Reader3 { get; set; }
        public string Reader4 { get; set; }
        public string Reader5 { get; set; }
        public string Reader6 { get; set; }
    }
}
