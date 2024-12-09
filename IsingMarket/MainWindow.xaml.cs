namespace IsingMarket
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Shapes;
    using System.Windows.Media;
    using IsingMarket.Domain;

    public partial class MainWindow : Window
    {
        /// <summary>
        /// An instance of the IsingModel.
        /// </summary>
        private IsingModel model;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the click event of the GenerateButton.
        /// Creates a new IsingModel instance and displays its grid.
        /// </summary>
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            int width = int.Parse(WidthTextBox.Text);
            int height = int.Parse(HeightTextBox.Text);

            model = new IsingModel(width, height, 2.0, 1.0);
            DisplayGrid();
        }

        /// <summary>
        /// Handles the click event of the RunButton.
        /// Runs a few steps of the simulation and updates the display.
        /// </summary>
        private void RunButton_Click(object sender, RoutedEventArgs e)
        {
            if (model != null)
            {
                model.Run(100);
                DisplayGrid();
            }
        }

        /// <summary>
        /// Displays the current state of the grid using up (↑) and down (↓) arrows for spins.
        /// </summary>
        private void DisplayGrid()
        {
            GridDisplay.Children.Clear();
            GridDisplay.Rows = model.GetGrid().GetHeight();
            GridDisplay.Columns = model.GetGrid().GetWidth();

            for (int y = 0; y < model.GetGrid().GetHeight(); y++)
            {
                for (int x = 0; x < model.GetGrid().GetWidth(); x++)
                {
                    var node = model.GetGrid().GetNode(x, y);
                    string arrow = node.Spin ==1 ? "↑" : "↓";

                    var textBlock = new TextBlock
                    {
                        Text = arrow,
                        FontSize = 20,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center
                    };

                    var border = new Border
                    {
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1),
                        Child = textBlock
                    };

                    GridDisplay.Children.Add(border);
                }
            }
        }
    }

}
