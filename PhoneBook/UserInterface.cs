using Phonebook;
using Spectre.Console;

namespace PhoneBook
{
    public class UserInterface
    {
        static internal void MainMenu()
        {
            while (true)
            {

                Console.Clear();

                var selection = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOptions.MainMenuOptions>()
                        .Title("What do you want to do?")
                        .AddChoices(Enum.GetValues<MenuOptions.MainMenuOptions>())
                );


                switch (selection)
                {
                    case MenuOptions.MainMenuOptions.AddContact:
                        ContactService.AddContact();
                        break;

                    case MenuOptions.MainMenuOptions.ViewContacts:
                        ContactService.ViewContacts();
                        break;

                    case MenuOptions.MainMenuOptions.SearchContact:
                        ContactService.ViewContact();
                        break;

                    case MenuOptions.MainMenuOptions.DeleteContact:
                        ContactService.DeleteContact();
                        break;

                    case MenuOptions.MainMenuOptions.UpdateContact:
                        ContactService.UpdateContact();
                        break;

                    case MenuOptions.MainMenuOptions.Exit:
                        AnsiConsole.MarkupLine("[bold red]Exiting the application...[/]");
                        return;
                }
            }
        }
    }
}