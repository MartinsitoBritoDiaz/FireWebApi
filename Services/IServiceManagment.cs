namespace FireApp.Services;

public interface IServiceManagment
{
  void SendEmail();
  void UpdateDatabase();
  void GenerateMerchandise();
  void SyncData();
}