using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace Praktika_Lavrentev_Abdrahmanov
{
    internal class CardGap
    {
        public StackPanel panel;
        private Label label;
        private string activeText;
        private SolidColorBrush clueColor, defaultColor, activeColor;
        private bool isCard;
        

        public CardGap(string activeText, SolidColorBrush clueColor, SolidColorBrush activeColor, int gridCol, int gridRow, Grid grid)
        {
            this.activeText = activeText;
            this.clueColor = clueColor;
            this.activeColor = activeColor;

            panel = new StackPanel();
            label = new Label();
            panel.Children.Add(label);

            defaultColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#D3D3D3"));
            SetDefault();

            panel.Height = 25;
            panel.Width = 150;
            label.HorizontalAlignment = HorizontalAlignment.Center;

            panel.MouseEnter += new MouseEventHandler(Gap_MouseEnter);
            panel.MouseLeave += new MouseEventHandler(Gap_MouseLeave);
           

            Grid.SetColumn(panel, gridCol);
            Grid.SetRow(panel, gridRow);
            grid.Children.Add(panel);
        }

        public void SetDefault()
        {
            panel.Background = defaultColor;
            label.Content = "";
            isCard = false; 
        }

        private void Gap_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!isCard)
            {
                panel.Background = clueColor;
                label.Content = activeText;
            }
        }

        private void Gap_MouseLeave(object sender, MouseEventArgs e)
        {
            if (!isCard)
            {
                panel.Background = defaultColor;
                label.Content = "";
            }
        }
        

        public void ActivateCard()
        {
            isCard = true;
            panel.Background = activeColor;
            label.Content = "Возьмите карту";
        }

        public bool GetCard()
        {
            return isCard;
        }

        

    }
}
