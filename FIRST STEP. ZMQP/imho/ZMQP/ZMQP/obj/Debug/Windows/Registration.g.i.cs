﻿#pragma checksum "..\..\..\Windows\Registration.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CB3A8946CF6C73F26F75FF7B01253F2790B55068833A67E8C85BEA72ABCA2091"
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
using ZMQP.Windows;


namespace ZMQP.Windows {
    
    
    /// <summary>
    /// Registration
    /// </summary>
    public partial class Registration : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 33 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ToolBarButtonMin;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ToolBarButtonClose;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Login;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Email;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PassBoxVisibility;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PassBoxNoVisibility;
        
        #line default
        #line hidden
        
        
        #line 149 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PassBoxButtonVisibility;
        
        #line default
        #line hidden
        
        
        #line 173 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PassBoxVisibilityDouble;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PassBoxNoVisibilityDouble;
        
        #line default
        #line hidden
        
        
        #line 191 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image PassBoxButtonVisibilityDouble;
        
        #line default
        #line hidden
        
        
        #line 213 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock enter;
        
        #line default
        #line hidden
        
        
        #line 228 "..\..\..\Windows\Registration.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock error_reg;
        
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
            System.Uri resourceLocater = new System.Uri("/ZMQP;component/windows/registration.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Windows\Registration.xaml"
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
            
            #line 27 "..\..\..\Windows\Registration.xaml"
            ((System.Windows.Controls.Grid)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Grid_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ToolBarButtonMin = ((System.Windows.Controls.Image)(target));
            
            #line 33 "..\..\..\Windows\Registration.xaml"
            this.ToolBarButtonMin.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ToolBarButtonMin_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ToolBarButtonClose = ((System.Windows.Controls.Image)(target));
            
            #line 49 "..\..\..\Windows\Registration.xaml"
            this.ToolBarButtonClose.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.ToolBarButtonClose_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Login = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.Email = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.PassBoxVisibility = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.PassBoxNoVisibility = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.PassBoxButtonVisibility = ((System.Windows.Controls.Image)(target));
            
            #line 149 "..\..\..\Windows\Registration.xaml"
            this.PassBoxButtonVisibility.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.PassBoxButtonVisibility_MouseDown);
            
            #line default
            #line hidden
            return;
            case 9:
            this.PassBoxVisibilityDouble = ((System.Windows.Controls.TextBox)(target));
            return;
            case 10:
            this.PassBoxNoVisibilityDouble = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 11:
            this.PassBoxButtonVisibilityDouble = ((System.Windows.Controls.Image)(target));
            
            #line 191 "..\..\..\Windows\Registration.xaml"
            this.PassBoxButtonVisibilityDouble.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.PassBoxButtonVisibilityDouble_MouseDown);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 209 "..\..\..\Windows\Registration.xaml"
            ((System.Windows.Documents.Hyperlink)(target)).Click += new System.Windows.RoutedEventHandler(this.Hyperlink_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 212 "..\..\..\Windows\Registration.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RegistrateNewUser);
            
            #line default
            #line hidden
            return;
            case 14:
            this.enter = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 15:
            this.error_reg = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

