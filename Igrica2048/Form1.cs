using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

namespace Igrica2048
{
     public partial class Form1 : Form
     {
          Random Rd = new Random();
          bool igrajPonovo = true;
          static ArrayList niz1 = new ArrayList();

          private Label[,] Igrica;

          public Form1()
          {
               InitializeComponent();

               Igrica = new Label[,]
               {
                    {label1,label2,label3,label4},
                    {label5,label6,label7,label8},
                    {label9,label10,label11,label12},
                    {label13,label14,label15,label16}
               };
          }

          public void podesavanjaBoje(Label[,] Igrica)
          {//ovom metodom se postavlja boja teksta i pozadine labela, odnosno matrice
              
               for (int i = 0; i < 4; i++)
               {
                    for (int j = 0; j < 4; j++)
                    {

                         if (Igrica[i, j].Text == "")
                         {
                              Igrica[i, j].BackColor = Color.LightBlue;
                         }
                         if (Igrica[i, j].Text == "2")
                         {
                              Igrica[i, j].BackColor = Color.DarkGray;
                              Igrica[i, j].ForeColor = Color.White;

                         }
                         if (Igrica[i, j].Text == "4")
                         {
                              Igrica[i, j].BackColor = Color.Gray;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "8")
                         {
                              Igrica[i, j].BackColor = Color.Orange;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "16")
                         {
                              Igrica[i, j].BackColor = Color.OrangeRed;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "32")
                         {
                              Igrica[i, j].BackColor = Color.DarkOrange;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "64")
                         {
                              Igrica[i, j].BackColor = Color.LightPink;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "128")
                         {
                              Igrica[i, j].BackColor = Color.Red;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "256")
                         {
                              Igrica[i, j].BackColor = Color.DarkRed;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "512")
                         {
                              Igrica[i, j].BackColor = Color.LightBlue;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "1024")
                         {
                              Igrica[i, j].BackColor = Color.Blue;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                         if (Igrica[i, j].Text == "2048")
                         {
                              Igrica[i, j].BackColor = Color.Green;
                              Igrica[i, j].ForeColor = Color.White;
                         }
                    }
               }

          }

          private void generisanjeBrojeva(Label[,] Igrica)
          {
               niz1.Clear();
               for (int i = 0; i < 4; i++)
               {
                    for (int j = 0; j < 4; j++)
                    {
                         if (Igrica[i, j].Text == "")
                         {
                              niz1.Add(i * 4 + j + 1);//u niz1 se dodaju brojevi od 1 do 16, pošto ima toliko kombinacija, tj. 4x4
                         }
                    }
               }

               if (niz1.Count > 0)
               {
                    //postavljamo da se brojevi 2 i 4 ispišu na random poljima prilikom pokretanja igre
                    int randomPolje = int.Parse(niz1[Rd.Next(0, niz1.Count - 1)].ToString());//bira se random broj iz niz1
                    int i0 = (randomPolje - 1) / 4;
                    int j0 = (randomPolje - 1) - i0 * 4;
                    int niz2 = Rd.Next(1, 10);//u niz2 se nasumično dodeljuje broj od 1 do 10
                    //ako je broj koji je dodeljen u niz2 od 1 do 6 onda se ispisuje dvojka u random polje
                    if (niz2 == 1 || niz2 == 2 || niz2 == 3 || niz2 == 4 || niz2 == 5 || niz2 == 6)
                    {
                         Igrica[i0, j0].Text = "2";
                    }//ako se u niz2 ispiše neki drugi broj, onda se u polje upisuje broj 4
                    else
                    {
                         Igrica[i0, j0].Text = "4";
                    }

               }
               podesavanjaBoje(Igrica);
          }

          
          //šta se dešava prilikom prvog pokretanja igrice
          private void Form1_Load(object sender, EventArgs e)
          {
               generisanjeBrojeva(Igrica);
               generisanjeBrojeva(Igrica);
               generisanjeBrojeva(Igrica);
          }

          

          public bool proveraPoteza(Label[,] Igrica) //proverava da li je moguće pomeranje gore, dole, levo ili desno
          {
               for (int i = 0; i < 4; i++)
               {
                    for (int j = 0; j < 4; j++)
                    {
                         if (Igrica[i, j].Text == "")
                         {
                              return false;//ako postoji neko prazno polje, znači da je moguće pomeranje
                         }
                         for (int k = j + 1; k < 4; k++)
                         {
                              if (Igrica[i, j].Text != "")//ako polje nije prazno, proveravamo polje iznad njega
                              {
                                   if (Igrica[i, j].Text == Igrica[i, k].Text)
                                   {
                                        return false;//vraća false ako je moguće pomeranje na gore ili na dole
                                   }
                                   break;
                              }
                         }
                    }
               }
               for (int i = 0; i < 4; i++)
               {
                    for (int j = 0; j < 4; j++)
                    {
                         if (Igrica[j, i].Text == "")
                         {
                              return false;
                         }
                         for (int k = j + 1; k < 4; k++)
                         {
                              if (Igrica[k, i].Text != "")//ako nije prazno polje
                              {
                                   if (Igrica[j, i].Text == Igrica[k, i].Text)//ako je brojčana vrednost [k,i] jednaka sa [j,i]
                                   {
                                        return false;//vraća false ako je moguće pomeranje levo ili desno
                                   }
                                   break;
                              }
                         }
                    }
               }
               return true;//ako nije moguće pomeranje onda vraća true
          } 



          private void Form1_KeyDown(object sender, KeyEventArgs e)
          {
               if (proveraPoteza(Igrica) == false)//ova metoda treba da vrati vrednost 0 (false) da bismo mogli da koristimo strelice gore,dole,levo,desno
               {
                    if (e.KeyCode == Keys.Up) //kada se pritisne strelica na gore
                    {
                         Potezi.PotezNaGore(Igrica, lblScore, () => generisanjeBrojeva(Igrica));//poziva se ova metoda
                    }

                    if (e.KeyCode == Keys.Down)//kada se pritisne strelica na dole
                    {
                         Potezi.PotezNaDole(Igrica, lblScore, () => generisanjeBrojeva(Igrica));//poziva se ova metoda
                    }

                    if (e.KeyCode == Keys.Left)//kada se pritisne strelica u levo
                    {
                         Potezi.PotezULevo(Igrica, lblScore, () => generisanjeBrojeva(Igrica));//poziva se ova metoda
                    }

                    if (e.KeyCode == Keys.Right)//kada se pritisne strelica u desno
                    {
                         Potezi.PotezUDesno(Igrica, lblScore, () => generisanjeBrojeva(Igrica));//poziva se ova metoda
                    }



               }
               else //ako je proveraPoteza() true, tj. ako nije moguć potez ni gore, ni dole, ni levo, ni desno
               {
                    igrajPonovo = false;
                    lblGameOver.Visible = true;
                    btnNewGame.Visible = true;
                    btnExit.Visible = true;
                    btnExit.Enabled = true;
                    btnNewGame.Enabled = true;
                    this.KeyDown -= new KeyEventHandler(this.Form1_KeyDown);
               }

          }


          private void Form1_Pobeda(object sender, EventArgs e)
          {
               for (int i = 0; i < 4; i++)
               {
                    for (int j = 0; j < 4; j++)
                    {
                         if (Igrica[i, j].Text == "16")
                         {
                              igrajPonovo = false;
                              lblCongratulations.Visible = true;
                              btnNewGame.Visible = true;
                              btnExit.Visible = true;
                              btnExit.Enabled = true;
                              btnNewGame.Enabled = true;
                         }

                    }
               }
          }


          private void btnNewGame_Click(object sender, EventArgs e)
          { //ova funkcija se koristi za ponovno pokretanje nakon završetka igre.
               this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
               lblScore.Text = "0";//Score se postavlja na 0 jer se restartuje igra
            
               lblGameOver.Visible = false;//povlači se labela GameOver
               btnExit.Visible = false;//povlači se dugme Exit
               igrajPonovo = true;//dozvoljava se dalja igra, tj. sledeći potez
               btnNewGame.Visible = false;//povlači se dugme New Game
               btnNewGame.Enabled = false;//povlači se dozvola igrača da klikne na New Game
               btnExit.Enabled = false;//povlači se dozvola igrača da klikne na Exit
               for (int i = 0; i < 4; i++)
               {
                    for (int j = 0; j < 4; j++)
                    {
                         Igrica[i, j].Text = "";//postavljaju se prazna polja
                    }
               }
               generisanjeBrojeva(Igrica);
               generisanjeBrojeva(Igrica);
               generisanjeBrojeva(Igrica);//generišu se 3 broja na početku

          }

          private void btnExit_Click(object sender, EventArgs e)
          {
               Application.Exit();//Prilikom klika na dugme Exit, zatvara se program.
          }

          private void newGameToolStripMenuItem_Click(object sender, EventArgs e)//kada se klikne na new game iz menuStrip opcije
          {
               lblScoreText.Visible = true; //tekst "SCORE:" se postavlja da bude vidljiv
               lblScore.Visible = true;//vidljiv je broj poena

               if (igrajPonovo == false)
               {
                    this.KeyDown += new KeyEventHandler(this.Form1_KeyDown);
               }
               igrajPonovo = true;//omogućava se sledeći potez
               lblScore.Text = "0";//score se restartuje
 
               lblGameOver.Visible = false;
               btnExit.Visible = false;
               btnNewGame.Visible = false;
               btnNewGame.Enabled = false;
               btnExit.Enabled = false;
               for (int i = 0; i < 4; i++)
               {
                    for (int j = 0; j < 4; j++)
                    {
                         Igrica[i, j].Visible = true;//vidljiva polja
                         Igrica[i, j].Text = "";//prazna polja
                    }
               }
                    generisanjeBrojeva(Igrica);
                    generisanjeBrojeva(Igrica);
                    generisanjeBrojeva(Igrica);//generišu se 3 broja
               
          }

          private void exitToolStripMenuItem_Click(object sender, EventArgs e)//exit opcija iz menuStrip
          {
               Application.Exit();//zatvara se program
          }

          private void btnNewGame_MouseHover(object sender, EventArgs e)//prelazak mišem preko dugmeta New Game
          {
               btnNewGame.BackColor = Color.Green;//boja dugmeta je zelena kad se pređe preko njega
          }

          private void btnNewGame_MouseLeave(object sender, EventArgs e)
          {
               btnNewGame.BackColor = Color.Orange;//boja dugmeta je narandžasta kada se miš skloni sa dugmeta
          }

          private void btnExit_MouseHover(object sender, EventArgs e)
          {
               btnExit.BackColor = Color.Green;
          }

          private void btnExit_MouseLeave(object sender, EventArgs e)
          {
               btnExit.BackColor = Color.Orange;
          }

          private void gamePlayToolStripMenuItem_Click(object sender, EventArgs e)//klik na "How To Play" iz menuStrip
          {
               MessageBox.Show("Igrica 2048 je slagalica koja podrazumeva " +
                    "klizno pomeranje blokova. Za pomeranje blokova se koriste strelice. " +
                    "Kada se dva bloka sa istim brojem dodirnu, oni se spoje u jedan blok. " +
                    "Cilj igre je da se blokovi pomeraju tako da se dobije broj 2048. ", 
                    "How To Play", MessageBoxButtons.OK, MessageBoxIcon.Information);

          }

          private void informationToolStripMenuItem_Click(object sender, EventArgs e)//klik na "Information" iz menuStrip
          {
               MessageBox.Show("2023 Seminarski rad - Sandra Panic ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


          }

     }
}
