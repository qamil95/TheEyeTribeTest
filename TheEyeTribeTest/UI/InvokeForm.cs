using System.Windows.Forms;

namespace TheEyeTribeTest
{
    public class InvokeForm : Form
    {
        public void DoInvoke(MethodInvoker del)
        {
            if (InvokeRequired)
            {
                Invoke(del);
            }
            else
            {
                del();
            }
        }
    }
}
