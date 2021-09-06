using NLog;
using NLog.Web;
using StarWars.Contracts.Command;
using StarWars.Contracts.Dto;
using StarWars.Contracts.Factory;
using System;
using System.IO;
using System.Text.Json;

namespace StarWars.Command
{
    public class RetrievePersonInfoCommand : IRetrievePersonInfoCommand
    {
        private readonly Logger _logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
        private readonly IPersonInfoDtoFactory _personInfoDtoFactory;
        private readonly string _personName;
        private readonly string _outputPath;

        public RetrievePersonInfoCommand(IPersonInfoDtoFactory personInfoDtoFactory, string personName, string outputPath)
        {
            _personInfoDtoFactory = personInfoDtoFactory;
            _personName = personName;
            _outputPath = outputPath;
        }

        public IPersonInfoDto Execute()
        {
            _logger.Info($"Retrieveing information about: {_personName}.");
            var personInfo = _personInfoDtoFactory.Create(_personName);
            var savePath = Path.Combine(_outputPath, $"{DateTime.Now:yyyy-MM-dd_HH_mm_ss}_{_personName.Replace(' ', '_')}.json");
            _logger.Info($"Saving result to: {savePath}.");
            Directory.CreateDirectory(_outputPath);
            File.WriteAllText(savePath, JsonSerializer.Serialize(personInfo, new JsonSerializerOptions() { WriteIndented = true }));
            return personInfo;
        }
    }
}
