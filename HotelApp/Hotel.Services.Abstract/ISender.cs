namespace Hotel.Services.Abstract
{
    public interface ISender
    {
        void Open();
        void Close();
        void Send(string text);
    }
}
