﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArchivesExplorer.Application.Resources {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class NotificationMessagePreparer {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal NotificationMessagePreparer() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("ArchivesExplorer.Application.Resources.NotificationMessagePreparer", typeof(NotificationMessagePreparer).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to FirstName.
        /// </summary>
        internal static string FirstName {
            get {
                return ResourceManager.GetString("FirstName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Greetings FirstName ! We have received your order № OrderId for ProductName. If you have any additional info, please inform us by sending message on this email..
        /// </summary>
        internal static string NotificationMessage {
            get {
                return ResourceManager.GetString("NotificationMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Order № OrderId.
        /// </summary>
        internal static string NotificationSubject {
            get {
                return ResourceManager.GetString("NotificationSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to OrderId.
        /// </summary>
        internal static string OrderId {
            get {
                return ResourceManager.GetString("OrderId", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to ProductName.
        /// </summary>
        internal static string ProductName {
            get {
                return ResourceManager.GetString("ProductName", resourceCulture);
            }
        }
    }
}