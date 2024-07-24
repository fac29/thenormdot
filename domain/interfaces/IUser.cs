using System;
using domain.entities;

namespace domain.interfaces;

public interface IUser
{

    Guid Id { get; }

    string Name { get; set; }

    string Email { get; set; }

    string Avatar { get; set; }

    string SummaryParagraph { get; set; }

    void AddUser(User user);

    void RemoveUser(User user);

    void UpdateUser(User user);
}
