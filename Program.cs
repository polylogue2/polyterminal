using System.Reflection;
using Spectre.Console;
class Program
{
    static void Main()
    {
        AnsiConsole.Clear();

        string version = ReadEmbeddedResource("polyterminal.version.txt");

        if (version == null)
        {
            Console.WriteLine("Version resource not found.");
            version = "unknown";
        }

        Console.Title = $"polyterminal v{version}";

        AnsiConsole.MarkupLine("[rgb(129,161,255)]guest[/][white]@[/][rgb(129,161,255)]alwaysdns.net[/][white]:~ $ [/]~/startup.sh");
        AnsiConsole.WriteLine();

        string buttonsAsciiSmall = @"
            ===========    ----------    ===========    ----------
            ===========    ----------    ===========    ----------
            ====   ====    ----  ----    ====   ====    ----  ----
            ====   ====    ----  ----    ====   ====    ----  ----
            ===========    ----------    ===========    ----------
            ===========    ----------    ===========    ----------
            ===========    ----------    ===========    ----------
            ===========    ----------    ===========    ----------
            ===========    ----------    ===========    ----------  
            ";
        AnsiConsole.MarkupLine($"[rgb(202,160,255)]{buttonsAsciiSmall}[/]");
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine($"[white]Welcome to [rgb(202,160,255)]polyterminal[/] (v{version}), my terminal-themed portfolio![/]");
        AnsiConsole.MarkupLine("[white]Check out the [rgb(129,161,255)][link=https://github.com/polylogue2/polyterminal]GitHub repository[/][/][/]");
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine("[white]Type 'help' for a list of available commands.[/]");
        AnsiConsole.WriteLine();

        while (true)
        {
            AnsiConsole.Markup("[rgb(129,161,255)]guest[/]");
            AnsiConsole.Markup("[white]@[/]");
            AnsiConsole.Markup("[rgb(129,161,255)]alwaysdns.net[/]");
            AnsiConsole.Markup("[white]:~ $ [/]");

            string input = Console.ReadLine()?.Trim() ?? "";

            if (string.IsNullOrEmpty(input))
                continue;

            int firstSpace = input.IndexOf(' ');
            string command = firstSpace == -1 ? input.ToLower() : input[..firstSpace].ToLower();
            string args = firstSpace == -1 ? "" : input[(firstSpace + 1)..];

            if (command == "exit" || command == "quit")
                break;

            switch (command)
            {
                case "about":
                    AnsiConsole.MarkupLine("[white]Hello! I'm Fresh, a hobbyist software developer and tech enthusiast, interested in networking and programming. I mainly make web-based projects, as well as terminal programs (like this!).[/]");
                    break;

                case "projects":
                    AnsiConsole.MarkupLine("[white]Some projects: Waveform music streamer, HF4 Park Minecraft campus, Polyboard macro keyboard.[/]");
                    break;

                case "home":
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = "https://alwaysdns.net/?utm_source=polyterminal",
                        UseShellExecute = true
                    });
                    break;

                case "links":
                    AnsiConsole.MarkupLine("[white]- YouTube:[/] [link=https://youtube.com/@polylogue2]youtube.com/@polylogue2[/]");
                    AnsiConsole.MarkupLine("[white]- GitHub:[/] [link=https://github.com/polylogue2]github.com/polylogue2[/]");
                    AnsiConsole.MarkupLine("[white]- Bluesky:[/] [link=https://bsky.app/profile/alwaysdns.net]bsky.app/profile/alwaysdns.net[/]");
                    AnsiConsole.WriteLine();
                    AnsiConsole.MarkupLine("[white](ctrl+click to open)[/]");
                    break;

                case "help":
                    AnsiConsole.WriteLine();
                    AnsiConsole.MarkupLine("[white]Available commands:[/]");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]about[/]      About me");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]projects[/]   Features my best projects");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]home[/]       Opens the main website");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]links[/]      Shows my social links");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]echo[/]       Renders text in the console");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]info[/]       Lists information about polyterminal");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]help[/]       Displays help text");
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]exit[/]       Quit polyterminal");
                    AnsiConsole.WriteLine();
                    break;

                case "info":
                    AnsiConsole.WriteLine();
                    AnsiConsole.MarkupLine($"[rgb(202,160,255)]polyterminal (Desktop) v{version}[/]");
                    AnsiConsole.MarkupLine("[white]Designed by polylogue @ MMXXV[/]");
                    AnsiConsole.MarkupLine("[white]polyterminal is a custom console portfolio, providing a unique way to interact with my website.[/]");
                    AnsiConsole.WriteLine();
                    break;

                case "echo":
                    if (!string.IsNullOrWhiteSpace(args))
                    {
                        AnsiConsole.MarkupLine($"[white]{args}[/]");
                    }
                    else
                    {
                        AnsiConsole.MarkupLine("[white]Usage: echo [rgb(202,160,255)]{message}[/][/]");
                    }
                    break;

                default:
                    AnsiConsole.MarkupLine($"-bash: [rgb(202,160,255)]{input}[/]: command not found");
                    break;
            }
        }

        static string ReadEmbeddedResource(string resourceName)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using Stream? stream = assembly.GetManifestResourceStream(resourceName);
            if (stream == null) return null;

            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd().Trim();
        }
    }
}
