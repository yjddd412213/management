using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace PaymentManagement.CommonCode
{
    public class Common
    {
        public static void SendFileToClient(string filePath, string mimeFileType, string orignalName, Page page)
        {
            if (filePath != "")
            {
                if (File.Exists(filePath))
                {
                    System.IO.FileInfo file = new System.IO.FileInfo(filePath);

                    page.Response.Charset = "GB2312";
                    page.Response.ContentEncoding = System.Text.Encoding.UTF8;
                    page.Response.AddHeader("Content-Disposition", "attachment; filename=" + page.Server.UrlEncode(orignalName));
                    page.Response.AddHeader("Content-Length", file.Length.ToString());
                    page.Response.ContentType = mimeFileType;
                    page.Response.WriteFile(file.FullName);
                    page.Response.Flush();
                    page.Response.Close();
                }
                else
                {
                    throw new Exception("文件不存在！");
                }
            }
        }

        public static string GetMIMEFileType(string orignalType)
        {
            switch (orignalType.ToLower())
            {
                case "pdf":
                    return "application/pdf";
                case "doc":
                    return "application/word";
                case "dot":
                    return "application/word";
                case "docx":
                    return "application/word";
                case "xls":
                    return "application/excel";
                case "xlsx":
                    return "application/excel";
                case "ppt":
                    return "application/powerpoint";
                case "pptx":
                    return "application/powerpoint";
                case "ppz":
                    return "application/powerpoint";
                case "pps":
                    return "application/powerpoint";
                case "pot":
                    return "application/powerpoint";
                default:
                    return "application/octet-stream";
            }
        }

        public static string ClearHtmlTag(string strText)
        {
            Regex regexTagStart = new Regex("<([^<^>]*)>", RegexOptions.IgnoreCase | RegexOptions.Compiled);
            strText = regexTagStart.Replace(strText, "");

            return strText;
        }

        public static string CutText(string text, int length)
        {
            if (text.Length > length)
            {
                text = text.Substring(0, length - 1);
            }

            return text;
        }

        public static System.Drawing.Image CutFixSizeImg(System.IO.Stream stream, int intWidth, int intHeight)
        {
            Bitmap img = new Bitmap(CutFixSizeImgPrev(stream, intWidth, intHeight));

            int nFixWidth = intWidth;
            int nFixHeight = intHeight;
            int nWidthStart = 0;
            int nHeightStart = 0;
            //pic's size
            int nImgWidth = 0;
            int nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            //
            if (nImgWidth > nFixWidth)
            {
                nWidthStart = (nImgWidth - nFixWidth) / 2;
            }
            else
            {
                nFixWidth = nImgWidth;
            }

            if (nImgHeight > nFixHeight)
            {
                nHeightStart = (nImgHeight - nFixHeight) / 2;
            }
            else
            {
                nFixHeight = nImgHeight;
            }
            Bitmap picReturn = img.Clone(new Rectangle(nWidthStart, nHeightStart, nFixWidth, nFixHeight), System.Drawing.Imaging.PixelFormat.Format24bppRgb);


            return picReturn;
        }

        public static System.Drawing.Image CutFixSizeImgPrev(System.IO.Stream stream, int intWidth, int intHeight)
        {
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            //
            double nImgWidth = 0;
            double nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            double nWidth = intWidth;
            double nHeight = intHeight;
            if (nImgWidth > nWidth && nWidth < (nImgWidth * nHeight) / nImgHeight)
            {
                nImgWidth = (nImgWidth * nHeight) / nImgHeight;
                nImgHeight = nHeight;
            }
            else if (nImgHeight > nHeight && nHeight < nWidth * nImgHeight / nImgWidth)
            {
                nImgHeight = nWidth * nImgHeight / nImgWidth;
                nImgWidth = nWidth;
            }

            Bitmap picReturn = new Bitmap(Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));
            Graphics g = Graphics.FromImage(picReturn);

            g.DrawImage(img, 0, 0, Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));

            //
            return picReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static System.Drawing.Image GetFixSizeImg(System.IO.Stream stream)
        {
            /*
             example:
             //oFileUpload.SaveAs(MapPath(_sitepath) + "\\uploads\\" + oFileUpload.FileName);
             Common.GetFixSizeImg(oFileUpload.PostedFile.InputStream).Save(MapPath(_sitepath) + "\\uploads\\" + oFileUpload.FileName);
             * 
             * Height : 313px
             */
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            //
            double nImgWidth = 0;
            double nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;
            int nWidth = img.Size.Width;
            int nHeight = 313;
            if (nImgHeight > 313)
            {
                //
                double dblWidth = nHeight * (nImgWidth / nImgHeight);
                nWidth = Convert.ToInt32(dblWidth);
            }
            else
            {
                nHeight = img.Size.Height;
            }

            Bitmap picReturn = new Bitmap(nWidth, nHeight);
            Graphics g = Graphics.FromImage(picReturn);

            g.DrawImage(img, 0, 0, nWidth, nHeight);

            //
            return picReturn;
        }

        public static System.Drawing.Image FixSize(System.IO.Stream stream, int intFixedWidth)
        {
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            //
            double nImgWidth = img.Size.Width; ;
            double nImgHeight = img.Size.Height;

            int nWidth = intFixedWidth;
            int nHeight = img.Size.Height;

            if (nImgWidth > intFixedWidth)
            {
                //
                double dblHeight = nHeight * (nWidth / nImgWidth);
                nHeight = Convert.ToInt32(dblHeight);
            }
            else
            {
                nWidth = img.Size.Width;
            }

            Bitmap picReturn = new Bitmap(nWidth, nHeight);
            Graphics g = Graphics.FromImage(picReturn);

            g.DrawImage(img, 0, 0, nWidth, nHeight);


            //
            return picReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static System.Drawing.Image CutFixSizeImg(System.IO.Stream stream)
        {
            /*
             example:
             //oFileUpload.SaveAs(MapPath(_sitepath) + "\\uploads\\" + oFileUpload.FileName);
             Common.GetFixSizeImg(oFileUpload.PostedFile.InputStream).Save(MapPath(_sitepath) + "\\uploads\\" + oFileUpload.FileName);
             * 
             * Width  : 160px
             * Height : 180px
             */
            Bitmap img = new Bitmap(CutFixSizeImgPreGallery(stream));

            int nFixWidth = 137;
            int nFixHeight = 88;
            int nWidthStart = 0;
            int nHeightStart = 0;
            //pic's size
            int nImgWidth = 0;
            int nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            //
            if (nImgWidth > nFixWidth)
            {
                nWidthStart = (nImgWidth - nFixWidth) / 2;
            }
            else
            {
                nFixWidth = nImgWidth;
            }

            if (nImgHeight > nFixHeight)
            {
                nHeightStart = (nImgHeight - nFixHeight) / 2;
            }
            else
            {
                nFixHeight = nImgHeight;
            }
            Bitmap picReturn = img.Clone(new Rectangle(nWidthStart, nHeightStart, nFixWidth, nFixHeight), System.Drawing.Imaging.PixelFormat.Format24bppRgb);


            return picReturn;
        }

        public static System.Drawing.Image CutFixSizeImgMedia(System.IO.Stream stream)
        {
            /*
             example:
             //oFileUpload.SaveAs(MapPath(_sitepath) + "\\uploads\\" + oFileUpload.FileName);
             Common.GetFixSizeImg(oFileUpload.PostedFile.InputStream).Save(MapPath(_sitepath) + "\\uploads\\" + oFileUpload.FileName);
             * 
             * Width  : 160px
             * Height : 180px
             */
            Bitmap img = new Bitmap(CutFixSizeImgPreMedia(stream));

            int nFixWidth = 82;
            int nFixHeight = 57;
            int nWidthStart = 0;
            int nHeightStart = 0;
            //pic's size
            int nImgWidth = 0;
            int nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            //
            if (nImgWidth > nFixWidth)
            {
                nWidthStart = (nImgWidth - nFixWidth) / 2;
            }
            else
            {
                nFixWidth = nImgWidth;
            }

            if (nImgHeight > nFixHeight)
            {
                nHeightStart = (nImgHeight - nFixHeight) / 2;
            }
            else
            {
                nFixHeight = nImgHeight;
            }
            Bitmap picReturn = img.Clone(new Rectangle(nWidthStart, nHeightStart, nFixWidth, nFixHeight), System.Drawing.Imaging.PixelFormat.Format24bppRgb);


            return picReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static System.Drawing.Image CutFixSizeImgPreMedia(System.IO.Stream stream)
        {
            /* Width  : 160px
             * Height : 180px
             */
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            //
            double nImgWidth = 0;
            double nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            double nWidth = 82;
            double nHeight = 57;
            if (nImgWidth > nWidth && nWidth < (nImgWidth * nHeight) / nImgHeight)
            {
                nImgWidth = (nImgWidth * nHeight) / nImgHeight;
                nImgHeight = nHeight;
            }
            else if (nImgHeight > nHeight && nHeight < nWidth * nImgHeight / nImgWidth)
            {
                nImgHeight = nWidth * nImgHeight / nImgWidth;
                nImgWidth = nWidth;
            }

            Bitmap picReturn = new Bitmap(Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));
            Graphics g = Graphics.FromImage(picReturn);

            g.DrawImage(img, 0, 0, Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));

            //
            return picReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static System.Drawing.Image CutFixSizeImgPre(System.IO.Stream stream)
        {
            /* Width  : 160px
             * Height : 180px
             */
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            //
            double nImgWidth = 0;
            double nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            double nWidth = 48;
            double nHeight = 48;
            if (nImgWidth > nWidth && nWidth < (nImgWidth * nHeight) / nImgHeight)
            {
                nImgWidth = (nImgWidth * nHeight) / nImgHeight;
                nImgHeight = nHeight;
            }
            else if (nImgHeight > nHeight && nHeight < nWidth * nImgHeight / nImgWidth)
            {
                nImgHeight = nWidth * nImgHeight / nImgWidth;
                nImgWidth = nWidth;
            }

            Bitmap picReturn = new Bitmap(Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));
            Graphics g = Graphics.FromImage(picReturn);

            g.DrawImage(img, 0, 0, Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));

            //
            return picReturn;
        }

        public static System.Drawing.Image CutFixSizeImgPreGallery(System.IO.Stream stream)
        {
            /* Width  : 160px
             * Height : 180px
             */
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            //
            double nImgWidth = 0;
            double nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            double nWidth = 137;
            double nHeight = 88;
            if (nImgWidth > nWidth && nWidth < (nImgWidth * nHeight) / nImgHeight)
            {
                nImgWidth = (nImgWidth * nHeight) / nImgHeight;
                nImgHeight = nHeight;
            }
            else if (nImgHeight > nHeight && nHeight < nWidth * nImgHeight / nImgWidth)
            {
                nImgHeight = nWidth * nImgHeight / nImgWidth;
                nImgWidth = nWidth;
            }

            Bitmap picReturn = new Bitmap(Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));
            Graphics g = Graphics.FromImage(picReturn);

            g.DrawImage(img, 0, 0, Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));

            //
            return picReturn;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static System.Drawing.Image CutSizeImg(System.IO.Stream stream, double width, double height)
        {
            System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stream);

            //
            double nImgWidth = 0;
            double nImgHeight = 0;
            nImgWidth = img.Size.Width;
            nImgHeight = img.Size.Height;

            double nWidth = width;
            double nHeight = height;

            if (nImgWidth > nWidth && nWidth < (nImgWidth * nHeight) / nImgHeight)
            {
                nImgWidth = (nImgWidth * nHeight) / nImgHeight;
                nImgHeight = nHeight;
            }
            else if (nImgHeight > nHeight && nHeight < nWidth * nImgHeight / nImgWidth)
            {
                nImgHeight = nWidth * nImgHeight / nImgWidth;
                nImgWidth = nWidth;
            }

            Bitmap picReturn = new Bitmap(Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));
            Graphics g = Graphics.FromImage(picReturn);

            g.DrawImage(img, 0, 0, Convert.ToInt32(nImgWidth), Convert.ToInt32(nImgHeight));

            //
            return picReturn;
        }

        public static bool ThumbnailCallback()
        {
            return false;
        }

        public static string GetPath(string strOriPath)
        {
            DirectoryInfo di = new DirectoryInfo(strOriPath);
            if (!di.Exists)
            {
                di.Create();
            }

            return strOriPath;
        }


        public static string GetByteString(byte[] data)
        {
            if (data == null) return "";
            return Encoding.ASCII.GetString(data);
        }
        public static byte[] GetStringByte(string data)
        {
            return Encoding.ASCII.GetBytes(data);
        }

        //
        public static string EnCodeKey(string key)
        {
            //
            string strKey = Guid.NewGuid().ToString() + key + Guid.NewGuid().ToString();
            byte[] bytData = Encoding.ASCII.GetBytes(strKey);
            strKey = Convert.ToBase64String(bytData);
            strKey = HttpUtility.UrlEncode(strKey);

            //
            return strKey;
        }
        public static string DeCodeKey(string key)
        {
            //
            string strKey = key;

            //
            strKey = HttpUtility.UrlDecode(strKey);
            byte[] bytData = Convert.FromBase64String(strKey);
            strKey = Encoding.ASCII.GetString(bytData);

            //
            int nLen = 36;
            strKey = strKey.Substring(nLen, strKey.Length - nLen * 2);

            //
            return strKey;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetFilename(string path, string filename)
        {
            string strFormat = filename.Substring(filename.LastIndexOf("."));
            FileInfo objFile = new FileInfo(path + "\\" + filename);
            while (objFile.Exists)
            {
                filename = "pic_" + GetRandomString(15) + strFormat;
                objFile = new FileInfo(path + "\\" + filename);
            }

            return filename;
        }

        public static string GetRandomString(int nLen)
        {
            string strRandomString = "";
            Random ra = new Random();
            for (int i = 0; i < nLen; i++)
            {
                strRandomString += ra.Next(0, 10).ToString();
            }
            return strRandomString;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool RemoveFile(string path, string filename)
        {
            try
            {
                FileInfo objFile = new FileInfo(path + "\\" + filename);
                if (objFile.Exists)
                {
                    objFile.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveFile(string path)
        {
            try
            {
                FileInfo objFile = new FileInfo(path);
                if (objFile.Exists)
                {
                    objFile.Delete();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// from db format to html format
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string FormatHtmlOutput(string strText)
        {
            strText = strText.Replace("\n", "<br/>");

            return strText;
        }
        /// <summary>
        /// from html format to db format
        /// </summary>
        /// <param name="strText"></param>
        /// <returns></returns>
        public static string FormatHtmlInput(string strText)
        {
            strText = strText.Replace("<br/>", "\n");

            return strText;
        }

        public static string BindUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                if (url.IndexOf("http://") == -1)
                {
                    url = "http://" + url;
                }
            }

            return url;
        }
    }
}