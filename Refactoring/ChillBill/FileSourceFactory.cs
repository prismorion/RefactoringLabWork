namespace ChillBill
{
    public static class FileSourceFactory
    {
        public static IFileSource CreateFileSource(string fileType)
        {
            fileType = fileType.TrimStart('.');
            switch (fileType)
            {
                case "json":
                    return new JsonFileSource();
                case "yaml" or "yml":
                    return new YamlFileSource();
                default:
                    throw new NotSupportedException($"Формат файла '{fileType}' не поддерживается");
            }
        }
    }
}
