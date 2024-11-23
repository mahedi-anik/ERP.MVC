namespace ERP.MVC.Application.Utilities
{
    public static class DirectoryHelper
    {
        /// <summary>
        /// Ensures that the specified directory exists. If it does not exist, it creates the directory.
        /// </summary>
        /// <param name="directoryPath">The path of the directory to check or create.</param>
        public static void EnsureDirectoryExists(string directoryPath)
        {
            // Check if the directory exists
            if (!Directory.Exists(directoryPath))
            {
                // Create the directory if it does not exist
                Directory.CreateDirectory(directoryPath);
            }
        }
    }
}
