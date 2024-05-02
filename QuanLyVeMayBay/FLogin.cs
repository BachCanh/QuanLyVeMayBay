using System.Data;
using System.Data.SqlClient;
using System.Drawing;

namespace QuanLyVeMayBay
{

    public partial class FLogin : Form
    {
        string adminConn = @"Data Source=LAPTOP-Q3MNC1CJ;Initial Catalog=master;Integrated Security=True;Encrypt=False";
        SqlConnection adminCon = null;
        public string userConn = string.Empty;
        SqlConnection userCon = null;
        public FLogin()
        {
            InitializeComponent();
        }

        private void parrotButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FMainPage fMain = new FMainPage();
            fMain.Show();
        }

        private void FLogin_Load(object sender, EventArgs e)
        {
            try
            {
                adminCon = new SqlConnection(adminConn);

                adminCon.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT name from sys.databases", adminCon))
                {
                    using (IDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cbbDatabase.Items.Add(dr[0].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                adminCon.Close();
            }
        }

        private void lblConnect_Click(object sender, EventArgs e)
        {
            try
            {
                string password = txtPassword.Text;
                string username = txtUsername.Text;
                string dbname = cbbDatabase.Text;
                userConn = @$"Data Source=LAPTOP-Q3MNC1CJ;Initial Catalog={dbname};User ID={username};Password={password};Encrypt=False";
                userCon = new SqlConnection(userConn);

                if (userCon.State != ConnectionState.Open)
                {
                    userCon.Open();
                    MessageBox.Show($"Connect successfully to database: {dbname}");
                    FNhanVien fInput = new FNhanVien(userConn);
                    this.Hide();
                    fInput.Closed += (s, args) => this.Close();
                    fInput.Show();
                }
                
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            finally
            {
                adminCon.Close();
            }
        }
    }
}
