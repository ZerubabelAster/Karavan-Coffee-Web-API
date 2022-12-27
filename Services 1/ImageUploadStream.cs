namespace KaravanCoffeeWebAPI.Services_1
{
    public class ImageUploadStream
    {
        private IWebHostEnvironment _webHostEnvironment;

        public ImageUploadStream(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadImage(IFormFile image)
        {
            string fileName = Path.GetFileName(image.FileName);
            string pathAndFileName = GetPathAndFileName(fileName);

            using (FileStream stream = new FileStream(pathAndFileName, FileMode.Create))
            {
                image.CopyToAsync(stream);
                stream.Close();
            }
            return pathAndFileName;
        }

        private string GetPathAndFileName(string fileName)
        {
            string path = _webHostEnvironment.WebRootPath + "\\Asset\\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            return path + Path.GetFileNameWithoutExtension(fileName)
                + "_" + Guid.NewGuid().ToString().Substring(0, 4)
                + Path.GetExtension(fileName);
        }
    }
}
