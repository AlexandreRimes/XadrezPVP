using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xadrez
{
    public partial class Xadrez : Form
    {
        public Xadrez()
        {
            InitializeComponent();
        }
        List<Point>posicoes = new List<Point>();//Matriz

        public List<PictureBox>listaPic = new List<PictureBox>();
        List<Peças>listaPecas = new List<Peças>();
        List<Armas> armas = new List<Armas>();
        public char turno = 'b';
        bool vezBrancas=true;

        public PictureBox peçaClicada = new PictureBox();
        
        bool cliquei = false;

       
        private void atribuiPosição()
        {
            peãoB1.Location = posicoes[48]; peãoB2.Location = posicoes[49];
            peãoB3.Location = posicoes[50]; peãoB4.Location = posicoes[51];
            peãoB5.Location = posicoes[52]; peãoB6.Location = posicoes[53];
            peãoB7.Location = posicoes[54]; peãoB8.Location = posicoes[55];
            torreB1.Location = posicoes[56]; torreB2.Location = posicoes[63];
            cavaloB1.Location = posicoes[57]; cavaloB2.Location = posicoes[62];
            bispoB1.Location = posicoes[58]; bispoB2.Location = posicoes[61];
            rainhaB.Location = posicoes[59]; reiB.Location = posicoes[60];
            
            listaPic.Add(peãoB1); listaPic.Add(peãoB3);
            listaPic.Add(peãoB5); listaPic.Add(peãoB7);
            listaPic.Add(peãoB2); listaPic.Add(peãoB4);
            listaPic.Add(peãoB6); listaPic.Add(peãoB8);
            listaPic.Add(torreB1); listaPic.Add(torreB2);
            listaPic.Add(cavaloB1); listaPic.Add(cavaloB2);
            listaPic.Add(bispoB1); listaPic.Add(bispoB2);
            listaPic.Add(rainhaB); listaPic.Add(reiB);

            //peças pretas
            peãoP1.Location = posicoes[8]; peãoP2.Location = posicoes[9];
            peãoP3.Location = posicoes[10]; peãoP4.Location = posicoes[11];
            peãoP5.Location = posicoes[12]; peãoP6.Location = posicoes[13];
            peãoP7.Location = posicoes[14]; peãoP8.Location = posicoes[15];
            torreP1.Location = posicoes[0]; torreP2.Location = posicoes[7];
            cavaloP1.Location = posicoes[1]; cavaloP2.Location = posicoes[6];
            bispoP1.Location = posicoes[2]; bispoP2.Location = posicoes[5];
            rainhaP.Location = posicoes[3]; reiP.Location = posicoes[4];
            
                listaPic.Add(peãoP1); listaPic.Add(peãoP3);
                listaPic.Add(peãoP5); listaPic.Add(peãoP7);
                listaPic.Add(peãoP2); listaPic.Add(peãoP4);
                listaPic.Add(peãoP6); listaPic.Add(peãoP8);
                listaPic.Add(torreP1); listaPic.Add(torreP2);
                listaPic.Add(cavaloP1); listaPic.Add(cavaloP2);
                listaPic.Add(bispoP1); listaPic.Add(bispoP2);
                listaPic.Add(rainhaP); listaPic.Add(reiP);
            
        }
        private void Xadrez_Load(object sender, EventArgs e)
        {

            posicoes.AddRange(new Point[]
            {
           /*0-7*/ new Point(202, 26), new Point(281, 26), new Point(360, 26), new Point(441, 26),new Point(521, 26), new Point(602, 26), new Point(682, 26), new Point(762, 26),
           /*8-15*/new Point(202, 100), new Point(281, 100), new Point(360, 100), new Point(441, 100),new Point(521, 100), new Point(602, 100), new Point(682, 100), new Point(762, 100),
           /*16-23*/new Point(202, 173), new Point(281, 173), new Point(360, 173), new Point(441, 173),new Point(521, 173), new Point(602, 173), new Point(682, 173), new Point(762, 173),
           /*24-31*/new Point(202, 246), new Point(281, 246), new Point(360, 246), new Point(441, 246),new Point(521, 246), new Point(602, 246), new Point(682, 246), new Point(762, 246),
           /*32-39*/new Point(202, 319), new Point(281, 319), new Point(360, 319), new Point(441, 319),new Point(521, 319), new Point(602, 319), new Point(682, 319), new Point(762, 319),
           /*40-47*/new Point(202, 394), new Point(281, 394), new Point(360, 394), new Point(441, 394),new Point(521, 394), new Point(602, 394), new Point(682, 394), new Point(762, 394),
           /*48-55*/new Point(202, 468), new Point(281, 468), new Point(360, 468), new Point(441, 468),new Point(521, 468), new Point(602, 468), new Point(682, 468), new Point(762, 468),
           /*56-63*/new Point(202, 541), new Point(281, 541), new Point(360, 541), new Point(441, 541),new Point(521, 541), new Point(602, 541), new Point(682, 541), new Point(762, 541)

            });

            atribuiPosição();
            
            Armas arma1 = new Armas();
            Armas arma2 = new Armas();
            Armas arma3 = new Armas(); 
            Armas arma4 = new Armas();
            Armas arma5 = new Armas();
            Armas arma6 = new Armas();

            //peão
            arma1.nome = "espadaFraca";
            arma1.dano = 2;
            arma1.imgArma = Properties.Resources.Tabuleiro;
            arma1.velocidade = 0.7;
            //bispo
            arma2.nome = "espadaMedia";
            arma2.dano = 3;
            arma2.imgArma = Properties.Resources.Tabuleiro;
            arma2.velocidade = 0.5;
            //cavalo
            arma3.nome = "espadaForte";
            arma3.dano = 3;
            arma3.imgArma = Properties.Resources.Tabuleiro;
            arma3.velocidade = 0.5;
            //torre
            arma4.nome = "pistolaMedia";
            arma4.dano = 4;
            arma4.imgArma = Properties.Resources.Tabuleiro;
            arma4.velocidade = 0.5;
            //rainha
            arma5.nome = "pistolaForte";
            arma5.dano = 6;
            arma5.imgArma = Properties.Resources.Tabuleiro;
            arma5.velocidade = 0.2;
            //rei
            arma6.nome = "canhao";
            arma6.dano = 999;
            arma6.imgArma = Properties.Resources.Tabuleiro;
            arma6.velocidade = 0.5;

            armas.AddRange(new Armas[] { arma1, arma2, arma3, arma4, arma5, arma6});




            for (int i = 0; i < listaPic.Count; i++)
            {
                Peças a = new Peças(this);  
                a.nomePeça = listaPic[i].Name;
                a.peçaLocation = listaPic[i].Location;
                a.imgPeça = listaPic[i];
                a.posições = posicoes;
                a.arma = AtribuiArmas(a.nomePeça);
                listaPecas.Add(a);
                a.peçasCriadas = listaPecas;
                a.form = this;
                
            }
            


        }
        private Armas AtribuiArmas(string nome)
        {
            nome = nome.ToLower();
            
            if (nome[0] == 'p')
            {
                return armas[0];
            }
            else if (nome[0] == 'b')
            {
                return armas[1];
            }
            else if(nome[0] == 'c')
            {
                return armas[2];
            }
            else if (nome[0] == 't')
            {
                return armas[3];
            }
            else if((nome[0] == 'r') && nome[1] == 'a')
            {
                return armas[4];
            }
            else
            {
                return armas[5];
            }
        }
        private void Xadrez_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Cursor.Position.Y.ToString() + " - " + Cursor.Position.X.ToString());
        }
        private void torreP1_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(torreP1);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void cavaloP1_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(cavaloP1);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void bispoP1_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(bispoP1);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void rainhaP_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(rainhaP);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void reiP_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(reiP);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void bispoP2_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(bispoP2);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void cavaloP2_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP2);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void torreP2_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(torreP2);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void peãoP8_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP8);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void peãoP7_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP7);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void peãoP6_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP6);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void peãoP5_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP5);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }

        private void peãoP4_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP4);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }
        private void peãoP3_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP3);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }
        private void peãoP2_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP2);
                if (a != null)
                {

                    for (int i = 0; i < a.Count; i++)
                    {


                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }
        private void peãoP1_Click(object sender, EventArgs e)
        {
            if (!vezBrancas)
            {
                List<PictureBox> a = Clique(peãoP1);
                if (a != null)
                {
                    for (int i = 0; i < a.Count; i++)
                    {
                        this.Controls.Remove(a[i]);
                    }
                }
            }
            else { MessageBox.Show("Não é sua vez"); }
        }
        /*---*/
        private void peãoB1_Click(object sender, EventArgs e)
        {
            List<PictureBox> a = Clique(peãoB1);

            if (a != null)
            {

                for (int i = 0; i < a.Count; i++)
                {


                    this.Controls.Remove(a[i]);
                }
            }
        }

        private void peãoB2_Click(object sender, EventArgs e)
        {
            List<PictureBox> a = Clique(peãoB2);

            if (a != null)
            {

                for (int i = 0; i < a.Count; i++)
                {


                    this.Controls.Remove(a[i]);
                }
            }
        }

        private void peãoB4_Click(object sender, EventArgs e)
        {

        }

        private void peãoB5_Click(object sender, EventArgs e)
        {

        }

        private void peãoB6_Click(object sender, EventArgs e)
        {

        }

        private void peãoB7_Click(object sender, EventArgs e)
        {

        }

        private void peãoB8_Click(object sender, EventArgs e)
        {

        }

        private void torreB1_Click(object sender, EventArgs e)
        {

        }

        private void cavaloB1_Click(object sender, EventArgs e)
        {

        }

        private void bispoB1_Click(object sender, EventArgs e)
        {

        }

        private void rainhaB_Click(object sender, EventArgs e)
        {

        }

        private void reiB_Click(object sender, EventArgs e)
        {

        }

        private void bispoB2_Click(object sender, EventArgs e)
        {
            
        }

        private void cavaloB2_Click(object sender, EventArgs e)
        {

        }

        private void torreB2_Click(object sender, EventArgs e)
        {

        }
        List<PictureBox> b = new List<PictureBox>();

        //
        public void AdicionarItemNaListBox(string texto)
        {
            listBox1.Items.Add(texto);
            if (texto.ToLower() == "p" || texto.ToLower() == null || texto == "")
            {
                vezBrancas = true;
            }
            else { vezBrancas = false; }

        }
        //
        public void OlhaUltimaJogada(ListBox a)
        {
        
        }

        public List<PictureBox> Clique(PictureBox a)
        {
    
            if (!cliquei)
            {   
                cliquei = true;
                if (b != null) {b.Clear();}
                
                    for (int i = 0; i < listaPecas.Count; i++)
                    {
                        if (listaPecas[i].nomePeça == a.Name)
                        {
                            // Movimentos padrão
                            b = listaPecas[i].Jogar(a.Name);
                           
                            
                        
                            if (b != null)
                            {
                                for (int j = 0; j < b.Count; j++)
                                {
                                    this.Controls.Add(b[j]);
                                }

                            }
                        }
                    }

                return null;
                
            }
            else if (cliquei) 
            {
                
                cliquei =false;
                return b;
            }
            else return null;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(label1.Text);
            a += 0.01;
            label1.Text = Convert.ToString(a);
            
        }

        



        /*public PictureBox Colide()
        {
            for(int i = 0; i < posicoes.Count; i++)
            {
                if (Cursor.Position.X -34 < (posicoes[i].X + 79) && Cursor.Position.X-34 > posicoes[i].X)
                {
                    if(Cursor.Position.Y-57  < (posicoes[i].Y + 74) && Cursor.Position.Y-57 > posicoes[i].Y)
                    {
                        return AnalisaPosicoes(posicoes[i]);
                        
                    }
                }
                
                
            }return null;
            
        }*/
        /*public PictureBox AnalisaPosicoes(Point posicao)
        {
            
            for (int i = 0; i < listaPecas.Count; i++)
            {
                if (posicao.Y == listaPecas[i].peçaLocation.Y && posicao.Y == listaPecas[i].peçaLocation.Y)
                {
                    string mensagem = listaPecas[i].nomePeça;
                    listBox1.Items.Add(mensagem);
                    MessageBox.Show(Cursor.Position.Y.ToString()+Cursor.Position.X.ToString());
                    break;
                }
                
            }
            return null;
        }*/

        private void Xadrez_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_ControlAdded(object sender, ControlEventArgs e)
        {
            MessageBox.Show("oi");
            if (listBox1.Items[listBox1.Items.Count].ToString().ToLower()=="p" || listBox1.Items[listBox1.Items.Count].ToString().ToLower() == null || listBox1.Items[listBox1.Items.Count].ToString().ToLower() == "")
            {
                vezBrancas = true;
            }
        }
    }

}
/*using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste_de_2
{
    public partial class Form1 : Form
    {
        private HashSet<Keys> pressedKeys = new HashSet<Keys>();
        private Timer gameLoopTimer;

        public bool wasd = false;
        public bool setas = false;
        Keys keys1;
        Keys keys2;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            // Configurar o timer para o loop do jogo
            gameLoopTimer = new Timer
            {
                Interval = 1 
            };
            gameLoopTimer.Tick += GameLoop;
            gameLoopTimer.Start();

            // Adicionar os eventos de teclado
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            pressedKeys.Add(e.KeyCode);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            pressedKeys.Remove(e.KeyCode);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Movimento do jogador 1 (WASD)
            if (pressedKeys.Contains(Keys.W))
                pictureBox1.Top -= 5;
            if (pressedKeys.Contains(Keys.S))
                pictureBox1.Top += 5;
            if (pressedKeys.Contains(Keys.A))
                pictureBox1.Left -= 5;
            if (pressedKeys.Contains(Keys.D))
                pictureBox1.Left += 5;

            // Movimento do jogador 2 (Setas)
            if (pressedKeys.Contains(Keys.Up))
                pictureBox2.Top -= 5;
            if (pressedKeys.Contains(Keys.Down))
                pictureBox2.Top += 5;
            if (pressedKeys.Contains(Keys.Left))
                pictureBox2.Left -= 5;
            if (pressedKeys.Contains(Keys.Right))
                pictureBox2.Left += 5;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }
    }
}*/