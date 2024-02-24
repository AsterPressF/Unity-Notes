
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private bool recordNextClickCreate = false;
        private bool recordNextClickDestroy = false;
        List<Button> buttons = new List<Button>();
        private int amountOfButtons = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void ShowList()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < buttons.Count; i++)
                listBox1.Items.Add(buttons[i].Name);
        }

        private void ChackPosition(int butX, int butY)
        {
            bool skipX = false, skipY = false;
            int CreateX = buttons[0].Location.X;
            int CreateY = buttons[0].Location.Y;
            while (skipX == false || skipY == false)
            {
                if (CreateX > butX)
                    CreateX -= 1;
                else if (CreateX < butX)
                    CreateX += 1;
                else if (CreateX == butX)
                    skipX = true;
                if (CreateY > butY)
                {
                    CreateY -= 1;
                }
                else if (CreateY < butY)
                {
                    CreateY += 1;
                }
                else if (CreateY == butY)
                    skipY = true;

                this.Controls.Add(CreateButton(CreateX, CreateY));
            }
        }

        private Button CreateButton(int x, int y)
        {
            Button button = new Button();
            button.Location = new Point(x, y);
            button.Size = new Size(20, 20);
            button.BackColor = Color.Red;
            return button;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (recordNextClickCreate)
            {
                int SizeX = 30;
                int SizeY = 30;
                Button button = new Button();
                int x = e.X - (SizeX / 2);
                int y = e.Y - (SizeY / 2);
                button.Name = $"{amountOfButtons}";
                button.Location = new Point(x, y);
                button.Size = new Size(SizeX, SizeY);
                button.Click += Button_Click;
                buttons.Add(button);
                amountOfButtons += 1;
                this.Controls.Add(button);
                recordNextClickCreate = false;
                label2.Text = null;
                ShowList();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (recordNextClickDestroy)
            {
                string name = ((Button)sender).Name;
                int deletePotion = Convert.ToInt16(name);
                this.Controls.Remove((Button)sender);
                buttons.Remove((Button)sender);
                recordNextClickDestroy = false;
                amountOfButtons -= 1;
                ShowList();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            recordNextClickCreate = true;
            label2.Text = "нажмите в какое-то место";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Cross;
            recordNextClickDestroy = true;
            label2.Text = "нажмите в какое-то место";
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChackPosition(button5.Location.X, button5.Location.Y);
        }
    }
}
