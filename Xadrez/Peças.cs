using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xadrez
{
    public class Armas
    {
        public string nome;
        public int dano;
        public Image imgArma;
        public double velocidade;
    }

    internal class Peças
    {
        public List<Point> posições = new List<Point>();//Matriz
        public List<Peças> peçasCriadas = new List<Peças>();//peças criadas

        public PictureBox imgPeça;
        public string nomePeça;
        public Point peçaLocation;
        public Armas arma;
        public Form form;


        List<PictureBox> a = new List<PictureBox>();
        public List<PictureBox> Jogar(string nomePeça)
        {

            //a.Clear();
            if (nomePeça.ToLower()[0] == 'p'){ return Peão();}

            
            return null;
        }


        Xadrez _xadrez;
        public  Peças(Xadrez form)
        {
            _xadrez = form;
        }

        public void AdicionarNaListBox(string a)
        {
            _xadrez.AdicionarItemNaListBox(a);
        }

        private void MudaPosição_Click(object sender, EventArgs e)
        {
            string tipo;
            
            PictureBox clickedPictureBox = sender as PictureBox;
            if (clickedPictureBox != null)
            {
                
                for (int i = 0; i<clickedPictureBox.Name.Count(); i++)
                {
                    if(i == clickedPictureBox.Name.Count() - 2)
                    {
                        if (clickedPictureBox.Name[i].ToString().ToLower() == "p") { tipo = "p"; AdicionarNaListBox(tipo); }
                        else { tipo = "b"; AdicionarNaListBox(tipo); }
                        
                        tipo = null;
                        
                    }
                }
                // Atualizar a posição da peça
                
                this.imgPeça.Location = clickedPictureBox.Location;
                this.peçaLocation = clickedPictureBox.Location;

                // Remover o PictureBox de indicação
                clickedPictureBox.Parent.Controls.Remove(clickedPictureBox);
                
                clickedPictureBox.Dispose();
                for (int i = 0;i<a.Count;i++)
                {
                    RemoverPictureBox(a[i],form);
                }
            }

        }
        public void RemoverPictureBox(PictureBox pictureBox, Form form)
        {
            if (form.Controls.Contains(pictureBox))
            {
                form.Controls.Remove(pictureBox);
                pictureBox.Dispose();
            }
        }
        public List<PictureBox> Peão()
        {
            a.Clear();
            if (this.nomePeça.ToLower()[this.nomePeça.Count() - 2] == 'p')
            {

                try
                {
                    for (int i = 0; i < posições.Count; i++)
                    {

                        if (posições[i] == this.peçaLocation)
                        {


                            PictureBox pictureBox = new PictureBox
                            {
                                Name = this.nomePeça,
                                Width = this.imgPeça.Width,
                                Height = this.imgPeça.Height,
                                BorderStyle = BorderStyle.FixedSingle,
                                Location = posições[i + 8], // Próxima posição
                                SizeMode = PictureBoxSizeMode.StretchImage, // Ajusta a imagem à área
                                BackColor = Color.Transparent,
                                Image = Properties.Resources.Movimento,


                            };



                            for (int j = 0; j < this.peçasCriadas.Count; j++)
                            {
                                if (this.peçasCriadas[j].peçaLocation == posições[i + 9])
                                {
                                    PictureBox pic = new PictureBox
                                    {
                                        Name = this.nomePeça,
                                        Width = this.imgPeça.Width,
                                        Height = this.imgPeça.Height,
                                        Location = posições[i + 9], // Próxima posição
                                        BorderStyle = BorderStyle.FixedSingle,
                                        SizeMode = PictureBoxSizeMode.StretchImage, // Ajusta a imagem à área
                                        BackColor = Color.Transparent,
                                        Image = Properties.Resources.Movimento
                                    };
                                    peçasCriadas[j].imgPeça.Location = new Point(99, 99);
                                    a.Add(pic);
                                    pic.Click += MudaPosição_Click;
                                }
                                if (this.peçasCriadas[j].peçaLocation == posições[i + 7])
                                {
                                    PictureBox pic = new PictureBox
                                    {
                                        Name = this.nomePeça,
                                        Width = this.imgPeça.Width,
                                        Height = this.imgPeça.Height,
                                        Location = posições[i + 7], // Próxima posição
                                        BorderStyle = BorderStyle.FixedSingle,
                                        SizeMode = PictureBoxSizeMode.StretchImage, // Ajusta a imagem à área
                                        BackColor = Color.Transparent,
                                        Image = Properties.Resources.Movimento
                                    };
                                    pic.Click += MudaPosição_Click;
                                    a.Add(pic);

                                }
                            }

                            pictureBox.Click += MudaPosição_Click;
                            a.Add(pictureBox);


                            return a;
                        }

                    }
                }
                catch (Exception e)
                {

                }
            }
            else 
            {
                try
                {
                    for (int i = 0; i < posições.Count; i++)
                    {

                        if (posições[i] == this.peçaLocation)
                        {


                            PictureBox pictureBox = new PictureBox
                            {
                                Name = this.nomePeça,
                                Width = this.imgPeça.Width,
                                Height = this.imgPeça.Height,
                                BorderStyle = BorderStyle.FixedSingle,
                                Location = posições[i - 8], // Próxima posição
                                SizeMode = PictureBoxSizeMode.StretchImage, // Ajusta a imagem à área
                                BackColor = Color.Transparent,
                                Image = Properties.Resources.Movimento,


                            };



                            for (int j = 0; j < this.peçasCriadas.Count; j++)
                            {
                                if (this.peçasCriadas[j].peçaLocation == posições[i - 9] && !estaNaPonta(this))
                                {
                                    PictureBox pic = new PictureBox
                                    {
                                        Name = this.nomePeça,
                                        Width = this.imgPeça.Width,
                                        Height = this.imgPeça.Height,
                                        Location = posições[i - 9], // Próxima posição
                                        BorderStyle = BorderStyle.FixedSingle,
                                        SizeMode = PictureBoxSizeMode.StretchImage, // Ajusta a imagem à área
                                        BackColor = Color.Transparent,
                                        Image = Properties.Resources.Movimento
                                    };
                                    peçasCriadas[j].imgPeça.Location = new Point(99,99);
                                    a.Add(pic);
                                    pic.Click += MudaPosição_Click;
                                }
                                if (this.peçasCriadas[j].peçaLocation == posições[i - 7] )
                                {
                                    PictureBox pic = new PictureBox
                                    {
                                        Name = this.nomePeça,
                                        Width = this.imgPeça.Width,
                                        Height = this.imgPeça.Height,
                                        Location = posições[i - 7], // Próxima posição
                                        BorderStyle = BorderStyle.FixedSingle,
                                        SizeMode = PictureBoxSizeMode.StretchImage, // Ajusta a imagem à área
                                        BackColor = Color.Transparent,
                                        Image = Properties.Resources.Movimento
                                    };
                                    pic.Click += MudaPosição_Click;
                                    peçasCriadas[j].imgPeça.Location = new Point(99, 99);
                                    a.Add(pic);

                                }
                            }

                            pictureBox.Click += MudaPosição_Click;
                            a.Add(pictureBox);


                            return a;
                        }

                    }
                }
                catch (Exception e)
                {

                }
            }
            return null;

        }

        public bool estaNaPonta(Peças peça)
        {
            if(peça.peçaLocation.X == 202 || peça.peçaLocation.X == 762)
            {
            return true;
            }
            else { return false; }
            
        }

    }
    //all the rainz in soho abvsklçjv
}
