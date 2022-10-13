

using System.Data;

namespace Shop_control.Data_base
{
    public class Classifications
    {
        [Key]
        public int classification_id { get; set; }
        public string? classification_name { get; set; }
    }

    public class Countryes
    {
        [Key]
        public int country_id { get; set; }
        public string? country_name { get; set; }
    }

    public class Cities
    {
        [Key]
        public int cities_id { get; set; }
        public string? cities_name { get; set; }
        public int? country_id { get; set; }
    }

    public class Street
    {
        [Key]
        public int street_id { get; set; }
        public string? street_name { get; set; }
        public int cities_id { get; set; }
    }


    public class Adresses
    {
        [Key]
        public int adresses_id { get; set; }
        public string? home_number { get; set; }
        public int stryte_id { get; set; }
    }

    public class Suppliers
    {
        [Key]
        public int supplier_id { get; set; }
        public string? supplier_name { get; set; }
        public int adress_id { get; set; }
        public string? phone_number { get; set; }
    }

    public class Positions
    {
        [Key]
        public int position_id { get; set; }
        public string? name_position { get; set; }
    }

    public class Persons
    {
        [Key]
        public int person_id { get; set; }
        public string? first_name { get; set; }
        public string? second_name { get; set; }
        public string? last_name { get; set; }
        public string? phone_number { get; set; }
        public DateOnly? birthday { get; set; }

        
    }

    public class Adresses_type
    {
        [Key]
        public int adress_type_id { get; set; }
        public string? adress_type { get; set; }
    }

    public class Persons_adress
    {
        [Key]
        public int person_adress_id { get; set; }
        public int person_id { get; set; }
        public int adress_type_id { get; set; }
        public int adress_id { get; set; }
    }


    public class Shops
    {
        [Key]
        public int shop_id { get; set; }
        public string? shop_name { get; set; }
        public int adress_id { get; set; }
        public string? shop_phone_number { get; set; }
        public TimeOnly open_time { get; set; }
        public TimeOnly close_time { get; set; }
    }

    public class Regular_customers
    {
        [Key]
        public int regular_customers_id { get; set; }
        public int person_id {get; set; }
        public string? email { get; set; }
    }

    public class Employees
    {
        [Key]
        public int employee_id { get; set; }
        public int person_id { get; set; }
        public string? corp_email { get; set; }
        public int shop_id { get; set; }
        public int position_id { get; set; }

        public Persons? persons { get; set; }  

        
    }

    public class Furnitures
    {
        [Key]
        public int furniture_id { get; set; }
        public string? name { get; set; }
        public string? code { get; set; }
        public int classification_id { get; set; }
        public int supplier_id { get; set; }
        public string? description { get; set; }
        public string? material { get; set; }
        public string? color_scheme { get; set; }
        public double price_USD { get; set; }

    }

    public class Operations
    {
        [Key]
        public int operations_id { get; set; }
        public string? operation_type { get; set; }
    }

    public class Transactions
    {
        [Key]
        public int transactions_id { get; set; }
        public int operation_id { get; set; }
        public int furniture_id { get; set; }
        public int amount { get; set; }
        public double transaction_sum { get; set; }
    }

    public class Turnovers
    {
        [Key]
        public int turnovers_id { get; set; }
        public int operation_id { get; set; }
        public int shop_id { get; set; }
        public int employee_id { get; set; }
        public string? remark { get; set; }

    }


}
