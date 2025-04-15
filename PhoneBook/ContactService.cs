using Phonebook;
using Spectre.Console;

namespace PhoneBook
{
    public class ContactService
    {
        static private Contact GetContactsOptions()
        {
            var contacts = PhoneController.ViewContacts();
            var contactsArray = contacts.Select(x => x.Name).ToArray();
            var selectedContact = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select a contact:")
                    .PageSize(10)
                    .AddChoices(contactsArray));
            var id = contacts.Single(x => x.Name == selectedContact).id;
            var contact = PhoneController.SearchContactById(id);
            return contact;
        }

        static internal void DeleteContact()
        {
            var contact = GetContactsOptions();
            PhoneController.DeleteContact(contact);
            AnsiConsole.MarkupLine("[red]Contact deleted successfully![/]");
        }

        internal static void AddContact()
        {
            AnsiConsole.MarkupLine("[green]Adding a new contact...[/]");
            PhoneController.AddContact();
        }

        internal static void ViewContacts()
        {
            AnsiConsole.MarkupLine("[blue]Viewing all contacts...[/]");
            var contacts = PhoneController.ViewContacts();
            VisualiseContacts.DisplayContacts(contacts);
        }

        internal static void ViewContact()
        {
            AnsiConsole.MarkupLine("[yellow]Searching for a contact...[/]");
            var contact = GetContactsOptions();
            VisualiseContacts.DisplayContact(contact);
        }

        internal static void UpdateContact()
        {
            var contact = GetContactsOptions();
            contact.Name = AnsiConsole.Ask<string>("Enter the contact's [green]new name[/]:", contact.Name);
            contact.PhoneNumber = AnsiConsole.Ask<string>("Enter the contact's [green]new phone number[/]:", contact.PhoneNumber);
            PhoneController.UpdateContact(contact);
        }
    }
}