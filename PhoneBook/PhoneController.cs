using Spectre.Console;
using PhoneBook;

namespace Phonebook
{
    public class PhoneController
    {


        internal static void AddContact()
        {
            var name = AnsiConsole.Ask<string>("Enter the contact's [green]name[/]:");
            var phoneNumber = AnsiConsole.Ask<string>("Enter the contact's [green]phone number[/]:");

            using (var db = new PhoneBookContext())
            {
                var contact = new Contact { Name = name, PhoneNumber = phoneNumber };
                db.Contacts.Add(contact);
                db.SaveChanges();
            }

            AnsiConsole.MarkupLine("[green]Contact added successfully![/]");
        }

        internal static void DeleteContact(Contact contact)
        {
            using var db = new PhoneBookContext();
            db.Remove(contact);
            db.SaveChanges();
        }

        internal static Contact SearchContactById(int id)
        {
            using var db = new PhoneBookContext();

            var contact = db.Contacts.SingleOrDefault(c => c.id == id); // Replace with actual ID input

            return contact;
        }

        internal static void UpdateContact(Contact contact)
        {
            using var db = new PhoneBookContext();

            db.Update(contact);
            db.SaveChanges();
            

        }

        internal static List<Contact> ViewContacts()
        {
            using var db = new PhoneBookContext();

            var contacts = db.Contacts.ToList();

            return contacts;
        }
    }
}