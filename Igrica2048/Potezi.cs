using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Igrica2048
{
     public static class Potezi
     {
          public static void PotezNaGore(Label[,] Igrica, Label lblScore, Action generisanjeBrojeva)
          {
               bool noviBroj = false;
               //za svako polje u tabeli
               for (int i = 0; i < 4; i++)
               {
                    int praznoPolje = 0;
                    for (int j = 0; j < 4; j++)
                    {
                         
                         if (Igrica[j, i].Text == "")
                         {
                              praznoPolje++;//ako je polje prazno, promenljiva praznoPolje se povećava na 1
                         }
                         else //ako polje ima neku vrednost
                         {
                              for (int m = j; m >= 0; m--) //proverava se polje ispod
                              {
                                   if (Igrica[m, i].Text == "") //ako je prazno
                                   {
                                        noviBroj = true; //noviBroj je true, poziva se metoda generisanjeBrojeva
                                        break;
                                   }
                              }
                              if (j + 1 < 4) //ako postoji polje iznad
                              {
                                   bool postojiPolje = true;

                                   for (int k = j + 1; k < 4; k++) //za polje iznad
                                   {
                                        if (Igrica[k, i].Text != "") //ako nije prazno
                                        {
                                             if (Igrica[j, i].Text == Igrica[k, i].Text)//proverava se da li su isti brojevi u poljima
                                             {
                                                  lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Igrica[j, i].Text) * 2).ToString();//izračunava se score i dodaje u lblScore

                                                  noviBroj = true; //nov broj je true
                                                  postojiPolje = false;//da bi posle moglo ponovo da se proveri
                                                  Igrica[j, i].Text = (int.Parse(Igrica[j, i].Text) * 2).ToString();//vrednost u polju se duplira jer smo spojili 2 polja
                                                  if (praznoPolje != 0) //ako je polje bilo prazno
                                                  {//potezom na gore, polje ispod tog praznog polja dobija njegovu praznu vrednost
                                                       Igrica[j - praznoPolje, i].Text = Igrica[j, i].Text; //u polje ispod [j,i] se postavlja vrednost polja [j,i] jer smo uradili potez na gore
                                                       Igrica[j, i].Text = ""; //polje [j,i] se postavlja da bude prazno jer se desilo pomeranje na gore

                                                  }
                                                  Igrica[k, i].Text = ""; //polje [k,i] se postavlja da bude prazno

                                                  break; 

                                             }
                                             break; 
                                        }
                                   }

                                   if (postojiPolje == true && praznoPolje != 0)
                                   {
                                        Igrica[j - praznoPolje, i].Text = Igrica[j, i].Text;
                                        Igrica[j, i].Text = "";

                                   }
                              }
                              else
                              {
                                   if (praznoPolje != 0) //ako postoji prazno polje
                                   {
                                        Igrica[j - praznoPolje, i].Text = Igrica[j, i].Text;
                                        Igrica[j, i].Text = "";

                                   }
                              }


                         }
                    }
               }


               if (noviBroj == true) //ako postoji novi broj
               {
                    generisanjeBrojeva(); //pozivamo metodu koja generiše da se stvori još dvojki ili četvorki
               }

          }



          public static void PotezNaDole(Label[,] Igrica, Label lblScore, Action generisanjeBrojeva)
          {
               bool noviBroj = false;
               //za svako polje u tabeli
               for (int i = 0; i < 4; i++)
               {
                    int praznoPolje = 0;
                    for (int j = 3; j >= 0; j--)
                    {
                         
                         if (Igrica[j, i].Text == "")
                         {
                              praznoPolje++;//ako je polje prazno
                         }
                         else //ako polje ima neku vrednost
                         {
                              for (int m = j + 1; m <= 3; m++)//proverava se polje ispod
                              {
                                   if (Igrica[m, i].Text == "")//ako je prazno
                                   {
                                        noviBroj = true;//generiše se novi broj
                                        break;
                                   }
                              }
                              if (j - 1 >= 0)//ako postoji polje ispod
                              {
                                   bool postojiPolje = true;

                                   for (int k = j - 1; k >= 0; k--)//za polje ispod
                                   {
                                        if (Igrica[k, i].Text != "")//ako nije prazno
                                        {
                                             if (Igrica[j, i].Text == Igrica[k, i].Text)//ako su jednaki
                                             {
                                                  lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Igrica[j, i].Text) * 2).ToString();

                                                  noviBroj = true;
                                                  postojiPolje = false;//da bi posle moglo ponovo da se proveri
                                                  Igrica[j, i].Text = (int.Parse(Igrica[j, i].Text) * 2).ToString();//potezom na dole, duplira se vrednost u polju jer smo ih spojili
                                                  if (praznoPolje != 0)//ako je polje bilo prazno
                                                  {//potezom na dole, polje iznad tog polja dobija praznu vrednost
                                                       Igrica[j + praznoPolje, i].Text = Igrica[j, i].Text;
                                                       Igrica[j, i].Text = "";

                                                  }
                                                  Igrica[k, i].Text = "";
                                                  break;

                                             }
                                             break;
                                        }
                                   }
                                   if (postojiPolje == true && praznoPolje != 0)
                                   {
                                        Igrica[j + praznoPolje, i].Text = Igrica[j, i].Text;
                                        Igrica[j, i].Text = "";

                                   }
                              }
                              else
                              {
                                   if (praznoPolje != 0)
                                   {
                                        Igrica[j + praznoPolje, i].Text = Igrica[j, i].Text;
                                        Igrica[j, i].Text = "";

                                   }
                              }


                         }
                    }
               }


               if (noviBroj == true)
               {
                    generisanjeBrojeva();
               }
          }



          public static void PotezULevo(Label[,] Igrica, Label lblScore, Action generisanjeBrojeva)
          {
               bool noviBroj = false;
               //za svako polje u tabeli
               for (int i = 0; i < 4; i++)
               {
                    int praznoPolje = 0;
                    for (int j = 0; j < 4; j++)
                    {


                         if (Igrica[i, j].Text == "")
                         {
                              praznoPolje++;//ako je prazno polje
                         }
                         else//ako polje ima neku vrednost
                         {
                              for (int m = j - 1; m >= 0; m--)//proverava se polje s leve strane
                              {
                                   if (Igrica[i, m].Text == "")//ako je prazno
                                   {
                                        noviBroj = true;//generiše se novi broj
                                        break;
                                   }
                              }
                              if (j + 1 < 4)//ako postoji polje levo
                              {
                                   bool postojiPolje = true;

                                   for (int k = j + 1; k < 4; k++)//za to polje levo
                                   {
                                        if (Igrica[i, k].Text != "")//ako nije prazno
                                        {

                                             if (Igrica[i, j].Text == Igrica[i, k].Text)//ako su jednaka polja
                                             {
                                                  lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Igrica[i, j].Text) * 2).ToString();

                                                  noviBroj = true;
                                                  postojiPolje = false;//da bi moglo ponovo da se proveri
                                                  Igrica[i, j].Text = (int.Parse(Igrica[i, j].Text) * 2).ToString();//vrednost u polju se duplira jer smo ih spojili
                                                  if (praznoPolje != 0)//ako je polje bilo prazno
                                                  {//potezom u levo, polje s leve strane postaje prazno
                                                       Igrica[i, j - praznoPolje].Text = Igrica[i, j].Text;
                                                       Igrica[i, j].Text = "";

                                                  }
                                                  Igrica[i, k].Text = "";
                                                  break;

                                             }
                                             break;
                                        }
                                   }
                                   if (postojiPolje == true && praznoPolje != 0)
                                   {
                                        Igrica[i, j - praznoPolje].Text = Igrica[i, j].Text;
                                        Igrica[i, j].Text = "";

                                   }
                              }
                              else
                              {
                                   if (praznoPolje != 0)
                                   {
                                        Igrica[i, j - praznoPolje].Text = Igrica[i, j].Text;
                                        Igrica[i, j].Text = "";

                                   }
                              }


                         }
                    }
               }


               if (noviBroj == true)
               {
                    generisanjeBrojeva();
               }
          }



          public static void PotezUDesno(Label[,] Igrica, Label lblScore, Action generisanjeBrojeva)
          {
               bool noviBroj = false;
               //za svako polje u tabeli
               for (int i = 0; i < 4; i++)
               {
                    int praznoPolje = 0;
                    for (int j = 3; j >= 0; j--)
                    {
                         
                         if (Igrica[i, j].Text == "")
                         {
                              praznoPolje++;//ako je polje prazno
                         }
                         else//ako polje nije prazno
                         {
                              for (int m = j + 1; m < 4; m++)//proverava se polje s desne strane
                              {
                                   if (Igrica[i, m].Text == "")//ako je to polje prazno
                                   {
                                        noviBroj = true;//generiše se novi broj
                                        break;
                                   }
                              }
                              if (j - 1 >= 0)//ako postoji polje s desne strane
                              {
                                   bool postojiPolje = true;

                                   for (int k = j - 1; k >= 0; k--)//za polje s desne strane
                                   {
                                        if (Igrica[i, k].Text != "")//ako nije prazno
                                        {


                                             if (Igrica[i, j].Text == Igrica[i, k].Text)//ako su jednaka polja
                                             {
                                                  lblScore.Text = (int.Parse(lblScore.Text) + int.Parse(Igrica[i, j].Text) * 2).ToString();

                                                  noviBroj = true;
                                                  postojiPolje = false;
                                                  Igrica[i, j].Text = (int.Parse(Igrica[i, j].Text) * 2).ToString();//duplira se vrednost u polju jer su spojena
                                                  if (praznoPolje != 0)//ako je polje bilo prazno
                                                  {//potezom u desno, polje s desne strane postaje prazno
                                                       Igrica[i, j + praznoPolje].Text = Igrica[i, j].Text;
                                                       Igrica[i, j].Text = "";

                                                  }
                                                  Igrica[i, k].Text = "";
                                                  break;

                                             }
                                             break;
                                        }
                                   }
                                   if (postojiPolje == true && praznoPolje != 0)
                                   {
                                        Igrica[i, j + praznoPolje].Text = Igrica[i, j].Text;
                                        Igrica[i, j].Text = "";

                                   }
                              }
                              else
                              {
                                   if (praznoPolje != 0)
                                   {
                                        Igrica[i, j + praznoPolje].Text = Igrica[i, j].Text;
                                        Igrica[i, j].Text = "";

                                   }
                              }
                         }
                    }
               }


               if (noviBroj == true)
               {
                    generisanjeBrojeva();
               }
          }
     }
}
