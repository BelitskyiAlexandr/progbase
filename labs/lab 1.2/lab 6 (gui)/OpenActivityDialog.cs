using System;
using Terminal.Gui;

public class OpenActivityDialog : Dialog
{
    public bool deleted;
    public bool updated;

    protected Activity activity;

    private TextField activityTitleTf;
    private TextField typeTf;
    private TextField commentTf;
    private TextField distanceTf;
    private DateField timeTf;
    private TextField idTf;

    public OpenActivityDialog()
    {
        this.Title = "Open activity";

        Button okBtn = new Button("Back");
        okBtn.Clicked += DialogConfirm;

        this.AddButton(okBtn);

        int rightColumnX = 20;

        Label activityTitleLbl = new Label(2, 2, "Title: ");
        activityTitleTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(activityTitleLbl),
            Width = 40,
            ReadOnly = true,
        };
        this.Add(activityTitleLbl, activityTitleTf);


        Label typeLbl = new Label(2, 4, "Type: ");
        typeTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(typeLbl),
            Width = 40,
            ReadOnly = true,
        };
        this.Add(typeLbl, typeTf);


        Label commentLbl = new Label(2, 6, "Commentary: ");
        commentTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(commentLbl),
            Width = 40,
            ReadOnly = true,
        };
        this.Add(commentLbl, commentTf);

        Label distanceLbl = new Label(2, 8, "Distance: ");
        distanceTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(distanceLbl),
            Width = 40,
            ReadOnly = true,
        };
        this.Add(distanceLbl, distanceTf);

        Label timeLbl = new Label(2, 10, "Time of creation: ");
        timeTf = new DateField()
        {
            X = rightColumnX,
            Y = Pos.Top(timeLbl),
            Width = 40,
            ReadOnly = true,
        };
        this.Add(timeLbl, timeTf);

        Label idLbl = new Label(2, 12, "Id: ");
        idTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(idLbl),
            Width = 40,
            ReadOnly = true,
        };
        this.Add(idLbl, idTf);


        Button editBtn = new Button(2, 14, "Edit");
        editBtn.Clicked += ActivityEdit;

        Button deleteBtn = new Button("Delete")
        {
            X = Pos.Right(editBtn) + 2,
            Y = Pos.Top(editBtn),
        };
        deleteBtn.Clicked += ActivityDelete;

        this.Add(editBtn);
        this.Add(deleteBtn);
    }

    private void ActivityEdit()
    {
        EditActivityDialog dialog = new EditActivityDialog();

        dialog.SetActivity(this.activity);

        Application.Run(dialog);

        if (!dialog.canceled)
        {
            Activity updatedActivity = dialog.GetEditActivity();
            this.updated = true;
            this.SetActivity(updatedActivity);
            activity = updatedActivity;
        }
    }



    private void ActivityDelete()
    {
        int index = MessageBox.Query("Delete activity", "Are you sure?", "No", "Yes");
        if (index == 1)
        {
            deleted = true;
            Application.RequestStop();
        }
    }

    public Activity GetActivity()
    {
        return this.activity;
    }

    public void SetActivity(Activity activity)
    {
        this.activity = activity;
        this.activityTitleTf.Text = activity.title;
        this.typeTf.Text = activity.type;
        this.commentTf.Text = activity.commentary;
        this.distanceTf.Text = activity.distance.ToString();
        this.timeTf.Text = activity.timeOfCreation.ToShortDateString();
        this.idTf.Text = activity.id.ToString();
    }


    private void DialogConfirm()
    {
        Application.RequestStop();
    }

}