using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Assignment_3
{

    public partial class Assignment3 : Form
    {
        int[] hand = new int[5];
        List<int> deck = new List<int>();
        private const string FILE_PATH = @"C:\Users\ryanh\source\repos\Assignment#3\Assignment#3\Hands\";


        public Assignment3()
        {
            InitializeComponent();
        }

        public void BuildDeck()
        {
            deck.Clear();
            for (int i = 0; i < imglstDeck.Images.Count; i++)
            {
                deck.Add(i);
            }
            deck.Shuffle();

        }


        private int DealCard()
        {
            int cardDealt = deck[0];
            deck.RemoveAt(0);
            return cardDealt;
        }

        public bool IsAnyKeepChecked()
        {


            if (chkKeep1.Checked)
            {
                return true;
            }
            if (chkKeep2.Checked)
            {
                return true;
            }
            if (chkKeep3.Checked)
            {
                return true;
            }
            if (chkKeep4.Checked)
            {
                return true;
            }
            if (chkKeep5.Checked)
            {
                return true;
            }

            return false;

        }

        public void DealHand()
        {

            // if any keeps do not shuffle

            if (!IsAnyKeepChecked())
                BuildDeck();





            //if any checkboxes are checked return true. if not any check box checked, rebuild deck




            // if checked k
            if (chkKeep1.Checked == false)
            {
                hand[0] = DealCard();
            }
            if (chkKeep2.Checked == false)
            {
                hand[1] = DealCard();
            }
            if (chkKeep3.Checked == false)
            {
                hand[2] = DealCard();
            }
            if (chkKeep4.Checked == false)
            {
                hand[3] = DealCard();
            }
            if (chkKeep5.Checked == false)
            {
                hand[4] = DealCard();
            }



            PictureBoxes();
        }

        public void PictureBoxes()
        {
            if (hand[0] <= -1 || hand[0] > 52)
            {
                picCard1.Image = null;
            }
            else
            {
                picCard1.Image = imglstDeck.Images[hand[0]];
            }


            if (hand[1] <= -1 || hand[1] > 52)
            {
                picCard2.Image = null;
            }
            else
            {
                picCard2.Image = imglstDeck.Images[hand[1]];
            }


            if (hand[2] <= -1 || hand[2] > 52)
            {
                picCard3.Image = null;
            }
            else
            {
                picCard3.Image = imglstDeck.Images[hand[2]];
            }


            if (hand[3] <= -1 || hand[3] > 52)
            {
                picCard4.Image = null;
            }
            else
            {
                picCard4.Image = imglstDeck.Images[hand[3]];
            }


            if (hand[4] <= -1 || hand[4] > 52)
            {
                picCard5.Image = null;
            }
            else
            {
                picCard5.Image = imglstDeck.Images[hand[4]];
            }
        }


        private void btnDeal_Click(object sender, EventArgs e)
        {


            DealHand();

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileName;
            saveFileHand.InitialDirectory = FILE_PATH;
            if (saveFileHand.ShowDialog() == DialogResult.OK)
            {

                fileName = saveFileHand.FileName;
                SaveFile(fileName);


            }
        }

        private void SaveFile(string fileName)
        {
            using StreamWriter writer = new(fileName);
            foreach (int i in hand)
            {
                writer.WriteLine(i);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            string fileName;
            openFileHand.InitialDirectory = FILE_PATH;
            if (openFileHand.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileHand.FileName;
                LoadFile(fileName);
            }
            else
            {
                MessageBox.Show("Load cancelled.");
            }

        }
        private void LoadFile(string fileName)
        {
            using StreamReader reader = new StreamReader(fileName);
            string? line = string.Empty;
            for (int l = 0; l < 5; l++)
            {
                line = reader.ReadLine();
                if (line != null)
                {
                    hand[l] = int.Parse(line);
                }
            }

            PictureBoxes();

        }


        private void chkKeep1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkKeep2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkKeep3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkKeep4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkKeep5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void picCard3_Click(object sender, EventArgs e)
        {
            chkKeep3.Checked = !chkKeep3.Checked;
        }

        private void picCard1_Click(object sender, EventArgs e)
        {
            //also checks the checkbox
            chkKeep1.Checked = !chkKeep1.Checked;
        }

        private void Assignment3_Load(object sender, EventArgs e)
        {
            DealHand();
            saveFileHand.InitialDirectory = FILE_PATH;
            openFileHand.InitialDirectory = FILE_PATH;
        }

        private void picCard1_Click_1(object sender, EventArgs e)
        {
            chkKeep1.Checked = !chkKeep1.Checked;
        }

        private void picCard2_Click(object sender, EventArgs e)
        {
            chkKeep2.Checked = !chkKeep2.Checked;
        }

        private void picCard4_Click(object sender, EventArgs e)
        {
            chkKeep4.Checked = !chkKeep4.Checked;
        }

        private void picCard5_Click(object sender, EventArgs e)
        {
            chkKeep5.Checked = !chkKeep5.Checked;
        }
    }
    public static class myExtension
    {
        private static Random rng = new Random();

        public static void Shuffle(this IList<int> deck)
        {

            int n = deck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                int value = deck[k];
                deck[k] = deck[n];
                deck[n] = value;
            }
        }

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
