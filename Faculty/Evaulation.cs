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
//using System.Threading.Tasks;
namespace Faculty
{
    public partial class Evaulation : Form
    {
        String murlf = "http://localhost/Student_Desigatation/";
        //String murlf = "http://172.25.5.54:8081/student_desigatation/";
        String report_marks = "";
        String technical_marks = "";
        String presentation_marks = "";
        String total_marks = "";
        String roll_no = "";
        static String fac_idf = "";
        public Evaulation(String f_id)
        {
            InitializeComponent();
            fac_idf = f_id;
            werror = new System.Windows.Forms.ErrorProvider();
            // String url = "http://gubappwebservices.esy.es/out_of_faculty";
            String url = murlf+"out_of_faculty";
            WebClient wc1 = new WebClient();
            NameValueCollection form = new NameValueCollection();
            form.Add("fact_id", fac_idf);
            byte[] otherstudents = wc1.UploadValues(url, form);
            String othrstud = Encoding.UTF8.GetString(otherstudents);
            OtherStudent[] js = JsonConvert.DeserializeObject<OtherStudent[]>(othrstud);
            int stu_len = js.Length;
            int i = 0;
            while (i < stu_len)
            {
                Roll_comboBox.Items.Insert(i, js[i].Roll_no);
                i++;
            }
        }       
        private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                MessageBox.Show("Already in progress");
            }
            else
            {
                backgroundWorker.RunWorkerAsync();

            }
        }
        private void button2_Click(object sender, EventArgs e) { 
            // String url = "http://gubappwebservices.esy.es/student_evaluted";
            String url = murlf+"student_evaluted";
            WebClient wc1 = new WebClient();
            byte[] eval_stud = wc1.DownloadData(url);
            String evalstud_str = Encoding.UTF8.GetString(eval_stud);
            EvaluatedStudents[] ev_stud = JsonConvert.DeserializeObject<EvaluatedStudents[]>(evalstud_str);
            int lengt = ev_stud.Length;
            int i = 0;
            evaluated_list.Items.Clear();
            while (lengt > i)
            {
                String Sr = (i + 1).ToString();
                ListViewItem mylist = new ListViewItem(Sr);
                mylist.SubItems.Add(ev_stud[i].Student_id);
                mylist.SubItems.Add(ev_stud[i].Name);
                mylist.SubItems.Add(ev_stud[i].Report_Writting);
                mylist.SubItems.Add(ev_stud[i].Technical_Content);
                mylist.SubItems.Add(ev_stud[i].Presentaion);
                mylist.SubItems.Add(ev_stud[i].Total);
                evaluated_list.Items.Add(mylist);
                i++;
            }
        }
        private void Report_textbox_Leave(object sender, EventArgs e)
        {
            report_marks = Report_textbox.Text;
            double rm;
            Double.TryParse(report_marks, out rm);
            if (rm < 0 || rm > 10)
            {
                werror.SetError(this.Report_textbox, "Only marks Between 0 to 10 allowed");
                Report_textbox.Focus();
            }
            else
            {
                werror.SetError(this.Report_textbox, "");
                werror.Clear();
            }
        }

        private void Roll_textbox_Leave(object sender, EventArgs e)
        {
            // String url = "http://gubappwebservices.esy.es/Student_detail_retrive_faculty";
            String url = murlf + "Student_detail_retrive_faculty";
            roll_no = Roll_comboBox.Text;           
            if (!roll_no.Equals("Select Roll No."))
            {
                WebClient wc1 = new WebClient();
                NameValueCollection value = new NameValueCollection();
                value.Add("roll_no", roll_no);
                value.Add("facult_id", fac_idf);
                byte[] stud_resp = wc1.UploadValues(url, value);
                String res_string = Encoding.UTF8.GetString(stud_resp);
                Student_json[] result = JsonConvert.DeserializeObject<Student_json[]>(res_string);
                // marks_exist[] me = JsonConvert.DeserializeObject<marks_exist[]>(res_string);
                if (result.Length > 0)
                {
                    //  String url2 = "http://gubappwebservices.esy.es/mark_already_exist";
                    String url2 = murlf + "mark_already_exist";
                    WebClient wc2 = new WebClient();
                    NameValueCollection value2 = new NameValueCollection();
                    value2.Add("facult_id", fac_idf);
                    value2.Add("studen_id", roll_no);
                    byte[] stud_resp2 = wc2.UploadValues(url2, value2);
                    String roll_alredy = Encoding.UTF8.GetString(stud_resp2);
                    JavaScriptSerializer js2 = new System.Web.Script.Serialization.JavaScriptSerializer();
                    //JavaScriptSerializer jd1=
                    marks_exist resp_json2 = js2.Deserialize<marks_exist>(roll_alredy);
                    if (resp_json2.response_code == 100)
                    {
                        String name = result[0].Name.ToString();
                        String cl = result[0].Branch.ToString();
                        name_textview.Text = name;
                        class_textview.Text = cl;
                    }
                    else if (resp_json2.response_code == 106)
                    {
                        // werror.SetError(this.Roll_textbox, "Already evaluatted");
                        //Roll_textbox.Focus();
                        DialogResult checkmsgbox = MessageBox.Show("Click on Ok to update marks", "Already evaluated", MessageBoxButtons.OKCancel);
                        if (checkmsgbox == DialogResult.OK)
                        {
                            String name = result[0].Name.ToString();
                            String cl = result[0].Branch.ToString();
                            name_textview.Text = name;
                            class_textview.Text = cl;
                        }
                        else
                        {
                            Roll_comboBox.Text = "Select Roll No.";
                            Roll_comboBox.Focus();
                        }
                    }
                }
                else
                {
                    werror.SetError(this.Roll_comboBox, "Student with this Roll No may have not registered ");
                    Roll_comboBox.Focus();
                }
            }
            else
            {
                Roll_comboBox.Focus();
                //   werror.SetError(this.Roll_textbox, "");
            }
        }

        private void Technical_textbox_Leave(object sender, EventArgs e)
        {
            technical_marks = Technical_textbox.Text;
            double tm;
            Double.TryParse(technical_marks, out tm);
            if (tm < 0 || tm > 10)
            {
                werror.SetError(this.Technical_textbox, "Only marks Between 0 to 10 allowed");
                Technical_textbox.Focus();

            }
            else
            {
                werror.SetError(this.Technical_textbox, "");
                werror.Clear();
            }
        }
        private void Presentation_textbox_Leave(object sender, EventArgs e)
        {
            presentation_marks = Presentation_textbox.Text;
            double pm;
            Double.TryParse(presentation_marks, out pm);
            if (pm < 0 || pm > 10)
            {
                werror.SetError(this.Presentation_textbox, "Only marks Between 0 to 10 allowed");
                Presentation_textbox.Focus();
            }
            else
            {
                werror.SetError(this.Presentation_textbox, "");
                werror.Clear();
                report_marks = Report_textbox.Text;
                technical_marks = Technical_textbox.Text;
                presentation_marks = Presentation_textbox.Text;
                if (report_marks.Equals("") || technical_marks.Equals("") || presentation_marks.Equals(""))
                {
                    werror.SetError(this.total_textview, "Some marks field may be empty ");
                }
                else
                {
                    werror.SetError(this.total_textview, "");
                    werror.Clear();
                    double rm;
                    Double.TryParse(report_marks, out rm);
                    double tm;
                    Double.TryParse(technical_marks, out tm);

                    Double.TryParse(presentation_marks, out pm);
                    double total = rm + tm + pm;
                    total_marks = total.ToString();
                    total_textview.Text = total_marks;
                }
            }
        }

        private void total_textview_Leave(object sender, EventArgs e)
        {
            double tm;
            Double.TryParse(total_marks, out tm);
            if (tm < 0 || tm > 10)
            {
                werror.SetError(this.total_textview, "Only marks Between 0 to 10 allowed");
                total_textview.Focus();
            }
            else
            {
                werror.SetError(this.total_textview, "");
                werror.Clear();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!roll_no.Equals("") && !report_marks.Equals("") && !technical_marks.Equals("") && !presentation_marks.Equals("") && !total_marks.Equals(""))
            {
                werror.SetError(this.button1, "");
                werror.Clear();
               // roll_no = Roll_comboBox.Text;
                String remarks = Remarks_textbox.Text;
                String uri = murlf + "marks_evaluation";
                //   String uri = "http://gubappwebservices.esy.es/marks_evaluation";
                WebClient wc = new WebClient();
                NameValueCollection form = new NameValueCollection();
                form.Add("facult_id", fac_idf);
                form.Add("studen_id", roll_no);
                form.Add("report_marks", report_marks);
                form.Add("technical_marks", technical_marks);
                form.Add("presentation_marks", presentation_marks);
                form.Add("total", total_marks);
                form.Add("remark", remarks);
                byte[] resp = wc.UploadValues(uri, form);
                String res_string = Encoding.UTF8.GetString(resp);
                JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
                marks_json resp_json = js.Deserialize<marks_json>(res_string);
                if (resp_json.response_code == 100)
                {
                    //Response_label.ForeColor = Color.Green;
                    // Response_label.Text = "Marks Submitted Successfully";
                    MessageBox.Show("Marks Submitted Successfully!", "Marks Evaluation Successfull");

                }
                else if (resp_json.response_code == 110)
                {
                    MessageBox.Show("Marks Updated Successfully!", "Marks Updation Successfull");

                }
                else
                {
                    MessageBox.Show("Something went wrong...Please Try Again", "Marks Evaluation Failed");
                }
                // e.Result = res_string;

            }
            else
            {
                werror.SetError(this.button1, "Fill all the details");
            }
         
        }
        private void backgroundWorker1_Runworkercompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //MessageBox.Show("Check");
            // String jsn = (e.Result).ToString();

        }
        public class Student_json
        {
            public string Name { get; set; }
            public string Branch { get; set; }
            public string broad_area { get; set; }
        }
        public class marks_json
        {
            public int response_code { get; set; }
        }
        public class marks_exist
        {
            public int response_code { get; set; }
        }
        public class EvaluatedStudents
        {

            public string Student_id { get; set; }
            public string Name { get; set; }
            public string Report_Writting { get; set; }
            public string Technical_Content { get; set; }
            public string Presentaion { get; set; }
            public string Total { get; set; }

        }

        public class Rootobject
        {
            public OtherStudent[] Property1 { get; set; }
        }

        public class OtherStudent        {
            public string Roll_no { get; set; }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Roll_comboBox.Text = "Select Roll No.";
            werror.Clear();
            Roll_comboBox.Focus();
            name_textview.Text = "";
            class_textview.Text = "";
            Report_textbox.Clear();
            Technical_textbox.Clear();
            Presentation_textbox.Clear();
            total_textview.Text = "";
            Remarks_textbox.Text = "";
            werror.SetError(this.Report_textbox, "");
            werror.SetError(this.Technical_textbox, "");
            werror.SetError(this.Presentation_textbox, "");
        }
    }
}
