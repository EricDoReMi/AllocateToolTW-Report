using AllocateTool.dao;
using AllocateTool.Entity;
using System;
using System.Data.OleDb;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AllocateTool.control
{
    public partial class EmpControl
    {
        private EmpDAO empDao = new EmpDAO();

        public void AddEmp(Emp emp) {
            try
            {
                OleDbConnection con = empDao.Begin();
                empDao.AddEmpItemDAO(con, emp);
                empDao.Commit();
            }
            catch (Exception)
            {
                empDao.RollBack();
                throw;
            }
            finally {
                empDao.Close();
            }
            
        }
    }
}
