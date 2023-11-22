namespace MyCompany.Service
{
    public static class Extensions
    {
        // Розширюючий метод для видалення підрядка "Controller"
        public static string CutController(this string str)
        {
            // Замінюємо всі входження підрядка "Controller" на порожній рядок
            return str.Replace("Controller","");
        }
    }
}
