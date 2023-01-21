using CdrNet.Data.Txt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CdrNet.Business.LogAggregate
{
    public static class LogServisi
    {
        private static List<Log> logListe = new List<Log>();

        public static void Error(string hataMesaji)
        {
            File.AppendAllText(Sabitler.LOG_DOSYA_YOLU, hataMesaji);
        }

        public static void Warningor(string uyariMesaji)
        {
            File.AppendAllText(Sabitler.LOG_DOSYA_YOLU, uyariMesaji);
        }

        public static void Information(string hatabilgiMesaji)
        {
            File.AppendAllText(Sabitler.LOG_DOSYA_YOLU, hatabilgiMesaji);
        }

        public static IReadOnlyCollection<Log> GetLogList()
        {
            var data = DosyaIslemleri.Oku(Sabitler.LOG_DOSYA_YOLU);
            logListe = JsonSerializer.Deserialize<List<Log>>(data, new JsonSerializerOptions { IncludeFields = true });
            return logListe.AsReadOnly();
        }
    }
}
