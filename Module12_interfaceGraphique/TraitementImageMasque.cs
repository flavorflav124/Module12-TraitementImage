using System;
using System.Collections.Generic;
using System.Text;

namespace Module12_interfaceGraphique
{
    public abstract class TraitementImageMasque : ITraitementImage
    {
        public ITraitementImage Suivant { get; set; }

        public int Largeur { get; set; }  // Ajouter precondition

        public Func<byte[], byte> Transformation { get; set; }



        public TraitementImageMasque(Func<byte[], byte> p_transformation)
        {
            this.Largeur = 3;
            this.Transformation = p_transformation;
        }




        public void TraiterImage(ImageManipulable p_image)
        {
            byte[] raw = p_image.Raw;
            byte[] res = new byte[raw.Length];
            int width = p_image.Width;
            int height = p_image.Height;

            byte[] donneesCourantes = new byte[this.Largeur * this.Largeur];
            for (int colonne = 0; colonne < width; colonne++)
            {
                for (int ligne = 0; ligne < height; ligne++)
                {
                    for (int composante = 0; composante < 3; composante++)
                    {
                        int posDonneesCourantes = 0;
                        for (int masqueX = -this.Largeur / 2; masqueX <= this.Largeur / 2; masqueX++)
                        {
                            int posX = Math.Min(Math.Max(0, colonne + masqueX), width - 1);
                            for (int masqueY = -this.Largeur / 2; masqueY <= this.Largeur / 2; masqueY++)
                            {
                                int posY = Math.Min(Math.Max(0, ligne + masqueY), height - 1);
                                donneesCourantes[posDonneesCourantes] = raw[(posY * width + posX) * 3 + composante];

                                ++posDonneesCourantes;
                            }
                        }
                        res[(ligne * width + colonne) * 3 + composante] = this.Transformation(donneesCourantes);
                    }
                }
            }

            Array.Copy(res, raw, raw.Length);
        }


       
    }
}
