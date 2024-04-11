namespace GameZone.Settings
{
    public static class ValidationParameters
    {
        public const int MaxImgSizeInMegabytes = 1;
        public const int MaxImgSizeInBytes = MaxImgSizeInMegabytes * 1024 * 1024;
        public const string AllowedExttensions = ".jpg,.jpeg,.png";
    }
}
