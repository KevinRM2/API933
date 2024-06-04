using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi93.Context;
using WebApi93.Services.IServices;



namespace WebAPI93.Services.Services
{
    public class AutoresServices : IAutorServices
    {
        private readonly ApplicationDbContext _context;
        public string Mensaje;

        //Constructor
        public AutoresServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);
                response = result.ToList();
                return new Response<List<Autor>>(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error:" + ex.Message);
            }
        }
    }
}