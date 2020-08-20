using FacturasAdeNet.COMMON.Entities;
using FacturasAdeNet.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturasAdeNet.DAL
{
    public class EmployeesRepository : IRepository<Employee>
    {
        private string DBName = "FacturasAdeNet.db";
        private string TableName = "Employees";

        public List<Employee> Read
        {
            get
            {
                List<Employee> data = new List<Employee>();
                using (var db = new LiteDatabase(DBName))
                {
                    data = db.GetCollection<Employee>(TableName).FindAll().ToList();
                }

                return data;
            }
        }

        public bool Create(Employee entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Employee>(TableName);
                    collection.Insert(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Employee>(TableName);
                    collection.Delete(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Employee modifiedEntity)
        {
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Employee>(TableName);
                    collection.Update(modifiedEntity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
