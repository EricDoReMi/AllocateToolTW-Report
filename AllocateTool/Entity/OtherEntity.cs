using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllocateTool.Entity
{
    public partial class Emp
    {
       public string M_leaderName { get; set; }
   
    }

    public partial class Record {
        
        public string M_name { get; set; }
        //是否登录了
        //0 未登录 1 登录
        public string M_login { get; set; }

        public int? M_EmpId { get; set; }

        //是否在职了
        //0 不在职 1 在职
        public string M_statue { get; set; }

       

      
    }


}
