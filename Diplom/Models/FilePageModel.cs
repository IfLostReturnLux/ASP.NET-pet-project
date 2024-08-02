namespace Diplom.Models
{
    [Serializable]
    public class FilePageModel
    {
        public string Path { get; set; }
        public List<string> DirectoriesName { get; set; }
        public List<string> FilesName { get; set; }
    }
}
