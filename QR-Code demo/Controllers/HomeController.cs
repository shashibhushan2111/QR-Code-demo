using Microsoft.AspNetCore.Mvc;
using QR_Code_demo.Models;
using QRCoder;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace QR_Code_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string inputText)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator QrGenerator = new QRCodeGenerator();
                QRCodeData QrData = QrGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q);
                QRCode obj = new QRCode(QrData);
                using (Bitmap bitmap = obj.GetGraphic(20))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    ViewBag.QrCode = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}