using System;
using Microsoft.Data.Sqlite;
using Terminal.Gui;

namespace interfaceGUI
{
    class Program
    {
        static void Main(string[] args)
        {

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
            string databaseFileName = "shop";
            SqliteConnection connection = new SqliteConnection($"Data Source={databaseFileName}");
            UserRepository userRepository = new UserRepository(connection);
            GoodRepository goodRepository = new GoodRepository(connection);
            OrderRepository orderRepository = new OrderRepository(connection);

            Application.Init();

            Toplevel top = Application.Top;

            bool loggedOut = true;
            while (loggedOut)
            {
                EnteringWindow enteringWin = new EnteringWindow();
                enteringWin.SetRepository(userRepository, orderRepository);


                top.Add(enteringWin);
                Application.Run();


                HomeWindow homeWindow = new HomeWindow(enteringWin.loggedUser);
                homeWindow.SetRepository(userRepository, goodRepository, orderRepository);
                top.RemoveAll();
                top.Add(homeWindow);
                Application.Run();
                loggedOut = homeWindow.loggedOut;

            }

            // User user = userRepository.GetUserByUsername("tester");
            // Order order = new Order();
            // Good good1 = goodRepository.GetById(11);
            // Good good2 = goodRepository.GetById(12);

            // order = new Order(user.id);
            // order.AddGoodToOrder(good1);
            // order.AddGoodToOrder(good2);
            // order.SetAmount();
            // // long id = orderRepository.Insert(order);
            // order.id = 12;

            // orderRepository.AddGoodsOrders(order);
        
        }
    }
}
