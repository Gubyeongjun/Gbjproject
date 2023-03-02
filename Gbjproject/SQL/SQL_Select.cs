using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbjproject.SQL
{
    public class SQL_Select
    {
        public static string dept_all = @" select dept_cd, dept_nm1, dept_nm2, dept_seq, dept_use from gbj_dept 
                                           where dept_nm1 like :dept_nm1 order by dept_seq asc ";

        public static string cdg_all = @" select cdg_grpcd, cdg_grpnm, cdg_length, cdg_nmleng, cdg_use from gbj_cdg 
                                          where cdg_grpnm like :grpnm order by cdg_grpcd asc ";

        public static string unit_grp = @" select cdg_grpcd || ':' || cdg_grpnm as grp, cdg_length, cdg_nmleng from gbj_cdg 
                                           where cdg_use = 'Y' order by cdg_grpcd asc ";

        public static string unit_all = @" select unit_grpcd, unit_cd, unit_nm1, unit_nm2, unit_seq, unit_use from gbj_unit 
                                           where unit_grpcd like :grpcd and unit_nm1 like :unit_nm order by unit_seq asc ";
    }
}
