namespace Inventory.AppCode.Helper
{
    public static class FileHelper
    {
        public static void WriteToFile(string path, string content)
        {
            File.WriteAllText(path, content);
        }

        public static string ReadFromFile(string path)
        {
            return File.ReadAllText(path);
        }

        public static bool FileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public static bool IsDirectory(string path)
        {
            return Directory.Exists(path);
        }

        public static string[] GetAllFilesInDirectory(string directoryPath)
        {
            return Directory.GetFiles(directoryPath);
        }

        public static bool IsFileExtensionValid(string fileName, List<string> allowedExtensions)
        {
            // Validate file extension against a list of allowed extensions
            string extension = Path.GetExtension(fileName);
            return allowedExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        }

        public static FileInfo GetFileInfo(string filePath)
        {
            return new FileInfo(filePath);
        }

        public static void CopyFile(string sourcePath, string destinationPath)
        {
            File.Copy(sourcePath, destinationPath);
        }

        public static void MoveFile(string sourcePath, string destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }

        public static void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        public static byte[] ReadFileAsBytes(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        public static void WriteBytesToFile(string filePath, byte[] data)
        {
            File.WriteAllBytes(filePath, data);
        }

        public static void AppendTextToFile(string filePath, string content)
        {
            File.AppendAllText(filePath, content);
        }

        public static void CreateFile(string filePath)
        {
            File.Create(filePath).Close();
        }

        public static string[] ReadAllLines(string filePath)
        {
            return File.ReadAllLines(filePath);
        }

        public static void WriteLinesToFile(string filePath, IEnumerable<string> lines)
        {
            File.WriteAllLines(filePath, lines);
        }

        public static string ReadFileUsingFileStream(string filePath)
        {
            using var stream = new FileStream(filePath, FileMode.Open);
            using var reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        public static void WriteFileUsingFileStream(string filePath, string content)
        {
            using var stream = new FileStream(filePath, FileMode.Create);
            using var writer = new StreamWriter(stream);
            writer.Write(content);
        }

        public static string GetFileExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        public static string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        public static string? GetFileDirectory(string filePath)
        {
            return Path.GetDirectoryName(filePath);
        }


    }
}
