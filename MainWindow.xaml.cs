using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika_Lavrentev_Abdrahmanov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CardGap getPassCardGap, passCardGap2, passCardGap3, bankCardGap;
        private  bool passCardInHand;
        private  Label handCard;
        private int time, stopCost, resultCost;

        public MainWindow()
        {
            InitializeComponent();
            passCardInHand= false;

            SolidColorBrush passCardColor = HelpMethods.getHexBrush("#98FB98");
            SolidColorBrush activeColor = HelpMethods.getHexBrush("#00FF7F");


            getPassCardGap = new CardGap("Получить карту-пропуск", passCardColor, activeColor ,0, 2, mainGrid);
            passCardGap2 = new CardGap("Вставьте карту-пропуск", passCardColor, activeColor,1, 2, mainGrid);
            passCardGap3 = new CardGap("Вставьте карту-пропуск", passCardColor, activeColor,2,2,mainGrid);

            getPassCardGap.panel.MouseDown += new MouseButtonEventHandler(Gap_MouseDown);
            passCardGap2.panel.MouseDown += new MouseButtonEventHandler(Gap2_MouseDown);

            bankCardGap = new CardGap("Вставьте карту банка", HelpMethods.getHexBrush("#87CEEB"), HelpMethods.getHexBrush("#0000CD"), 1, 4, mainGrid);
            
            handCard= new Label();
            handCard.Content = "Нет карты!";
            Grid.SetColumn(handCard, 0);
            Grid.SetRow(handCard, 0);
            mainGrid.Children.Add(handCard);
        }

        private void Gap_MouseDown(object sender, MouseEventArgs e)
        {
            if (getPassCardGap.GetCard())
            {
                getPassCardGap.SetDefault();
                passCardInHand = true;
                handCard.Content = "Карта получена!";
            }
        }

        private void Gap2_MouseDown(object sender, MouseEventArgs e)
        {
            if (!passCardGap2.GetCard())
            {
                passCardGap2.ActivateCard();
            }
            else passCardGap2.SetDefault();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!passCardInHand) getPassCardGap.ActivateCard();
            else MessageBox.Show("Карта получена!");
        }

        private void PassCardTaken()
        {
            passCardInHand = true;
            handCard.Content = "Карта получена";
        }
    }
}
