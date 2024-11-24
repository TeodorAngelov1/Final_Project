namespace PcStore.Common
{
    public static class EntityValidationConstants
    {
        public static class Product
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
        }

        public static class Category
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            
        }

        public static class Part
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int TypeMinLength = 10;
            public const int TypeMaxLength = 60;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 500;
            public const int PriceMinLength = 1;
            public const int PriceMaxValue = 10000;
        }

        public static class Laptop
        {
            public const int NameMinLength = 3;
            public const int NameMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 500;
            public const int PriceMinValue = 1;
            public const int PriceMaxValue = 300000;
        }
    }
}
