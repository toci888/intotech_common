using Intotech.Common.ImageManagement;

namespace Intotech.Common.Tests;

[TestClass]
public class ImageManagerTest
{
    [TestMethod]
    public void TestMy3ImageManagement()
    {
        ImageManager im = new ImageManager("https://scontent.fwaw7-1.fna.fbcdn.net");

        string result = im.GetImageBase64("/v/t39.30808-6/274276787_5059313134128039_4678920387161799416_n.jpg?_nc_cat=111&ccb=1-7&_nc_sid=09cbfe&_nc_ohc=pXXqXX9uErcAX8_DJ3Y&_nc_oc=AQluF8UaW4jqA9YAKDpXZO4gHkCG16fqnUlIxIoSJgHit2SDmb2PNaC0lVo1ng1Ri40&_nc_ht=scontent.fwaw7-1.fna&oh=00_AfCkU6N52TARGE6xEWcWXaIEfbJpS-7BNNZ4gZzv72FSUA&oe=63C51F92");
    }
}