using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab11
{
    public partial class RibbonLab11
    {
        private void RibbonLab11_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            this.playLab("Lab1");
        }

        private void playLab(string labName)
        {
            try
            {
                string result = "";
                RunnerLabs labRunner = new RunnerLabs();
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..", @"..", "input.txt");
                switch (labName)
                {
                    case "Lab1":
                        result = labRunner.RunLab1(filePath);
                        break;
                    case "Lab2":
                        result = labRunner.RunLab2(filePath);
                        break;
                    case "Lab3":
                        result = labRunner.RunLab3(filePath);
                        break;
                    default:
                        throw new ArgumentException("Нічого не знайдено");
                }

                MessageBox.Show("Відповідь: " + result);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, RibbonControlEventArgs e)
        {
            this.playLab("Lab2");
        }

        private void button3_Click(object sender, RibbonControlEventArgs e)
        {
            this.playLab("Lab3");
        }

        private string GetInputFilePath(string labName)
{
    string basePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "CrossPlatform", "Labs");

    string labFolderPath = Path.Combine(basePath, labName);

    Console.WriteLine($"Шлях до файлу: {labFolderPath}");

    if (Directory.Exists(labFolderPath))
    {
        string filePath = Path.Combine(labFolderPath, "input.txt");
        Console.WriteLine($"Перевірка файлу: {filePath}");

        if (File.Exists(filePath))
        {
            return filePath;
        }
        else
        {
            throw new FileNotFoundException($"Файл {filePath} не знайдено.");
        }
    }

    return null;
}
    }
}
