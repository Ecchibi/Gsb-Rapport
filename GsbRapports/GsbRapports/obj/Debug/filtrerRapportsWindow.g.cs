﻿#pragma checksum "..\..\filtrerRapportsWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8D94382F83A27224B2B14AA43E1DCCEFCDFF9E21A723B7A202DEFA2D80E108DD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using GsbRapports;
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


namespace GsbRapports {
    
    
    /// <summary>
    /// filtrerRapportsWindow
    /// </summary>
    public partial class filtrerRapportsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateDebut;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dateFin;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbVisiteur;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtMedecin;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbMedecin;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dtg;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnValider;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\filtrerRapportsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSeria;
        
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
            System.Uri resourceLocater = new System.Uri("/GsbRapports;component/filtrerrapportswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\filtrerRapportsWindow.xaml"
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
            this.dateDebut = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.dateFin = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.cmbVisiteur = ((System.Windows.Controls.ComboBox)(target));
            
            #line 29 "..\..\filtrerRapportsWindow.xaml"
            this.cmbVisiteur.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbVisiteur_SelectionChanged_1);
            
            #line default
            #line hidden
            return;
            case 4:
            this.txtMedecin = ((System.Windows.Controls.TextBox)(target));
            
            #line 33 "..\..\filtrerRapportsWindow.xaml"
            this.txtMedecin.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtQuantite_KeyUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbMedecin = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\filtrerRapportsWindow.xaml"
            this.cmbMedecin.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbMedecin_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dtg = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 7:
            this.btnValider = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\filtrerRapportsWindow.xaml"
            this.btnValider.Click += new System.Windows.RoutedEventHandler(this.btnValider_Click_1);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnSeria = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\filtrerRapportsWindow.xaml"
            this.btnSeria.Click += new System.Windows.RoutedEventHandler(this.btnSeria_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

