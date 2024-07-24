using System;
using System.Collections.Generic;
using System.Linq;
using domain.entities;
using domain.interfaces;
using infrastructure.data;

namespace infrastructure.repositories;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<IUser> GetAllUsers()
    {
        return _context.Users.Select(u => (IUser)u).ToList();
    }

    public IUser? GetUserById(Guid id)
    {
        if (id == Guid.Empty)
        {
            return null;
        }
        return _context.Users.Find(id);
    }

    public void AddUser(IUser user)
    {
        _context.Users.Add((User)user);
        _context.SaveChanges();
    }

    public void RemoveUser(IUser user)
    {
        _context.Users.Remove((User)user);
        _context.SaveChanges();
    }

    public void UpdateUser(IUser user)
    {
        _context.Users.Update((User)user);
        _context.SaveChanges();
    }

}
