﻿#pragma checksum "..\..\..\win_employees\del_emp_window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7CD6E2508C8ECBFB36296630C2259E4E05C6A399"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
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
using carRental.win_employees;


namespace carRental.win_employees {
    
    
    /// <summary>
    /// del_emp_window
    /// </summary>
    public partial class del_emp_window : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_emp;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_end_step1;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_end_step2;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_inf1;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_inf2;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_inf3;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_inf4;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\win_employees\del_emp_window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lbl_inf5;
        
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
            System.Uri resourceLocater = new System.Uri("/carRental;component/win_employees/del_emp_window.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\win_employees\del_emp_window.xaml"
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
            this.combo_emp = ((System.Windows.Controls.ComboBox)(target));
            
            #line 17 "..\..\..\win_employees\del_emp_window.xaml"
            this.combo_emp.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Combo_car_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_end_step1 = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\win_employees\del_emp_window.xaml"
            this.btn_end_step1.Click += new System.Windows.RoutedEventHandler(this.Btn_end_step1_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_end_step2 = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\win_employees\del_emp_window.xaml"
            this.btn_end_step2.Click += new System.Windows.RoutedEventHandler(this.Btn_end_step2_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lbl_inf1 = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.lbl_inf2 = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lbl_inf3 = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lbl_inf4 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lbl_inf5 = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

