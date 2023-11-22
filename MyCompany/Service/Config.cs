namespace MyCompany.Service
{
    public class Config
    {
        // Властивість для рядка підключення до бази даних
        public static string ConnectionString { get; set; }

        // Властивість для назви компанії
        public static string CompanyName { get; set; }

        // Властивість для телефону компанії
        public static string CompanyPhone { get; set; }

        // Властивість для скороченого номера телефону компанії
        public static string CompanyPhoneShort { get; set; }

        // Властивість для електронної пошти компанії
        public static string CompanyEmail { get; set; }
    }
}
