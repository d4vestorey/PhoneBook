using Spectre.Console;

namespace PhoneBook
{
    public class VisualiseContacts
    {
        internal static void DisplayContacts(List<Contact> contacts)
        {
            
            Console.Clear();

            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Name");
            table.AddColumn("Phone Number");

            foreach (var contact in contacts)
            {
                table.AddRow(contact.id.ToString(), contact.Name, contact.PhoneNumber);
            }

            AnsiConsole.Write(table);
            Console.ReadLine();
        }

        internal static void DisplayContact(Contact contact)
        {
            Console.Clear();

            var table = new Table();
            table.AddColumn("ID");
            table.AddColumn("Name");
            table.AddColumn("Phone Number");

            table.AddRow(contact.id.ToString(), contact.Name, contact.PhoneNumber);

            AnsiConsole.Write(table);
            Console.ReadLine();
        }
    }
}