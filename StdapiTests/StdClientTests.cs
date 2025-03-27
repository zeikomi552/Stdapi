using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stdapi;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stdapi.Tests
{
    [TestClass()]
    public class StdClientTests
    {
        [TestMethod()]
        public async Task Txt2ImgRequestTest()
        {
            StdClient client = new StdClient();

            var ret = await client.Txt2ImgRequest("http://127.0.0.1:7861", new Models.StdTxt2ImageM()
            {
                Prompt = "test",
            });

            Assert.AreEqual(ret.Images.Count, 1);

            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
            var base64 = ret.Images.ElementAt(0);
            StdClient.ConvertImage(base64, Path.Combine(stCurrentDir, @"testimg\result1.png"));

        }

        [TestMethod()]
        public async Task Img2ImgRequestTest()
        {
            StdClient client = new StdClient();

            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
            var ret = await client.Img2ImgRequest("http://127.0.0.1:7861", Path.Combine(stCurrentDir, @"testimg\Image1.png"), new Models.StdImg2ImgM()
            {
                Prompt = "test",
            });
            Assert.AreEqual(ret.Images.Count, 1);

            var base64 = ret.Images.ElementAt(0);
            StdClient.ConvertImage(base64, Path.Combine(stCurrentDir, @"testimg\result2.png"));


        }

        [TestMethod()]
        public async Task SdModelsRequestTest()
        {
            StdClient client = new StdClient();

            string stCurrentDir = System.IO.Directory.GetCurrentDirectory();
            var ret = await client.SdModelsRequest("http://127.0.0.1:7861");

            Assert.IsTrue(ret.Count > 0);
        }
    }
}