using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VendingAccountant.Utils
{
    public static class ConcurrentHelper
    {
        public static void Manipulate<T>(this T control, Action<T> action) where T : Control
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action<T, Action<T>>(Manipulate),
                            new object[] { control, action });
            }
            else
            { action(control); }
        }
    }
}
