// 代码生成时间: 2025-09-02 15:05:41
 * This class serves as a basic user interface component library for an ASP.NET application.
 * It contains a set of UI components that can be used across different pages or components.
 */

using System;
using System.Collections.Generic;
using System.Web.UI;

namespace UiComponentLibrary
{
    // This is the base interface for all UI components
    public interface IUiComponent
    {
        void RenderControl(HtmlTextWriter writer);
    }

    // This class represents a simple label UI component
    public class Label : IUiComponent
    {
        private readonly string _text;
        private readonly string _id;

        public Label(string id, string text)
        {
            _id = id;
            _text = text;
        }

        // Renders the label component to the HTML output
        public void RenderControl(HtmlTextWriter writer)
        {
            writer.AddAttribute("id", _id);
            writer.AddAttribute("runat", "server");
            writer.RenderBeginTag("asp:Label");
            writer.Write(_text);
            writer.RenderEndTag();
        }
    }

    // This class represents a simple button UI component
    public class Button : IUiComponent
    {
        private readonly string _text;
        private readonly string _onclick;
        private readonly string _id;

        public Button(string id, string text, string onclick)
        {
            _id = id;
            _text = text;
            _onclick = onclick;
        }

        // Renders the button component to the HTML output
        public void RenderControl(HtmlTextWriter writer)
        {
            writer.AddAttribute("id", _id);
            writer.AddAttribute("runat", "server");
            writer.AddAttribute("onclick", _onclick);
            writer.RenderBeginTag("input");
            writer.AddAttribute("type", "button");
            writer.AddAttribute("value", _text);
            writer.RenderBeginTag("/input");
            writer.RenderEndTag();
        }
    }

    // This class contains methods to manage UI components
    public class UiComponentManager
    {
        private readonly List<IUiComponent> _components;

        public UiComponentManager()
        {
            _components = new List<IUiComponent>();
        }

        // Adds a UI component to the manager
        public void AddComponent(IUiComponent component)
        {
            if (component == null)
                throw new ArgumentNullException(nameof(component));

            _components.Add(component);
        }

        // Removes a UI component from the manager
        public bool RemoveComponent(IUiComponent component)
        {
            return _components.Remove(component);
        }

        // Renders all UI components managed by this instance
        public void RenderComponents(HtmlTextWriter writer)
        {
            foreach (var component in _components)
            {
                component.RenderControl(writer);
            }
        }
    }
}
