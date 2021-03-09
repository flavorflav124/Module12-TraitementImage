using System;
using System.Collections.Generic;
using System.Text;

namespace Module12_interfaceGraphique
{
    public interface ITraitementImage
    {
        public ITraitementImage Suivant { get; set; }
        public void TraiterImage(ImageManipulable p_image);
    }
}
