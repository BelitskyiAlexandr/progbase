using Terminal.Gui;

public class EditActivityDialog : newActivityDialog
{

    public EditActivityDialog()
    {
        this.Title = "Edit Activity";

       
    }

    public void SetActivity(Activity activity)
    {
        this.activityTitleTf.Text = activity.title;
        this.commentTf.Text = activity.commentary;
        this.typeTf.Text = activity.type;
        this.distanceTf.Text = activity.distance.ToString();
        this.timeTf.Text = activity.timeOfCreation.ToShortDateString();
        this.idTf.Text = activity.id.ToString();
    }

}