using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.Caching;
using System.Net;
using System.Web.Script.Serialization;
using System.Collections.Specialized;
using Newtonsoft.Json;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using Excel = Microsoft.Office.Interop.Excel;
//using System.Windows.Forms;
namespace Faculty
{
    public partial class Faculty_Dashboard : Form
    {

        String nm = null;
        String murlf = "http://localhost/Student_Desigatation/";
      //  String murlf = "http://172.25.5.54:8081/student_desigatation/";
        public Faculty_Dashboard(String nam)
        {
            InitializeComponent();
            nm = nam;
            Faculty_Pannel fcp = new Faculty_Pannel();
            fcp.Visible = false;
         //   MessageBox.Show("Dashboad");
            String urlst = murlf+"stun_under_faculty";
            WebClient we = new WebClient();
            NameValueCollection dat = new NameValueCollection();
            dat.Add("facult_id", nam);
            byte[] bt = we.UploadValues(urlst,dat);
            String rep = Encoding.UTF8.GetString(bt);
            stu_data_ser[] js = JsonConvert.DeserializeObject<stu_data_ser[]>(rep);
            
            int stu_len = js.Length;
            int i = 0;
            while (i<stu_len)
            {
                comboBox1.Items.Insert(i, js[i].roll_no);//+"  "+ js[i].name );
                //MessageBox.Show(js[i].name);
                comboBox2.Items.Insert(i, js[i].roll_no);
                comboBox3.Items.Insert(i, js[i].roll_no);
                comboBox4.Items.Insert(i, js[i].roll_no);
                i++;
            }
           

            Faculty_Pannel frm = new Faculty_Pannel();
            frm.Visible = false;
            // MessageBox.Show(nam);
           
        }
         

