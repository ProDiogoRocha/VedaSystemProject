using System;
using System.IO;

namespace VedaSystem.Application.Utils
{
    public static class MemoryFile
    {
        public static MemoryStream ArquivoTemporario(string html)
        {
            Byte[] res = null;
            using (MemoryStream ms = new MemoryStream())
            {
                var pdf = TheArtOfDev.HtmlRenderer.PdfSharp.PdfGenerator.GeneratePdf(html, PdfSharp.PageSize.A4);
                pdf.Save(ms);
                res = ms.ToArray();
            }

            MemoryStream mspdf = new MemoryStream(res);

            return mspdf;
        }
    }
}
