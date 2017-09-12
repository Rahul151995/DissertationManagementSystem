using Newtonsoft.Json;
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
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Excel = Microsoft.Office.Interop.Excel;

namespace Faculty
{

    public partial class Admin : Form
    {
        String murlf = "http://localhost/Student_Desigatation/";
        //  String murlf = "http://172.25.5.54:8081/student_desigatation/";
        String sroll_no = "";
        public Admin()
        {
            InitializeComponent();
            werror = new System.Windows.Forms.ErrorProvider();

            string urlData = String.Empty;
            WebClient wc = new WebClient();
            urlData = wc.DownloadString(murlf + "faculty_drop_down");
            //  MessageBox.Show(urlData);

            Faculty_data[] fcnam = JsonConvert.DeserializeObject<Faculty_data[]>(urlData);//JsonConverter<Faculty_name[]>()

            int x = fcnam.Length;
            for (int i = 0; i < x; i++)
            {

                guide.Items.Insert(i, fcnam[i].Faculty_Code + " " + fcnam[i].Faculty_Namee);
                drop_fact_r.Items.Insert(i, fcnam[i].Faculty_Code);
                sfacultyo.Items.Insert(i, fcnam[i].Faculty_Code);
            }
            String url = murlf + "adm_all_student";
            WebClient wc1 = new WebClient();

            byte[] students = wc1.DownloadData(url);
            String othrstud = Encoding.UTF8.GetString(students);
            Allstudents[] js = JsonConvert.DeserializeObject<Allstudents[]>(othrstud);
            int stu_len = js.Length;
            int j = 0;
            while (j < stu_len)
            {
                selectRoll.Items.Insert(j, js[j].Roll_no);
                j++;
            }


            //     ErrorProvider facrrp =new System.Windows.Forms.ErrorProvider();
        }



        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //add_faculty.Hide();
            werror.Clear();

            splitContainer1.Panel2.Show();
            // registerpanel.Show();
            addfaculty.Hide();

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


            e.Result = "gbu";
            String uri = murlf + "Student_Registary";


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
            WebRequest request = WebRequest.Create(murlf + "Student_Registary");
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

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void registerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            werror.Clear();

            //  registerpanel.Hide();
            //  splitContainer1.Panel2.
            update_passwordPanel.Hide();
            addfaculty.Show();
            //  splitContainer1.Panel2.Hide();








        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addfaculty.Show();
            werror.Clear();

            update_passwordPanel.Show();
            list_student.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (backgroundWorker2.IsBusy)
            {
                MessageBox.Show("Already in progress");
            }
            else
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }

