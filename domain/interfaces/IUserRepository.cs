using System;

namespace domain.interfaces;

public interface IUserRepository
{
    IEnumerable<IUser> GetAllUsers();
    IUser GetUserById(Guid id);
    void AddUser(IUser user);
    void RemoveUser(IUser user);
    void UpdateUser(IUser user);
}