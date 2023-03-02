using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbjproject.SQL
{
    public class SQL_insert
    {
        public static string dept_insert = @" insert into gbj_dept (dept_cd, dept_nm1, dept_nm2, dept_seq, dept_use) 
                                              values(:cd, :nm1, :nm2, :seq, :use) ";

        public static string cdg_insert = @" insert into gbj_cdg (cdg_grpcd, cdg_grpnm, cdg_length, cdg_nmleng, cdg_use) 
                                             values(:cd, :nm, :leng, :nmlg, :use) ";

        public static string unit_insert = @" insert into gbj_unit (unit_grpcd, unit_cd, unit_nm1, unit_nm2, unit_seq, unit_use)
                                              values(:grpcd, :cd, :nm1, :nm2, :seq, :use) ";
    }
}
