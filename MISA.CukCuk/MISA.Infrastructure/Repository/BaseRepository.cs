using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.Core.Interfaces.Repository;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infrastructure.Repository
{
    public class BaseRepository<MISAEntity> : IBaseRepository<MISAEntity>
    {

        private readonly IConfiguration _configuration;
        protected IDbConnection dbConnection;
        string _className;
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            dbConnection = new MySqlConnection(_configuration.GetConnectionString("SqlConnection"));
            _className = typeof(MISAEntity).Name;
        }


        public List<MISAEntity> GetAll()
        {
            var entities = dbConnection.Query<MISAEntity>($"Proc_Get{_className}s", commandType: CommandType.StoredProcedure);

            return entities.AsList();
        }

        public List<MISAEntity> GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public int Add(MISAEntity entity)
        {
            var dynamicParam = new DynamicParameters();

            ////3. Them du lieu vao db:

            ////Doc tung prop cua obj:
            var properties = entity.GetType().GetProperties();

            ////Duyet tung prop:
            foreach (var prop in properties)
            {
                //lay ten cua prop
                var propName = prop.Name;

                //lay val cu prop
                var propValue = prop.GetValue(entity);

                //Them param tuong ung voi moi prop
                dynamicParam.Add($"@{propName}", propValue);
            }

            var rowsEffect = dbConnection.Execute($"Proc_Insert{_className}", param: dynamicParam, commandType: CommandType.StoredProcedure);

            return rowsEffect;
        }


        public int Update(MISAEntity entity, Guid entityId)
        {
            var dynamicParam = new DynamicParameters();

            ////3. Them du lieu vao db:

            ////Doc tung prop cua obj:
            var properties = entity.GetType().GetProperties();

            ////Duyet tung prop:
            foreach (var prop in properties)
            {
                //lay ten cua prop
                var propName = prop.Name;

                //lay val cu prop
                var propValue = prop.GetValue(entity);

                //Them param tuong ung voi moi prop
                if (propValue != null)
                {
                    dynamicParam.Add($"@{propName}", propValue);
                }

            }

            var rowsEffect = dbConnection.Execute($"Proc_Update{_className}", param: dynamicParam, commandType: CommandType.StoredProcedure);

            return rowsEffect;
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
