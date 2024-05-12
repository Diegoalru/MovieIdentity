using QRCoder;

namespace MovieIdentity.Services;

/// <summary>
/// Service for generating QR codes.
/// </summary>
public class QrCodeService
{
    private readonly QRCodeGenerator _generator;

    /// <summary>
    /// Initializes a new instance of the <see cref="QrCodeService"/> class.
    /// </summary>
    /// <param name="generator">The QR code generator.</param>
    public QrCodeService(QRCodeGenerator generator)
    {
        _generator = generator;
    }

    /// <summary>
    /// Generates a QR code for the specified text and returns it as a Base64 string.
    /// </summary>
    /// <param name="textToEncode">The text to encode in the QR code.</param>
    /// <returns>A Base64 string representing the QR code.</returns>
    public string GetQrCodeAsBase64(string textToEncode)
    {
        var qrCodeData = _generator.CreateQrCode(textToEncode, QRCodeGenerator.ECCLevel.Q);
        var qrCode = new PngByteQRCode(qrCodeData);

        return Convert.ToBase64String(qrCode.GetGraphic(4));
    }
}
