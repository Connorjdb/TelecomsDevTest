using Interfaces.Services;
using QRCoder;

namespace TestServices
{
    public class QrGeneratorService : IQrGeneratorService
    {
        public byte[] GenerateQR(string textToEncode, string hexColour1, string hexColour2)
        {
            return BitmapByteQRCodeHelper.GetQRCode(textToEncode, 20, hexColour1, hexColour2, QRCodeGenerator.ECCLevel.L);
        }
    }
}
