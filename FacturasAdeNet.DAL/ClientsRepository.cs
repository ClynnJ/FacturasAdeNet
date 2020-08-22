using FacturasAdeNet.COMMON.Entities;
using FacturasAdeNet.COMMON.Interfaces;
using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacturasAdeNet.DAL
{
    class ClientsRepository : IRepository<Client>
    {

        private string DBName = "FacturasAdeNet.db";
        private string TableName = "Clients";

        public List<Client> Read {
            get
            {
                List<Client> data = new List<Client>();
                using (var db = new LiteDatabase(DBName))
                {
                    data = db.GetCollection<Client>(TableName).FindAll().ToList();
                }

                return data;
            }
        }

        public bool Create(Client entity)
        {
            while (true)
            {
                entity.Id = new Cid().NewCid();
                using (var db = new LiteDatabase(DBName))
                {
                    var cl = db.GetCollection<Client>(TableName);
                    if (cl.Exists(entity.Id))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }

                }
            }
            try
            {
                using(var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Client>(TableName);
                    collection.Insert(entity);
                }
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            try
            {
                using(var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Client>(TableName);
                    collection.Delete(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Edit(Client modifiedEntity)
        {
            try
            {
                using(var db = new LiteDatabase(DBName))
                {
                    var collection = db.GetCollection<Client>(TableName);
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
