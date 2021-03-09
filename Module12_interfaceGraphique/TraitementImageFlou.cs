using System;
using System.Collections.Generic;
using System.Text;

namespace Module12_interfaceGraphique
{
    public class TraitementImageFlou : TraitementImageMasque
    {
        public TraitementImageFlou(Func<byte[], byte> p_transformation) : base(p_transformation)
        {
            ;
        }

        [System.ComponentModel.Description("Image flou")] 

        private static byte TraiterDonnees(byte[] p_donnees)
        {
            int somme = 0;
            for (int i = 0; i < p_donnees.Length; i++)
            {
                somme += p_donnees[i];
            }

            return (byte)(somme / p_donnees.Length);
        }

        public override string ToString()
        {
            return "Traitement image flou";
        }

    }
}
