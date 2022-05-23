namespace ts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Start();
            dataGridView1.Columns[0].Width = 200;
            dataGridView1.Columns[1].Width = dataGridView1.Width - 200;

            String[] lines = File.ReadAllLines(@"./tasks0.txt");

            foreach (String line in lines)
            {
                if( String.IsNullOrWhiteSpace(line) || line[0] == '#')
                {
                    continue;
                }
                String[] words = line.Split('|');
                dataGridView1.Rows.Add(new object[] { words[0].Trim(), words[1].Trim() });
            }

            
            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label2.Text = DateTime.Now.ToString("yyyy-MM-dd");
            label3.Text = DateTime.Now.ToString("HH:mm:ss");

            if(label3.Text == "16:00:00" || label3.Text == "08:00:00" )
            {
                try
                {
                    WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
                    wplayer.URL = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath),"ring/1.mp3");
                    wplayer.controls.play();
                    MessageBox.Show("完成所有工作了吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message,"Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            String[] lines = File.ReadAllLines(@"./tasks0.txt");

            foreach (String line in lines)
            {
                if (String.IsNullOrWhiteSpace(line) || line[0] == '#')
                {
                    continue;
                }
                String[] words = line.Split('|');
                dataGridView1.Rows.Add(new object[] { words[0].Trim(), words[1].Trim() });
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows.Clear();
            String[] lines = File.ReadAllLines(@"./tasks1.txt");

            foreach (String line in lines)
            {
                if (String.IsNullOrWhiteSpace(line) || line[0] == '#')
                {
                    continue;
                }
                String[] words = line.Split('|');
                dataGridView1.Rows.Add(new object[] { words[0].Trim(), words[1].Trim() });
            }
        }


    }
}