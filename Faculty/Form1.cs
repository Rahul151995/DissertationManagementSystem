using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Faculty
{
    public partial class Form1 : Form
    {
        int i = 0;
        String datatravel=null;
       String murlf = "http://localhost/Student_Desigatation/";
     //   String murlf = "http://172.25.5.54:8081/student_desigatation/";
        public Form1()
        {
            InitializeComponent();
      
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            if (i == 0)
            {
               registerpanel.Show();
               // LoginPanel.Hide();
              //  MessageBox.Show("u clicked i = 0");
                i++;
            }
            else
            {
                LoginPanel.Hide();
               // MessageBox.Show("u clicked i>0");
            }
            

        }

        private void registerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (bb == true)
            {
                //  MessageBox.Show("Internet connections are available");


                if (backgroundWorker1.IsBusy)
                {
                    MessageBox.Show("Background task is running");
                }
                else
                {
                    backgroundWorker1.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show("Internet connections are not available");

            }        
         }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String Name = name.Text;
            String Roll_No = rollno.Text;
            String Branch = branch.Text;
            String Broad_Area = broad_area.Text;
            String Topic = topic.Text;

            String am = guide.Text;
            String s = am.Split(' ').First();

            String Guide = s;
            String Password = password.Text;
            String Conform_Password = confirm_pass.Text;
            String Any_other_info = any_other_info.Text;
            if (Name.Equals(""))
            {
                e.Result = "1";
            }
            else if (Roll_No.Equals(""))
            {
                e.Result = "2";
            }
            else if (Branch.Equals(""))
            {
                e.Result = "3";
            }
            else if (Broad_Area.Equals(""))
            {
                e.Result = "4";
            }
            else if (Topic.Equals(""))
            {
                e.Result = "5";
            }
            else if (Guide.Equals(""))
            {
                e.Result = "6";
            }
            else if (Password.Equals(""))
            {
                e.Result = "7";
            }
            else if (Conform_Password.Equals(""))
            {
                e.Result = "8";
            }
            else if (Password.Equals(Conform_Password))
            {
                e.Result = "gbu";
                String uri =murlf+"Student_Registary";


                WebClient wc = new WebClient();
                NameValueCollection form = new NameValueCollection();
                form.Add("name", Name);
                form.Add("roll_no", Roll_No);
                form.Add("branch", Branch);
                form.Add("broad_area", Broad_Area);
                form.Add("topic", Topic);
                form.Add("guide", Guide);
                form.Add("any_other_info", Any_other_info);
                form.Add("password", Password);
                string postData = "name=" + Name + "&roll_no=" + Roll_No + "&branch=" + Branch + "&broad_area=" + Broad_Area + "&topic=" + Topic + "&guide=" +
                                             Guide + "&any_other_info=" + Any_other_info + "&password=" + Password;
                //Setting up connection with Server.
                ASCIIEncoding encoding = new ASCIIEncoding();
                byte[] data = encoding.GetBytes(postData);
                WebRequest request = WebRequest.Create(murlf+"Student_Registary");
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = data.Length;

                Stream stream = request.GetRequestStream();
                stream.Write(data, 0, data.Length);
                stream.Close();

                WebResponse response = request.GetResponse();
                stream = response.GetResponseStream();

                StreamReader sr = new StreamReader(stream);
                String text = sr.ReadToEnd();
                // MessageBox.Show(text);
                Student_resp results = JsonConvert.DeserializeObject<Student_resp>(text);
                string a = results.message;
                MessageBox.Show(a);
            }
            else
            {
                e.Result = "9";
                MessageBox.Show("Password did not match");

            }
        }
        private void backgroundWorker1_RunWorkerCompleted_1(object sender, RunWorkerCompletedEventArgs e)
        {
            string assd = e.Result.ToString();
            errorProvider1.Clear();  //name 
           

            errorProvider1.Clear();
       

            if (assd.Equals("1"))
            {
                errorProvider1.SetError(name, "Nmae is empty");
                //errorProvider2.SetError(name, "Roll No is empty");
            }
            else if (assd.Equals("2"))
            {
                errorProvider1.SetError(name, "Roll No is empty");
            }
            else if (assd.Equals("3"))
            {
                errorProvider1.SetError(name, "Branch is empty");
            }
            else if (assd.Equals("4"))
            {
                errorProvider1.SetError(name, "Broad is empty");
            }
            else if (assd.Equals("5"))
            {
                errorProvider1.SetError(name, "Topic Area is empty");
            }
            else if (assd.Equals("6"))
            {
                errorProvider1.SetError(name, "Guide is empty");
            }
            else if (assd.Equals("7"))
            {
                errorProvider1.SetError(name, "password is empty");
            }
            else if (assd.Equals("8"))
            {
                errorProvider1.SetError(name, "confirm password is empty");
            }
            else if (assd.Equals("8"))
            {
                errorProvider1.SetError(name, " password is not match");
                errorProvider1.SetError(name, " password is not match");
            }
        }


        private void backgroundWorker1_Runworkercompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String gg = e.Result.ToString();

           // show123.AppendText(gg);
           
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginPanel.Show();
            registerpanel.Show();
            
            Studentdetailpanel.Hide();
         
            //LoginPanel.Show();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginPanel.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            String LoginRollNo = rollnoLogin.Text;
            String LoginPassword = passwordLogin.Text;
            
            string postData = "roll_no=" + LoginRollNo + "&password=" + LoginPassword;
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);
            WebRequest request = WebRequest.Create(murlf+"Student_detail_retrive");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream stream = request.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            WebResponse response = request.GetResponse();
            stream = response.GetResponseStream();

            StreamReader sr = new StreamReader(stream);
           String text = sr.ReadToEnd();
           // MessageBox.Show(text);

            Boolean a = text.Contains("Invalid User detail");
            if (a == true)
            {
                MessageBox.Show("invalid user");
                e.Cancel = true;
            }
            else
            {

                MessageBox.Show("valid user");
                student_json[] result = JsonConvert.DeserializeObject<student_json[]>(text);
                String name = result[0].Name.ToString();
                String branch = result[0].Branch.ToString();
                String rollno = result[0].Roll_no.ToString();
                String broadare = result[0].broad_area.ToString();
                String topic = result[0].topic.ToString();
                String anyotherinfo = result[0].any_other_info.ToString();
                String guide = result[0].Guide.ToString();
                String password = result[0].password.ToString();
                datatravel = text;
                e.Result = datatravel;
             } }

        private void backgroundWorker2_Runworkercompleted(object sender, RunWorkerCompletedEventArgs e)
        {           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
            {
            string urlData = String.Empty;
            WebClient wc = new WebClient();
            urlData = wc.DownloadString(murlf+"faculty_drop_down");
            //  MessageBox.Show(urlData);

            Faculty_data[] fcnam = JsonConvert.DeserializeObject<Faculty_data[]>(urlData);//JsonConverter<Faculty_name[]>()

            int x = fcnam.Length;
            for (int i = 0; i < x; i++)
            {

                guide.Items.Insert(i, fcnam[i].Faculty_Code + " " + fcnam[i].Faculty_Namee);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool bb = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();

            if (bb == true)
            {
                if (!backgroundWorker2.IsBusy)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Background task is running");
                }
            }
            else
            {

                MessageBox.Show("Internet is not available");
            }                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
        }

    


        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker2_RunWorkerCompleted_2(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled != true)
            {
                String a = e.Result.ToString();
                Studentdetailpanel.Visible = true;
                Studentdetailpanel.Show();
                student_json[] result = JsonConvert.DeserializeObject<student_json[]>(a);
                String name = result[0].Name.ToString();
                String branch = result[0].Branch.ToString();
                String rollno = result[0].Roll_no.ToString();
                String broadare = result[0].broad_area.ToString();
                String topic = result[0].topic.ToString();
                String anyotherinfo = result[0].any_other_info.ToString();
                String guide = result[0].Guide.ToString();
                String password = result[0].password.ToString();


                label24.Text = name;
                label28.Text = rollno;
                label27.Text = branch;
                label26.Text = broadare;
                label25.Text = topic;
                label23.Text = guide;
                label22.Text = anyotherinfo;
            }
           
        }

        private void Studentdetailpanel_BackgroundImageLayoutChanged(object sender, EventArgs e)
        {

        }

        private void errorProvider1_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
         
           
        }

        private void Studentdetailpanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }


    public class student_json
    {
        public string Name { get; set; }
         public string Roll_no { get; set; }
         public string Branch { get; set; }
         public string broad_area { get; set; }
         public string topic { get; set; }
         public string any_other_info { get; set; }
         public string password { get; set; }
         public string Guide { get; set; }
       
    }
    public class Student_resp
    {
        public string response_code { get; set; }
        public string response_desc { get; set; }
        public string message { get; set; }
 
    }

    public class Faculty_data
    {
        public string Faculty_Code;
        public string Faculty_Namee;

    }

}
