using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STGCodeChallenge9
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string s = txtText.Text.Trim();
            MessageBox.Show(string.Format("The string '" + s + "' is{0} a palindrome.", (isPalindrome(s) ? "" : " not")));
        }

        private bool isPalindrome(string s)
        {
            long l;
            char[] arr;

            // If the input is one number, do the binary check
            if (long.TryParse(s, out l))
            {
                s = Convert.ToString(l, 2);
            }

            // See if we have a palindrome
            // Convert all the chars to lowercase and remove non-alphanumerics
            arr = s.ToLowerInvariant().Where(c => (char.IsLetterOrDigit(c))).ToArray();
            s = new string(arr);

            // Split the string in two - 1st half and 2nd half
            string s1, s2;
            int len = s.Length / 2;
            s1 = s.Substring(0, len);
            s2 = s.Substring((s.Length % 2 != 0 ? len + 1 : len), len);
            // Reverse the 2nd half
            arr = s2.ToCharArray();
            Array.Reverse(arr);
            s2 = new string (arr);

            // If the two halves are the same we have a palindrome
            return (s1 == s2);
        }
    }
}
