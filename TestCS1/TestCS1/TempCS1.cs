using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestCS1
{
    class TempCS1
    {
        ////--- частный случай: когда кол-во повторяющихся букв строго меньше 10
        //private string WriteToStrEnd(char c, int n)
        //{
        //    string str = "";
        //    for (int i = 0; i < n; i++)
        //    {
        //        str += c.ToString();
        //    }

        //    return str;
        //}

        //private void Decompress()
        //{
        //    string strStart = tbCompressed.Text;
        //    if (strStart == "") return;
        //    string strEnd = "";

        //    try
        //    {
        //        char[] carray = strStart.ToCharArray();
        //        char cprev = '0';
        //        foreach (char c in carray)
        //        {
        //            if (char.IsNumber(c) && char.IsLetter(cprev))
        //            {
        //                strEnd += WriteToStrEnd(cprev, Int32.Parse(c.ToString()));
        //            }
        //            else if (char.IsLetter(c) && char.IsLetter(cprev))
        //            {
        //                strEnd += WriteToStrEnd(cprev, 1);
        //            }
        //            cprev = c;
        //        }
        //        if (char.IsLetter(cprev)) strEnd += cprev.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }

        //    tbDecompressed.Text = strEnd;
        //}
        ////---

        
    }
}
