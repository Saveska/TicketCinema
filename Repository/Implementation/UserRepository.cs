using TicketCinema.Models.Identity;
using TicketCinema.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace TicketCinema.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<TicketCinemaAppUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<TicketCinemaAppUser>();
        }
        public IEnumerable<TicketCinemaAppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public TicketCinemaAppUser Get(string id)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.MovieInShoppingCarts")
               .Include("UserCart.MovieInShoppingCarts.CurrentMovie")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(TicketCinemaAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(TicketCinemaAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(TicketCinemaAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
