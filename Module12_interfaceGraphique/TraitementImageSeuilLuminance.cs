using System;
using System.Collections.Generic;
using System.Text;

namespace Module12_interfaceGraphique
{
    public class TraitementImageSeuilLuminance : ITraitementImage
    {
        public ITraitementImage Suivant { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Seuil { get; set; }
        public string Description { get { return $"Traitement de la luminence de l'image"; } }

      


        public void TraiterImage(ImageManipulable p_image)
        {
            byte[] raw = p_image.Raw;
            for (int longueur = 0; longueur < raw.Length / 3; longueur++)
            {
                int l3 = longueur * 3;
                byte luminance = (byte)((raw[l3] + raw[l3 + 1] + raw[l3 + 2]) / 3);
                byte valeur = 0;
                if (luminance > this.Seuil)
                {
                    valeur = 255;
                }
                raw[l3] = valeur;
                raw[l3 + 1] = valeur;
                raw[l3 + 2] = valeur;
            }

            this.Suivant?.TraiterImage(p_image);
        }

        public override string ToString()
        {
            return Description;
        }
    }
}
