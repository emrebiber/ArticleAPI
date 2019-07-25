using System.Collections.Generic;
using ArticleAPI.DAL.Repositories.Article;
using Moq;
using Xunit;

namespace ArticleAPI.Tests
{
    public class ArticlesControllerTest
    {
        [Fact]
        public void Should_Mock_Function_Return_Article()
        {
            //Arrange
            var mock = new Mock<IArticleRepository>();
            var expected = new DAL.Models.Article();

            mock.Setup(x => x.GetArticleById(1)).Returns(expected);

            //Act
            var actual = mock.Object.GetArticleById(1);

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Mock_Function_Return_AllArticles()
        {
            //Arrange
            var mock = new Mock<IArticleRepository>();
            var expected = new List<DAL.Models.Article>();

            mock.Setup(x => x.GetAllArticles()).Returns(expected);

            //Act
            var actual = mock.Object.GetAllArticles();

            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
