namespace FireApp.Services;

public class ServiceManagment : IServiceManagment
{
    public void GenerateMerchandise()
    {
      Console.WriteLine($"Generate Merchandise: Long runing task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void SendEmail()
    {
      Console.WriteLine($"Send Email: Long runing task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void SyncData()
    {
      Console.WriteLine($"Sync Data: Long runing task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }

    public void UpdateDatabase()
    {
      Console.WriteLine($"Update Database: Long runing task {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
    }
}