        private void Faculty_Dashboard_Load(object sender, EventArgs e)
        {
            tabPage1.Text = "My Student";
            tabPage2.Text = "Evaluation";
            WebClient we = new WebClient();
            MessageBox.Show("Dashboard");
            Faculty_Pannel fcp = new Faculty_Pannel();
            fcp.Visible = false;
            fcp.Close();
           
            //fcp.Show()
            //fcp.Show();
            //Faculty_Pannel.Visible = false;
            NameValueCollection nform = new NameValueCollection();
            nform.Add("fac_id", nm);
            String urls = murlf+"student_data_retr_dir_faculty";
            byte[] data = we.UploadValues(urls, nform);
            String resp = Encoding.UTF8.GetString(data);
            //MessageBox.Show(resp);
            // JavaScriptSerializer jser = new JavaScriptSerializer();
            //   List<stu_data_ser> ls = new List<stu_data_ser>();
            stu_data_ser[] s_der = JsonConvert.DeserializeObject<stu_data_ser[]>(resp);
            int lengt = s_der.Length;
 //           MessageBox.Show("length of array " + lengt.ToString());
            int i = 0;
            while (lengt > i)
            {
                ListViewItem lvti = new ListViewItem(s_der[i].name);
                //MessageBox.Show(s_der[0].name);
                lvti.SubItems.Add(s_der[i].roll_no);
                //             MessageBox.Show(s_der[1].roll_no);

                lvti.SubItems.Add(s_der[i].branch);
                //           MessageBox.Show(s_der[1].branch);

                lvti.SubItems.Add(s_der[i].topic);
                //         MessageBox.Show(s_der[0].topic);

                lvti.SubItems.Add(s_der[i].broad_area);
                //     MessageBox.Show(s_der[1].broad_area);
                listView1.Items.Add(lvti);
                i++;
            }


        }
        
        
        private void tabPage1_Click(object sender, EventArgs e)
        {
          
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //     String fa_c = resulttxt.Text;
           // ListViewItem ltv = new ListViewItem("Sa");
            WebClient we = new WebClient();
            NameValueCollection nform = new NameValueCollection();
            nform.Add("fac_id", nm);
            String urls = murlf+"student_data_retr_dir_faculty";
            byte[] data = we.UploadValues(urls, nform);
            String resp = Encoding.UTF8.GetString(data);
            //MessageBox.Show(resp);
            // JavaScriptSerializer jser = new JavaScriptSerializer();
         //   List<stu_data_ser> ls = new List<stu_data_ser>();
           stu_data_ser[] s_der = JsonConvert.DeserializeObject<stu_data_ser[]>(resp);
            int lengt = s_der.Length;
         //   MessageBox.Show("length of array "+lengt.ToString());
            int i = 0;
            while (lengt > i)
            {
                ListViewItem lvti = new ListViewItem(s_der[i].name);
                //MessageBox.Show(s_der[0].name);
                lvti.SubItems.Add(s_der[i].roll_no);
                //             MessageBox.Show(s_der[1].roll_no);

                lvti.SubItems.Add(s_der[i].branch);
                //           MessageBox.Show(s_der[1].branch);

                lvti.SubItems.Add(s_der[i].topic);
                //         MessageBox.Show(s_der[0].topic);

                lvti.SubItems.Add(s_der[i].broad_area);
                //     MessageBox.Show(s_der[1].broad_area);
                listView1.Items.Add(lvti);
                i++;
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            Evaulation ec = new Evaulation(nm);
            ec.Show();
            //    Evaulation e
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String url = murlf+"change_major";
            String r_numb = comboBox1.Text;
          //  String ruim=r_numb.
            String topic = newbroad.Text;
            WebClient we = new WebClient();
            NameValueCollection ncc = new NameValueCollection();
            ncc.Add("roll_no", r_numb);
            ncc.Add("topic", topic);
            byte[] reet = we.UploadValues(url, ncc);
            String respon = Encoding.UTF8.GetString(reet);
            JavaScriptSerializer js = new JavaScriptSerializer();
            stu_resp rp = js.Deserialize<stu_resp>(respon);
           // JavaScriptSerializer js=nre 
           // MessageBox.Show(r_numb);
            if(rp.response_code==100)
            {
                MessageBox.Show("Updated Successfully", "Updated");
            }
            else
                if(rp.response_code==101)
            {
                MessageBox.Show("Updation Not Possible", "Sorry");
            }
         
            //  this.printDocument1.Print += new PrintPageEventHandler();
        }

        

        private void button2_Click_1(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            WebClient we = new WebClient();
            NameValueCollection nform = new NameValueCollection();
            nform.Add("fac_id", nm);
            String urls = murlf+"student_data_retr_dir_faculty";
            byte[] data = we.UploadValues(urls, nform);
            String resp = Encoding.UTF8.GetString(data);
            //MessageBox.Show(resp);
            // JavaScriptSerializer jser = new JavaScriptSerializer();
            //   List<stu_data_ser> ls = new List<stu_data_ser>();
            stu_data_ser[] s_der = JsonConvert.DeserializeObject<stu_data_ser[]>(resp);
            int lengt = s_der.Length;
            //           MessageBox.Show("length of array " + lengt.ToString());
            int i = 0;
            while (lengt > i)
            {
                ListViewItem lvti = new ListViewItem(s_der[i].name);
                //MessageBox.Show(s_der[0].name);
                lvti.SubItems.Add(s_der[i].roll_no);
                //             MessageBox.Show(s_der[1].roll_no);

                lvti.SubItems.Add(s_der[i].branch);
                //           MessageBox.Show(s_der[1].branch);

                lvti.SubItems.Add(s_der[i].topic);
                //         MessageBox.Show(s_der[0].topic);

                lvti.SubItems.Add(s_der[i].broad_area);
                //     MessageBox.Show(s_der[1].broad_area);
                listView1.Items.Add(lvti);
                i++;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String url = murlf + "inter_marks";
            String interroll = comboBox2.Text;
            String intermarks = internamlMarksbox.Text;
            WebClient we = new WebClient();
            NameValueCollection incoll = new NameValueCollection();
            incoll.Add("student_id", interroll);
            incoll.Add("internal", intermarks);
            byte[] res = we.UploadValues(url, incoll);
            String respon = Encoding.UTF8.GetString(res);            
            JavaScriptSerializer js = new JavaScriptSerializer();
            internal_marks rp = js.Deserialize<internal_marks>(respon);
            // JavaScriptSerializer js=nre 
            // MessageBox.Show(r_numb);
            if (rp.responce_code == 100)
            {
                MessageBox.Show("Updated Successfully", "Updated");
            }
            else
                if (rp.responce_code == 101)
            {
                MessageBox.Show("Updation Not Possible", "Sorry");
            }
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            String rollno = comboBox3.Text;
            String taskde = richTextBox1.Text;
            String datep= dateTimePicker1.Text;
            WebClient wec = new WebClient();
            NameValueCollection nec = new NameValueCollection();
            nec.Add("sroll", rollno);
            nec.Add("task_de", taskde);
                nec.Add("dead", datep);
            byte[] bt = wec.UploadValues(murlf + "task_assgin", nec);
            String ser = Encoding.UTF8.GetString(bt);
            MessageBox.Show(ser);
            JavaScriptSerializer jser = new JavaScriptSerializer();
            stu_resp sttp = jser.Deserialize<stu_resp>(ser);  
            //      stu_resp[] strpp = JsonConvert.DeserializeObject<stu_resp[]>(ser);
            if(sttp.response_code == 100)
            {
                MessageBox.Show("Task Added", "Task Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Something Went Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
             }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            String rollno = comboBox3.Text;
            listView2.Items.Clear();
            WebClient wec = new WebClient();
            NameValueCollection nec = new NameValueCollection();
            nec.Add("rollno", rollno);
            
            byte[] rest= wec.UploadValues(murlf + "task_desc", nec);
            String mret = Encoding.UTF8.GetString(rest);
            stu_task[] stdta = JsonConvert.DeserializeObject<stu_task[]>(mret);
            int sizlis = stdta.Length;
            int slen = 0;
            while(slen<sizlis)
            {
                ListViewItem ls = new ListViewItem(stdta[slen].id);
                ls.SubItems.Add(stdta[slen].student_id);
                ls.SubItems.Add(stdta[slen].task);
                ls.SubItems.Add(stdta[slen].assaign_date);
                ls.SubItems.Add(stdta[slen].deadline);
                ls.SubItems.Add(stdta[slen].status);
                listView2.Items.Add(ls);
                slen++;
            }
            
        }
        private void print_detail()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument pdco = new PrintDocument();
            pd.Document = pdco;
            pdco.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            DialogResult drs = pd.ShowDialog();
            if(drs==DialogResult.OK)
            {
                printDocument1.Print();
            }


        }
        public void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // PrintDocument pdr = new PrintDocument();
            //pdr.Print();
            Graphics gr = e.Graphics;
            Font fn = new Font("Courier New", 8);
            float fhgt = fn.GetHeight();
            int stx = 3;
            int sty = 3;
            int offst = 20;
            gr.DrawString("Stundet List", new Font("Impact", 10), new SolidBrush(Color.Black), stx, sty);
            WebClient wcc = new WebClient();
            String urll= murlf + "student_data_retr_dir_faculty";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("fac_id", nm);
            byte[] ress= wcc.UploadValues(urll, nvc);
            String respp = Encoding.UTF8.GetString(ress);
            stu_data_ser[] sdres = JsonConvert.DeserializeObject<stu_data_ser[]>(respp);
          //  stu_data_ser[] sdres = JsonConvert.DeserializeObject<stu_data_ser[]>(respp);
            int strlen = sdres.Length;
            int k = 0;
           while(k<strlen)
            {
                String nam = (sdres[k].name).PadRight(10);
              String rolno=sdres[k].roll_no.PadRight(10);
              String sbran= sdres[k].branch.PadRight(10);
              String stopi=sdres[k].topic.PadRight(10);
              String broad_are=sdres[k].broad_area.PadRight(10);
                //     String guid=sdres[k].guide;
                String prout = nam + "" + rolno + "" + sbran + "" + stopi + "" + broad_are + "";// + guid;
 //               MessageBox.Show(sbran);
                gr.DrawString(prout,fn, new SolidBrush(Color.Black), stx+20, sty + offst);
                offst = offst + (int)fhgt+10;
                k++;
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument2_PrintPage(object sender, PrintPageEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            print_detail();

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            String stuid = comboBox4.Text;
            WebClient wec = new WebClient();
            NameValueCollection task_id = new NameValueCollection();
            task_id.Add("student_roll", stuid);
            byte[] resp = wec.UploadValues(murlf + "student_task", task_id);
            String oresp = Encoding.UTF8.GetString(resp);
            MessageBox.Show(oresp);
            task_id_ass[] tasid = JsonConvert.DeserializeObject<task_id_ass[]>(oresp);
            int p = 0;
            while (p < tasid.Length)
            {
                comboBox5.Items.Add(tasid[p].id);
                p++;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            
            String sid = comboBox4.Text;
            String tid = comboBox5.Text;
            String sta = comboBox6.Text;
            WebClient wec = new WebClient();
            NameValueCollection nec = new NameValueCollection();
            nec.Add("student_roll", sid);
            nec.Add("task_id", tid);
            nec.Add("student_status", sta);
            byte[] resp = wec.UploadValues(murlf + "task_status", nec);
            String srresp = Encoding.UTF8.GetString(resp);
            stu_resp str = (new JavaScriptSerializer()).Deserialize<stu_resp>(srresp);
            if(str.response_code==100)
            {
                MessageBox.Show("Task Status Updated", "Updated", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Task Status Updatation Failed", "Failed", MessageBoxButtons.OK);
            }

            


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            if(xlapp==null)
            {
                MessageBox.Show("Excel not Installed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Excel.Workbook excelwor;
            Excel.Worksheet excelshet;
            object misValue = System.Reflection.Missing.Value;
            excelwor = xlapp.Workbooks.Add(misValue);
            excelshet = (Excel.Worksheet)excelwor.Worksheets.get_Item(1);
            excelshet.Cells[1, 1] = "Roll No";
            excelshet.Cells[1, 2] = "Name";
            excelshet.Cells[2, 1] = "13/ICS/041";
            excelshet.Cells[2, 2] = "Sachin";
            //  excelwor.SaveAs("C:\\sampleexcel.xls", Excel.XlFileFormat.xlWorkbookNormal);
            excelwor.SaveAs("d:\\csharp-Excel.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
           // xlWorkBook.Close(true, misValue, misValue);
            excelwor.Close(true, misValue, misValue);
          
            xlapp.Quit();
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
            if(xlapp==null)
            {
                MessageBox.Show("Excel not Installed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Excel.Workbook excelbook;
            Excel.Worksheet excelsheet;
            object misValue = System.Reflection.Missing.Value;
            excelbook = xlapp.Workbooks.Add(misValue);
            excelsheet = (Excel.Worksheet)excelbook.Worksheets.get_Item(1);
            excelsheet.Cells[1, 1] = "Name";
            excelsheet.Cells[1, 2] = "Roll No";
            excelsheet.Cells[1, 3] = "Branch";
            excelsheet.Cells[1, 4] = "Topic";
            excelsheet.Cells[1, 5] = "Broad Area";

            WebClient wcc = new WebClient();
            String urll = murlf + "student_data_retr_dir_faculty";
            NameValueCollection nvc = new NameValueCollection();
            nvc.Add("fac_id", nm);
            byte[] ress = wcc.UploadValues(urll, nvc);
            String respp = Encoding.UTF8.GetString(ress);
            stu_data_ser[] sdres = JsonConvert.DeserializeObject<stu_data_ser[]>(respp);
            //  stu_data_ser[] sdres = JsonConvert.DeserializeObject<stu_data_ser[]>(respp);
            int strlen = sdres.Length;
            int k = 0;
            while (k < strlen)
            {
                int p = 1;
                String nam = (sdres[k].name);//.PadRight(10);
                String rolno = sdres[k].roll_no;//.PadRight(10);
                String sbran = sdres[k].branch;//.PadRight(10);
                String stopi = sdres[k].topic;//.PadRight(10);
                String broad_are = sdres[k].broad_area;//.PadRight(10);
                excelsheet.Cells[k + 2, p] = nam;
                excelsheet.Cells[k + 2, p+1] = rolno;
                excelsheet.Cells[k + 2, p+2] = sbran;
                excelsheet.Cells[k + 2, p + 3] = stopi;
                excelsheet.Cells[k + 2, p + 4] = broad_are;
                k++;
            }
            excelbook.SaveAs("d:\\Guided_Student.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            excelbook.Close(true,misValue,misValue);
            xlapp.Quit();



        }
    }
    class task_id_ass
        {
        public String id;
         }
    class stu_data_ser
    {
        public String name;
        public String roll_no;
        public String branch;
        public String topic;
        public String broad_area;
        public String guide;
    } 
    class stu_task
    {
        public String id;
        public String student_id;
        public String task;
        public String assaign_date;
        public String deadline;
        public String status;
    }
    class stu_resp
    {
     public   int response_code;
    }
    class internal_marks
    {
        public int responce_code;
    }
}

