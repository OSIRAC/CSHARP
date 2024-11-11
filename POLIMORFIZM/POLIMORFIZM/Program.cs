using System;
using System.Reflection;

namespace POLIMORFIZM
{

    class Program
    {
        static void Main(string[] args)
        { 
            // İLK HAYVANIN CONSTRUCTORU ÇALIŞIR SONR AKEDİNİN ÇÜNKÜ KEDİ NESNESİ ÜRETİYORUZ VE KALITIM VAR SADECE ERİŞTİĞİMİZ YER FİLTRELENDİ
            HAYVAN hayvan = new KEDİGİLLER(15);  // POLİMORFİZM OLMASI İÇİN KALITIM ŞARTTIR
            // BURDA BİR KEDİ HAYVAN MIDIR DİYE SORU SORUYORUZ EVET

            hayvan.Ad = "ÇİTA";  // AMA BURADA SADECE REFERANS TÜRÜ NEYSE ONA ERİŞEBİLİRZ BİİZM O BİR NEVİ ANAHTARIMIZDIR HAYVAN CLASSININ ÖZELLİKLERİ GELİR SADECE BURDA

            KEDİGİLLER kedigiller = new KEDİGİLLER(10);
            kedigiller.Pençe_Sayisi = 15;
            kedigiller.AVLA();  // BURDA NAMEHİDİNG GİBİ ÜSTTEKİ GÖRÜLMEZ AMA
            hayvan.AVLA();      // AMA BURDA HAYVANA BAKAR NAME HİDİNG OLSAYDI ALTTA BİLE İKİ FARKLI FONKSİYON OLDUĞUNDNA VE SADECE BURADA SINIRLI OLDUĞUNDNA BURADAKİNİ ALIRDI
                                // AMA OVERRİDE DA BURADA SINIRLI OLSA DA BU METHOD OVERRİDE YANİ YENİDEN YAZILMIŞ DEMEK BURDAKİNİ DEĞİL ALTTAKİNİ GEÇERLİ SAYAR BUNA DİNAMİC POLİMORFİZM DENİR POLİMORFİZM + OVERRİDE
                                // AMA OVERRİDE OLMASI İÇİN İLLA POLİMORFİZME GEREK YOKTUR
                                // STAİC POLİMORFİZM DE OVERLOADİNGDİR
                                // OVERRİDE FARKININ ORATAYA ÇIKMASI İÇİN POLİMORFİZM LAZIMDIR AMA YOKSA NAMEHİDİNG GİBİ OLUR

            HAYVAN hayvan1 = kedigiller;  // UPCASTİNG OTOMATİK YAPILIR
            hayvan1.AVLA();

            KEDİGİLLER kedigiler1 = (KEDİGİLLER)hayvan;  // DOWNCASTİNG ELLE YAPILMALI CAST İŞLEMİ VE HİYERAŞİK YAPILAR ARASINDA OLUR BU İŞLEM
            kedigiler1.AVLA();

             HAYVAN hayvan2 = new ASLAN(4);
            KEDİGİLLER kedigiller2 = (KEDİGİLLER)(hayvan2);  // REFERANS TÜRÜ İLE NESNE TÜRÜ ARASINDA Kİ ŞEYLERE DÖNÜŞÜM YAPABİLİRZ
            HAYVAN hayvan3 = new KEDİGİLLER(4);

            // ASLAN aslan = (ASLAN)hayvan3; BU GEÇERLİ OLMAZ ÇÜNKÜ ASLAN aslan = new KEDİGİLLER(4) E DÖNÜŞÜR BU DA KALITIMA AYKIRIDIR

            if(hayvan3 is HAYVAN)
            {
                Console.WriteLine("EVET hayvan3 bir HAYVAN dır");
            }  // İS OPERATÖRÜ REFERANSIN GÖSTERDİĞİ NESNEYE BAKAR  HAYVAN3 KEDİGİLLERE AİT AYNI ZAMANDA BİR HAYVANDA
        }
    }

    class HAYVAN
    {

        public HAYVAN(int a)  
        {
            Console.WriteLine($"A NIN DEĞERİ : {a}");
        }

         virtual public void AVLA()
        {
            Console.WriteLine("HAYVAN AVLADIM");
        }

        public string? Ad { get; set; }

        public int Yas { get; set; }
    }

    class KEDİGİLLER : HAYVAN
    {
        public KEDİGİLLER(int b) : base(b)
        {
            Console.WriteLine($"B NIN DEĞERİ : {b}");
        }

        public  override void AVLA()
        {
            Console.WriteLine("KEDİ AVLADIM");
        }
        public string? Kürk_Rengi { get; set; }

        public int Pençe_Sayisi { get; set; }
    }

    class ASLAN : KEDİGİLLER
    {
        public ASLAN(int c) : base(c)
        {
            
        }
        public int Güç { get; set; }
    }
}
