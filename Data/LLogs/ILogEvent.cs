using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DIO.ContasBancarias.Data.LLogs
{
    public interface ILogEvent
    {
        [JsonInclude]
        public DateTime DataHoraEvento { get; set; }
        [JsonInclude]
        public string Descricao { get; set; }
    }
}