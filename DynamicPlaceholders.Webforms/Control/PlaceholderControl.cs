using System;
using System.Linq;
using System.Web.UI;
using Sitecore.Common;
using Sitecore.Layouts;
using Sitecore.Web.UI;
using Sitecore.Web.UI.WebControls;

namespace DynamicPlaceholders.Webforms.Control
{
    public class PlaceholderControl : WebControl, IExpandable
    {
        private string _key = Placeholder.DefaultPlaceholderKey;
        private Placeholder _placeholder;

        public string Key
        {
            get
            {
                return _key;
            }
            set
            {
                _key = value.ToLower();
            }
        }

        protected string DynamicKey
        {
            get
            {
                if (DynamicKey1 != null)
                {
                    return DynamicKey1;
                }
                DynamicKey1 = _key;
                var stack = Switcher<Placeholder, PlaceholderSwitcher>.GetStack(false);
                var current = stack.Peek();
                var renderings = Sitecore.Context.Page.Renderings.Where(rendering => (rendering.Placeholder == current.ContextKey || rendering.Placeholder == current.Key) && rendering.AddedToPage);
                var renderingReferences = renderings as RenderingReference[] ?? renderings.ToArray();
                if (!renderingReferences.Any()) return DynamicKey1;
                {
                    var rendering = renderingReferences.Last();
                    DynamicKey1 = rendering.UniqueId;
                }
                return DynamicKey1;
            }
        }

        public string DynamicKey1 { get; set; }

        protected override void CreateChildControls()
        {
            Sitecore.Diagnostics.Tracer.Debug("DynamicKeyPlaceholder: Adding dynamic placeholder with Key " + DynamicKey);
            _placeholder = new Placeholder { Key = PlaceholdersContext.Add(Key, Guid.Parse(DynamicKey)) };
            Controls.Add(_placeholder);
            _placeholder.Expand();
        }

        protected override void DoRender(HtmlTextWriter output)
        {
            RenderChildren(output);
        }

        public void Expand()
        {
            EnsureChildControls();
        }
    }
}