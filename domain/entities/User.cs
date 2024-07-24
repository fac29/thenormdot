using System;
using domain.interfaces;

namespace domain.entities;

public class User : IUser
{
    public Guid Id { get; }

    public string Name { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Avatar { get; set; } = string.Empty;

    public string SummaryParagraph { get; set; } = string.Empty;

    public User(Guid id)
    {
        Id = id;
    }

    public void AddUser(User user)
    {
        // This method doesn't make sense for a single User object
        throw new InvalidOperationException("AddUser operation is not supported for a single User object.");
    }

    public void RemoveUser(User user)
    {
        // This method doesn't make sense for a single User object
        throw new InvalidOperationException("RemoveUser operation is not supported for a single User object.");
    }

    public void UpdateUser(User user)
    {
        if (user == null)
            throw new ArgumentNullException(nameof(user));

        if (user.Id != this.Id)
            throw new ArgumentException("Cannot update a different user.", nameof(user));

        Name = user.Name;
        Email = user.Email;
        Avatar = user.Avatar;
        SummaryParagraph = user.SummaryParagraph;
    }
}