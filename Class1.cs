using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    class Knco
    {
        public string GetWeaponCode_Company(string gc_id)
        {
            try
            {
                using SqlConnection con = new SqlConnection(@"Data Source=desktop-7275d5a\sqlexpress;Initial Catalog=wpn_program;Integrated Security=True;User ID=sa;Password=admin"); // making connection   
                using SqlDataAdapter sda = new SqlDataAdapter("SELECT WeaponCode, Company FROM gc_details WHERE GCID=@column_1;", con);
                //modify for SQL injection protection
                sda.SelectCommand.Parameters.AddWithValue("@column_1", gc_id);
                DataTable dt = new DataTable(); //this is creating a virtual table  
                sda.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    return "Y<" + dt.Rows[0][0] + "<" + dt.Rows[0][1];
                }
                else
                {
                    return "N<NA<NA";
                }
            }
            catch (Exception exc)
            {
                return "ERR<"+exc.Message.ToString()+"<NA";
            }
        }
        public virtual string issueWeapon(string gc_id,string weapon_code)
        {
            string gc_weapon_code;
            string[] ret = GetWeaponCode_Company(gc_id).Split();

            if (ret[0] == "Y")
            {
                //match found
                gc_weapon_code = ret[1];
                if (gc_weapon_code == weapon_code)//check if GC matches weapon Code
                {
                    /*issue weapon 
                     * 1. update weapon status
                     * 2. log transaction*
                     * */

                    return "Issued";
                }
                else
                {
                    return "Kote NCO Cannot Issue Weapons Of Diffetent ";
                }
                

            }
            else if (ret[0] == "N")
            {
                //no match found
                return "No match for GC ID found";

            }
            else {
                //error connecting to database
                return ret[1];

            }
            

        }

    }
    class ccdr : Knco
    { 
    
    }
}
