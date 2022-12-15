using ClaimsThroughErrors.Properties;
using ClosedXML.Excel;
using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace ClaimsThroughErrors
{
    public partial class Form1 : Form
    {
        // Handles drag and drop functionality
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;


        private string ResourcesFolder { get { return Path.Combine(Application.StartupPath, "Resources"); } }
        private string Claims { get; set; }
        private string Eligibility { get; set; }
        private string ClaimsFile { get; set; } // Filename for Claims converted to .xlsx
        private string EligibilityFile { get; set; } // Filename for Eligibility converted to .xlsx
        private string ClaimsPath { get { return Path.Combine(ResourcesFolder, ClaimsFile); } }
        private string EligibilityPath { get { return Path.Combine(ResourcesFolder, EligibilityFile); } }
        private string ExcelDate { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void ColorChanger(TextBox tb, PictureBox pb, Panel panel)
        {
            tb.ForeColor = Color.FromArgb(78, 184, 206);
            panel.BackColor = Color.FromArgb(78, 184, 206);
            pb.BackgroundImage = Resources.import_csv35Blue;
            return;
        }

        private void ButtonColorChanger(Button btn, bool entered = true)
        {
            if (entered)
                btn.ForeColor = Color.FromArgb(78, 184, 206);
            else
                btn.ForeColor = Color.WhiteSmoke;
        }

        private void SelectFilePrompt(string type)
        {
            bool claims = type.Equals("Claims");

            OpenFileDialog file1 = new OpenFileDialog
            {
                Title = claims ? "Select Claims Through File" : "Select Elgibility Highmark File",
                Filter = "CSV files (*.csv)|*.csv",
                InitialDirectory = @"C:\Documents",
                RestoreDirectory = false,
                Multiselect = false
            };

            if (file1.ShowDialog() == DialogResult.OK)
            {
                if (claims)
                {
                    claimsTB.Text = file1.FileName;
                    claimsTB.ReadOnly = false;
                    claimsTB.Cursor = Cursors.IBeam;
                    return;
                }

                eligibilityTB.Text = file1.FileName;
                eligibilityTB.ReadOnly = false;
                eligibilityTB.Cursor = Cursors.IBeam;
            }
        }

        private bool ClaimsValidator()
        {
            bool status = File.Exists(claimsTB.Text);

            if (!status)
            {
                Claims = null;
                errorProvider1.SetIconPadding(claimsTB, -10);
                errorProvider1.SetError(claimsTB, "Invalid File Path");
                claimsTB.ForeColor = Color.Red;
                claimsPanel.BackColor = Color.Red;
                claimsIMG.BackgroundImage = Resources.import_csv35Red;
            }
            else
            {
                Claims = claimsTB.Text;
                this.errorProvider1.SetError(claimsTB, "");
                ColorChanger(claimsTB, claimsIMG, claimsPanel);
            }

            return status;
        }

        private bool EligibilityValidator()
        {
            bool status = File.Exists(eligibilityTB.Text);

            if (!status)
            {
                Eligibility = null;
                errorProvider1.SetIconPadding(eligibilityTB, -10);
                errorProvider1.SetError(eligibilityTB, "Invalid File Path");
                eligibilityTB.ForeColor = Color.Red;
                eligibilityPanel.BackColor = Color.Red;
                eligibilityIMG.BackgroundImage = Resources.import_csv35Red;
            }
            else
            {
                Eligibility = eligibilityTB.Text;
                this.errorProvider1.SetError(eligibilityTB, "");
                ColorChanger(eligibilityTB, eligibilityIMG, eligibilityPanel);
            }

            return status;
        }

        // Generates ClaimsError.xlsx
        private void ClaimsErrGenerator()
        {
            try
            {
                XLWorkbook claimsWB = new XLWorkbook(ClaimsPath);
                IXLWorksheet claimsWS1 = claimsWB.Worksheet(1);
                XLWorkbook eligibilityWB = new XLWorkbook(EligibilityPath);
                eligibilityWB.Worksheet(1).CopyTo(claimsWB, "Eligibility For Highmark");
                IXLWorksheet claimsWS2 = claimsWB.Worksheet(2);

                claimsWS1.Cell(1, claimsWS1.LastColumnUsed().ColumnNumber() + 1).Value = "ID";

                ConcatAdder(claimsWS1, claimsWS1.LastColumnUsed().ColumnNumber(), 'E', 'F', 'D');

                claimsWS2.Cell(1, claimsWS2.LastColumnUsed().ColumnNumber() + 1).Value = "ID";

                ConcatAdder(claimsWS2, claimsWS2.LastColumnUsed().ColumnNumber(), 'B', 'C', 'F');

                claimsWS2.Cell(1, claimsWS2.LastColumnUsed().ColumnNumber() + 1).Value = "HM";

                TextAdder(claimsWS2, claimsWS2.LastColumnUsed().ColumnNumber(), "Yes");

                claimsWS1.Cell(1, claimsWS1.LastColumnUsed().ColumnNumber() + 1).Value = "HM";

                VLookupAdder(claimsWS1, claimsWS1.LastColumnUsed().ColumnNumber());

                claimsWB.CalculateMode = XLCalculateMode.Auto;

                claimsWS1.RangeUsed().SetAutoFilter();

                string fn = SaveFilePrompt();

                if (string.IsNullOrEmpty(fn))
                    return;

                claimsWB.Worksheets.Add($"ERRORS{ExcelDate}");

                claimsWB.SaveAs(fn);

                Process.Start(fn);
            }
            catch (Exception err) { KillExcelProcess(); Debug.WriteLine(err.Message.ToString()); }
        }

        // Sets the Properties above
        private void FileSetter()
        {
            ClaimsFile = $"{Path.GetFileNameWithoutExtension(Claims)}.xlsx";
            EligibilityFile = $"{Path.GetFileNameWithoutExtension(Eligibility)}.xlsx";
        }

        // Turns .CSV file to .XLSX
        private void ExcelConverter()
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb1 = app.Workbooks.Open(claimsTB.Text);
            Excel.Workbook wb2 = app.Workbooks.Open(eligibilityTB.Text);
            Excel.Worksheet ws1 = (Excel.Worksheet)wb1.Worksheets.get_Item(1);
            Excel.Worksheet ws2 = (Excel.Worksheet)wb2.Worksheets.get_Item(1);
            Excel.Range ws1Used = ws1.UsedRange;
            Excel.Range ws2Used = ws2.UsedRange;

            wb1.SaveAs(ClaimsPath, 51);
            wb1.Close();
            wb2.SaveAs(EligibilityPath, 51);
            wb2.Close();
            app.Quit();
        }

        // Deletes previous .xlsx files
        private void ResourceDeleter()
        {
            DirectoryInfo directory = new DirectoryInfo(ResourcesFolder);
            foreach (FileInfo file in directory.GetFiles()) file.Delete();
        }

        // Closes Excel Process if open
        private void KillExcelProcess()
        {
            var processes = from p in Process.GetProcessesByName("EXCEL")
                            select p;

            foreach (var process in processes)
            {
                if (process.ProcessName.Equals("EXCEL"))
                    process.Kill();
            }
        }

        // Adds Concat Formula 
        private void ConcatAdder(IXLWorksheet ws, int col, char a, char b, char c)
        {
            int rows = ws.RowsUsed().Count();

            for (var i = 2; i < rows; i++)
            {
                ws.Cell(i, col).FormulaA1 = $"CONCATENATE({a}{i}, {b}{i}, {c}{i})";
            }
        }

        // Adds VLookup Formula
        private void VLookupAdder(IXLWorksheet ws, int col)
        {
            int rows = ws.RowsUsed().Count();

            for (var i = 2; i < rows; i++)
            {
                ws.Cell(i, col).FormulaA1 = $"=VLOOKUP(M{i},'Eligibility For Highmark'!$S:$T,2,FALSE)";
            }
        }

        // Adds Header and Yes values to cells
        private void TextAdder(IXLWorksheet ws, int col, string text)
        {
            int rows = ws.RowsUsed().Count();

            for (var i = 2; i < rows; i++)
            {
                ws.Cell(i, col).Value = text;
            }
        }

        private string SaveFilePrompt()
        {
            string fn = Path.GetFileNameWithoutExtension(claimsTB.Text);
            fn = fn.Substring(fn.Length - 10);
            fn = fn.Replace(".", "");
            string month = fn.Substring(0, 2);
            string day = fn.Substring(2, 2);
            string year = fn.Substring(4, 4);

            ExcelDate = $"{year}{month}{day}";

            SaveFileDialog saveFile = new SaveFileDialog()
            {
                Title = "Save Claims Through Errors",
                DefaultExt = ".xlsx",
                Filter = "Excel Files| *.xlsx; *.xlsm",
                InitialDirectory = @"C:\\documents",
                FileName = $"Claims Through {year}{month}{day} ERRORS.xlsx"
            };



            if (saveFile.ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return saveFile.FileName;

        }

        // Shows Spinner GIF and runs functions resposible for generating ERRORS File
        private void ShowSpinner()
        {
            try
            {
                submitButton.Invoke((MethodInvoker)delegate { spinnerBox.Visible = true; });
                Application.DoEvents();
                KillExcelProcess(); // Kills any active Excel processes to minimize errors
                FileSetter(); // Sets properties so their values can be used globally
                ResourceDeleter(); // Deletes previously converted xlsx files
                ExcelConverter(); // Converts to xlsx
                ClaimsErrGenerator(); // Generates XLSX File
                submitButton.Invoke((MethodInvoker)delegate { spinnerBox.Visible = false; });
            }
            catch { }
        }

        private void ClaimsTB_Validating(object sender, CancelEventArgs e)
        {

        }

        // Makes it so user can't mess with TextBox until they've submitted File
        private void Form1_Load(object sender, EventArgs e)
        {
            claimsTB.ReadOnly = true;
            eligibilityTB.ReadOnly = true;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ClaimsTB_Click(object sender, EventArgs e)
        {



        }

        private void EligibilityTB_Click_1(object sender, EventArgs e)
        {
            if (claimsTB.Text.Equals("Claims Through"))
                return;

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (!ClaimsValidator() || !EligibilityValidator())
                return;

            // Lines of code required to make gif work
            ThreadStart threadStart = new ThreadStart(ShowSpinner);
            Thread thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SubmitButton_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanger(submitButton);
        }

        private void SubmitButton_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanger(submitButton, false);
        }

        private void ExitBtn_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanger(exitBtn);
        }

        private void ExitBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanger(exitBtn, false);
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void MinimizeBtn_MouseEnter(object sender, EventArgs e)
        {
            ButtonColorChanger(minimizeBtn);
        }

        private void MinimizeBtn_MouseLeave(object sender, EventArgs e)
        {
            ButtonColorChanger(minimizeBtn, false);
        }

        private void ClaimsTB_TextChanged(object sender, EventArgs e)
        {

            ClaimsValidator();
        }

        private void EligibilityTB_TextChanged(object sender, EventArgs e)
        {
            EligibilityValidator();
        }

        private void ClaimsIMG_Click(object sender, EventArgs e)
        {
            SelectFilePrompt("Claims");

        }

        private void EligibilityIMG_Click(object sender, EventArgs e)
        {
            SelectFilePrompt("Eligibility");
        }
    }
}
