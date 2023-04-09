// See https://aka.ms/new-console-template for more information
using tpmodul8;

CovidConfig config = new CovidConfig();
ReadJSON read = new ReadJSON();

read.covCon.UbahSatuan_1302213038();

Console.WriteLine("Berapa suhu badan anda saat ini? " +
    "Dalam nilai " + read.covCon.satuan_suhu);
double temp = double.Parse(Console.ReadLine());

Console.WriteLine("Berapa hari yang lalu (perkiraan) " +
    "anda terakhir memiliki gejala demam?");
int day = int.Parse(Console.ReadLine());

if (day < read.covCon.batas_hari_demam)
{
    if (read.covCon.satuan_suhu == "celcius" 
        && temp >= 36.5 && temp <= 37.5)
    {
        Console.WriteLine(read.covCon.pesan_diterima);
    } else if (read.covCon.satuan_suhu == "fahrenheit" 
        && temp >= 97.7 && temp <= 99.5)
    {
        Console.WriteLine(read.covCon.pesan_diterima);
    } else
    {
        Console.WriteLine(read.covCon.pesan_ditolak);
    }
} else
{
    Console.WriteLine(read.covCon.pesan_ditolak);
}