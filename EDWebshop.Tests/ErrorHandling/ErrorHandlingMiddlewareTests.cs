using EDWebshop.Api.ErrorHandling;
using Microsoft.AspNetCore.Http;

namespace EDWebshop.Api.Tests.ErrorHandling
{
    [TestClass]
    public class ErrorHandlingMiddlewareTests
    {
        [TestMethod]
        public async Task Invoke_Should_Not_Change_Status_Code_If_No_Error_Occur()
        {
            // Arrange
            var middleware = new ErrorHandlingMiddleware(next: context => Task.CompletedTask);
            var context = new DefaultHttpContext();

            // Act
            await middleware.Invoke(context);

            // Assert

            Assert.AreEqual(StatusCodes.Status200OK, context.Response.StatusCode);
        }

        [TestMethod]
        public async Task Invoke_Should_Handle_Exception_And_Return_InternalServerError()
        {
            // Arrange
            var exceptionMessage = "Simulated exception";
            var middleware = new ErrorHandlingMiddleware(next: context => throw new Exception(exceptionMessage));
            var context = new DefaultHttpContext();
            context.Response.Body = new MemoryStream();

            // Act
            await middleware.Invoke(context);

            // Assert
            context.Response.Body.Seek(0, SeekOrigin.Begin);
            using var reader = new StreamReader(context.Response.Body);
            var responseText = await reader.ReadToEndAsync();

            Assert.AreEqual(StatusCodes.Status500InternalServerError, context.Response.StatusCode);
            Assert.AreEqual("text/plain", context.Response.ContentType);
            StringAssert.Contains(responseText, $"Ett internt serverfel har inträffat: {exceptionMessage}.");
        }
    }
}