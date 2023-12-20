using Intotech.Common.ImageManagement;

namespace Intotech.Common.Tests;

[TestClass]
public class ImageManagerTest
{
    [TestMethod]
    public void TestMy3ImageManagement()
    {
        ImageManager im = new ImageManager(); //"https://scontent.fwaw7-1.fna.fbcdn.net"

        byte[] result = im.GetImageBytes("https://scontent-frx5-1.xx.fbcdn.net/v/t39.30808-1/262427974_4735820343143988_5239449481639743539_n.jpg?stp=c0.54.200.200a_dst-jpg_p200x200&_nc_cat=105&ccb=1-7&_nc_sid=7206a8&_nc_ohc=6YGgU2kKkCIAX_Q6Jdx&_nc_ht=scontent-frx5-1.xx&oh=00_AfCquUWK2QkphGQzmhW9XY6uWY6igzMdM7cFBxWqsWxh4w&oe=63C91A30");
    }
}