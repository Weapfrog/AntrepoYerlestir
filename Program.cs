using System.Collections;


string AntrepoYerlestir(string depoDurum, string[] gelenVagonlar)
            {
                Console.WriteLine("Başlangıçtaki depo durumu:" + depoDurum);
                char[] depoDurumChar = depoDurum.ToCharArray();

                //depo durumu tek tek incelenebilmek adına dizi haline getiriliyor.


                for(int vagonlar = 0; vagonlar < gelenVagonlar.Length;vagonlar++)
                {
                    char[] gelenVagonChar = gelenVagonlar[vagonlar].ToCharArray(); // vagonlar teker teker incelenmek üzere alınıyor.

                    for (int i = gelenVagonChar.Length - 1; i >= 0; i--) // vagon dizisinde gezinebilmek için for döngüsü oluşturuluyor.
                {
                    var tempVagon = Convert.ToInt32(gelenVagonChar[i] - 48);
                    // ascii tablosunda char '0' = 48 olduğu için 48 çıkartıp ekleyerek int değeri alınıyor.
                    // rakamların char değerleri integer değerlerinden 48 fazla.
                    while (tempVagon >= 0)
                    {
                        if(tempVagon == 0) // aktif vagonda ürün yok ise diğer vagona geçiliyor.
                        {
                            break;
                        }
                        else 
                        {
                            for (int j = i + 2; j >= 0; j--) // vagonda ürün olduğu için depo dizisinde gezinmek için for döngüsü oluşturuluyor.
                            {
                                var tempDurum = Convert.ToInt32(depoDurumChar[j] - 48);
                                if(tempDurum == -13) // sonsuzluk işareti geldiyse, '#' ascii - 48 == -13
                                {
                                } 
                                else if (tempDurum < 9) // aktif depoda yer varsa
                                {
                                    tempVagon--; // vagondaki ürün sayısı azaltılıyor.
                                    gelenVagonChar[i] = Convert.ToChar(tempVagon + 48); // vagondaki ürün sayısı yenileniyor.
                                    tempDurum++; // depodaki ürün sayısı arttırılıyor.
                                    depoDurumChar[j] = Convert.ToChar(tempDurum + 48); // depodaki ürün sayısı yenileniyor.
                                    break;
                                }
                                else if (tempDurum == 9) // depo ürün alamayacak kadar doldu ise
                                {
                                    tempDurum = 0; // otomatik boşaltma sistemi başlatılıyor.
                                    depoDurumChar[j] = Convert.ToChar(tempDurum + 48); // aktif depodaki ürün sayısı 0 a indirgeniyor.
                                }
                            }
                        }
                    }
                }
                }
                string sonDepoDurumu = new string(depoDurumChar);
                return sonDepoDurumu;
            }
    string depoDurumu = "0#54134427902231984111412732221";
    string[] gelenVagonlar= {"10808313931813319430761116496","93876532983858416774152932536"};
    Console.WriteLine(AntrepoYerlestir(depoDurumu,gelenVagonlar));