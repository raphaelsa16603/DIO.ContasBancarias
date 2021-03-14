using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DIO.ContasBancarias.Data.LLogs
{
    public interface ILogFile
    {
        [JsonInclude]
        public string DiretorioLog { get; set; }

        [JsonInclude]
        public string ArquivoLog { get; set; }

        [JsonInclude]
        public List<ILogEvent> Logs { get; set; }
        
    }
}