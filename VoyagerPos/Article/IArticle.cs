namespace VoyagerPos
{
    public interface IArticle
    {
        string productCode
        {
            get;
        }

        decimal CalculatePrice(decimal quantity);
    }
}
