using System.Collections.Generic;
using System.Data;
using Dapper;
using lego.Models;

namespace lego.Repositories
{
    public class KitsRepository
    {
        private readonly IDbConnection _db;

        public KitsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Kit> GetAll()
        {
            string sql = "SELECT * FROM Kits;";
            return _db.Query<Kit>(sql);
        }

        internal Kit GetById(int id)
        {
            string sql = "SELECT * FROM Kit WHERE id = @id;";
            return _db.QueryFirstOrDefault<Kit>(sql, new { id });
        }

        internal Kit Create(Kit newKit)
        {
            string sql = @"
                INSERT INTO Kits
                    (name, description, price)
                VALUES
                    (@name, @description, @price);
                SELECT LAST_INSERT_ID();
                ";
            int id = _db.ExecuteScalar<int>(sql, newKit);
            newKit.Id = id;
            return newKit;
        }

        internal Kit Edit(Kit update)
        {
            string sql = @"
                UPDATE FROM Kits
                SET
                    name = @name,
                    description = @description,
                    price = @price
                WHERE id = @Id";
            _db.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM Kits WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}