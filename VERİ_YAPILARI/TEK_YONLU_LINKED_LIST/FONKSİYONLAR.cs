using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TEK_YONLU_LINKED_LIST
{
    internal class FONKSİYONLAR
    {
        public NODE HEAD { get; set; }

        public FONKSİYONLAR()
        {
            HEAD = null;
        }

        public void SONA_EKLE(int data)
        {
            NODE eleman = new(data);

            if(HEAD == null)
            {
                HEAD = eleman;
                Console.WriteLine("LİSTE OLUŞTURLUDU İLK DÜĞÜM EKLENDİ");
            }
            else
            {
                NODE temp = HEAD;
                while(temp.next != null) 
                { 
                    temp = temp.next;
                }
                temp.next = eleman;
                Console.WriteLine("LİSTE SONUNA ELEMAN EKLENDİ");
            }
        }
        public void BASA_EKLE(int data)
        {
            NODE eleman = new(data);
            if(HEAD == null)
            {
                HEAD = eleman;
                Console.WriteLine("LİSTE OLUŞTURLUDU İLK DÜĞÜM EKLENDİ");
            }
            else
            {
                eleman.next = HEAD;
                HEAD = eleman;
                Console.WriteLine("LİSTE BAŞINA ELEMAN EKLENDİ");
            }
        }

        public void YAZDİR()
        {
            NODE temp = HEAD;
            if(HEAD == null)
            {
                Console.WriteLine("LİSTE BOŞ");
            }
            else
            {
                Console.Write("BAŞ ->");
                while (temp.next != null)
                {
                    Console.Write(temp.data +"->");
                    temp = temp.next;
                }
                Console.Write(temp.data + "SON ");
            }
        }

        public void BASTAN_SİL()
        {
            if(HEAD == null)
            {
                Console.WriteLine("LİSTE BOŞ");
            }
            else
            {
                HEAD = HEAD.next;
                Console.WriteLine("BAŞTAN ELEMAN SİLİNDİ");
            }

        }

        public void SONDAN_SİL()
        {
            if (HEAD == null)
            {
                Console.WriteLine("LİSTE BOŞ");
            }
            else if(HEAD.next == null)
            {
                HEAD = null;
                Console.WriteLine("LİSTEDE KALAN SON DÜĞÜM SİLİNDİ");
            }
            else
            {
                NODE temp = HEAD;
                NODE temp2 = temp;
                while (temp.next != null)
                {
                    temp2 = temp;     // TEMP2 SONDNA Bİ ÖNCEKİ OLUR
                    temp = temp.next; // SON DÜĞÜM TUTULUR
                }
                temp2.next = null;
                Console.WriteLine("SON DÜĞÜM SİLİNDİ");
            }

        }

        public void ARAYA_EKLE(int indis, int data)
        {
            NODE eleman = new NODE(data);
            bool sonuc = false;
            if (HEAD == null && indis == 1)
            {
                HEAD = eleman;
                Console.WriteLine("EKLEME YAPILID");
                sonuc = true;
            }
            else if (HEAD.next == null || indis ==1)
            {
                BASA_EKLE(data);
                sonuc = true;
            }
            else
            {
                int i = 1;
                NODE temp = HEAD;
                NODE temp1 = temp;
                while (temp1.next != null)
                {
                    if(i ==indis)
                    {
                        sonuc = true;
                        temp1.next = eleman;
                        eleman.next = temp ;
                        Console.WriteLine("ARAYA EKLENDİ");
                        i++;
                        break;
                    }
                    temp1 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    sonuc = true;
                    temp1.next = eleman;
                    eleman.next = null;
                    Console.WriteLine("ARAYA EKLENDİ");            
                }

            }
            if(sonuc == false)
            {
                Console.WriteLine("HATALI İNDİS SEÇİMİ");
            }
        }

        public void ARADAN_SİL(int indis)
        {
            bool sonuc = false;
            if(HEAD == null)
            {
                Console.WriteLine("LİSTE BOŞ");
                sonuc = true;
            }
            else if(HEAD.next == null || indis ==1)
            {
                BASTAN_SİL();
                sonuc = true;
            }
            else
            {
                int i = 1;
                NODE temp = HEAD;
                NODE temp1 = temp;
                while(temp.next != null)
                {
                    if(i ==indis)
                    {
                        sonuc = true;
                        temp = temp.next;
                        Console.WriteLine("SİLİNDİ");
                        i++;
                        break;
                    }
                    temp1 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    SONDAN_SİL();
                    sonuc = true;
                }
            }
            if(sonuc == false)
            {
                Console.WriteLine("YANLI SEÇENEK");
            }



        }
    }
}
