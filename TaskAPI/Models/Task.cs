namespace TaskAPI.Models
{
  public class Task
  {
    public int Id { get; set; }
    public string Text { get; set; }
    public string Day { get; set; }
    public bool Reminder { get; set; }
  }
}
