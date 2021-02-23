using System;
using System.Collections.Generic;
using lego.Models;
using lego.Repositories;

namespace lego.Services
{
    public class BricksService
    {
        private readonly BricksRepository _repo;

        public BricksService(BricksRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Brick> GetAll()
        {
            return _repo.GetAll();
        }

        internal Brick GetById(int id)
        {
            Brick brick = _repo.GetById(id);
            if (brick == null)
            {
                throw new Exception("invalid Id");
            }
            return brick;
        }

        internal Brick Create(Brick newBrick)
        {
            return _repo.Create(newBrick);
        }

        internal Brick Edit(Brick updated)
        {
            var original = GetById(updated.Id);

            updated.color = updated.color != null ? updated.color : original.color;
            updated.pegs = updated.pegs > 0 ? updated.pegs : original.pegs;
            updated.price = updated.price > 0 ? updated.price : original.price;

            return _repo.Edit(updated);

        }

        internal string Delete(int id)
        {
            var data = GetById(id);
            _repo.Delete(id);
            return "Deleted Brick";
        }
    }
}