﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class LinkedListEgitim:ListADT
    {
        public Node dugum;
        public override void InsertFirst(object value)
        {
            Node tempHead = new Node() { Data = value };

            if (Head == null) //ilk düğüm null ise (yani liste boşsa) heade ekle
            {
                Head = tempHead;
            }
            else 
            {
                //head'i head'in next'i yap ve yeni head'i eklenecek düğüm yap
                tempHead.Next = Head; 
                Head = tempHead;
            }
            Size++;
        }


        public override void DeletePos(object Position)
        {
            if (Head != null)
            {
                Node temp = Head;

                Node posPreNode = new Node();
                posPreNode = Head;

                if (((Egitim)temp.Data).OkulAdi == ((Egitim)Position).OkulAdi) //Silinecek düğüm head ise head'i bir sonraki düğüm yap
                {
                    Head = temp.Next;
                }
                while (temp != null) //silinecek değer bulunana kadar (okul adı ile kontrol edilecek) listede ilerle
                {
                    if (((Egitim)temp.Data).OkulAdi == ((Egitim)Position).OkulAdi) //silinecek değer bulunduğunda silinecek değerin next'ini bi önceki değerin next'i yap böylece listede artık temp'i gösteren eleman kalmadı ve silme işlemi gerçekleşti
                        posPreNode.Next = temp.Next;
                    else 
                        posPreNode = temp;

                    temp = temp.Next;
                }
                Size--;
            }
        }

        public override string DisplayElements()
        {
            string temp = "";
            Node i = Head;
            while (i != null) //Liste null olana kadar listedeki iş bilgilerini temp'e ekle ve ilerle
            {  
                temp += "İş adı : " + ((IsDeneyimi)i.Data).IsAd.ToString() + Environment.NewLine + "Görevi : " + ((IsDeneyimi)i.Data).Gorev.ToString() + Environment.NewLine + "İşyeri adresi : " + ((IsDeneyimi)i.Data).IsAdres.ToString();
                i = i.Next;
            }
            return temp;
        }

        public bool DoksanUzeriNot()
        {
            Boolean doksanUzerimi = false;
            Node temp = Head; //bakılacak kişinin Head düğümünde itibaren(ilk eğitim bilgisinden itibaren) tüm düğümleri kontrol edilecek
            if (temp == null) //bakılacak eğitim bilgisi kalmadıysa veya hiç eğitim bilgisi eklenmediyse doksan üzerinde notu yoktur. false döndür.
                doksanUzerimi = false; 
            else if (((Egitim)temp.Data).NotOrtalamasi > 90) //doksan üzerinde notu var true döndür.
                doksanUzerimi = true;
            else //null da değil doksan üzerinde notuda yok listede ilerle
                temp = temp.Next;
            return doksanUzerimi;
        }
    }
}
