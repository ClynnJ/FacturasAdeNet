using FacturasAdeNet.COMMON.Entities;
using FacturasAdeNet.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturasAdeNet.DAL
{
    public class BillsRepository : IRepository<Bill>
    {
        private string DBName = "FacturasAdeNet.db";
        private string TableName = "Bills";
        public List<Bill> Read
        {
            get
            {
                List<Bill> data = new List<Bill>();
                using (var db = new LiteDatabase(DBName))
                {
                    data = db.GetCollection<Bill>(TableName).FindAll().ToList();
                }
                return data;
            }
        }

        public bool Create(Bill entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            try
            {
                using (var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Bill>(TableName);
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
                    var collection = db.GetCollection<Bill>(TableName);
                    collection.Delete(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Bill modifiedEntity)
        {
            throw new NotImplementedException();
        }
    }
}
