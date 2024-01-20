namespace SmartMonitoringSystem.Services
{
    public class FileService
    {
        private readonly IConfiguration _configuration;
        public FileService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool SaveImageToFile(byte[] image, string FileName)
        {
            try
            {
                var fileName = FileName;
                var filePath = _configuration["TargetImage"];

                var fullPath = Path.Combine(filePath, fileName);

                File.WriteAllBytes(fullPath, image);

                if (!File.Exists(fullPath))
                {
                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
