using Microsoft.EntityFrameworkCore;

namespace Lab0.Models;

public class ContactDbService(AddDbContext context, ILogger<ContactDbService> logger) : IContactService
{
    public List<Contact> GetContacts()
    {
        return context.Contacts.ToList();
    }

    public void AddContact(Contact contact)
    {
        context.Contacts.Add(contact);      // Contact zostanie stowrzony 
        context.SaveChanges();              // a następnie wstawiony do bazy z zapisem
    }

    public bool UpdateContact(Contact contact)
    {
        try
        {
            context.Contacts.Update(contact);
            context.SaveChanges();

        }
        catch (DbUpdateConcurrencyException e)
        {
            logger.LogError(e.Message);     // w razie gdyby nie udało się zaktualizowanie, wyświetlony zostanie konkretny komunikat o błędzie
            return false;
        }
        return  true;
    }

    public bool DeleteContactById(int id)
    {
        var deleted = context.Contacts.Find(id);
        if (deleted == null)
        {
            return false;                   // nie da się usunąć czegoś, czego nie ma 
        }

        context.Contacts.Remove(deleted);
        context.SaveChanges();
        return  true;
    }

    public Contact? GetContactById(int id)
    {
        var contact = context.Contacts.Find(id);
        return contact;                             // jeśli nie będzie contact to zostanie zwrócone null - widomo wtedy, że contact nie istnieje
    }
}