        private void backgroundWorkerupdatePassword_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!admin_user.Equals("") && !admin_newpass.Equals(""))
            {
                werror.SetError(this.button1, "");
                werror.Clear();
                String username = admin_user.Text;
                String newpassword = admin_newpass.Text;

                String uri = murlf + "admin_change";
                //   String uri = "http://gubappwebservices.esy.es//admin_change";
                WebClient wc = new WebClient();
                NameValueCollection form = new NameValueCollection();
                form.Add("admin_id", username);
                form.Add("password", newpassword);
                byte[] resp = wc.UploadValues(uri, form);
                String res_string = Encoding.UTF8.GetString(resp);
                e.Result = res_string;


            }
            else
            {
                werror.SetError(this.button1, "Fill all the details");
            }
        }

        private void backgroundWorkerupdatePassword_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            String js_string = e.Result.ToString();
            JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
            Admin_change adm_json = js.Deserialize<Admin_change>(js_string);
            if (adm_json.response_code == 100)
            {
                MessageBox.Show("Administrator Password Updated", "Success!");

            }
            else
            {
                MessageBox.Show("Administrator Password Updated couldn't be updated", "Failure!");

            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // String f_key = fac_key.Text;
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
                //   sign_form.Add("facaultu_key_id", f_key);
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
                    //splitContainer1.Panel2.Show();
                    // panel1.Hide();

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

        private void button2_Click_1(object sender, EventArgs e)
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


        private void fac_key_TextChanged(object sender, EventArgs e)
        {

        }

        private void fac_name_Leave(object sender, EventArgs e)
        {
            String f_nm = fac_name.Text;
            if (f_nm.Equals(""))
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
            if (f_id.Equals(""))
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
            if (pas.Equals(""))
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
            if (!(c_pas.Equals(pas)))
            {
                werror.SetError(this.f_password, "Password Not March");
                f_cpassword.Focus();
            }
            else
            {
                werror.SetError(this.f_password, "");
                werror.Clear();
            }


        }

        private void f_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_Leave(object sender, EventArgs e)
        {
            /*
            String st_name = name.Text;
            if(st_name.Equals(""))
                {

                name.Focus();
                werror.SetError(this.name, "Student Should have name");
                }
            else
            {
                werror.SetError(this.name,"");
                werror.Clear();
            }
            */

        }

        private void rollno_Leave(object sender, EventArgs e)
        {
            /*
            String rlo = rollno.Text;
            if(rlo.Equals(""))
            {
                rollno.Focus();
                werror.SetError(this.rollno, "Roll no should be not Blank");
            }
            else


            {
                werror.SetError(this.rollno, "");
                werror.Clear();
            }
            */
        }

        private void branch_Leave(object sender, EventArgs e)
        {
            /*
            String br = branch.Text;
            if(br.Equals(""))
            {
                werror.SetError(this.branch,"Branch Should not be blank");
                branch.Focus();
            }
            else
            {
                werror.SetError(this.branch, "");
                werror.Clear();
            }
            */
        }

        private void broad_area_Leave(object sender, EventArgs e)
        {
            /*
            String brod = broad_area.Text;
            if(brod.Equals(""))
            {
                werror.SetError(this.broad_area, "Broad area shoud not blank");
                broad_area.Focus();   
            }
            else
            {
                werror.SetError(this.broad_area, "");
                werror.Clear();
            }
            */
        }

        private void topic_Leave(object sender, EventArgs e)
        {/*
            String topcc = topic.Text;
            if(topcc.Equals(""))
            {
                werror.SetError(this.topic, "Topic should not blank");
                topic.Focus();
            }
            else
            {
                werror.SetError(this.topic, "");
                werror.Clear();
            }
            */
        }

        private void guide_Leave(object sender, EventArgs e)
        {
            /*
            String guid = guide.Text;
            if(guid.Equals(""))
            {
                werror.SetError(this.guide, "Guide Should not blank");
                guide.Focus();
            }
            else
            {
                werror.SetError(this.guide, "");
                werror.Clear();

            }
            */
        }

        private void confirm_pass_Leave(object sender, EventArgs e)
        {
            /*
            String conf_txt = confirm_pass.Text;
            String pas_t = password.Text;
            if(conf_txt==pas_t)
            {
                werror.SetError(this.confirm_pass, "Password and confirm password not match");
                password.Focus();
              //  confirm_pass.Text = "";
                //confirm_pass.Focus();

            }
            else
            {
                werror.SetError(this.confirm_pass, "");
                werror.Clear();
            }
            */
        }

        private void branch_TextChanged(object sender, EventArgs e)
        {

        }

        private void front_admin_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //      stude_list_view.Show();
            avgp.Hide();
            splitContainer1.Panel2.Show();
            addfaculty.Show();
            update_passwordPanel.Show();
            list_student.Show();
            String url = murlf + "adm_student_list";

            ListViewItem lvtt = new ListViewItem("1");
            //   stude_list_view.Items.Add(lvtt);
            //lvtt.
            //stude_list_view.Items.
            //stude_list_view slc = new stude_list_view();

            //     stude_list_view slv = new stude_list_view();

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            String url = murlf + "adm_student_list";
            // String rloo = roll.Text;
            WebClient wc = new WebClient();
            // NameValueCollection nc = new NameValueCollection();
            // nc.Add("stud_id", rloo);
            String rest = wc.DownloadString(url);
            //   String jsonstr = Encoding.UTF8.GetString(rest);
            student_admin[] strs = JsonConvert.DeserializeObject<student_admin[]>(rest);
            int lengt = strs.Length;
            int i = 0;
            while (i < lengt)
            {
                ListViewItem lvtt = new ListViewItem(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Faculty_Name);
                //   lvtt.SubItems.Add(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Student_id);
                lvtt.SubItems.Add(strs[i].Name);
                lvtt.SubItems.Add(strs[i].Branch);

                lvtt.SubItems.Add(strs[i].Report_Writting);
                lvtt.SubItems.Add(strs[i].Technical_Content);
                lvtt.SubItems.Add(strs[i].Presentaion);
                lvtt.SubItems.Add(strs[i].topic);
                lvtt.SubItems.Add(strs[i].Total);
                lvtt.SubItems.Add(strs[i].remark);
                //       stude_list_view.Items.Add(lvtt);
                i++;
            }


        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            String url = murlf + "adm_student_list";
            // String rloo = roll.Text;
            WebClient wc = new WebClient();
            // NameValueCollection nc = new NameValueCollection();
            // nc.Add("stud_id", rloo);
            String rest = wc.DownloadString(url);
            //   String jsonstr = Encoding.UTF8.GetString(rest);
            student_admin[] strs = JsonConvert.DeserializeObject<student_admin[]>(rest);
            int lengt = strs.Length;
            int i = 0;
            while (i < lengt)
            {
                ListViewItem lvtt = new ListViewItem(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Faculty_Name);
                //   lvtt.SubItems.Add(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Student_id);
                lvtt.SubItems.Add(strs[i].Name);
                lvtt.SubItems.Add(strs[i].Branch);

                lvtt.SubItems.Add(strs[i].Report_Writting);
                lvtt.SubItems.Add(strs[i].Technical_Content);
                lvtt.SubItems.Add(strs[i].Presentaion);
                lvtt.SubItems.Add(strs[i].topic);
                lvtt.SubItems.Add(strs[i].Total);
                lvtt.SubItems.Add(strs[i].remark);
                //     stude_list_view.Items.Add(lvtt);
                i++;
            }




        }

        private void button3_Click_3(object sender, EventArgs e)
        {
            String url = murlf + "adm_student_list";
            WebClient wc = new WebClient();
            String ress = wc.DownloadString(url);
            student_admin[] str = JsonConvert.DeserializeObject<student_admin[]>(ress);
            int arsiz = str.Length;

            int i = 0;
            while (i < arsiz)
            {
                ListViewItem ltvs = new ListViewItem(str[i].Faculty_Code);
                ltvs.SubItems.Add(str[i].Faculty_Name);
                ltvs.SubItems.Add(str[i].Student_id);
                ltvs.SubItems.Add(str[i].Name);
                ltvs.SubItems.Add(str[i].Branch);
                ltvs.SubItems.Add(str[i].topic);
                ltvs.SubItems.Add(str[i].Technical_Content);
                ltvs.SubItems.Add(str[i].Presentaion);
                ltvs.SubItems.Add(str[i].Report_Writting);
                ltvs.SubItems.Add(str[i].Total);
                ltvs.SubItems.Add(str[i].remark);
                //   stude_list_view.Items.Add(ltvs);
                i++;
            }

        }

        private void addfaculty_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void update_passwordPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void admin_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void admin_newpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void f_cpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void fac_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void fac_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void any_other_info_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void confirm_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void guide_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }

        private void topic_TextChanged(object sender, EventArgs e)
        {

        }

        private void broad_area_TextChanged(object sender, EventArgs e)
        {

        }

        private void rollno_TextChanged(object sender, EventArgs e)
        {

        }

        private void name_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_4(object sender, EventArgs e)
        {
            String url = murlf + "adm_student_list";
            // String rloo = roll.Text;
            WebClient wc = new WebClient();
            // NameValueCollection nc = new NameValueCollection();
            // nc.Add("stud_id", rloo);
            String rest = wc.DownloadString(url);
            //   String jsonstr = Encoding.UTF8.GetString(rest);
            student_admin[] strs = JsonConvert.DeserializeObject<student_admin[]>(rest);
            int lengt = strs.Length;
            int i = 0;
            while (i < lengt)
            {
                ListViewItem lvtt = new ListViewItem(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Faculty_Name);
                //   lvtt.SubItems.Add(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Student_id);
                lvtt.SubItems.Add(strs[i].Name);
                lvtt.SubItems.Add(strs[i].Branch);

                lvtt.SubItems.Add(strs[i].Report_Writting);
                lvtt.SubItems.Add(strs[i].Technical_Content);
                lvtt.SubItems.Add(strs[i].Presentaion);
                lvtt.SubItems.Add(strs[i].topic);
                lvtt.SubItems.Add(strs[i].Total);
                lvtt.SubItems.Add(strs[i].remark);
                // stude_list_view.Items.Add(lvtt);
                i++;
            }
        }

        private void button3_Click_5(object sender, EventArgs e)
        {
            String url = murlf + "adm_student_list";
            // String rloo = roll.Text;
            WebClient wc = new WebClient();
            // NameValueCollection nc = new NameValueCollection();
            // nc.Add("stud_id", rloo);
            String rest = wc.DownloadString(url);
            //   String jsonstr = Encoding.UTF8.GetString(rest);
            student_admin[] strs = JsonConvert.DeserializeObject<student_admin[]>(rest);
            int lengt = strs.Length;
            int i = 0;
            while (i < lengt)
            {
                ListViewItem lvtt = new ListViewItem(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Faculty_Name);
                //   lvtt.SubItems.Add(strs[i].Faculty_Code);
                lvtt.SubItems.Add(strs[i].Student_id);
                lvtt.SubItems.Add(strs[i].Name);
                lvtt.SubItems.Add(strs[i].Branch);

                lvtt.SubItems.Add(strs[i].Report_Writting);
                lvtt.SubItems.Add(strs[i].Technical_Content);
                lvtt.SubItems.Add(strs[i].Presentaion);
                lvtt.SubItems.Add(strs[i].topic);
                lvtt.SubItems.Add(strs[i].Total);
                lvtt.SubItems.Add(strs[i].remark);
                //stude_list_view.Items.Add(lvtt);
                i++;
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void averageMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            werror.Clear();
            addfaculty.Show();
            update_passwordPanel.Show();
            list_student.Show();
            avgp.Show();
            GroupByfacPanel.Hide();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //rahulSuper_user
        String rest = null;
        private void button4_Click(object sender, EventArgs e)
        {
            String url = murlf + "avgstudent_marks";
            WebClient wc = new WebClient();
            rest = wc.DownloadString(url);
            student_admins[] strs = JsonConvert.DeserializeObject<student_admins[]>(rest);
            int lengt = strs.Length;
            int j = 0;
            listView1.Items.Clear();
            while (j < lengt)
            {
                ListViewItem lvtt = new ListViewItem(strs[j].Roll_no);
                //lvtt.SubItems.Add(strs[j].Roll_no);          
                lvtt.SubItems.Add(strs[j].Guide);
                lvtt.SubItems.Add(strs[j].Faculty_Code);
                lvtt.SubItems.Add(strs[j].avg_total);

                listView1.Items.Add(lvtt);

                j++;
            }





        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
        String studen_res_string = null;
        private void selectRoll_Leave(object sender, EventArgs e)
        {

            // String url = "http://gubappwebservices.esy.es/Student_detail_retrive_faculty";
            String url = murlf + "adm_acc_student";
            sroll_no = selectRoll.Text;
            if (!roll_no.Equals("Select Roll No"))
            {
                WebClient wc1 = new WebClient();
                NameValueCollection value = new NameValueCollection();
                studentlist.Items.Clear();
                value.Add("stud_id", sroll_no);
                byte[] stud_resp = wc1.UploadValues(url, value);
                studen_res_string = Encoding.UTF8.GetString(stud_resp);
                GroupByFac[] result = JsonConvert.DeserializeObject<GroupByFac[]>(studen_res_string);
                // marks_exist[] me = JsonConvert.DeserializeObject<marks_exist[]>(res_string);
                if (result.Length > 0)
                {
                    werror.Clear();
                    werror.SetError(this.selectRoll, "");
                    int lengt = result.Length;
                    int i = 0;
                    studentlist.Items.Clear();
                    while (lengt > i)
                    {
                        String Sr = (i + 1).ToString();
                        ListViewItem mylist = new ListViewItem(Sr);

                        mylist.SubItems.Add(result[i].Faculty_Code);
                        mylist.SubItems.Add(result[i].Report_Writting);
                        mylist.SubItems.Add(result[i].Technical_Content);
                        mylist.SubItems.Add(result[i].Presentaion);
                        mylist.SubItems.Add(result[i].Total);
                        mylist.SubItems.Add(result[i].remark);
                        studentlist.Items.Add(mylist);
                        i++;
                    }
                }
                else
                {
                    werror.SetError(this.selectRoll, "This Student is not yet Evaluated ");
                    selectRoll.Focus();
                }
            }
            else
            {
                selectRoll.Focus();
                //   werror.SetError(this.Roll_textbox, "");
            }
        }

        private void groupByFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addfaculty.Show();
            werror.Clear();
            update_passwordPanel.Show();
            list_student.Show();
            avgp.Show();
            
            GroupByfacPanel.Show();
            faculty_r.Hide();

        }
        public void printmypage()
        {
            PrintDialog prd = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            prd.Document = pdoc;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage_1);
            DialogResult drdd = prd.ShowDialog();
            if(drdd==DialogResult.OK)
            {
                printDocument1.Print();
            }
        }


        public void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
        
        }
        private void selectRoll_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupByFacultyrahulToolStripMenuItem_Click(object sender, EventArgs e)
        {

            werror.Clear(); GroupByfacPanel.Show();
            avgp.Show();
            addfaculty.Show();
            update_passwordPanel.Show();
            list_student.Show();
            faculty_r.Show();
            student_under_faculty.Hide();
        }
        String res_strings_fact = null;
        private void drop_fact_r_SelectedIndexChanged(object sender, EventArgs e)
        {
            //rahul

            // String url = "http://gubappwebservices.esy.es/adm_acc_faculty";
            String url = murlf + "adm_acc_faculty";
            sroll_no = drop_fact_r.Text;
            if (!roll_no.Equals("Select Roll No"))
            {
                WebClient wc1 = new WebClient();
                NameValueCollection value = new NameValueCollection();
                studentlist.Items.Clear();
                value.Add("fact_id", sroll_no);
                byte[] stud_resp = wc1.UploadValues(url, value);
                res_strings_fact = Encoding.UTF8.GetString(stud_resp);
                Accf[] results = JsonConvert.DeserializeObject<Accf[]>(res_strings_fact);
                // marks_exist[] me = JsonConvert.DeserializeObject<marks_exist[]>(res_string);
                if (results.Length > 0)
                {
                  //  werror.Clear();
                   // werror.SetError(this.selectRoll, "");
                    int lengt = results.Length;
                    
                    listView2.Items.Clear();
                    for(int i = 0; i < lengt;i++ )
                    {
                        String Sr = (i + 1).ToString();
                        ListViewItem mylist = new ListViewItem(Sr);


                        mylist.SubItems.Add(results[i].ID);
                        mylist.SubItems.Add(results[i].Faculty_Code);
                        mylist.SubItems.Add(results[i].Student_id);
                        mylist.SubItems.Add(results[i]._internal);
                        mylist.SubItems.Add(results[i].Report_Writting);
                        mylist.SubItems.Add(results[i].Technical_Content);
                        mylist.SubItems.Add(results[i].Presentaion);
                        mylist.SubItems.Add(results[i].Total);
                        mylist.SubItems.Add(results[i].remark);
                        listView2.Items.Add(mylist);
                       
                    }
                }
                else
                {
                   // werror.SetError(this.selectRoll, "This Student is not yet Evaluated ");
                  //  selectRoll.Focus();
                }
            }
            else
            {
                //selectRoll.Focus();
                //   werror.SetError(this.Roll_textbox, "");
            }









            //rahul
        }

        private void Printcmd_Click(object sender, EventArgs e)
        {
            printmypage();
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            Graphics gr = e.Graphics;
            Font fn = new Font("Courier New", 8);
            float fhgt = fn.GetHeight();
            int stx = 3;
            int sty = 3;
            int offst = 20;

            String url = murlf + "avgstudent_marks";
            WebClient wc = new WebClient();
            String rest = wc.DownloadString(url);
            MessageBox.Show(rest);
            student_admins[] strs = JsonConvert.DeserializeObject<student_admins[]>(rest);
            int lengt = strs.Length;
            int j = 0;
            //  listView1.Items.Clear();
            while (j < lengt)
            {
                String rollno = strs[j].Roll_no; //{ get; set; }
                String guid = strs[j].Guide;//{ get; set; }
                String facultyCode = strs[j].Faculty_Code; //{ get; set; }
                String avgtotal = strs[j].avg_total;//{ get; set; }
                String prrout = rollno + " " + guid + " " + facultyCode + " " + avgtotal;
                MessageBox.Show(prrout);
                gr.DrawString(prrout, fn, new SolidBrush(Color.Black), stx + 10, sty + offst);
                offst = offst + (int)fhgt + 10;
                j++;
            }

        }
        public void  printbyfaculty()
        {
            PrintDialog pdi = new PrintDialog();
            PrintDocument pdoc = new PrintDocument();
            pdi.Document = pdoc;
            pdoc.PrintPage += new PrintPageEventHandler(printDocument2_PrintPage);
            DialogResult drss = pdi.ShowDialog();
            if (drss==DialogResult.OK)
            {
                printDocument2.Print();
            }
        }

        private void button3_Click_6(object sender, EventArgs e)
        {
            printbyfaculty();
        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics grp = e.Graphics;
            Font fnt=new Font("Courier New", 8);
            float fhgt = fnt.GetHeight();
            int stxx = 3;
            int styy = 3;
            int stoff = 10;
            Accf[] jsres = JsonConvert.DeserializeObject<Accf[]>(res_strings_fact);
            int p = 0;
            while(p<jsres.Length)
            {
                String sid = jsres[p].ID;
                String faculty_code = jsres[p].Faculty_Code;
                String student_id = jsres[p].Student_id;
                String s_internal = jsres[p]._internal;
                String report_writting = jsres[p].Report_Writting;
                String technical_content = jsres[p].Technical_Content;
                String presentaion = jsres[p].Presentaion;
                String total = jsres[p].Total;
                String remark = jsres[p].remark;
                String prrst = sid + " " + faculty_code + " " + student_id + " " + " " + s_internal + " " + " " + report_writting + " " + " " + technical_content + " " + presentaion + " " + total + " " + remark;
                grp.DrawString(prrst, fnt, new SolidBrush(Color.Black), stxx + 10, styy + stoff);
                stoff = stoff + 20;
                 p++;
            }
           // WebClient wec = new WebClient();



        }
         public void printaccstuden()
        {
            PrintDialog pdr = new PrintDialog();
            PrintDocument pdocc = new PrintDocument();
            pdr.Document = pdocc;
            pdocc.PrintPage += new PrintPageEventHandler(printDocument3_PrintPage);
            DialogResult dress = pdr.ShowDialog();
            if (DialogResult.OK==dress)
            {
                printDocument3.Print();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            printaccstuden();
        }

        private void printDocument3_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics grp = e.Graphics;
            Font fnt = new Font("Courier New", 8);
            int stxx = 10;
            int styy = 10;
            int stoff = 10;

            GroupByFac[] res = JsonConvert.DeserializeObject<GroupByFac[]>(studen_res_string);
            int k = 0;
            while(k<res.Length)
            {
                String faculty_code = res[k].Faculty_Code;
                String report_writting = res[k].Report_Writting;
                String technical_content = res[k].Technical_Content;
                String presentaion = res[k].Technical_Content;
                String total = res[k].Total;
                String remark = res[k].remark;
                String prro = faculty_code + " " + report_writting + " " + technical_content + " " + presentaion + " " + total + " " + remark;
                grp.DrawString(prro, fnt, new SolidBrush(Color.Black), stxx + 10, styy + stoff);
                    stoff = stoff + 10;
                k++;
            }


        }

        private void studentUnderFacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            werror.Clear(); GroupByfacPanel.Show();
            avgp.Show();
            addfaculty.Show();
            update_passwordPanel.Show();
            list_student.Show();
            faculty_r.Show();
            student_under_faculty.Show();

        }

        private void sfacultyo_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView3.Items.Clear();
            String fculid = sfacultyo.Text;
            WebClient wec = new WebClient();
            NameValueCollection nec = new NameValueCollection();
            nec.Add("fac_id", fculid);
            byte[] resp = wec.UploadValues(murlf + "student_data_retr_dir_faculty", nec);
            String sresp = Encoding.UTF8.GetString(resp);
            student_unde_fact[] facut = JsonConvert.DeserializeObject<student_unde_fact[]>(sresp);
            //MessageBox.Show(sresp);
            int k = 0;
            while(k<facut.Length)
            {
             //   MessageBox.Show(facut[k].name);
                ListViewItem ls = new ListViewItem(facut[k].name);
                ls.SubItems.Add(facut[k].roll_no);
                ls.SubItems.Add(facut[k].branch);
                ls.SubItems.Add(facut[k].topic);
                ls.SubItems.Add(facut[k].broad_area);
                listView3.Items.Add(ls);
                k++;
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            if(xlapp==null)
            {
                MessageBox.Show("Microsft Excel Not Found", "Error", MessageBoxButtons.OKCancel);
            }
            Excel.Workbook workbok;
            Excel.Worksheet workshet;
            object misValue = System.Reflection.Missing.Value;
            workbok = xlapp.Workbooks.Add(misValue);
            workshet = (Excel.Worksheet)workbok.Worksheets.get_Item(1);
            //     workshet = (Excel.Worksheets)workbok.Worksheets.get_Item(1);
            workshet.Cells[1,1] = "Sno";
            workshet.Cells[1, 2] = "Faculty Code";
            workshet.Cells[1, 3] = "Student ID";
            workshet.Cells[1, 4] = "Internal";
            workshet.Cells[1, 5] = "Report Writing";
            workshet.Cells[1, 6] = "Technical Content";
            workshet.Cells[1, 7] = "Presentation";
            workshet.Cells[1, 8] = "Total";
            //   WebClient we = new WebClient();
            Accf[] rst = JsonConvert.DeserializeObject<Accf[]>(res_strings_fact);
            for(int i=0;i<rst.Length;i++)
            {
                workshet.Cells[i + 2, 1] = rst[i].ID;
                workshet.Cells[i + 2, 2] = rst[i].Faculty_Code;
                workshet.Cells[i + 2, 3] = rst[i].Student_id;
                workshet.Cells[i + 2, 4] = rst[i]._internal;
                workshet.Cells[i + 2, 5] = rst[i].Report_Writting;
                workshet.Cells[i + 2, 6] = rst[i].Technical_Content;
                workshet.Cells[i + 2, 7] = rst[i].Presentaion;
                workshet.Cells[i + 2, 8] = rst[i].Total;

            }
            workbok.SaveAs("d:\\According Faculty.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            workbok.Close(true, misValue, misValue);
            xlapp.Quit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            if(xlapp==null)
            {
                MessageBox.Show("Microsoft Excel not installed", "Error", MessageBoxButtons.OKCancel);
            }
            Excel.Workbook exwork;
            Excel.Worksheet exsheet;
            object misValue = System.Reflection.Missing.Value;
            exwork = xlapp.Workbooks.Add(misValue);
            exsheet = (Excel.Worksheet)exwork.Worksheets.get_Item(1);
            //exsheet.Cells[1, ] = "S.NO.";
            exsheet.Cells[1, 1] = "Faculty Code";
            exsheet.Cells[1, 2] = "Report";
            exsheet.Cells[1, 3] = "Technical";
            exsheet.Cells[1, 4] = "Presentation";
            exsheet.Cells[1, 5] = "Total";
            GroupByFac[] gfac = JsonConvert.DeserializeObject<GroupByFac[]>(studen_res_string);
            for(int i=0;i<gfac.Length;i++)
            {
                exsheet.Cells[i + 2, 1] = gfac[i].Faculty_Code;
                exsheet.Cells[i + 2, 2] = gfac[i].Report_Writting;
                exsheet.Cells[i + 2, 3] = gfac[i].Technical_Content;
                exsheet.Cells[i + 2, 4] = gfac[i].Presentaion;
                exsheet.Cells[i + 2, 5] = gfac[i].Total;
            }
            exwork.SaveAs("d:\\According to Student.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            exwork.Close(true, misValue, misValue);
            xlapp.Quit();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            Excel.Workbook exworkb;
            Excel.Worksheet exsheet;
            object misValue = System.Reflection.Missing.Value;
            exworkb = xlapp.Workbooks.Add(misValue);
            exsheet = exworkb.Worksheets.get_Item(1);
            exsheet.Cells[1, 1] = "Roll No";
            exsheet.Cells[1, 2] = "Guide";
            exsheet.Cells[1, 3] = "Facuty Code";
            exsheet.Cells[1, 4] = "Average";
            student_admins[] stadmin = JsonConvert.DeserializeObject<student_admins[]>(rest);
            for(int i=0;i<stadmin.Length;i++)
            {
                exsheet.Cells[i + 2, 1] = stadmin[i].Roll_no;
                exsheet.Cells[i + 2, 2] = stadmin[i].Guide;
                exsheet.Cells[i + 2, 3] = stadmin[i].Faculty_Code;
                exsheet.Cells[i + 2, 4] = stadmin[i].avg_total;




            }
            exworkb.SaveAs("d:\\All Student.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            exworkb.Close(true, misValue, misValue);
            xlapp.Quit();


            //String rest

        }
    }
    public class Admin_change
    {
        public int response_code { get; set; }
    }




    public class student_admin
    {
        public String Name { get; set; }
        public String Faculty_Name { get; set; }
        public String Faculty_Code { get; set; }
        public String Student_id { get; set; }
        // public String Name { get; set; }
        public String Branch { get; set; }
        // public String Faculty_Name { get; set; }
        public String Report_Writting { get; set; }
        // public String Faculty_Code { get; set; }
        public String Technical_Content { get; set; }
        public String topic { get; set; }
        public String Presentaion { get; set; }
        public String Total { get; set; }
        public String remark { get; set; }
        //  public String Report_Writting { get; set; }
    }
    public class student_admins
    {
        public String Roll_no { get; set; }
        public String Guide { get; set; }
        public String Faculty_Code { get; set; }
        public String avg_total { get; set; }
    }



    public class GroupByFac
    {

        public string Faculty_Code { get; set; }
        public string Report_Writting { get; set; }
        public string Technical_Content { get; set; }
        public string Presentaion { get; set; }
        public string Total { get; set; }
        public string remark { get; set; }
    }

    public class Allstudents
    {
        public string Roll_no { get; set; }
    }





    public class Accf
    {
        public string ID { get; set; }
        public string Faculty_Code { get; set; }
        public string Student_id { get; set; }
        public string _internal { get; set; }
        public string Report_Writting { get; set; }
        public string Technical_Content { get; set; }
        public string Presentaion { get; set; }
        public string Total { get; set; }
        public string remark { get; set; }
    }
    public class student_unde_fact
    {
            public String name;
            public String roll_no;
            public String branch;
            public String topic;
            public String broad_area;
            public String guide;
     }






}
