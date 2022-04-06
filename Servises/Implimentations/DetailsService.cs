﻿using RestApi.Interfaces;
using RestApi.Models;
using System.Collections.Generic;

namespace RestApi.Servises.Implimentations
{
    public class DetailsService
    {
        private readonly IRepo<Details> _repo;
        public DetailsService(IRepo<Details> repo)
        {
            _repo = repo;
        }
        public IEntity Get(int number)
        {
            return _repo.Get(number);
        }
        public void Delete(int number)
        {
            _repo.Delete(number);
        }
        public void Post(Details details)
        {
            _repo.Post(details);
        }
        public void Put(Details details)
        {
            _repo.Put(details);
        }
        public List<Details> GetAll(int limit)
        {
            return _repo.GetAll(limit);
        }
    }
}