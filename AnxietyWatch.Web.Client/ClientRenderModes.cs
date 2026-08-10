using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace AnxietyWatch.Web.Client;

public static class ClientRenderModes
{
    public static IComponentRenderMode WebAssembly { get; } =
        new InteractiveWebAssemblyRenderMode(prerender: false);
}
