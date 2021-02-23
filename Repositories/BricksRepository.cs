using System.Collections.Generic;
using System.Data;
using Dapper;
using lego.Models;

namespace lego.Repositories
{
    public class BricksRepository
    {
        private readonly IDbConnection _db;

        public BricksRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Brick> GetAll()
        {
            string sql = "SELECT * FROM Bricks;";
            return _db.Query<Brick>(sql);
        }

        internal Brick GetById(int id)
        {
            string sql = "SELECT * FROM Bricks WHERE id = @id;";
            return _db.QueryFirstOrDefault<Brick>(sql, new { id });
        }

        internal Brick Create(Brick newBrick)
        {
            string sql = @"
                INSERT INTO Bricks
                    (color, pegs, price)
                VALUES
                    (@color, @pegs, @price);
                SELECT LAST_INSERT_ID();
                ";
            int id = _db.ExecuteScalar<int>(sql, newBrick);
            newBrick.Id = id;
            return newBrick;
        }

        internal Brick Edit(Brick update)
        {
            string sql = @"
                UPDATE FROM Bricks
                SET
                    color = @color,
                    pegs = @pegs,
                    price = @price
                WHERE id = @Id";
            _db.Execute(sql, update);
            return update;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM Bricks WHERE id = @id LIMIT 1";
            _db.Execute(sql, new { id });
        }
    }
}