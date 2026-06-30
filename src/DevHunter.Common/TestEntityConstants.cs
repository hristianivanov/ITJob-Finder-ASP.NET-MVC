namespace DevHunter.Common
{
    public static class TestEntityConstants
    {
        public const string TEST_IMAGE_URL = "https://example.com/image.jpg";
        public const string TEST_DOCUMENT_URL = "https://example.com/document.pdf";
        public const string TEST_FOLDER = "upload/folder";

        // Cloudinary-formatted URL required by EnhanceCloudinaryUrl (must contain "/v")
        public const string TEST_CLOUDINARY_IMAGE_URL =
            "https://res.cloudinary.com/test/image/upload/v1/test.jpg";
    }
}
