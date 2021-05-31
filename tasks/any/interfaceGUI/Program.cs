using System;
using Microsoft.Data.Sqlite;
using Terminal.Gui;

namespace interfaceGUI
{
    class Program
    {
        static void Main(string[] args)
        {
            string databaseFileName = "shop";
            SqliteConnection connection = new SqliteConnection($"Data Source={databaseFileName}");
            UserRepository userRepository = new UserRepository(connection);

            Application.Init();

            Toplevel top = Application.Top;

            EnteringWindow win = new EnteringWindow();
            win.SetRepository(userRepository);

            // MenuBar menuBar = new MenuBar(new MenuBarItem[]
            // {
            // new MenuBarItem("_File", new MenuItem[]
            // {
            //     new MenuItem("_New record", "",win.ClickNew),
            //     new MenuItem("_Quit", "", win.ClickQuit),
            // }),
            // new MenuBarItem("_Help", new MenuItem[]
            // {
            //     new MenuItem("_About","", win.ClickAbout)
            // })
            // });


            // top.Add(menuBar);

            top.Add(win);


            Application.Run();
        }
    }
}
