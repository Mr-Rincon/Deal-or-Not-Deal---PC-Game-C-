using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DialOrNoDeal
{
    public partial class frmPlay : Form
    {
        private int[] boxesValue = new int[20] { 10, 1, 5, 15, 50, 100, 250, 500, 750, 1000, 3000, 5000, 10000, 15000, 20000, 35000, 50000, 75000, 100000, 250000 };
        public int noSelected = 0;
        public int callDealer = 0;
        public frmPlay()
        {
            InitializeComponent();
        }

        //Events that happend when the form LOAD.
        private void frmPlay_Load(object sender, EventArgs e)
        {
            tableBoxes.Enabled = false;
        }

        //********************START METHODS*********************

        //Move first box picked from table to the pickedBox area.
        public void moveBox(string number, Button shuffledButton, Bitmap Nueva)
        {
            //Check if there is any box alrady picked up.
            noSelected++;

            btnPickedBox.Visible = true;

            //Creating a new button with the number selected.
            //Button button = new Button();
            shuffledButton.Visible = false; //Disapeard the button from the table.

            //New characteristics of the button moved.
            btnPickedBox.Name = "button" + noSelected.ToString();
            btnPickedBox.Text = number;
            btnPickedBox.Image = Nueva;
            btnPickedBox.Size = new Size(107, 110);
            btnPickedBox.BackColor = System.Drawing.Color.Transparent;
            btnPickedBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            btnPickedBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            btnPickedBox.FlatAppearance.BorderSize = 0;
            btnPickedBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            btnPickedBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnPickedBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnPickedBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;


            btnPickedBox.Enabled = false;

            lblAreYouReady.Location = new System.Drawing.Point(280, 560);
            lblAreYouReady.Text = "It's time to play, open your first box.";
        }

        //SWAP boxes from table to the invisible button.
        public void moveLastBox1(string number, Bitmap Nueva)
        {
            //New characteristics of the button moved.
            btnWait.Name = "button" + noSelected.ToString();
            btnWait.Text = number;
            btnWait.Image = Nueva;
            btnWait.Size = new Size(107, 110);
            btnWait.BackColor = System.Drawing.Color.Transparent;
            btnWait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            btnWait.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            btnWait.FlatAppearance.BorderSize = 0;
            btnWait.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            btnWait.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnWait.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnWait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }

        public void moveLastBox3(string number, Bitmap Nueva)
        {
            //New characteristics of the button moved.
            btnPickedBox.Name = "button" + noSelected.ToString();
            btnPickedBox.Text = number;
            btnPickedBox.Image = Nueva;
            btnPickedBox.Size = new Size(107, 110);
            btnPickedBox.BackColor = System.Drawing.Color.Transparent;
            btnPickedBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            btnPickedBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            btnPickedBox.FlatAppearance.BorderSize = 0;
            btnPickedBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            btnPickedBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnPickedBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnPickedBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        }

        //OPEN the box and show the value.
        public void openBox(Button btnBox, string number)
        {
            callDealer++;
            noSelected++;

            Bitmap imagene = new Bitmap(Application.StartupPath + @"\img\boxes\openBox.png");
            btnBox.Image = imagene;

            btnBox.Text = number;
            btnBox.Size = new Size(107, 110);
            btnBox.BackColor = System.Drawing.Color.Transparent;
            btnBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            btnBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption;
            btnBox.FlatAppearance.BorderSize = 0;
            btnBox.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            btnBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            btnBox.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            btnBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btnBox.ForeColor = System.Drawing.Color.Black;
            btnBox.Enabled = false;

            lblAreYouReady.Location = new System.Drawing.Point(420, 580);
            lblAreYouReady.Text = "Good job, Keep going!";

            //BANKER Calls.
            if ((callDealer == 5) || (callDealer == 8) || (callDealer == 11) || (callDealer == 14) || (callDealer == 17))
            {
                tableBoxes.Enabled = false;

                lblAreYouReady.Location = new System.Drawing.Point(290, 590);
                lblAreYouReady.Text = "OH! The banker is calling.";

                picNoelEdmonds.Visible = false;
                picPhone.Visible = true;
                btnAnswer.Visible = true;
            }

            if (noSelected == 19)
            {
                btnSwap.Visible = true;
                btnKeep.Visible = true;
                tableBoxes.Enabled = false;

                lblWinner.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.00F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                lblWinner.Visible = true;
                lblWinner.Location = new System.Drawing.Point(305, 475);
                lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblWinner.BringToFront();
                lblWinner.Text = "Would you like to SWAP your box?";

                lblAreYouReady.Location = new System.Drawing.Point(550, 580);
                lblAreYouReady.Text = "OR";
            }
        }

        //Shuffe all the values from the array among the boxes on the table.
        public void btnSuffle()
        {
            //lblTarget.Text = "";//Message on the bottom of the screen.
            int[] shuffleValues = FisherYates(boxesValue);

            //Assing suffled numbers to buttons.
            btnBox1.Text = "£" + shuffleValues[0].ToString();
            btnBox2.Text = "£" + shuffleValues[1].ToString();
            btnBox3.Text = "£" + shuffleValues[2].ToString();
            btnBox4.Text = "£" + shuffleValues[3].ToString();
            btnBox5.Text = "£" + shuffleValues[4].ToString();
            btnBox6.Text = "£" + shuffleValues[5].ToString();
            btnBox7.Text = "£" + shuffleValues[6].ToString();
            btnBox8.Text = "£" + shuffleValues[7].ToString();
            btnBox9.Text = "£" + shuffleValues[8].ToString();
            btnBox10.Text = "£" + shuffleValues[9].ToString();
            btnBox11.Text = "£" + shuffleValues[10].ToString();
            btnBox12.Text = "£" + shuffleValues[11].ToString();
            btnBox13.Text = "£" + shuffleValues[12].ToString();
            btnBox14.Text = "£" + shuffleValues[13].ToString();
            btnBox15.Text = "£" + shuffleValues[14].ToString();
            btnBox16.Text = "£" + shuffleValues[15].ToString();
            btnBox17.Text = "£" + shuffleValues[16].ToString();
            btnBox18.Text = "£" + shuffleValues[17].ToString();
            btnBox19.Text = "£" + shuffleValues[18].ToString();
            btnBox20.Text = "£" + shuffleValues[19].ToString();
        }

        //Move randomly all the values of the boxes.
        private int[] FisherYates(int[] array)
        {
            Random r = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int index = r.Next(i);
                int temp = array[index]; //Swap
                array[index] = array[i];
                array[i] = temp;
            }

            return array;
        }

        //Get random number and display on the banker's offer.
        private string randomNumber()
        {
            Random r = new Random();
            var number = r.Next(500, 8000);

            string formattedNumber = number.ToString("0,000");

            return formattedNumber;
        }


        //*************FINISH METHODS************



        //********************START EVENTS*********************
        private void btnBox1_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox1.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox1, number);
            }
        }

        private void btnBox2_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox2.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox2, number);
            }
        }

        private void btnBox3_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox3.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox3, number);
            }
        }

        private void btnBox4_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox4.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox4, number);
            }
        }

        private void btnBox5_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox5.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox5, number);
            }
        }

        private void btnBox6_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox6.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox6, number);
            }
        }

        private void btnBox7_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox7.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox7, number);
            }
        }

        private void btnBox8_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox8.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox8, number);
            }
        }

        private void btnBox9_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox9.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox9, number);
            }
        }

        private void btnBox10_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox10.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox10, number);
            }
        }

        private void btnBox11_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox11.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox11, number);
            }
        }

        private void btnBox12_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox12.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox12, number);
            }
        }

        private void btnBox13_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox13.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox13, number);
            }
        }

        private void btnBox14_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox14.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox14, number);
            }
        }

        private void btnBox15_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox15.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox15, number);
            }
        }

        private void btnBox16_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox16.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox16, number);
            }
        }

        private void btnBox17_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox17.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox17, number);
            }
        }

        private void btnBox18_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox18.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox18, number);
            }
        }

        private void btnBox19_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox19.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox19, number);
            }
        }

        private void btnBox20_Click(object sender, EventArgs e)
        {
            Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox20.png");

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            if (noSelected == 0)
            {
                moveBox(number, shuffledButton, imagen);
            }
            else
            {
                openBox(btnBox20, number);
            }
        }


        // are you ready YES button.
        private void btnYes_Click(object sender, EventArgs e)
        {
            btnSuffle();

            lblAreYouReady.Location = new System.Drawing.Point(466, 560);
            lblAreYouReady.Text = "Choose your box!!";
            btnYes.Visible = false;
            btnNo.Visible = false;
            tableBoxes.Enabled = true;
        }

        // are you ready NO button.
        private void btnNo_Click(object sender, EventArgs e)
        {
            frmIntro frm = new frmIntro();
            frm.Show();

            this.Close();
        }

        //ANSWER Button Event.
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            picBanker.Visible = true;
            btnAnswer.Visible = false;
            picPhone.Visible = false;
            btnDeal.Visible = true;
            btnNoDeal.Visible = true;
            lblBankerOffer.Visible = true;

            lblAreYouReady.Location = new System.Drawing.Point(350, 560);
            lblAreYouReady.Text = "Banker's offer is: ";

            lblBankerOffer.Location = new System.Drawing.Point(650, 550);
            //Random number for the offer of the banker.

            lblBankerOffer.Text = "£" + randomNumber();
        }

        private void btnNoDeal_Click(object sender, EventArgs e)
        {
            tableBoxes.Enabled = true;

            picNoelEdmonds.Visible = true;
            picBanker.Visible = false;
            btnDeal.Visible = false;
            btnNoDeal.Visible = false;
            lblBankerOffer.Visible = false;

            lblAreYouReady.Location = new System.Drawing.Point(380, 560);
            lblAreYouReady.Text = "Your decision, keep going!!";
        }

        private void btnDeal_Click(object sender, EventArgs e)
        {
            btnDeal.Visible = false;
            btnNoDeal.Visible = false;
            lblBankerOffer.Visible = false;

            lblWinner.Visible = true;
            lblWinner.Location = new System.Drawing.Point(365, 150);
            lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblWinner.Text = "Box sold for:\r\n" + lblBankerOffer.Text;

            lblAreYouReady.Location = new System.Drawing.Point(250, 560);
            lblAreYouReady.Text = "Open your box to see what you had there.";

            btnPickedBox.Enabled = true;
        }

        private void btnPickedBox_Click(object sender, EventArgs e)
        {
            Bitmap imagene = new Bitmap(Application.StartupPath + @"\img\boxes\openBox.png");
            btnPickedBox.Image = imagene;

            Button shuffledButton = (Button)sender;
            string number = shuffledButton.Text; //Add button text

            openBox(btnPickedBox, number);

            lblAreYouReady.Location = new System.Drawing.Point(495, 560);
            lblAreYouReady.Text = "GAME OVER";

            //If in case of opening the box at the very end.
            if (noSelected > 19)
            {
                lblWinner.Visible = true;
                lblWinner.Location = new System.Drawing.Point(465, 150);
                lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblWinner.Text = "YOU HAVE EARN!!\r\n" + number;
            }

            //IF in case of the offer from the banker is accepted.
            if (noSelected < 19)
            {
                lblWinner.Visible = true;
                lblWinner.Location = new System.Drawing.Point(265, 150);
                lblWinner.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                lblWinner.Text = "YOU HAVE EARN!!\r\n" + lblBankerOffer.Text;
            }

            btnExit.Visible = true;
        }

        private void btnKeep_Click(object sender, EventArgs e)
        {
            tableBoxes.Enabled = true;
            btnKeep.Visible = false;
            btnSwap.Visible = false;
            lblWinner.Visible = false;
            btnPickedBox.Enabled = true;

            lblAreYouReady.Location = new System.Drawing.Point(215, 580);
            lblAreYouReady.Text = "Open the boxes to see how much you WON!!";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            frmIntro frm = new frmIntro();
            frm.Show();

            this.Close();
        }
        
        private void btnSwap_Click(object sender, EventArgs e)
        {
            btnKeep.Visible = false;
            btnSwap.Visible = false;
            lblWinner.Visible = false;
            lblAreYouReady.Visible = false;
            tableBoxes.Enabled = true;

            if (btnBox1.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox1.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox1.Text;
                moveLastBox3(number, imagen);

                btnBox1.Text = btnWait.Text;
                btnBox1.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox2.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox2.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox2.Text;
                moveLastBox3(number, imagen);

                btnBox2.Text = btnWait.Text;
                btnBox2.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox3.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox3.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox3.Text;
                moveLastBox3(number, imagen);

                btnBox3.Text = btnWait.Text;
                btnBox3.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox4.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox4.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox4.Text;
                moveLastBox3(number, imagen);

                btnBox4.Text = btnWait.Text;
                btnBox4.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox5.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox5.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox5.Text;
                moveLastBox3(number, imagen);

                btnBox5.Text = btnWait.Text;
                btnBox5.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox6.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox6.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox6.Text;
                moveLastBox3(number, imagen);

                btnBox6.Text = btnWait.Text;
                btnBox6.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox7.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox7.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox7.Text;
                moveLastBox3(number, imagen);

                btnBox7.Text = btnWait.Text;
                btnBox7.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox8.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox8.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox8.Text;
                moveLastBox3(number, imagen);

                btnBox8.Text = btnWait.Text;
                btnBox8.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox9.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox9.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox9.Text;
                moveLastBox3(number, imagen);

                btnBox9.Text = btnWait.Text;
                btnBox9.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox10.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox10.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox10.Text;
                moveLastBox3(number, imagen);

                btnBox10.Text = btnWait.Text;
                btnBox10.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox11.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox11.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox11.Text;
                moveLastBox3(number, imagen);

                btnBox11.Text = btnWait.Text;
                btnBox11.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox12.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox12.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox12.Text;
                moveLastBox3(number, imagen);

                btnBox12.Text = btnWait.Text;
                btnBox12.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox13.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox13.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox13.Text;
                moveLastBox3(number, imagen);

                btnBox13.Text = btnWait.Text;
                btnBox13.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox14.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox14.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox14.Text;
                moveLastBox3(number, imagen);

                btnBox14.Text = btnWait.Text;
                btnBox14.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox15.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox15.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox15.Text;
                moveLastBox3(number, imagen);

                btnBox15.Text = btnWait.Text;
                btnBox15.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox16.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox16.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox16.Text;
                moveLastBox3(number, imagen);

                btnBox16.Text = btnWait.Text;
                btnBox16.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox17.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox17.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox17.Text;
                moveLastBox3(number, imagen);

                btnBox17.Text = btnWait.Text;
                btnBox17.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox18.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox18.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox18.Text;
                moveLastBox3(number, imagen);

                btnBox18.Text = btnWait.Text;
                btnBox18.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox19.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox19.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox19.Text;
                moveLastBox3(number, imagen);

                btnBox19.Text = btnWait.Text;
                btnBox19.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }

            if (btnBox20.Enabled == true)
            {
                Bitmap imagen = new Bitmap(Application.StartupPath + @"\img\boxes\closeBox20.png");
                Bitmap holdedImagen = new Bitmap(btnPickedBox.Image);

                Button btnNuevo = new Button();

                string numberHoldedBox = btnPickedBox.Text;
                moveLastBox1(numberHoldedBox, holdedImagen);

                string number = btnBox20.Text;
                moveLastBox3(number, imagen);

                btnBox20.Text = btnWait.Text;
                btnBox20.Image = btnWait.Image;

                btnPickedBox.Enabled = true;
            }


            lblAreYouReady.Location = new System.Drawing.Point(215, 580);
            lblAreYouReady.Text = "Open the boxes to see how much you WON!!";

        }




        //********************FINISH EVENTS*********************

    }
}
