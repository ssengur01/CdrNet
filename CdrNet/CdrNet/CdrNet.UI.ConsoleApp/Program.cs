﻿using CdrNet.Business.KasaAggregate;
using CdrNet.Business;

Menu(); 


static void Menu()

{
  var secim = CevapAl("1. Ürün Ekle\n2. Ürün Sat\n3. Kasa Durumu\n4. Çıkış",false);
    switch (secim)
    {
        case "1":
            UrunEkle();
            break;
        case "2":
            UrunSat();
            break;
        case "3":
            KasaDurumu();
            break;
        case "4":
            Environment.Exit(0);
            break;
        default:
            MenuyeDonus();
            break;
    }
}

static void MenuyeDonus(string mesaj="Menüye dönmek için ENTER.")
{
    Console.WriteLine(mesaj);
    Console.ReadLine();
    Menu();
}
static void KasaDurumu()
{
    UygulamaServisi servis = new UygulamaServisi();
    var bakiye = servis.KasaBakiyesi();
    var liste = servis.KasaListesi();
    Console.WriteLine("Tarih \t\t\tTutar\t\tAçıklama");
    foreach(var k in liste)
        Console.WriteLine($"{k._tarih.ToShortDateString()}\t\t{k._tutar}\t\t{k._aciklama}");

    Console.WriteLine("Güncel Kasa Bakiyesi : " + bakiye);
    MenuyeDonus();

}
static void UrunEkle()
{
    throw new NotImplementedException();
}
static void UrunSat()
{
    throw new NotImplementedException();
}




static string CevapAl(string ekranMetni,bool ayniSatirdaMi = true)
{
    if (ayniSatirdaMi)
        Console.Write(ekranMetni);
    else
        Console.WriteLine(ekranMetni);

    return Console.ReadLine();
}