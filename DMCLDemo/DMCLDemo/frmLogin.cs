using dmcldll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DMCLDemo
    {
    public partial class frmLogin : Form
    {
        #region "Properties"

        private bool _Authenticated = false;

        public bool Authenticated
        {
            get { return _Authenticated; }
            set { _Authenticated = value; }
        }
        private string _Username = "";

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        #endregion

        public frmLogin()
        {
            InitializeComponent();
        }

        // exit the program if they do not want to login
        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            //Application.Exit();
            Authenticated = false;
        }

        // check that username and password are not empty
        // lookup username in database and compare passwords - if ok continue
        // if not ok, retry 2 more times then exit
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {

            if (tbPassword.Text.Length > 0 && tbUsername.Text.Length > 0)
            {
                // Try the documentum login to get a sessino here
                // TODO 

                String docbase = Properties.Settings.Default["DocbaseName"].ToString();
                docbase = Properties.Settings.Default.DocbaseName;
                
                String docbaseUser = tbUsername.Text;
                String docbasePassword = tbPassword.Text;

                // Do the connection - get a session
                //String session = DMCL.dmAPIGet("connect," + docbase +" ," + docbaseUser +","+ docbasePassword );

                String session = DMCL.dmAPIGet("connect,EPAProd,dmadmin,Password99");

                if (session != null)
                {

                    Properties.Settings.Default["DocbaseUser"] = docbaseUser;

                    Properties.Settings.Default.Save();
                    Authenticated = true;
                    this.Close(); // close this form - do not exit the application
                }
                else
                {
                    String errorMessage = DMCL.dmAPIGet("getmessage,c");
                    Console.Write(DMCL.dmAPIGet("getmessage,c"));
                    MessageBox.Show(errorMessage);
                    MessageBox.Show("Username or Password not recognised");
                }


                            }
            else // password or username is empty
            {
                Authenticated = false;
                MessageBox.Show("You need to enter both a username and a password to continue");
            }

        }

        // Does the user exist?
        // if so - is the password correct?
        private bool UserAuthenticated(string p, string p_2)
        {
            try
            {
                int result = 0;
                Authenticated = true;
                if (result > 0) return true;
            }
            catch (Exception) // FIXED: Added Exception catching  which defaults to Not Authenticated
            {
                Authenticated = false;
                return false;
            }
            Authenticated = false;
            return false;
        }

        // You do not need this
        
        private void frmLogin_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'applicationDataSet.Users' table. You can move, or remove it, as needed.

            int resint = DMCL.dmAPIInit();
            String map = DMCL.dmAPIGet("getdocbasemap,c");

            if (map == null)
            {

                Console.WriteLine("No docbases are available");
                Console.WriteLine("No docbases are available");
                MessageBox.Show("No Docbases Available");
                this.Close();

            }



        }

        // register the user - get Username, password x 2
        // Add user to database if passwords match


    }
        
    }

