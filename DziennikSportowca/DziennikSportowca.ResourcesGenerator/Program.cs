using DziennikSportowca.Common.Consts.Domain;
using DziennikSportowca.Common.Resources.Setup;
using System;
using System.Collections.Generic;
using System.IO;

namespace DziennikSportowca.ResourcesGenerator
{
    class Program
    {
        private static readonly string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\"));
        private static readonly Dictionary<TemplateTypes, string> templates = new Dictionary<TemplateTypes, string>();

        static void Main()
        {
            InitializeTemplates();
            GenerateDictionaries();           
        }

        private static void InitializeTemplates()
        {
            foreach (TemplateTypes script in typeof(TemplateTypes).GetEnumValues())
                templates.Add(script, ReadFile(script.ToString(), FileExtensions.TXT));
            
        }

        #region Generators

        private static void GenerateDictionaries()
        {
            var dictionaries = Setup.GetDictionaries();
            List<string> sqlStrings = new List<string>();

            foreach (var dictionary in dictionaries)
            {
                sqlStrings.Add(string.Format(templates[TemplateTypes.DictionaryTemplate], dictionary.DictionaryId, dictionary.DictionaryName));

                foreach (var name in dictionary.Names)
                    sqlStrings.Add(string.Format(templates[TemplateTypes.DictionaryNameTemplate], dictionary.DictionaryId, name.Culture, name.Name));
                
            }

            SaveFile(string.Join("", sqlStrings), ScriptTypes.Dictionaries, FileExtensions.SQL);
        }

        #endregion Generators

        #region Files methods

        private static string ReadFile(string fileName, FileExtensions extension)
        {
            return File.ReadAllText(Path.Combine(projectPath, FolderTypes.Templates.ToString(), $"{fileName}.{extension.ToString().ToLower()}"));
        }

        private static void SaveFile(string data, ScriptTypes scriptType, FileExtensions extension)
        {
            string savePath = Path.Combine(projectPath, FolderTypes.Scripts.ToString(), $"{scriptType.ToString()}.{extension.ToString().ToLower()}");

            using (FileStream fileStrem = new FileStream(savePath, FileMode.Create))
            using (StreamWriter streamWriter = new StreamWriter(fileStrem))
            {
                streamWriter.Write(data, 0, data.Length);
                streamWriter.Close();
                fileStrem.Close();
            }
        }

        #endregion Files methods

        #region Enums

        private enum ScriptTypes
        {
            Dictionaries
        }

        private enum FolderTypes
        {
            Scripts,
            Templates
        }

        private enum TemplateTypes
        {
            DictionaryTemplate,
            DictionaryNameTemplate
        }

        #endregion Enums
    }
}
