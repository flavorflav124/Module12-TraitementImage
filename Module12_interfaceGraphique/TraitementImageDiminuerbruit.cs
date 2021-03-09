using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Module12_interfaceGraphique
{
    [Description("Diminuer bruit")]
    public class TraitementImageDiminuerbruit : TraitementImageMasque
    {
        public TraitementImageDiminuerbruit(Func<byte[], byte> p_transformation) : base(p_transformation)
        {
            ;
        }

        private static byte TraiterDonnees(byte[] p_donnees)
        {
            Array.Sort(p_donnees);

            return p_donnees[p_donnees.Length / 2];
        }


        public override string ToString()
        {
            return "Traitement du bruit de l<image";
        }

    }
}
