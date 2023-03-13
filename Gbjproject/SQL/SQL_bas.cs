using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gbjproject.SQL
{
    public class SQL_bas
    {
        static public string bas_load = @" select unit_grpcd, unit_cd|| ':' ||unit_nm2 as unit from gbj_unit
                                           where unit_use = 'Y'
                                           order by unit_grpcd asc ";

        static public string bas_select = @" select bas_empno from gbj_bas 
                                             where bas_empno like :empno and bas_name like :name and bas_dept like :dept and bas_pos like :pos ";

        static public string bas_insert = @" insert into gbj_bas( bas_empno, bas_resno, bas_name, bas_cname, bas_ename, bas_fix, 
                                                                  bas_zip, bas_addr, bas_hdpno, bas_telno, bas_email, 
                                                                  bas_mil_sta, bas_mil_mil, bas_mil_rnk, bas_mar, 
                                                                  bas_acc_bank, bas_acc_name, bas_acc_no, 
                                                                  bas_cont, bas_emp_sdate, bas_emp_edate, 
                                                                  bas_wsta, bas_entdate, bas_resdate, bas_levdate, bas_reidate, 
                                                                  bas_pos, bas_dut, bas_dept, bas_jkpdate, bas_posdate, bas_dptdate, bas_rmk ) 
                                                          values( :empno, :resno, :name, :cname, :ename, :fix, 
                                                                  :zip, :addr, :hdpno, :telno, :email, 
                                                                  :mil_sta, :mil_mil, :mil_rnk, :mar, 
                                                                  :acc_bank, :acc_name, :acc_no, 
                                                                  :cont, :emp_sdate, :emp_edate, 
                                                                  :wsta, :entdate, :resdate, :levdate, :reidate, 
                                                                  :pos, :dut, :dept, :jkpdate, :posdate, :dptdate, :rmk ) ";

        static public string bas_update = @"";

        static public string bas_delete = @" delete from gbj_bas where bas_empno = :empno ";
    }
}
