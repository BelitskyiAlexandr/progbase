using System;
using Microsoft.Data.Sqlite;
using Terminal.Gui;

class Program
{

    static void Main(string[] args)
    {
        string filepath = "./activitydb";
        SqliteConnection connection = new SqliteConnection($"Data Source={filepath}");
        ActivityRepository repo = new ActivityRepository(connection);

        Application.Init();

        Toplevel top = Application.Top;

        MainWindow win = new MainWindow();
        win.SetRepository(repo);

        MenuBar menuBar = new MenuBar(new MenuBarItem[]
        {
            new MenuBarItem("_File", new MenuItem[]
            {
                new MenuItem("_New record", "",win.ClickNew),
                new MenuItem("_Quit", "", win.ClickQuit),
            }),
            new MenuBarItem("_Help", new MenuItem[]
            {
                new MenuItem("_About","", win.ClickAbout)
            })
        });


        top.Add(menuBar);

        top.Add(win);


        Application.Run();
    }


}
