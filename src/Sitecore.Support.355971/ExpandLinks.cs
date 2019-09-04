using Sitecore;
using Sitecore.Configuration;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Pipelines.RenderField;
using Sitecore.Web;

namespace Sitecore.Support.Pipelines.RenderField
{
    public class ExpandLinks
    {
        public virtual void Process(RenderFieldArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (!Context.PageMode.IsExperienceEditorEditing)
            {
                try
                {
                    args.Result.FirstPart = DynamicLink.ExpandLinks(args.Result.FirstPart, Settings.Rendering.SiteResolving);
                    args.Result.LastPart = DynamicLink.ExpandLinks(args.Result.LastPart, Settings.Rendering.SiteResolving);

                }
                catch (InvalidLinkFormatException ex)
                {
                    Log.Error("Failed to render ill-formatted link", ex, this);
                }
            }
        }
    }
}