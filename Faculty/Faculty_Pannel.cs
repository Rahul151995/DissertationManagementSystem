using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Script.Serialization;
using System.Net;
using System.Collections.Specialized;
namespace Faculty
{
    public partial class Faculty_Pannel : Form
    {
        System.Windows.Forms.ErrorProvider werror;
        public String murlf = "http://localhost/Student_Desigatation/";
        //String murlf = "http://172.25.5.54:8081/student_desigatation/";
        public Faculty_Pannel()
        {
            InitializeComponent();
            werror = new System.Windows.Forms.ErrorProvider();
            panel1.Hide();
            splitContainer1.Panel2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String f_id = faculty_id.Text;
            String f_pass = password.Text;
            String url_serv = murlf+"faculty_login";
//            String url_serv = "http://gubappwebservices.esy.es/faculty_login";
            Uri mur = new Uri(url_serv);
            WebClient wc = new WebClient();
            NameValueCollection form = new NameValueCollection();
            form.Add("faculty_id", f_id);
            form.Add("faculty_password", f_pass);
            byte[] ret = wc.UploadValues(url_serv, form);
            //       wc.UploadValuesAsync(mur,form);
            // String rete = wc.DownloadString(url_serv);
            String mrestt = Encoding.UTF8.GetString(ret);
            //  String mresp = respo.ToString();
            // String ress = resp.ToString();
            JavaScriptSerializer jser = new JavaScriptSerializer();
            server_responce s_resp = jser.Deserialize<server_responce>(mrestt);

            //   s_resp.response_code
            if (s_resp.response_code == 100)
            {
                Faculty_Dashboard facul_dash = new Faculty_Dashboard(f_id);

                //facul_dash.Shown += new EventHandler(cacheacces);
                

                facul_dash.Show();
                //   this.Close();
                //facul_dash.Show(cacheacces());

                //  MessageBox.Show(s_resp.response_desc);
            }
            else
            {
                MessageBox.Show("Invalid Combination","Invalid");
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            splitContainer1.Panel2.Show();

            panel1.Hide();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {

            splitContainer1.Panel2.Show();
            panel1.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            String f_key = fac_key.Text;
            String f_id = fac_id.Text;
            String f_name = fac_name.Text;
            String f_pass = f_password.Text;
            String f_cpass = f_cpassword.Text;
            //String url_serv = "http://gubappwebservices.esy.es/faculty_Registraion";
            String url_serv = murlf+"faculty_Registraion";

            WebClient wc = new WebClient();
            if ((f_password.Equals(f_password))==false)
            {
                MessageBox.Show("Password Not Match");
            }
            else
            {
                NameValueCollection sign_form = new NameValueCollection();
                sign_form.Add("facaultu_key_id", f_key);
                sign_form.Add("faculty_code", f_id);
                sign_form.Add("faculty_name", f_name);
                sign_form.Add("passwo", f_pass);
                byte[] rep= wc.UploadValues(url_serv, sign_form);
                String s_resp = Encoding.UTF8.GetString(rep);
                //MessageBox.Show(s_resp);
                JavaScriptSerializer jscer = new JavaScriptSerializer();
                server_responce ser = jscer.Deserialize<server_responce>(s_resp);
                //MessageBox.Show(ser.response_code.ToString());
                if(ser.response_code==100)
                {
                    MessageBox.Show("You  are now Registered with us","Success");
                    splitContainer1.Panel2.Show();
                    panel1.Hide();

                }
                else
                    if(ser.response_code==102)
                {
                    MessageBox.Show("You are Already Registered ","Sorry");
                }
                else
                    if(ser.response_code==101)
                {
                    MessageBox.Show("Invalid Detail","Invalid");

                }
            }
        }
        private void fac_key_Leave(object sender, EventArgs e)
        {
           String fc_if = fac_key.Text;
            if(fc_if.Equals(""))
            {
                werror.SetError(this.fac_key, "This Field should not be empty");
                fac_key.Focus();  
            }
            else
            {
                werror.SetError(this.fac_key, "");
                werror.Clear();
            }
        }

        private void fac_key_TextChanged(object sender, EventArgs e)
        {

        }

        private void fac_name_Leave(object sender, EventArgs e)
        {
            String f_nm = fac_name.Text;
            if(f_nm.Equals(""))
            {
                werror.SetError(this.fac_name, "The Faculty name should not be empty");
                fac_name.Focus();  
            }
            else
            {
                werror.SetError(this.fac_name, "");
                werror.Clear();
            }
        }

        private void fac_id_Leave(object sender, EventArgs e)
        {
            String f_id = fac_id.Text;
            if(f_id.Equals(""))
            {
                werror.SetError(this.fac_id, "Faculty Id Should not be Blank");
                fac_id.Focus();
            }
            else
            {
                werror.SetError(this.fac_id, "");
                werror.Clear();
            }
        }

        private void f_password_Leave(object sender, EventArgs e)
        {
            String pas = f_password.Text;
            if(pas.Equals(""))
            {
                werror.SetError(f_password, "Password should no be Blank");
            }
            else
            {
                werror.Clear();
            }
        }

        private void panel1_Leave(object sender, EventArgs e)
        {

        }

        private void f_cpassword_Leave(object sender, EventArgs e)
        {
            String c_pas = f_cpassword.Text;
            String pas = f_password.Text;
            if(!(c_pas.Equals(pas)))
            {
                werror.SetError(this.f_password, "Password Not March");
                f_cpassword.Focus();
            }
            else
            {
                werror.Clear();
            }


        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void facultyToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void faculty_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void f_cpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void f_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void fac_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void fac_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
        }

        private void f_cpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                String f_key = fac_key.Text;
                String f_id = fac_id.Text;
                String f_name = fac_name.Text;
                String f_pass = f_password.Text;
                String f_cpass = f_cpassword.Text;
                //String url_serv = "http://gubappwebservices.esy.es/faculty_Registraion";
                String url_serv = murlf + "faculty_Registraion";

                WebClient wc = new WebClient();
                if ((f_password.Equals(f_password)) == false)
                {
                    MessageBox.Show("Password Not Match");
                }
                else
                {
                    NameValueCollection sign_form = new NameValueCollection();
                    sign_form.Add("facaultu_key_id", f_key);
                    sign_form.Add("faculty_code", f_id);
                    sign_form.Add("faculty_name", f_name);
                    sign_form.Add("passwo", f_pass);
                    byte[] rep = wc.UploadValues(url_serv, sign_form);
                    String s_resp = Encoding.UTF8.GetString(rep);
                    //MessageBox.Show(s_resp);
                    JavaScriptSerializer jscer = new JavaScriptSerializer();
                    server_responce ser = jscer.Deserialize<server_responce>(s_resp);
                    //MessageBox.Show(ser.response_code.ToString());
                    if (ser.response_code == 100)
                    {
                        MessageBox.Show("You  are now Registered with us", "Success");
                        splitContainer1.Panel2.Show();
                        panel1.Hide();

                    }
                    else
                        if (ser.response_code == 102)
                    {
                        MessageBox.Show("You are Already Registered ", "Sorry");
                    }
                    else
                        if (ser.response_code == 101)
                    {
                        MessageBox.Show("Invalid Detail", "Invalid");

                    }
                }

            }
        }

