namespace PestKontroll.Services.Interfaces
{
    public interface IPKFileService
    {
        public Task<byte[]> ConvertFileToByteArrayAsync(IFormFile file);
        public string ConvertByteArrayToFile(byte[] fileData, string extansion);
        public string GetFileIcon(string file);
        public string FormatFileSize(long bytes);
    }
}
