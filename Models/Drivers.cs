namespace FireApp.Models;

public class Driver {
  public Guid Id { get; set; }
  public string Name { get; set; } = string.Empty;
  public int DiverNumber { get; set; }
  public int Status { get; set; }
}