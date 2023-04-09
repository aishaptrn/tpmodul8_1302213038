using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8
{
    internal class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
        public CovidConfig() { }
        public CovidConfig(string satuan_suhu, int batas_hari_demam, 
            string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
        
        public void UbahSatuan_1302213038()
        {
            if (satuan_suhu == "celcius")
            {
                satuan_suhu = "fahrenheit";
            } else
            {
                satuan_suhu = "celcius";
            }
        }
    }

    class ReadJSON
    {
        public CovidConfig covCon;
        public const string readFile = "D:\\aisha n\\Documents\\AISHA\\uni\\Semester 4\\" +
            "KPL\\Praktikum\\TP Mod 8\\tpmodul8_1302213038\\tpmodul8\\covid_config.json";
        public ReadJSON()
        {
            try
            {
                ReadConfigFile_1302213038();
            }
            catch (Exception)
            {
                setDefault_1302213038();
                writeNewConfigFile_1302213038();
            }
        }

        private CovidConfig ReadConfigFile_1302213038()
        {
            string configJson = File.ReadAllText(readFile);
            covCon = JsonSerializer.Deserialize<CovidConfig>(configJson);
            return covCon;
        }

        private void setDefault_1302213038()
        {
            string pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            string pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
            covCon = new CovidConfig("celcius", 14, pesan_ditolak, pesan_diterima);
        }

        private void writeNewConfigFile_1302213038()
        {
            JsonSerializerOptions options = new JsonSerializerOptions() { WriteIndented = true };

            string jsonStr = JsonSerializer.Serialize(covCon, options);
            File.WriteAllText(readFile, jsonStr);
        }
    }
}
