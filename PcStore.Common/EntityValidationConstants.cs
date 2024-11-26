namespace PcStore.Common
{
    public static class EntityValidationConstants
    {

        public static class Part
        {
            public const int BrandMinLength = 3;
            public const int BrandMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 500;
            public const int PriceMinValue = 1;
            public const int PriceMaxValue = 10000;
        }

        public static class Laptop
        {
            public const int BrandMinLength = 3;
            public const int BrandMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 500;
            public const int PriceMinValue = 1;
            public const int PriceMaxValue = 300000;
        }

        public static class MyCart
        {
            public const int BrandMinLength = 3;
            public const int BrandMaxLength = 50;
            public const int DescriptionMinLength = 5;
            public const int DescriptionMaxLength = 500;
            public const int PriceMinValue = 1;
            public const int PriceMaxValue = 300000;
        }
    }
}
