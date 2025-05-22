using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OdontoAPP.Services
{
    public class RoboflowService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "or9iUws2M4NzKpUPYged";
        private const string DatasetName = "odontoapp";
        private const string DatasetVersion = "1";

        public RoboflowService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Método para upload de imagens locais
        public async Task<string> UploadImageAsync(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            string encodedImage = Convert.ToBase64String(imageArray);

            string uploadUrl = $"https://api.roboflow.com/dataset/{DatasetName}/upload?api_key={ApiKey}&name={Path.GetFileName(imagePath)}&split=train";

            var content = new StringContent(encodedImage, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync(uploadUrl, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // Método para inferência em imagens locais
        public async Task<string> InferLocalImageAsync(string imagePath)
        {
            byte[] imageArray = File.ReadAllBytes(imagePath);
            string encodedImage = Convert.ToBase64String(imageArray);

            string inferenceUrl = $"https://detect.roboflow.com/{DatasetName}/{DatasetVersion}?api_key={ApiKey}&name={Path.GetFileName(imagePath)}";

            var content = new StringContent(encodedImage, Encoding.UTF8, "application/x-www-form-urlencoded");

            var response = await _httpClient.PostAsync(inferenceUrl, content);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }

        // Método para inferência em imagens hospedadas
        public async Task<string> InferHostedImageAsync(string imageUrl)
        {
            string inferenceUrl = $"https://detect.roboflow.com/{DatasetName}/{DatasetVersion}?api_key={ApiKey}&image={HttpUtility.UrlEncode(imageUrl)}";

            var response = await _httpClient.PostAsync(inferenceUrl, null);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
