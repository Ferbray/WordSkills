﻿#pragma checksum "..\..\..\Pages\RegBegun.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "98B292C9B8E47D68A31CFB09646AC8119DD2B524F8B78AAC1295BAF573E8DC9A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
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
using WpfApp1.Pages;


namespace WpfApp1.Pages {
    
    
    /// <summary>
    /// RegBegun
    /// </summary>
    public partial class RegBegun : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock subtitle;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegEmail;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox RegPass;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox RegPassAgree;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegName;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RegFamily;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_gender;
        
        #line default
        #line hidden
        
        
        #line 84 "..\..\..\Pages\RegBegun.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo_country;
        
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
            System.Uri resourceLocater = new System.Uri("/WpfApp1;component/pages/regbegun.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\RegBegun.xaml"
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
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Pages\RegBegun.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.subtitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.RegEmail = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.RegPass = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 52 "..\..\..\Pages\RegBegun.xaml"
            this.RegPass.KeyDown += new System.Windows.Input.KeyEventHandler(this.PasswordBox_KeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.RegPassAgree = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 54 "..\..\..\Pages\RegBegun.xaml"
            this.RegPassAgree.KeyDown += new System.Windows.Input.KeyEventHandler(this.PasswordBox_KeyDown_1);
            
            #line default
            #line hidden
            return;
            case 6:
            this.RegName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.RegFamily = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.combo_gender = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.combo_country = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 10:
            
            #line 87 "..\..\..\Pages\RegBegun.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RegMarathon);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 95 "..\..\..\Pages\RegBegun.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
