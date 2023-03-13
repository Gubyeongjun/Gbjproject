using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbjproject.SQL
{
    public class SQL_update
    {
        static public string dept_update = @" update gbj_dept set dept_nm1 = :nm1, dept_nm2 = :nm2, dept_seq = :seq, dept_use = :use 
                                              where dept_cd = :cd ";

        static public string cdg_update = @" update gbj_cdg set cdg_grpnm = :grpnm, cdg_length = :length, cdg_nmleng = :nmleng, cdg_use = :use 
                                             where cdg_grpcd = :cd";

        static public string unit_update = @" update gbj_unit set unit_nm1 = :nm1, unit_nm2 = :nm2, unit_seq = :seq, unit_use = :use 
                                              where unit_grpcd = :grpcd and unit_cd = :cd";
    }
}
