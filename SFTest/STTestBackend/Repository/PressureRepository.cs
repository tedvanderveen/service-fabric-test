﻿using Dapper;
using SFTestBackend.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace STTestBackend.Repository
{
    public class PressureRepository : IRepository<Quantity<int>>
    {
        private readonly string _connectionString;

        public PressureRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> CreateAsync(Quantity<int> entity)
        {
            int rowsAffected = 0;
            using (var connection = new SqlConnection(_connectionString))
            {
                rowsAffected = await connection.ExecuteAsync(
                    @"INSERT Pressure([Id], [Value], [Date], [Unit]) values (@Id, @Value, @Date,@Unit)",
                    new
                    {
                        Id = Guid.NewGuid(),
                        entity.Value,
                        Date = DateTime.Now,
                        Unit = entity.Unit.Type
                    });
            }

            return rowsAffected > 0;
        }
    }
}
