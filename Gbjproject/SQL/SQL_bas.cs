using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbjproject.SQL
{
    public class SQL_bas
    {
        static public string bas_select = @" select bas_empno from gbj_bas 
                                             where bas_empno like :empno and bas_name like :name and bas_dept like :dept and bas_pos like :pos ";

        static public string bas_insert = @"";

        static public string bas_update = @"";

        static public string bas_delete = @"";
    }
}
