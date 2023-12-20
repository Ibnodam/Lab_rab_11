

try 
{
    Console.Write("Введите название организации: ");
    string? org = Console.ReadLine();
    Console.Write("Введите число рабочих станций: ");
    int stations = int.Parse(Console.ReadLine());
    Console.Write("Введите среднее расстояние между станциями: ");
    double s = double.Parse(Console.ReadLine());
    Console.Write("Введите среднюю скорость передачи данных (Мб/с): ");
    double p = double.Parse(Console.ReadLine());

    Parent parent = new Parent(org,stations,s);
    Console.WriteLine($"Название организации: {parent.Org}; 'качество' класса 1 уровня (Q) = {parent.Q(parent.Stations,parent.S):F2}");

    Child child = new Child(org, stations, s, p);
    Console.WriteLine($"Название организации: {child.Org}; 'качество' класса 2 уровня (Qp) = {child.Q(parent.Stations, parent.S):F2}");
}
catch (Exception ex)
{ Console.WriteLine(ex.Message); }






class Parent
{
    private string? org;
    private int stations;
    private double s;

    public string? Org { get { return org; } set { if (value != null) org = value; } }
    public int Stations { get { return stations; } set { if(value >= 0) stations = value; } }
    public double S { get { return s; } set { if (value >= 0) s = value; } }

    public virtual double Q(int Stations, double S)
    { return (Stations * S); }

    public Parent(string? org, int stations, double s)
    { 
        this.Org = org;
        this.Stations = stations;   
        this.S = s;
    
    }


}

class Child : Parent
{
    private string? org;
    private int stations;
    private double s;
    private double p;



    public string? Org { get { return org; } set { if (value != null) org = value; } }
    public int Stations { get { return stations; } set { if (value >= 0) stations = value; } }
    public double S { get { return s; } set { if (value >= 0) s = value; } }

    public double P { get { return p; } set { if (value >= 0) p = value; } }


    public override double Q(int Stations, double S)
    {
        return (base.Q(Stations, S) * P);
    }
    //public override double Q(double Q, double P)
    //{ return (Q*P); }

    public Child(string? org, int stations, double s, double p) : base(org, stations, s)
    {
        this.Org = base.Org;
        this.Stations = base.Stations;
        this.S = base.S;
        this.P = p;
    }
}