        private void password_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                String f_id = faculty_id.Text;
                String f_pass = password.Text;
                String url_serv = murlf + "faculty_login";
                //            String url_serv = "http://gubappwebservices.esy.es/faculty_login";
                Uri mur = new Uri(url_serv);
                WebClient wc = new WebClient();
                NameValueCollection form = new NameValueCollection();
                form.Add("faculty_id", f_id);
                form.Add("faculty_password", f_pass);
                byte[] ret = wc.UploadValues(url_serv, form);
                //       wc.UploadValuesAsync(mur,form);
                // String rete = wc.DownloadString(url_serv);
                String mrestt = Encoding.UTF8.GetString(ret);
                //  String mresp = respo.ToString();
                // String ress = resp.ToString();
                JavaScriptSerializer jser = new JavaScriptSerializer();
                server_responce s_resp = jser.Deserialize<server_responce>(mrestt);

                //   s_resp.response_code
                if (s_resp.response_code == 100)
                {
                    Faculty_Dashboard facul_dash = new Faculty_Dashboard(f_id);

                    //facul_dash.Shown += new EventHandler(cacheacces);


                    facul_dash.Show();
                    //   this.Close();
                    //facul_dash.Show(cacheacces());

                    //  MessageBox.Show(s_resp.response_desc);
                }
                else
                {
                    MessageBox.Show("Invalid Combination", "Invalid");
                }
            }
        }

        private void Faculty_Pannel_Load(object sender, EventArgs e)
        {

        }

        /*  private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
           {

           }*/
    }
    public class server_responce
    {
     public   int response_code { get; set; }
        public String response_desc { get; set; }
    }
}
