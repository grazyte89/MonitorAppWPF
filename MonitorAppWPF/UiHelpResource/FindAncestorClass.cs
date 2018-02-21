using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace MonitorAppWPF.UiHelpResource
{
    public class FindAncestorClass
    {
        public static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            /*var parent = VisualTreeHelper.GetParent(current) as T;
            if (parent != null)
            {
                return parent;
            }
            return FindAnchestor<T>(parent);*/
            while (current != null)
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            return null;
        }
    }
}
