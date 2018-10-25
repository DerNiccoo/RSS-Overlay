using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SimpleOverlay
{
    public partial class Notification : Form
    {
        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        static System.Windows.Forms.Timer displayTimer = new System.Windows.Forms.Timer();
        private static List<Notification> mInstance = new List<Notification>();
        private int yPos;

        public Notification(string header, string body, string host = "", int posOffset = 0)
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                    
            lb_Header.Text = ElipseTextAfterChars(header, 30);
            lb_Body.Text = LineBreakAfterChars(ElipseTextAfterChars(body, 250), 40);

            if (host != "")
                LoadHostPicture(host);

            yPos = 15 + (posOffset * 139);
            
            displayTimer.Tick += (sender, e) => DisplayTimeOver(sender, e, this);
            displayTimer.Interval = 8000;
            displayTimer.Start();
        }

        public static void Create(string header, string body, string host = "", int posOffset = 0)
        {
            var t = new System.Threading.Thread(() => {
                mInstance.Add(new Notification(header, body, host, posOffset));
                Application.Run(mInstance[mInstance.Count - 1]);
            });
            t.SetApartmentState(System.Threading.ApartmentState.STA);
            t.IsBackground = true;
            t.Start();
        }

        public static void Destroy(int window)
        {            
            if (mInstance[window] != null) mInstance[window].Invoke(new Action(() => mInstance[window].Close()));
        }

        // So the form doesnt steal the Focus of current focus
        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        private static void DisplayTimeOver(object source, EventArgs e, Form form)
        {            
            displayTimer.Stop();
            Destroy((form.Location.Y - 15) / 139);
            //form.Close();            
        }

        private void LoadHostPicture(string host)
        {
            if (host == "de.wowhead.com")
                pb_Logo.Image = SimpleOverlay.Properties.Resources.wh_logo;
        }

        private void Notification_Load(object sender, EventArgs e)
        {
            this.Location = new Point(15, yPos);
            this.BackColor = Color.White;
            //this.TransparencyKey = Color.White;
            this.TopMost = true;
            //this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = FormBorderStyle.None;

            int initialStyle = GetWindowLong(this.Handle, -20);
            SetWindowLong(this.Handle, -20, initialStyle | 0x80000 | 0x20);
        }

        private string LineBreakAfterChars(string value, int chars)
        {
            if (value.Length <= chars)
                return value;

            string result = "";
            int lineLen = 0;

            List<string> vs = value.Split().ToList();
            foreach (string s in vs)
            {
                if (lineLen + s.Length <= chars)
                {
                    result += s + " ";
                    lineLen += s.Length;
                }
                else
                {
                    result += "\r\n" + s + " ";
                    lineLen = s.Length;
                }
            }

            return result;
        }

        private string ElipseTextAfterChars(string value, int chars)
        {
            if (value.Length <= chars)
                return value;

            string result = "";
            int lineLen = 0;

            List<string> vs = value.Split().ToList();
            foreach (string s in vs)
            {
                if (lineLen + s.Length <= chars)
                {
                    result += s + " ";
                    lineLen += s.Length + 1;
                }
                else
                {
                    result += "...";
                    break;
                }
            }

            return result;
        }
    }
}
