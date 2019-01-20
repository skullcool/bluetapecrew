namespace BlueTapeCrew.Web.Services.Interfaces
{
    public interface ISessionService
    {
        string GetId();
        void SetCategory(string name);
        void SetProduct(int productId);
    }
}
