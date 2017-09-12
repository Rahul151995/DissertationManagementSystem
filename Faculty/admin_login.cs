using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Specialized;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.IO;
using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Faculty
{
    public partial class admin_login : Form
    {
        String murlf = "http://localhost/Student_Desigatation/";
        //String murlf = "http://172.25.5.54:8081/student_desigatation/";
        public admin_login()
        {
            InitializeComponent();
             werror = new System.Windows.Forms.ErrorProvider();

        }

        private void admin_login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Already in progress");
            }
            else
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!admin_user.Equals("") && !admin_pass.Equals(""))
            {
                 werror.SetError(this.button1, "");
                 werror.Clear();
                String username = admin_user.Text;
                String password = admin_pass.Text;

                String uri =murlf+ "adm_login";
                //   String uri = "http://gubappwebservices.esy.es/adm_login";
                WebClient wc = new WebClient();
                NameValueCollection form = new NameValueCollection();
                form.Add("admin_id", username);
                form.Add("password", password);                
                byte[] resp = wc.UploadValues(uri, form);
                String res_string = Encoding.UTF8.GetString(resp);
                e.Result = res_string;
                
               
            }
            else
            {
                 werror.SetError(this.button1, "Fill all the details");
            }
        }
        private void backgroundWorker1_Runworkercompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String js_string = e.Result.ToString();
            JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            Admin_login adm_json = js.Deserialize<Admin_login>(js_string);
            if (adm_json.responce_code == 100)
            {
                MessageBox.Show("Administrator Verified", "Success!");
                Admin ad = new Admin();
                ad.Show();

            }
            else
            {
                MessageBox.Show("You are not Administrator", "Failure!");

            }
        }
    }
    public class Admin_login
    {
        public int responce_code { get; set; }
    }
}
