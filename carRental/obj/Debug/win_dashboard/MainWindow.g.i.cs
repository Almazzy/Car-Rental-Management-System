#pragma checksum "..\..\..\win_dashboard\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C55B77B50068EA9159DC77784AD12D63D19A5A6018B3A47F9B113F3FAE7D38FA"
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


namespace carRental.win_dashboard
{


    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector
    {


#line 12 "..\..\..\win_dashboard\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_rentals;

#line default
#line hidden


#line 13 "..\..\..\win_dashboard\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_customers;

#line default
#line hidden


#line 14 "..\..\..\win_dashboard\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_cars;

#line default
#line hidden


#line 43 "..\..\..\win_dashboard\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_overview;

#line default
#line hidden


#line 44 "..\..\..\win_dashboard\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_finance;

#line default
#line hidden


#line 47 "..\..\..\win_dashboard\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btn_reload;

#line default
#line hidden

        private bool _contentLoaded;

        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (_contentLoaded)
            {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/carRental;component/win_dashboard/mainwindow.xaml", System.UriKind.Relative);

#line 1 "..\..\..\win_dashboard\MainWindow.xaml"
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
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.btn_rentals = ((System.Windows.Controls.Button)(target));

#line 12 "..\..\..\win_dashboard\MainWindow.xaml"
                    this.btn_rentals.Click += new System.Windows.RoutedEventHandler(this.Btn_rentals_Click);

#line default
#line hidden
                    return;
                case 2:
                    this.btn_customers = ((System.Windows.Controls.Button)(target));

#line 13 "..\..\..\win_dashboard\MainWindow.xaml"
                    this.btn_customers.Click += new System.Windows.RoutedEventHandler(this.Btn_customers_Click);

#line default
#line hidden
                    return;
                case 3:
                    this.btn_cars = ((System.Windows.Controls.Button)(target));

#line 14 "..\..\..\win_dashboard\MainWindow.xaml"
                    this.btn_cars.Click += new System.Windows.RoutedEventHandler(this.Btn_cars_Click);

#line default
#line hidden
                    return;
                case 4:
                    this.btn_dashboard = ((System.Windows.Controls.Button)(target));

#line 15 "..\..\..\win_dashboard\MainWindow.xaml"
                    this.btn_dashboard.Click += new System.Windows.RoutedEventHandler(this.Btn_dashboard_Click);

#line default
#line hidden
                    return;
                case 5:
                    this.btn_overview = ((System.Windows.Controls.Button)(target));

#line 43 "..\..\..\win_dashboard\MainWindow.xaml"
                    this.btn_overview.Click += new System.Windows.RoutedEventHandler(this.Btn_overview_Click);

#line default
#line hidden
                    return;
                case 6:
                    this.btn_finance = ((System.Windows.Controls.Button)(target));

#line 44 "..\..\..\win_dashboard\MainWindow.xaml"
                    this.btn_finance.Click += new System.Windows.RoutedEventHandler(this.Btn_finance_Click);

#line default
#line hidden
                    return;
                case 7:
                    this.btn_reload = ((System.Windows.Controls.Button)(target));

#line 47 "..\..\..\win_dashboard\MainWindow.xaml"
                    this.btn_reload.Click += new System.Windows.RoutedEventHandler(this.Btn_reload_Click);

#line default
#line hidden
                    return;
            }
            this._contentLoaded = true;
        }
    }
}

