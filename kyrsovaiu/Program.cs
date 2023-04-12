using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.ExceptionServices;



using (ApplicationContext db = new ApplicationContext())
{
    OrderType ort1 = new OrderType
    {
        Id = 1,
        Type = "brokerage"
    };
    OrderType ort2 = new OrderType
    {
        Id = 2,
        Type = "dealer"
    };

    db.OrderTypes.AddRange(ort1, ort2);
    db.SaveChanges();

    OrderVeriety ov1 = new OrderVeriety
    {

        Veriety = "unilateral"
    };
    OrderVeriety ov2 = new OrderVeriety
    { 
        Veriety = "multilateral"
    };

    db.OrderVerietys.AddRange(ov1, ov2);
    db.SaveChanges();

    Currency c1 = new Currency {  CurrenxyFull = "RUBLES", CurrenxyShort = "RUB" }; 
    Currency c2 = new Currency {  CurrenxyFull = "AMERICAN DOLLAR", CurrenxyShort = "USD" };
    Currency c3 = new Currency {  CurrenxyFull = "EUR", CurrenxyShort = "EUR" }; 
    db.Currencys.AddRange(c1, c2);

    Order or1 = new Order
    {
        OrderType = ort1,
        OrderVeriety = ov2,
        Currency = c1,
        Tiker = "LADA",
        Count = 1000,
        Type = "deferred forms of payment",
        Number = 954,
        Data = "10.12.2012",
        Duration = "urgently"
    };
    Order or2 = new Order
    {
        OrderType = ort1,
        OrderVeriety = ov1,
        Currency = c2,
        Tiker = "OZON",
        Count = 447,
        Type = "deferred forms of payment",
        Number = 1054,
        Data = "5.02.2014",
        Duration = "urgently"
    };
    Order or3 = new Order
    {

        OrderType = ort2,
        OrderVeriety = ov2,
        Currency = c3,
        Tiker = "YNDX",
        Count = 253,
        Type = "deferred forms of payment",
        Number = 2042,
        Data = "17.10.2016",
        Duration = "urgently"
    };
    
    db.Orders.AddRange(or1,or2,or3); 

    db.SaveChanges();


    int choice = -1;
    do
    {   
        Console.WriteLine("*****************************");
        Console.WriteLine("1.Просмотр таблиц");
        Console.WriteLine("2.Ввод новых записей");
        Console.WriteLine("3.Редактирование");
        Console.WriteLine("4.Удаление");
        Console.WriteLine("5.Вывод данных из таблиц по ID");
        Console.WriteLine("6.Вывод поручений по ID");
        Console.WriteLine("7.Выход");
        Console.WriteLine("*****************************\n");
        choice = Convert.ToInt32(Console.ReadLine());
        int ft;
        int id_ =0, otd_ = 0, c_ = 0, ov_ = 0, count_ = 0, number_ = 0,ch3;
        string tiker_, type_, data_, duration_, veriety_, curfull_,curshort_;
        switch (choice)
        {
            case 1:
                var orders = db.Orders.ToList();
                var ordertypes = db.OrderTypes.ToList();
                var orderverietys = db.OrderVerietys.ToList();
                var currencys = db.Currencys.ToList();
                Console.WriteLine("************Order************\n");
                foreach (Order u in orders)
                {
                    Console.WriteLine($"{u.Id}. {u.OrderVerietyID} - {u.OrderVerietyID} - {u.CurrencyId} - {u.Tiker} - {u.Count} - {u.Type} - {u.Number} - {u.Data} - {u.Duration}");
                }
                Console.WriteLine("***********OrderType***********\n");
                foreach (OrderType u in ordertypes)
                {
                    Console.WriteLine($"{u.Id}. {u.Type}");
                }
                Console.WriteLine("*********OrderVeriety************\n");
                foreach (OrderVeriety u in orderverietys)
                {
                    Console.WriteLine($"{u.Id}. {u.Veriety}");
                }
                Console.WriteLine("********Currency**********\n");
                foreach (Currency u in currencys)
                {
                    Console.WriteLine($"{u.Id}. {u.CurrenxyFull} - {u.CurrenxyShort}");
                }
                Console.WriteLine("*****************************\n");
                
                break;

            case 2:
                Console.WriteLine("Выберите таблицу");
                Console.WriteLine("1.Order");
                Console.WriteLine("2.OrderType");
                Console.WriteLine("3.OrderVeriety");
                Console.WriteLine("4.Currency");
                Console.WriteLine("5.Выход");
                Console.WriteLine("");
                int ch2 = Convert.ToInt32(Console.ReadLine());

                switch (ch2)
                {
                    case 1:
                        Console.WriteLine("Введите:");
                        Console.WriteLine("1.Id");
                        id_ = Convert.ToInt32(Console.ReadLine());
                        if (db.Orders.Find(id_) != null)
                        {
                            Console.WriteLine("Данный Id существует");
                            break;
                        }
                        Console.WriteLine("2.OrderTypeId");
                        otd_ = Convert.ToInt32(Console.ReadLine());
                        if (db.OrderTypes.Find(otd_) == null)
                        {
                            Console.WriteLine("Данный Id не существует");
                            break;
                        }
                        Console.WriteLine("3.OrderVerietyID");
                        ov_ = Convert.ToInt32(Console.ReadLine());
                        if (db.OrderVerietys.Find(ov_) == null)
                        {
                            Console.WriteLine("Данный Id не существует");
                            break;
                        }
                        
                        Console.WriteLine("4.CurrencyId");
                        c_ = Convert.ToInt32(Console.ReadLine());
                        if (db.Currencys.Find(c_) == null)
                        {
                            Console.WriteLine("Данный Id не существует");
                            break;
                        }
                        
                        Console.WriteLine("5.Tiker");
                        tiker_ = Console.ReadLine();
                        Console.WriteLine("6.Count");
                        count_ = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("7.Type");
                        type_ = Console.ReadLine();
                        Console.WriteLine("8.Number");
                        number_ = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("9.Data");
                        data_ = Console.ReadLine();
                        Console.WriteLine("10.Duration");
                        duration_ = Console.ReadLine();

                        Order or = new Order
                        {
                            Id = id_,
                            OrderTypeId = otd_,
                            OrderVerietyID = ov_,
                            CurrencyId = c_,
                            Tiker = tiker_,
                            Count = count_,
                            Type = type_,
                            Number = number_,
                            Data = data_,
                            Duration = duration_
                        };

                        db.Orders.AddRange(or);
                        db.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Введите:");
                        Console.WriteLine("1.Id");
                        id_ = Convert.ToInt32(Console.ReadLine());
                        if (db.OrderTypes.Find(id_) != null)
                        {
                            Console.WriteLine("Данный Id существует");
                            break;
                        }
                        Console.WriteLine("2.Type");
                        type_ = Console.ReadLine();

                        OrderType ort = new OrderType
                        {
                            Id = id_,
                            Type = type_
                        };

                        db.OrderTypes.AddRange(ort);
                        db.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Введите:");
                        Console.WriteLine("1.Id");
                        id_ = Convert.ToInt32(Console.ReadLine());
                        if (db.OrderVerietys.Find(id_) != null)
                        {
                            Console.WriteLine("Данный Id существует");
                            break;
                        }
                        Console.WriteLine("2.Veriety");
                        veriety_ = Console.ReadLine();
                        OrderVeriety ov = new OrderVeriety
                        {
                            Id = id_,
                            Veriety = veriety_
                        };

                        db.OrderVerietys.AddRange(ov);
                        db.SaveChanges();
                        break;

                    case 4:
                        Console.WriteLine("Введите:");
                        Console.WriteLine("1.Id");
                        id_ = Convert.ToInt32(Console.ReadLine());
                        if (db.Currencys.Find(id_) != null)
                        {
                            Console.WriteLine("Данный Id существует");
                            break;
                        }
                        Console.WriteLine("2.CurrenxyFull");
                        curfull_ = Console.ReadLine();
                        Console.WriteLine("3.CurrenxyShort");
                        curshort_ = Console.ReadLine();
                        
                    


                        Currency cur = new Currency
                        {
                            Id = id_,
                            CurrenxyFull = curfull_,
                            CurrenxyShort = curshort_
                        };

                        db.Currencys.AddRange(cur);
                        db.SaveChanges();
                        break;

                    case 5:
                        Console.WriteLine("Back");
                        break;

                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
                break;

            case 3:
                Console.WriteLine("Выберите таблицу");
                Console.WriteLine("1.Order");
                Console.WriteLine("2.OrderType");
                Console.WriteLine("3.OrderVeriety");
                Console.WriteLine("4.Currency");
                Console.WriteLine("5.Выход");
                ch3 = Convert.ToInt32(Console.ReadLine());
                ft = 0;
                switch (ch3)
                {
                    case 1:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        Order? order = db.Orders.Find(ft);
                        if (order == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        Console.WriteLine("Введите номер для изменения:");
                        Console.WriteLine("1.Tiker");
                        Console.WriteLine("2.Count");
                        Console.WriteLine("3.Type");
                        Console.WriteLine("4.Number");
                        Console.WriteLine("5.Data");
                        Console.WriteLine("6.Duration");
                        Console.WriteLine("7.Выход");
                        ch3 = Convert.ToInt32(Console.ReadLine());
                        switch (ch3)
                        {
                            case 1:
                                Console.WriteLine("1.Tiker");
                                order.Tiker = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("2.Count");
                                order.Count = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 3:
                                Console.WriteLine("3.Type");
                                order.Type = Console.ReadLine();
                                break;
                            case 4:
                                Console.WriteLine("4.Number");
                                order.Number = Convert.ToInt32(Console.ReadLine());
                                break;
                            case 5:
                                Console.WriteLine("5.Data");
                                order.Data = Console.ReadLine();
                                break;
                            case 6:
                                Console.WriteLine("6.Data");
                                order.Duration = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Выход");
                                break;
                        }
                        db.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        OrderType? ordertype = db.OrderTypes.Find(ft);
                        if (ordertype == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        Console.WriteLine("1.Type");
                        ordertype.Type = Console.ReadLine();
                        db.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        OrderVeriety? orderveriety = db.OrderVerietys.Find(ft);
                        if (orderveriety == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        Console.WriteLine("Введите номер для изменения:");
                        Console.WriteLine("1.Veriety");
                        orderveriety.Veriety = Console.ReadLine();
                        db.SaveChanges();
                        break;
                    case 4:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        Currency? currency = db.Currencys.Find(ft);
                        if (currency == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        Console.WriteLine("Введите номер для изменения:");
                        Console.WriteLine("1.CurrencyFull");
                        Console.WriteLine("2.CurrencyShort");
                        ch3 = Convert.ToInt32(Console.ReadLine());
                        switch (ch3)
                        {
                            case 1:
                                Console.WriteLine("1.CurrencyFull");
                                currency.CurrenxyFull = Console.ReadLine();
                                break;
                            case 2:
                                Console.WriteLine("2.CurrencyShort");
                                currency.CurrenxyShort = Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Неправильный выбор");
                                break;
                        }
                        db.SaveChanges();
                        break;

                    case 5:
                        Console.WriteLine("Выход");
                        break;

                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
                break;
            case 4:
                Console.WriteLine("Выберите таблицу");
                Console.WriteLine("1.Order");
                Console.WriteLine("2.OrderType");
                Console.WriteLine("3.OrderVeriety");
                Console.WriteLine("4.Currency");
                Console.WriteLine("5.Выход");
                int ch4 = Convert.ToInt32(Console.ReadLine());
                ft = 0;
                switch (ch4)
                {
                    case 1:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        Order? order = db.Orders.Find(ft);
                        if (order == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        db.Orders.Remove(order);
                        db.SaveChanges();
                        break;
                    case 2:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        OrderType? ordertype = db.OrderTypes.Find(ft);
                        if (ordertype == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        db.OrderTypes.Remove(ordertype);
                        db.SaveChanges();
                        break;
                    case 3:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        OrderVeriety? orderveriety = db.OrderVerietys.Find(ft);
                        if (orderveriety == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        db.OrderVerietys.Remove(orderveriety);
                        db.SaveChanges();
                        break;

                    case 4:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        Currency? cur = db.Currencys.Find(ft);
                        if (cur == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        db.Currencys.Remove(cur);
                        db.SaveChanges();
                        break;

                    case 5:
                        Console.WriteLine("Выход");
                        break;

                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
                break;
            case 5:
                Console.WriteLine("Выберите таблицу");
                Console.WriteLine("1.Order");
                Console.WriteLine("2.OrderType");
                Console.WriteLine("3.OrderVeriety");
                Console.WriteLine("4.Currency");
                Console.WriteLine("5.Выход");
                int ch5 = Convert.ToInt32(Console.ReadLine());
                ft = 0;
                switch (ch5)
                {
                    case 1:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        Order? order = db.Orders.Find(ft);
                        if (order == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        Console.WriteLine($"{order.Id}. {order.OrderVerietyID} - {order.OrderVerietyID} - {order.CurrencyId} - {order.Tiker} - {order.Count} - {order.Type} - {order.Number} - {order.Data} - {order.Duration}");
                        break;
                    case 2:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        OrderType? ordertype = db.OrderTypes.Find(ft);
                        if (ordertype == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        Console.WriteLine($"{ordertype.Id}. {ordertype.Type}");
                        break;
                    case 3:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        OrderVeriety? orderveriety = db.OrderVerietys.Find(ft);
                        if (orderveriety == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        Console.WriteLine($"{orderveriety.Id}. {orderveriety.Veriety}");
                        break;

                    case 4:
                        Console.WriteLine("Введите:ID");
                        ft = Convert.ToInt32(Console.ReadLine());
                        Currency? cur = db.Currencys.Find(ft);
                        if (cur == null)
                        {
                            Console.WriteLine("По такому ID ничего не найдено");
                            break;
                        }
                        db.Currencys.Remove(cur);
                        db.SaveChanges();
                        break;

                    case 5:
                        Console.WriteLine("Back");
                        break;

                    default:
                        Console.WriteLine("Неправильный выбор");
                        break;
                }
                break;
            case 6:
                Console.WriteLine("Введите:ID");
                ft = Convert.ToInt32(Console.ReadLine());
                Order? orde = db.Orders.Find(ft);
                if (orde == null)
                {
                    Console.WriteLine("По такому ID ничего не найдено");
                    break;
                }
                /* Тут SQL запрос нужен*/
                Console.WriteLine($"{orde.Type} - {db.OrderVerietys.Find(orde.OrderVerietyID)} - {orde.Tiker}- {orde.Count} - {db.OrderTypes.Find(orde.OrderTypeId)} - {orde.Number} - {orde.Data}- {orde.Duration}");
                break;
            case 7:
                Console.WriteLine("Спасибо за просмотр");
                break;
            default:
                Console.WriteLine("Неправильный выбор");
                choice = 7;
                break;
        }


    }
    while (choice != 7);

    return 0;


}
public class ApplicationContext : DbContext 
{
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<OrderType> OrderTypes { get; set; } = null!;
    public DbSet<OrderVeriety> OrderVerietys { get; set; } =null!;
    public DbSet<Currency> Currencys { get; set; } = null!;
    public ApplicationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated(); // гарантируем, что бд будет создана
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(@"host=localhost;port=5432;database=testdb;username=postgres;password=cxcxcx444");
    }
}



public class Order
{
    public int Id { get; set; }
    public int OrderTypeId { get; set; }
    public int OrderVerietyID { get; set; }
    public int CurrencyId { get; set; }
    public OrderType OrderType { get; set; }
    public OrderVeriety OrderVeriety { get; set; }
    public Currency Currency { get; set; }  
    public string? Tiker { get; set; }
    public int Count { get; set; }
    public string? Type{ get; set; }
    public int Number { get; set; }

    public string? Data { get; set; }
    public string?  Duration { get; set; }
}
public class OrderType
{   
    public int Id { get; set; }
   /* public ICollection<Order> Orders { get; set; }*/
    public string? Type { get; set; }
   
}
public class OrderVeriety
{
    public int Id { get; set; }
    /*public ICollection<Order> Orders { get; set; } */
    public string? Veriety { get; set; }

    
}
public class Currency
{   
    public int Id { get; set; }
   /* public ICollection<Order> Orders { get; set; }*/
    public string? CurrenxyFull { get; set; }
    public string? CurrenxyShort { get; set; }
}
