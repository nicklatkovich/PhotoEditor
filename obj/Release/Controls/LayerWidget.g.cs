﻿#pragma checksum "..\..\..\Controls\LayerWidget.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C57B5CF659BF54A2A4D807817542B6E1"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PhotoEditor.Controls {
    
    
    /// <summary>
    /// LayerWidget
    /// </summary>
    public partial class LayerWidget : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Controls\LayerWidget.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas previewCanvas;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Controls\LayerWidget.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.TextBlock WidgetText;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\Controls\LayerWidget.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        private System.Windows.Controls.TextBox EditBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PhotoEditor;component/controls/layerwidget.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Controls\LayerWidget.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 9 "..\..\..\Controls\LayerWidget.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.UserContol_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.previewCanvas = ((System.Windows.Controls.Canvas)(target));
            return;
            case 3:
            
            #line 33 "..\..\..\Controls\LayerWidget.xaml"
            ((System.Windows.Controls.Label)(target)).MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Label_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.WidgetText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.EditBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 57 "..\..\..\Controls\LayerWidget.xaml"
            this.EditBox.KeyUp += new System.Windows.Input.KeyEventHandler(this.editBox_KeyUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
