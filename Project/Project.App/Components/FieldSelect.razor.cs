using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.App.Components
{
    public class SelectModel<ValueType> : ComponentBase
    {
        public ElementReference ElemRef = new ElementReference("fieldselect-" + Guid.NewGuid());

        [Parameter] public Dictionary<ValueType, string> Items { get; set; }

        private ValueType _value;

        [Parameter]
        public ValueType Value
        {
            get => _value;
            set { if (!Value.Equals(value)) _value = value; ValueChanged.InvokeAsync(value); }
        }

        [Parameter] public EventCallback<ValueType> ValueChanged { get; set; }

        [Parameter] public string Label { get; set; }

        [Parameter] public bool Required { get; set; }

        [Parameter(CaptureUnmatchedValues = true)]
        public IDictionary<string, object> AdditionalAttributes { get; set; }

        [Parameter] public int Col { get; set; } = 12;

        public bool isFocus;

        protected void ToggleFocus() => isFocus = !isFocus;

        [Parameter] public string CssClass { get; set; }

    }
}
