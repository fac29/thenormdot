using System;
using domain.interfaces;

namespace domain.entities;

public class User : IUser
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Avatar { get; set; }
    public string SummaryParagraph { get; set; }

    // Parameterless constructor
    public User()
    {
        Id = Guid.NewGuid();
    }

    public void AddUser(User user)
    {
        throw new NotImplementedException();
    }

    public void RemoveUser(User user)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(User user)
    {
        throw new NotImplementedException();
    }
}