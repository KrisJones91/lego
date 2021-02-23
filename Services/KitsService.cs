using System;
using System.Collections.Generic;
using lego.Models;
using lego.Repositories;

namespace lego.Services
{
    public class KitsService
    {
        private readonly KitsRepository _repo;

        public KitsService(KitsRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Kit> GetAll()
        {
            return _repo.GetAll();
        }

        internal Kit GetById(int id)
        {
            Kit kit = _repo.GetById(id);
            if (kit == null)
            {
                throw new Exception("invalid Id");
            }
            return kit;
        }

        internal Kit Create(Kit newKit)
        {
            return _repo.Create(newKit);
        }

        internal Kit Edit(Kit updated)
        {
            var original = GetById(updated.Id);

            updated.name = updated.name != null ? updated.name : original.name;
            updated.description = updated.description != null ? updated.description : original.description;
            updated.price = updated.price > 0 ? updated.price : original.price;

            return _repo.Edit(updated);

        }

        internal string Delete(int id)
        {
            var data = GetById(id);
            _repo.Delete(id);
            return "Deleted Kit";
        }
    }
}