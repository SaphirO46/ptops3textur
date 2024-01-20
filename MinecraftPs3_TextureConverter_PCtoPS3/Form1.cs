using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using MinecraftPs3_TextureConverter_PCtoPS3.Object;

namespace MinecraftPs3_TextureConverter_PCtoPS3
{
    public partial class Form1 : Form
    {


        List<Block> blocksList = new List<Block>();

            // Nombre de lignes et de colonnes dans le tableau Excel
            int rows = 34;
            int cols = 16;

            // Taille des blocs dans le tableau Excel
            int blockSize = 16;

        // Liste de noms à utiliser
        List<string> blockNames = new List<string> { "grass_block_top", "stone", "dirt", "grass_block_side", "oak_planks", "stone_slab_side", "stone_slab_top", "bricks", "tnt_side", "tnt_top", "tnt_bottom", "cobweb", "poppy", "XXX", "XXX", "oak_sapling", "cobblestone", "bedrock", "sand", "gravel", "oak_log", "oak_log_top", "iron_block", "gold_block", "diamond_block", "emerald_block", "redstone_block", "dropper_front", "red_mushroom", "brown_mushroom", "jungle_sapling", "XXX", "gold_ore", "iron_ore", "coal_ore", "bookshelf", "mossy_cobblestone", "obsidian", "grass_block_side_overlay", "grass", "dispenser_front_vertical", "beacon", "dropper_front_vertical", "crafting_table_top", "furnace_front", "furnace_side", "dispenser_front", "XXX", "sponge", "glass", "diamond_ore", "redstone_ore", "oak_leaves", "XXX", "stone_bricks", "dead_bush", "fern", "daylight_detector_top", "daylight_detector_side", "crafting_table_side", "crafting_table_front", "furnace_front_on", "furnace_top", "spruce_sapling", "white_wool", "spawner", "snow", "XXX", "grass_block_snow", "cactus_top", "cactus_side", "cactus_bottom", "clay", "sugar_cane", "jukebox_side", "jukebox_top", "lily_pad", "mycelium_side", "mycelium_top", "birch_sapling", "torch", "oak_door_top", "iron_door_top", "ladder", "oak_trapdoor", "iron_bars", "farmland_moist", "farmland", "wheat_stage0", "wheat_stage1", "wheat_stage2", "wheat_stage3", "wheat_stage4", "wheat_stage5", "wheat_stage6", "wheat_stage7", "lever", "oak_door_bottom", "iron_door_bottom", "redstone_torch", "mossy_stone_bricks", "cracked_stone_bricks", "pumpkin_top", "netherrack", "soul_sand", "glowstone", "piston_top_sticky", "piston_top", "piston_side", "piston_bottom", "piston_inner", "melon_stem_disconnected", "rail_corner", "black_wool", "gray_wool", "redstone_torch_off", "spruce_log", "birch_log", "pumpkin_side", "carved_pumpkin", "carved_pumpkin", "cake_top", "cake_side", "cake_inner", "cake_bottom", "red_mushroom_block", "brown_mushroom_block", "attached_pumpkin_stem" };



        public Form1()
        {

            InitializeComponent();
            // Boucle pour générer les coordonnées et créer les objets Block
            int compteTour = 0;
            if (blockNames.Count > 0)
            {
                int nameIndex = 0;
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (blockNames.Count > compteTour ) {
                            
                                int x = col * blockSize;
                                int y = row * blockSize;

                                // Utilise le prochain nom de la liste
                                string currentName = blockNames[nameIndex];
                            
                                Block newBlock = new Block(currentName, x, y);
                            Console.WriteLine(currentName + " / x: " + x + " / y: " + y);
                                blocksList.Add(newBlock);
                            
                                // Incrémente l'index du nom
                                nameIndex = (nameIndex + 1) % blockNames.Count;
                            
                            compteTour++;
                        }
                    }


                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Terrain terrain = new Terrain(blocksList, 256, 544, "MonTerrain");




            string folderPath = "C:/!minecraft-ps3-texturespack/BAREBONE/Bare Bones 1.13-1.14/assets/minecraft/textures/block"; // Remplace cela par le chemin de ton dossier d'images
                string outputImagePath = "C:/!minecraft-ps3-texturespack/BAREBONE/outputTest/out.png"; // Remplace cela par le chemin de l'image de sortie

                terrain.MergeImagesInFolder(folderPath, outputImagePath);

                Console.WriteLine("L'image a été créée avec succès!");
            






        }


    }
}

