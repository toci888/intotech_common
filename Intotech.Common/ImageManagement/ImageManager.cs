namespace Intotech.Common.ImageManagement;

public class ImageManager
{
    protected HttpClient httpRequestClient;

    public ImageManager() //string baseUrl
    {
        httpRequestClient = new HttpClient();

        //httpRequestClient.BaseAddress = new Uri(baseUrl);
    }

    public virtual string GetImageBase64(string url)
    {
        byte[] imageBytes = httpRequestClient.GetByteArrayAsync(url).Result;

        return Convert.ToBase64String(imageBytes);
    }
}