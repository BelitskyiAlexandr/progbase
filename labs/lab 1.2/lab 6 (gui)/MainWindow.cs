using System;
using System.Collections.Generic;
using Terminal.Gui;

public class MainWindow : Window
{
    private ListView allActivitiesView;
    private ActivityRepository repo;
    private int pageLength = 3;
    private int page = 1;

    private Label totalPagesLabel;
    private Label pageLabel;
    public MainWindow()
    {
        this.Title = "Main";

        Rect frame = new Rect(4, 8, 40, 20);
        allActivitiesView = new ListView(new List<Activity>())
        {
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };
        allActivitiesView.OpenSelectedItem += OpenActivity;


        Button prevPageBtn = new Button(2, 6, "prev");
        prevPageBtn.Clicked += ToPrevPage;
        pageLabel = new Label("?")
        {
            X = Pos.Right(prevPageBtn) + 2,
            Y = Pos.Top(prevPageBtn),
            Width = 5,
        };
        totalPagesLabel = new Label("?")
        {
            X = Pos.Right(pageLabel) + 2,
            Y = Pos.Top(prevPageBtn),
            Width = 5,
        };
        Button nextPageBtn = new Button("next")
        {
            X = Pos.Right(totalPagesLabel) + 2,
            Y = Pos.Top(prevPageBtn),
        };
        nextPageBtn.Clicked += ToNextPage;
        this.Add(prevPageBtn, pageLabel, totalPagesLabel, nextPageBtn);

        FrameView frameView = new FrameView("Activities")
        {
            X = 2,
            Y = 8,
            Width = Dim.Fill() - 4,
            Height = pageLength + 2,
        };
        frameView.Add(allActivitiesView);


        Button newActivityBtn = new Button(2, 4, "Create new activity");
        newActivityBtn.Clicked += ClickNew;


        this.Add(frameView);
        this.Add(newActivityBtn);

    }

    private void ToPrevPage()
    {
        if (page == 1)
        {
            return;
        }
        this.page -= 1;
        ShowCurrentPage();
    }
    private void ToNextPage()
    {
        if (page >= repo.GetTotalPages())
        {
            return;
        }
        this.page += 1;
        ShowCurrentPage();
    }
    private void ShowCurrentPage()
    {
        if(allActivitiesView == null)
        {
            List<string> noRecords = new List<string>();
            noRecords.Add("No record in database");
            allActivitiesView.SetSource(noRecords);
        }
        this.pageLabel.Text = page.ToString();
        this.totalPagesLabel.Text = repo.GetTotalPages().ToString();
        this.allActivitiesView.SetSource(repo.GetPage(page));
    }


    public void SetRepository(ActivityRepository repository)
    {
        this.repo = repository;
        ShowCurrentPage();
    }

    public void ClickNew()
    {
        newActivityDialog dialog = new newActivityDialog();
        Application.Run(dialog);

        if (!dialog.canceled)
        {
            Activity activity = dialog.GetActivity();
            if (!(activity == null))
            {
                long activityId = repo.Add(activity);
                activity.id = activityId;
                OpenActivityAfterAdding(activity);
            }
            else
                ClickNew();
        }
        allActivitiesView.SetSource(repo.GetPage(page));
    }
    private void OpenActivityAfterAdding(Activity activity)
    {
        OpenActivityDialog dialog = new OpenActivityDialog();

        dialog.SetActivity(activity);

        Application.Run(dialog);
    }

    public void ClickQuit()
    {
        Application.RequestStop();
    }

    public void ClickAbout()
    {
        Button back = new Button(30, 16, "Back");
        back.Clicked += ClickQuit;

        Dialog dialog = new Dialog("About", back);
        TextView textView = new TextView()
        {
            X = 2,
            Y = 2,
            Width = 65,
            Height = 12,
            ReadOnly = true,
            Text = @"
        Цей додаток призначений для ведення списку подій:
            їхного короткого опису, коментарів і тд.
                
            
            Знаходиться на ранній стадії розробки


                Автор: Беліцький Олександр  
            
                    ActivityApp Beta"

        };

        dialog.Add(textView);
        dialog.AddButton(back);

        Application.Run(dialog);
    }

    private void OpenActivity(ListViewItemEventArgs args)
    {
        Activity activity = (Activity)args.Value;
        OpenActivityDialog dialog = new OpenActivityDialog();

        dialog.SetActivity(activity);

        Application.Run(dialog);

        if (dialog.deleted)
        {
            bool result = repo.Delete(activity.id);
            if (result)
            {
                int pages = repo.GetTotalPages();
                if (page > pages && page > 1)
                {
                    page -= 1;
                    this.ShowCurrentPage();
                }

                allActivitiesView.SetSource(repo.GetPage(page));
            }
            else
            {
                MessageBox.ErrorQuery("Delete activity", "Can not delete activity", "OK");
            }
        }

        if (dialog.updated)
        {
            bool result = repo.Update(activity.id, dialog.GetActivity());
            if (result)
            {
                allActivitiesView.SetSource(repo.GetPage(page));
            }
            else
            {
                MessageBox.ErrorQuery("Update activity", "Can not update activity", "OK");
            }
        }
    }
}