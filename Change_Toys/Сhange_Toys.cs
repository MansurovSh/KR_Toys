using Nito.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;


public abstract class Toy
{
    protected static int id = 0;
    protected string name;
    protected int countToy;
    protected int weight;

    public static int count;

    public string GetName() => name;
    public int GetCountToy() => countToy;
    public int GetWeight() => weight;
    public void SetWeight(int weight) => this.weight = weight;

    public void SetdCountToy() => this.countToy--;

    public abstract void ChangeWeight();
    public void AddNewToy(int count) => this.countToy += count;
}

public class CarToy : Toy
{
    private static CarToy instance;

    private CarToy(int countToy, int weight)
    {
        id += 1;
        name = "Car";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static CarToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new CarToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}

public class DollToy : Toy
{
    private static DollToy instance;

    private DollToy(int countToy, int weight)
    {
        id += 1;
        name = "Doll";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static DollToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new DollToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}


public class RobotToy : Toy
{
    private static RobotToy instance;

    private RobotToy(int countToy, int weight)
    {
        id += 1;
        name = "Robot";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static RobotToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new RobotToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}

public class BallToy : Toy
{
    private static BallToy instance;

    private BallToy(int countToy, int weight)
    {
        id += 1;
        name = "Ball";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static BallToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new BallToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}

public class PuzzleToy : Toy
{
    private static PuzzleToy instance;

    private PuzzleToy(int countToy, int weight)
    {
        id += 1;
        name = "Puzzle";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static PuzzleToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new PuzzleToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}

public class TeddyBearToy : Toy
{
    private static TeddyBearToy instance;

    private TeddyBearToy(int countToy, int weight)
    {
        id += 1;
        name = "TeddyBear";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static TeddyBearToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new TeddyBearToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}

public class TrainToy : Toy
{
    private static TrainToy instance;

    private TrainToy(int countToy, int weight)
    {
        id += 1;
        name = "Train";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static TrainToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new TrainToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}

public class BlockToy : Toy
{
    private static BlockToy instance;

    private BlockToy(int countToy, int weight)
    {
        id += 1;
        name = "Block";
        this.countToy = countToy;
        this.weight = weight;
    }

    public static BlockToy GetInstance(int countToy, int weight)
    {
        if (instance == null)
        {
            instance = new BlockToy(countToy, weight);
            Toy.count += 1;
        }
        return instance;
    }

    public override void ChangeWeight() { }
}

public class ControlVer
{
    private static ControlVer instance;
    private Dictionary<string, double> toyWeights = new Dictionary<string, double>();

    private ControlVer() { }

    public static ControlVer GetInstance()
    {
        if (instance == null)
        {
            instance = new ControlVer();
        }
        return instance;
    }

    public void AddToyWeight(string toyName, double weight)
    {
        toyWeights[toyName] = weight;
    }

    public string GetRandomToy()
    {
        double totalWeight = toyWeights.Values.Sum();
        double randomNumber = new Random().NextDouble() * totalWeight;
        double cumulativeWeight = 0;
        foreach (var kvp in toyWeights)
        {
            cumulativeWeight += kvp.Value;
            if (randomNumber <= cumulativeWeight)
            {
                return kvp.Key;
            }
        }
        return toyWeights.Keys.Last();
    }

    public void UpdateWeight(string toyName, int newWeight)
    {
        if (toyWeights.ContainsKey(toyName))
        {
            toyWeights[toyName] = newWeight;
        }
    }

    public Dictionary<string, double> GetToyWeights() => toyWeights;
}

public class Animation : Window
{
    private RotateTransform rotate = new RotateTransform();
    private ControlVer controlVer = ControlVer.GetInstance();
    private Canvas canvas = new Canvas
    {
        Height = 400,
        Width = 400,
        Background = Brushes.White,
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Center
    };

    private Ellipse ellipse = new Ellipse
    {
        Height = 300,
        Width = 300,
        Fill = Brushes.Transparent,
        Stroke = Brushes.Black,
        StrokeThickness = 2
    };

    private Polygon pointer = new Polygon
    {
        Fill = Brushes.Black,
        Points = new PointCollection
        {
            new Point(200, 0), 
            new Point(190, 30), 
            new Point(210, 30) 
        }
    };

    private Toy[] toys;

    public Animation()
    {
        this.Width = 500;
        this.Height = 500;
        
        Ruletka();
    }

    public void Ruletka()
    {
        toys = new Toy[]
        {
            CarToy.GetInstance(20, 10),
            DollToy.GetInstance(15, 40),
            RobotToy.GetInstance(10, 30),
            BallToy.GetInstance(25, 20),
            PuzzleToy.GetInstance(5, 50),
            TeddyBearToy.GetInstance(30, 10),
            TrainToy.GetInstance(10, 40),
            BlockToy.GetInstance(20, 25)
        };

        foreach (var toy in toys)
        {
            controlVer.AddToyWeight(toy.GetName(), toy.GetWeight());
        }

        ellipse.RenderTransform = rotate;
        ellipse.RenderTransformOrigin = new Point(0.5, 0.5);
        Canvas.SetLeft(ellipse, 50);
        Canvas.SetTop(ellipse, 50);
        canvas.Children.Add(ellipse);

        
        DoubleAnimation rotateAnimation = new DoubleAnimation
        {
            From = 0,
            To = 360,
            Duration = new Duration(TimeSpan.FromSeconds(2)),
            RepeatBehavior = RepeatBehavior.Forever
        };
        rotate.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);

