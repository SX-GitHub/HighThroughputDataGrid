using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace HighThroughputDataGrid.Common
{
    public static class DependencyExtension
    {
        public static IEnumerable<FrameworkElement> GetVisualChildren(this Visual visual)
        {
            return Enumerable.Range(0, VisualTreeHelper.GetChildrenCount(visual)).Select(i =>
                    VisualTreeHelper.GetChild(visual, i)).Cast<FrameworkElement>();
        }

        public static T FindVisualChild<T>(this Visual visual) where T: Visual
        {
            for(int i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++)
            {
                Visual child = VisualTreeHelper.GetChild(visual, i) as Visual;
                if (child is T)
                    return (T)child;

                child = FindVisualChild<T>(child);
                if (child is T)
                    return (T)child;
            }
            return null;
        }

        public static T FindVisualParent<T>(this Visual visual) where T : Visual
        {
            var parent = VisualTreeHelper.GetParent(visual);
            while(parent != null)
            {
                if (parent is T)
                    return (T)parent;
                parent = VisualTreeHelper.GetParent(parent);
            }
            return null;
        }
    }
}
