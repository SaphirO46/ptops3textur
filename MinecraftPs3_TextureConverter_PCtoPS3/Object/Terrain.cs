using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftPs3_TextureConverter_PCtoPS3.Object
{
    class Terrain
    {
        public List<Block> Blocks { get; set; }
        public int TailleX { get; set; }
        public int TailleY { get; set; }
        public string Nom { get; set; }

        public Terrain(List<Block> blocks, int tailleX, int tailleY, string nom)
        {
            Blocks = blocks;
            TailleX = tailleX;
            TailleY = tailleY;
            Nom = nom;
        }

        // Méthode pour ajouter un bloc au terrain
        public void AjouterBlock(Block nouveauBlock)
        {
            Blocks.Add(nouveauBlock);
        }

        public void DrawImage(string imageName, string[] imagePaths, Graphics g,int x,int y)
        {
            foreach (string imagePath in imagePaths)
            {
                string fileName = Path.GetFileNameWithoutExtension(imagePath);

                if (fileName.Equals(imageName, StringComparison.OrdinalIgnoreCase))
                {

                    using (Image img = Image.FromFile(imagePath))
                    {

                        // Dessiner l'image à la position spécifiée
                        g.DrawImage(img, x, y, img.Width, img.Height);
                    }

                    // Sortir de la boucle une fois que l'image a été trouvée et dessinée
                    break;
                }
            }
        }
        public void MergeImagesInFolder(string folderPath, string outputImagePath)
        {
            string[] imagePaths = Directory.GetFiles(folderPath, "*.png"); // Tu peux ajuster l'extension en fonction de tes besoins

            if (imagePaths.Length == 0)
            {
                Console.WriteLine("Aucune image trouvée dans le dossier.");
                return;
            }

           
            // Créer une nouvelle image de sortie
            using (Bitmap outputImage = new Bitmap(TailleX, TailleY))
            using (Graphics g = Graphics.FromImage(outputImage))
            {
                g.Clear(Color.Transparent);
                using (Image img = Image.FromFile("./image/terrain.png"))
                {
                    // Dessiner l'image à la position spécifiée
                    g.DrawImage(img, 0, 0, img.Width, img.Height);
                }
                foreach (var square in Blocks)
                {
                    DrawImage(square.Nom, imagePaths, g,square.X , square.Y);

                }
                // Enregistrer l'image de sortie
                outputImage.Save(outputImagePath, System.Drawing.Imaging.ImageFormat.Png);
            }
        }
    }
}
