﻿#pragma checksum "..\..\..\UnitsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "1390A4358A7686057715912CD07A98390BAB6A5DA03BF24496E507662734C98F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using KIT206;
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


namespace KIT206 {
    
    
    /// <summary>
    /// UnitsWindow
    /// </summary>
    public partial class UnitsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Title;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Home;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Units;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Staff;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid HomeGrid;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textAllUnits;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textAllStaff;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textUnitsTaught;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox unitsList;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox staffList;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\UnitsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox taughtList;
        
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
            System.Uri resourceLocater = new System.Uri("/ConsoleApplication;component/unitswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UnitsWindow.xaml"
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
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.Title = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Home = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\..\UnitsWindow.xaml"
            this.Home.Click += new System.Windows.RoutedEventHandler(this.Button_Click_Home);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Units = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\..\UnitsWindow.xaml"
            this.Units.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Staff = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UnitsWindow.xaml"
            this.Staff.Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.HomeGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 7:
            this.textAllUnits = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.textAllStaff = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.textUnitsTaught = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.unitsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 11:
            this.staffList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 12:
            this.taughtList = ((System.Windows.Controls.ListBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

