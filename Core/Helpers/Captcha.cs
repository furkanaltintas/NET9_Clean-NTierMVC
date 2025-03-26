using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Core.Helpers;

public static class Captcha
{
    const string Letters = "2346789ABCDEFGHJKLMNPRTUVWXYZ";
    const string CaptchaCode = "CaptchaCode";

    public static string GenerateCaptchaCode()
    {
        Random rand = new Random();
        int maxRand = Letters.Length - 1;

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < 4; i++)
        {
            int index = rand.Next(maxRand);
            stringBuilder.Append(Letters[index]);
        }

        return stringBuilder.ToString();
    }

    public static bool ValidateCaptchaCode(string userInputCaptcha, HttpContext context)
    {
        var isValid = userInputCaptcha == context.Session.GetString(CaptchaCode);
        // GetString kullanabilmek için Nuget üzerinden Microsoft.AspNetCore.Http.Extensions kurmanız gerekmektedir.
        context.Session.Remove(CaptchaCode);
        return isValid;
    }

    public static CaptchaResult GenerateCaptchaImage(int width, int height, string captchaCode)
    {
        using (Bitmap baseMap = new Bitmap(width, height))
        using (Graphics graph = Graphics.FromImage(baseMap))
        {
            Random random = new Random();

            graph.Clear(GetRandomLightColor());

            DrawCaptchaCode();
            DrawDisorderLine();
            AdjustRippleEffect();

            MemoryStream ms = new MemoryStream();

            baseMap.Save(ms, ImageFormat.Png);

            return new CaptchaResult { CaptchaCode = captchaCode, CaptchaByteData = ms.ToArray(), TimeStamp = DateTime.Now };

            int GetFontSize(int imageWidth, int captchCodeCount)
            {
                var averageSize = imageWidth / captchCodeCount;

                return Convert.ToInt32(averageSize);
            }

            Color GetRandomDeepColor()
            {
                int redlow = 160, greenLow = 100, blueLow = 160;
                return Color.FromArgb(random.Next(redlow), random.Next(greenLow), random.Next(blueLow));
            }

            Color GetRandomLightColor()
            {
                int low = 180, high = 255;

                int nRend = random.Next(high) % (high - low) + low;
                int nGreen = random.Next(high) % (high - low) + low;
                int nBlue = random.Next(high) % (high - low) + low;

                return Color.FromArgb(nRend, nGreen, nBlue);
            }

            void DrawCaptchaCode()
            {
                SolidBrush fontBrush = new SolidBrush(Color.Black);
                int fontSize = GetFontSize(width, captchaCode.Length);
                Font font = new Font(FontFamily.GenericSerif, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
                for (int i = 0; i < captchaCode.Length; i++)
                {
                    fontBrush.Color = GetRandomDeepColor();

                    int shiftPx = fontSize / 6;

                    float x = i * fontSize + random.Next(-shiftPx, shiftPx) + random.Next(-shiftPx, shiftPx);
                    int maxY = height - fontSize;
                    if (maxY < 0) maxY = 0;
                    float y = random.Next(0, maxY);

                    graph.DrawString(captchaCode[i].ToString(), font, fontBrush, x, y);
                }
            }

            void DrawDisorderLine()
            {
                Pen linePen = new Pen(new SolidBrush(Color.Black), 3);
                for (int i = 0; i < random.Next(3, 5); i++)
                {
                    linePen.Color = GetRandomDeepColor();

                    Point startPoint = new Point(random.Next(0, width), random.Next(0, height));
                    Point endPoint = new Point(random.Next(0, width), random.Next(0, height));
                    graph.DrawLine(linePen, startPoint, endPoint);
                }
            }

            void AdjustRippleEffect()
            {
                short nWave = 6;
                int nWidth = baseMap.Width;
                int nHeight = baseMap.Height;

                Point[,] pt = new Point[nWidth, nHeight];

                for (int x = 0; x < nWidth; ++x)
                {
                    for (int y = 0; y < nHeight; ++y)
                    {
                        var xo = nWave * Math.Sin(2.0 * 3.1415 * y / 128.0);
                        var yo = nWave * Math.Cos(2.0 * 3.1415 * x / 128.0);

                        var newX = x + xo;
                        var newY = y + yo;

                        if (newX > 0 && newX < nWidth)
                        {
                            pt[x, y].X = (int)newX;
                        }
                        else
                        {
                            pt[x, y].X = 0;
                        }


                        if (newY > 0 && newY < nHeight)
                        {
                            pt[x, y].Y = (int)newY;
                        }
                        else
                        {
                            pt[x, y].Y = 0;
                        }
                    }
                }

                Bitmap bSrc = (Bitmap)baseMap.Clone();

                BitmapData bitmapData = baseMap.LockBits(new Rectangle(0, 0, baseMap.Width, baseMap.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                int scanline = bitmapData.Stride;

                IntPtr scan0 = bitmapData.Scan0;
                IntPtr srcScan0 = bmSrc.Scan0;

                unsafe
                {
                    byte* p = (byte*)(void*)scan0;
                    byte* pSrc = (byte*)(void*)srcScan0;

                    int nOffset = bitmapData.Stride - baseMap.Width * 3;

                    for (int y = 0; y < nHeight; ++y)
                    {
                        for (int x = 0; x < nWidth; ++x)
                        {
                            var xOffset = pt[x, y].X;
                            var yOffset = pt[x, y].Y;

                            if (yOffset >= 0 && yOffset < nHeight && xOffset >= 0 && xOffset < nWidth)
                            {
                                if (pSrc != null)
                                {
                                    p[0] = pSrc[yOffset * scanline + xOffset * 3];
                                    p[1] = pSrc[yOffset * scanline + xOffset * 3 + 1];
                                    p[2] = pSrc[yOffset * scanline + xOffset * 3 + 2];
                                }
                            }

                            p += 3;
                        }
                        p += nOffset;
                    }
                }

                baseMap.UnlockBits(bitmapData);
                bSrc.UnlockBits(bmSrc);
                bSrc.Dispose();
            }
        }
    }

}
