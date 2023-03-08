using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbjproject.SQL
{
    public class SQL_delete
    {   
        public static string dept_delete = @" delete from gbj_dept where dept_cd = :dept_cd ";

        public static string cdg_delete = @" delete from gbj_cdg where cdg_grpcd = :grpcd ";
         
        public static string unit_delete = @" delete from gbj_unit where unit_grpcd = :grpcd and unit_cd = :cd ";
    }
}
