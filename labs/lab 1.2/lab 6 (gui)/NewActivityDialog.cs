using System;
using Terminal.Gui;

public class newActivityDialog : Dialog
{
    public bool canceled;

    protected TextField activityTitleTf;
    protected TextField typeTf;
    protected TextField commentTf;
    protected TextField distanceTf;
    protected DateField timeTf;
    protected TextField idTf;

    public newActivityDialog()
    {
        this.Title = "Create new activity";

        Button okBtn = new Button("OK");
        okBtn.Clicked += DialogConfirm;

        Button cancelBtn = new Button("Cancel");
        cancelBtn.Clicked += DialogCanceled;

        this.AddButton(cancelBtn);
        this.AddButton(okBtn);

        int rightColumnX = 20;

        Label activityTitleLbl = new Label(2, 2, "Title: ");
        activityTitleTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(activityTitleLbl),
            Width = 40,
        };
        this.Add(activityTitleLbl, activityTitleTf);


        Label typeLbl = new Label(2, 4, "Type: ");
        typeTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(typeLbl),
            Width = 40,
        };
        this.Add(typeLbl, typeTf);


        Label commentLbl = new Label(2, 6, "Commentary: ");
        commentTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(commentLbl),
            Width = 40,
        };
        this.Add(commentLbl, commentTf);

        Label distanceLbl = new Label(2, 8, "Distance: ");
        distanceTf = new TextField("")
        {
            X = rightColumnX,
            Y = Pos.Top(distanceLbl),
            Width = 40,
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
        idTf = new TextField("Id will be choose automatically")
        {
            X = rightColumnX,
            Y = Pos.Top(idLbl),
            Width = 40,
            ReadOnly = true,
        };
        this.Add(idLbl, idTf);


    }

    public Activity GetActivity()
    {
        if (!double.TryParse(distanceTf.Text.ToString(), out double result))
        {
            MessageBox.ErrorQuery("Error", $"Distance must be real number but have {distanceTf.Text.ToString()}", "OK");
            return null;
        }
        return new Activity()
        {
            title = activityTitleTf.Text.ToString(),
            type = typeTf.Text.ToString(),
            commentary = commentTf.Text.ToString(),
            distance = result,
            timeOfCreation = DateTime.Now,
        };
    }

    public Activity GetEditActivity()
    {
        if (!double.TryParse(distanceTf.Text.ToString(), out double result))
        {
            MessageBox.ErrorQuery("Error", $"Distance must be real number but have {distanceTf.Text.ToString()}", "OK");
            return null;
        }
        return new Activity()
        {
            title = activityTitleTf.Text.ToString(),
            type = typeTf.Text.ToString(),
            commentary = commentTf.Text.ToString(),
            distance = result,
            timeOfCreation = System.DateTime.Parse(timeTf.Text.ToString()),
            id = long.Parse(idTf.Text.ToString()),
        };
    }

    private void DialogCanceled()
    {
        this.canceled = true;
        Application.RequestStop();
    }

    private void DialogConfirm()
    {
        this.canceled = false;
        Application.RequestStop();
    }

}