        double angleStep = 360.0 / 10;
        double radius = 150;
        double centerX = 200;
        double centerY = 200;

        Color[] segmentColors = new Color[]
        {
            Colors.Red,
            Colors.Green,
            Colors.Blue,
            Colors.Yellow,
            Colors.Orange,
            Colors.Purple,
            Colors.Cyan,
            Colors.Magenta,
            Colors.Brown,
            Colors.Gray
        };

        for (int i = 0; i < 10; i++)
        {
            double startAngle = i * angleStep;
            double endAngle = startAngle + angleStep;

            PathFigure segmentFigure = new PathFigure
            {
                StartPoint = new Point(centerX, centerY),
                IsClosed = true
            };

            Point startPoint = new Point(
                centerX + radius * Math.Cos(startAngle * Math.PI / 180),
                centerY + radius * Math.Sin(startAngle * Math.PI / 180)
            );
            Point endPoint = new Point(
                centerX + radius * Math.Cos(endAngle * Math.PI / 180),
                centerY + radius * Math.Sin(endAngle * Math.PI / 180)
            );

            segmentFigure.Segments.Add(new LineSegment(startPoint, true));
            segmentFigure.Segments.Add(new ArcSegment(endPoint, new Size(radius, radius), 0, false, SweepDirection.Clockwise, true));

            PathGeometry segmentGeometry = new PathGeometry();
            segmentGeometry.Figures.Add(segmentFigure);

            Path segmentPath = new Path
            {
                Fill = new SolidColorBrush(segmentColors[i]),
                Opacity = 0.5,
                Data = segmentGeometry
            };

            canvas.Children.Add(segmentPath);

            TextBlock textBlock = new TextBlock
            {
                Text = toys.Length > i ? toys[i].GetName() : $"Part {i + 1}",
                Foreground = Brushes.White,
                FontWeight = FontWeights.Bold,
                RenderTransform = new RotateTransform(startAngle + angleStep / 2, centerX, centerY)
            };

            double textX = centerX + (radius / 2) * Math.Cos((startAngle + angleStep / 2) * Math.PI / 180);
            double textY = centerY + (radius / 2) * Math.Sin((startAngle + angleStep / 2) * Math.PI / 180);

            Canvas.SetLeft(textBlock, textX);
            Canvas.SetTop(textBlock, textY);

            canvas.Children.Add(textBlock);
        }

        pointer.RenderTransformOrigin = new Point(0.5, 0);
        Canvas.SetLeft(pointer, centerX - 10);
        Canvas.SetTop(pointer, centerY - 200);
        canvas.Children.Add(pointer);


        Grid grid = new Grid();
        grid.Children.Add(canvas);
        this.Content = grid;

        Button stopAtSegmentButton = new Button
        {
            Content = "Stop at Segment 5",
            Margin = new Thickness(5),
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Bottom
        };
        stopAtSegmentButton.Click += StopAtSegmentButton_Click;
        grid.Children.Add(stopAtSegmentButton);

        Button startButton = new Button
        {
            Content = "Start",
            Margin = new Thickness(5),
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Top
        };
        startButton.Click += StartButton_Click;
        grid.Children.Add(startButton);
    }

    private void StopAtSegmentButton_Click(object sender, RoutedEventArgs e)
    {
        Random random = new Random();
        DoubleAnimation rotateAnimation = new DoubleAnimation
        {
            From = rotate.Angle,
            To = rotate.Angle + random.Next(720, 1440),
            Duration = new Duration(TimeSpan.FromSeconds(2)),
            FillBehavior = FillBehavior.HoldEnd
        };

        rotateAnimation.Completed += (s, ev) =>
        {
            string selectedToyName = controlVer.GetRandomToy();
            Toy selectedToy = toys.FirstOrDefault(toy => toy.GetName() == selectedToyName);
            if (selectedToy != null)
            {
                selectedToy.SetdCountToy();
                MessageBox.Show($"Вы выиграли: {selectedToy.GetName()}!");
            }
        };

        rotate.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
    }

    private void StartButton_Click(object sender, RoutedEventArgs e)
    {
        DoubleAnimation rotateAnimation = new DoubleAnimation
        {
            From = 0,
            To = 360,
            Duration = new Duration(TimeSpan.FromSeconds(10)),
            RepeatBehavior = RepeatBehavior.Forever
        };
        rotate.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
    }


    
}

public class Program
{
    [STAThread]
    public static void Main()
    {
        Application app = new Application();
        app.Run(new Animation());
    }
}
