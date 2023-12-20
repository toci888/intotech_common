namespace Intotech.Common.ImageManagement;

public class ImageManager
{
    protected HttpClient httpRequestClient;

    public ImageManager() //string baseUrl
    {
        httpRequestClient = new HttpClient();

        //httpRequestClient.BaseAddress = new Uri(baseUrl);
    }

    public virtual byte[] GetImageBytes(string url)
    {
        return httpRequestClient.GetByteArrayAsync(url).Result;

        //return Convert.ToBase64String(imageBytes);
    }
}