using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Module12_interfaceGraphique
{
    public partial class EcranImage : Form
    {

        private const string filtresFichiers = "Images (*.jpeg) |*.jpeg|Tous les fichiers (*.*)|*.*";
        private string m_nomImageCourante;

        public EcranImage()
        {
            InitializeComponent();
        }

        private void EcranImage_Load(object sender, EventArgs e)
        {
            // Il ne les voit pas...
            comboBox1.Items.AddRange(UtilitaireTraitements.RechercherTraitementsImage().ToArray());
        }

        private void tsmOuvrir_Click(object sender, EventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.AddExtension = true;
            ofd.Filter = filtresFichiers;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.m_nomImageCourante = ofd.FileName;
                ImageManipulable image = new ImageManipulable(m_nomImageCourante);
            }


        }

        private void tsmFichierOuvrir(object sender, EventArgs e)
        {
            // Enregistrer et etc
        }

      

        private void AfficherImageCourante(ImageManipulable p_image)
        {
            try
            {
                pictureBox1.Image = p_image.Image;
            }
            catch (Exception)
            {

                throw;
            }
          
        }


        private void DeplacementFleche(int p_index)
        {

            int nbTraitement = this.comboBox1.Items.Count;
            if (this.comboBox1.SelectedIndex + p_index > nbTraitement + 1)
            {
                this.comboBox1.SelectedIndex = 0;
            }
            if (this.comboBox1.SelectedIndex + p_index < 0)
            {
                this.comboBox1.SelectedIndex = nbTraitement;
            }
            else
            {
                this.comboBox1.SelectedIndex = this.comboBox1.SelectedIndex + p_index;
            }
        }

        private void btnhaut_Click(object sender, EventArgs e)
        {
            int index = 1;
            DeplacementFleche(index);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = 1;
            DeplacementFleche(index);
        }
    }
}
