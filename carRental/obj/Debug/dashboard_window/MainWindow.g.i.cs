#pragma checksum "..\..\..\dashboard_window\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5322F253581196B72BEFD9A0755083493215CB36619B1FAC214881D1911A36DC"
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
using carRental;


namespace carRental {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\dashboard_window\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_rentals;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\dashboard_window\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_customers;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\dashboard_window\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cars;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\dashboard_window\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_dashboard;
        
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
            System.Uri resourceLocater = new System.Uri("/carRental;component/dashboard_window/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\dashboard_window\MainWindow.xaml"
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
            this.btn_rentals = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\dashboard_window\MainWindow.xaml"
            this.btn_rentals.Click += new System.Windows.RoutedEventHandler(this.Btn_rentals_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btn_customers = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\dashboard_window\MainWindow.xaml"
            this.btn_customers.Click += new System.Windows.RoutedEventHandler(this.Btn_customers_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btn_cars = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\dashboard_window\MainWindow.xaml"
            this.btn_cars.Click += new System.Windows.RoutedEventHandler(this.Btn_cars_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btn_dashboard = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\dashboard_window\MainWindow.xaml"
            this.btn_dashboard.Click += new System.Windows.RoutedEventHandler(this.Btn_dashboard_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

