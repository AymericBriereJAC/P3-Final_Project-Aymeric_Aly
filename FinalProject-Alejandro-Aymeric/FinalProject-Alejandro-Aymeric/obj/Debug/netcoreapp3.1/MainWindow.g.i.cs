﻿#pragma checksum "..\..\..\mainwindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3D7FF3D12C0112746DE2EB0EE91DD9F1CF91DD8E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FinalProject_Alejandro_Aymeric;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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


namespace FinalProject_Alejandro_Aymeric {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\mainwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbItems;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\mainwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addCart;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\mainwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvCartItems;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\mainwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Delete;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\mainwindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/FinalProject-Alejandro-Aymeric;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\mainwindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.9.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.lbItems = ((System.Windows.Controls.ListBox)(target));
            
            #line 19 "..\..\..\mainwindow.xaml"
            this.lbItems.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LbItems_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 26 "..\..\..\mainwindow.xaml"
            ((System.Windows.Controls.ListBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ListBoxItem_Selected_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.addCart = ((System.Windows.Controls.Button)(target));
            
            #line 33 "..\..\..\mainwindow.xaml"
            this.addCart.Click += new System.Windows.RoutedEventHandler(this.AddCart_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lvCartItems = ((System.Windows.Controls.ListView)(target));
            return;
            case 5:
            this.Delete = ((System.Windows.Controls.Button)(target));
            
            #line 58 "..\..\..\mainwindow.xaml"
            this.Delete.Click += new System.Windows.RoutedEventHandler(this.Delete_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            
            #line 70 "..\..\..\mainwindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.payCash_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 71 "..\..\..\mainwindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.payDebit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

