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

namespace notepad
{
    public partial class Form1 : Form
    {
        private string FilePath;
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                if (dialog.ShowDialog()==DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                    textBox1.Text=File.ReadAllText(FilePath);
                }
            }

        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FilePath))
            {
                using(SaveFileDialog dialog=new SaveFileDialog())
                {
                    if (dialog.ShowDialog()==DialogResult.OK)
                    {
                        FilePath = dialog.FileName;
                        File.WriteAllText(FilePath,textBox1.Text);
                    }
                }
            }
            File.WriteAllText(FilePath, textBox1.Text);
        }

        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            переносПоСловамToolStripMenuItem.Checked = !переносПоСловамToolStripMenuItem.Checked;
            textBox1.WordWrap = переносПоСловамToolStripMenuItem.Checked;
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = dialog.FileName;
                    File.WriteAllText(FilePath, textBox1.Text);
                }
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Undo();  
        }

        private void вырезатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Cut();
        }

        private void копироватьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Copy();
        }

        private void ввставитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Paste();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.SelectAll();
        }

        private void времяИДатаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox1.Text += DateTime.Now.ToShortTimeString()+" "+DateTime.Now.ToShortDateString();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FontDialog dialog = new FontDialog())
            {
                if (dialog.ShowDialog()==DialogResult.OK)
                {
                    textBox1.Font = dialog.Font;


                }

            }
        }

        private void справочникToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void справочникToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "file:\\help.chm");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
