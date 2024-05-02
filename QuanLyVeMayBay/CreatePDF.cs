using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using PdfSharp.Fonts;
using System.Reflection;

namespace QuanLyVeMayBay
{
    public static class CreatePDF
    {
        public static void CreatePDFDocument(VeMayBay ve)
        {
            // Register the code pages encoding provider (if necessary)
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            // Set the custom font resolver
            MyFontResolver.Apply();
            // Create a new PDF document
            PdfDocument pdfDocument = new PdfDocument();

            pdfDocument.Info.Title = "Ve May Bay";

            // Add a page to the PDF document
            PdfPage page = pdfDocument.AddPage();
            page.Orientation = PdfSharp.PageOrientation.Landscape;
            page.Height = 650;
            page.Width = 600;
            // Create a graphics object for the page
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage image = XImage.FromFile("assets/VJ_Hotline.png");
            // Create a font for drawing text
            XFont fontTitle = new XFont("Arial", 20, XFontStyleEx.Bold);
            XFont fontSubTitle = new XFont("Arial", 18, XFontStyleEx.Bold);
            XFont fontH1 = new XFont("Arial", 15, XFontStyleEx.Bold);
            XFont fontInfo1 = new XFont("Arial", 15, XFontStyleEx.Regular);
            XFont fontInfo2 = new XFont("Arial", 10.5, XFontStyleEx.Regular);
            //gfx.DrawPath()
            // Draw text on the page
            gfx.DrawImage(image, 0, 0, image.Width, image.Height);
            double mLeft = 20;
            double mTop = 100;
            gfx.DrawString("VÉ ĐIỆN TỬ VÀ XÁC NHẬN HÀNH TRÌNH", fontTitle, XBrushes.Red, new XPoint(mLeft, mTop));
            mTop += 25;
            gfx.DrawString("Ma Ve: " + ve.MaVe, fontTitle, XBrushes.Red, new XPoint(mLeft, mTop));
            XColor backgroundColor = XColors.DarkSlateGray;
            XPen pen = new XPen(XColors.DarkRed, 1);
            double x1 = 20; // X-coordinate of the start point
            double y1 = 140; // Y-coordinate of the start point
            double x2 = 580;
            double y2 = 140;
            gfx.DrawLine(pen, x1, y1, x2, y2);
            XSolidBrush backgroundBrush = new XSolidBrush(backgroundColor);
            double heightRec = 20;
            double widthRec = 120;

            mTop += 30;
            gfx.DrawRectangle(new XSolidBrush(XColors.Red), mLeft, mTop, 560, heightRec + 8); // Draw the background color
            gfx.DrawString("Thông tin hành khách", fontSubTitle, XBrushes.White, new XPoint(mLeft + 5, mTop + 20));

            mTop += 35;
            gfx.DrawRectangle(backgroundBrush, mLeft, mTop, widthRec, heightRec); // Draw the background color
            gfx.DrawString("Ngày đặt:", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.NgayDat.ToString("dd/MM/yyyy"), fontInfo1, XBrushes.Black, new XPoint(widthRec + mLeft + 5, mTop + 15));

            mTop += 25;
            gfx.DrawRectangle(backgroundBrush, mLeft, mTop, widthRec, heightRec); // Draw the background color
            gfx.DrawString("Tên:", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.KhachHang.HoTen, fontInfo1, XBrushes.Black, new XPoint(widthRec + mLeft + 5, mTop + 15));

            mTop += 25;
            gfx.DrawRectangle(backgroundBrush, mLeft, mTop, widthRec, heightRec); // Draw the background color
            gfx.DrawString("Email:", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.KhachHang.Email, fontInfo1, XBrushes.Black, new XPoint(widthRec + mLeft + 5, mTop + 15));

            mTop += 25;
            gfx.DrawRectangle(backgroundBrush, mLeft, mTop, widthRec, heightRec); // Draw the background color
            gfx.DrawString("So Dien Thoai:", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.KhachHang.SDT, fontInfo1, XBrushes.Black, new XPoint(widthRec + mLeft + 5, mTop + 15));

            x1 = 20; // X-coordinate of the start point
            y1 = mTop + 30; // Y-coordinate of the start point
            x2 = 580;
            y2 = mTop + 30;
            gfx.DrawLine(pen, x1, y1, x2, y2);

            mTop += 40;
            gfx.DrawRectangle(new XSolidBrush(XColors.Red), mLeft, mTop, 560, heightRec + 8); // Draw the background color
            gfx.DrawString("Thông tin chuyến bay", fontSubTitle, XBrushes.White, new XPoint(mLeft + 5, mTop + 20));

            mTop += 35;

            gfx.DrawRectangle(backgroundBrush, mLeft, mTop, 560, heightRec); // Draw the background color
            gfx.DrawString("Chuyến bay", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.ChuyenBay.MaCB, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            mLeft += 110;
            gfx.DrawString("Ngày", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.ChuyenBay.NgayBay.ToString("dd/MM/yyyy"), fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            mLeft += 90;
            gfx.DrawString("Loại vé", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.LoaiVe.TenLoai, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            mLeft += 80;
            gfx.DrawString("Khởi hành", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.ChuyenBay.CatCanh.ToString(@"hh\:mm") + " - " + ve.ChuyenBay.XuatPhat, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            mLeft += 130;
            gfx.DrawString("Đến", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.ChuyenBay.HaCanh.ToString(@"hh\:mm") + " - " + ve.ChuyenBay.Den, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));


            mLeft = 20;
            mTop += 15;
            x1 = 20; // X-coordinate of the start point
            y1 = mTop + 30; // Y-coordinate of the start point
            x2 = 580;
            y2 = mTop + 30;
            gfx.DrawLine(pen, x1, y1, x2, y2);

            mTop += 40;
            gfx.DrawRectangle(new XSolidBrush(XColors.Red), mLeft, mTop, 560, heightRec + 8); // Draw the background color
            gfx.DrawString("Giá vé và lệ phí", fontSubTitle, XBrushes.White, new XPoint(mLeft + 5, mTop + 20));
            mTop += 35;

            gfx.DrawRectangle(backgroundBrush, mLeft, mTop, 560, heightRec); // Draw the background color
            gfx.DrawString("Leg", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString("1", fontInfo2, XBrushes.Black, new XPoint(mLeft + 15, mTop + 35));

            mLeft += 40;
            gfx.DrawString("Tên hành khách", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.KhachHang.HoTen, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            mLeft += 160;
            gfx.DrawString("Mô tả", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString("Ve may bay Loai " + ve.LoaiVe.TenLoai, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            mLeft += 160;
            gfx.DrawString("Số tiền", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.LoaiVe.Gia.ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            mLeft += 100;
            gfx.DrawString("Cộng", fontH1, XBrushes.White, new XPoint(mLeft + 5, mTop + 15));
            gfx.DrawString(ve.LoaiVe.Gia.ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            if(ve.HanhLy.Gia != null)
            {
                mTop += 15;
                mLeft = 20;
                gfx.DrawString("1", fontInfo2, XBrushes.Black, new XPoint(mLeft + 15, mTop + 35));
                mLeft += 40;
                gfx.DrawString(ve.KhachHang.HoTen, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));
                mLeft += 160;
                gfx.DrawString("Hanh ly ky gui " + ve.HanhLy.Cannang + "kg", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));
                mLeft += 160;
                gfx.DrawString(((decimal)ve.HanhLy.Gia).ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));
                mLeft += 100;
                gfx.DrawString(((decimal)ve.HanhLy.Gia).ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));
            }
            foreach(GoiMon gm in ve.GM)
            {
                mTop += 15;
                mLeft = 20;
                gfx.DrawString(gm.SoLuong.ToString(), fontInfo2, XBrushes.Black, new XPoint(mLeft + 15, mTop + 35));

                mLeft += 40;
                gfx.DrawString(ve.KhachHang.HoTen, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

                mLeft += 160;
                gfx.DrawString("Suat An" + gm.SA.TenSA, fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

                mLeft += 160;
                gfx.DrawString(gm.TongTien().ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

                mLeft += 100;
                gfx.DrawString(gm.TongTien().ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));

            }

            mTop += 20;
            mLeft = 20;
            mLeft += 260;
            gfx.DrawString("Tổng cộng: ", fontInfo1, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));
            mLeft += 100;
            gfx.DrawString(ve.CalTongTien().ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));
            mLeft += 100;
            gfx.DrawString(ve.CalTongTien().ToString("N0") + " VND", fontInfo2, XBrushes.Black, new XPoint(mLeft + 5, mTop + 35));


            string filePath = @$"C:\Users\Canh\Downloads\{ve.MaVe.ToUpper()}.pdf";

            pdfDocument.Save(filePath);
        }
    }
}
class MyFontResolver : IFontResolver
{
    public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
    {
        // Ignore case of font names.
        var name = familyName.ToLower().TrimEnd('#');

        // Deal with the fonts we know.
        switch (name)
        {
            case "arial":
                if (isBold)
                {
                    if (isItalic)
                        return new FontResolverInfo("Arial#bi");
                    return new FontResolverInfo("Arial#b");
                }
                if (isItalic)
                    return new FontResolverInfo("Arial#i");
                return new FontResolverInfo("Arial#");
        }

        // We pass all other font requests to the default handler.
        // When running on a web server without sufficient permission, you can return a default font at this stage.
        return PlatformFontResolver.ResolveTypeface(familyName, isBold, isItalic);
    }

    /// <summary>
    /// Return the font data for the fonts.
    /// </summary>
    public byte[] GetFont(string faceName)
    {
        switch (faceName)
        {
            case "Arial#":
                return FontHelper.Arial;

            case "Arial#b":
                return FontHelper.ArialBold;

            case "Arial#i":
                return FontHelper.ArialItalic;

            case "Arial#bi":
                return FontHelper.ArialBoldItalic;
        }

        return null;
    }


    internal static MyFontResolver OurGlobalFontResolver = null;

    /// <summary>
    /// Ensure the font resolver is only applied once (or an exception is thrown)
    /// </summary>
    internal static void Apply()
    {
        if (OurGlobalFontResolver == null || GlobalFontSettings.FontResolver == null)
        {
            if (OurGlobalFontResolver == null)
                OurGlobalFontResolver = new MyFontResolver();

            GlobalFontSettings.FontResolver = OurGlobalFontResolver;
        }
    }
}


/// <summary>
/// Helper class that reads font data from embedded resources.
/// </summary>
public static class FontHelper
{
    public static byte[] Arial
    {
        get { return LoadFontData("QuanLyVeMayBay.fonts.arial.arial.ttf"); }
    }

    public static byte[] ArialBold
    {
        get { return LoadFontData("QuanLyVeMayBay.fonts.arial.arialbd.ttf"); }
    }

    public static byte[] ArialItalic
    {
        get { return LoadFontData("QuanLyVeMayBay.fonts.arial.ariali.ttf"); }
    }

    public static byte[] ArialBoldItalic
    {
        get { return LoadFontData("QuanLyVeMayBay.fonts.arial.arialbi.ttf"); }
    }

    /// <summary>
    /// Returns the specified font from an embedded resource.
    /// </summary>
    static byte[] LoadFontData(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();

        // Test code to find the names of embedded fonts
        //var ourResources = assembly.GetManifestResourceNames();

        using (Stream stream = assembly.GetManifestResourceStream(name))
        {
            if (stream == null)
                throw new ArgumentException("No resource with name " + name);

            int count = (int)stream.Length;
            byte[] data = new byte[count];
            stream.Read(data, 0, count);
            return data;
        }
    }
}