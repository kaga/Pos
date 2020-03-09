using System.Collections.Generic;
using VoyagerPos;
using System.Linq;

namespace VoyagerPosTest
{
    class SimpleArticleDataSource : ProductDataSource
    {
        public List<IArticle> articles;

        public SimpleArticleDataSource()
        {
            articles = new List<IArticle>();
        }

        public IArticle FindProduct(string productCode)
        {
            var article = articles.Find((article) => article.productCode == productCode);
            return article;           
        }
    }
}
