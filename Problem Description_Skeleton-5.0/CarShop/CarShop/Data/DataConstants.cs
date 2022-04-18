namespace CarShop.Data
{
    public class DataConstants
    {
        public const int IdMaxValue = 40;
        public const int DefaultMaxLength = 20;
        public const int DefaultMinLength = 5;

        public const int UsernameMinLength = 4;
        public const string UserEmailRegularExpression = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string UserTypeClient = "Client";
        public const string UserTypeMechanic = "Mechanic";

        public const int CarPlateNumberLength = 8;
        public const string CarPlateNumberRegularExpression = @"[A-Z]{2}[0-9]{4}[A-Z]{2}";
        public const int CarYearMinValue = 1900;
        public const int CarYearMaxValue = 2100;

        


    }
}
