namespace VoyagerPos
{
    public interface IArticle
    {
        string productCode
        {
            get;
        }

        decimal CalculatePrice(int quantity);
    }
}
