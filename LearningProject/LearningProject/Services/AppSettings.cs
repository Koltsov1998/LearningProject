using System;
using System.IO;
using Newtonsoft.Json;

namespace LearningProject.Services
{
    public class AppSettings
    {
        public int ParsingDepth { set; get; } = 100;
        private string _settingsPath;

        public void Init()
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var settingDirectoryPath = Path.Combine(appDataPath, "MemeSearchSettings");
            _settingsPath = Path.Combine(settingDirectoryPath, "settings.json");

            if (!File.Exists(_settingsPath))
            {
                Directory.CreateDirectory(settingDirectoryPath);

                File.Create(_settingsPath).Dispose();
                Save();
            }
            else
            {
                Load();
            }
        }

        private void Load()
        {
            var seriallizedSettings = File.ReadAllText(_settingsPath);
            var settings = JsonConvert.DeserializeObject<AppSettings>(seriallizedSettings);

            this.ParsingDepth = settings.ParsingDepth;
        }

        private void Save()
        {
            var seriallizedSettings = JsonConvert.SerializeObject(this, Formatting.Indented);
            
            File.WriteAllText(_settingsPath, seriallizedSettings);
        }
    }
}
