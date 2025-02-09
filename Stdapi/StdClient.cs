using Stdapi.Models;
using Stdapi.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stdapi
{
    public class StdClient
    {
        #region POSTのリクエスト実行処理
        /// <summary>
        /// POSTのリクエスト実行処理
        /// </summary>
        /// <param name="uri">URI</param>
        /// <param name="outdir">出力先ディレクトリ</param>
        public async Task<StdPostResponseM> Txt2ImgRequest(string uri, StdTxt2ImageM prompt)
        {
            StdPostResponseM tmp = new StdPostResponseM();
            string request = string.Empty;

            // エンドポイント + パラメータ
            string url = uri + StdTxt2ImageM.Endpoint;

            StringContent payload = prompt.GetPayload();    // Payloadの取得
            request = await tmp.Request(url, payload);      // Requestの実行

            // 実行してJSON形式をデシリアライズ
            var request_model = JSONUtil.DeserializeFromText<StdPostResponseM>(request);

            return request_model;

        }
        #endregion

        #region POSTのリクエスト実行処理
        /// <summary>
        /// POSTのリクエスト実行処理
        /// </summary>
        /// <param name="uri">URI</param>
        /// <param name="outdir">出力先ディレクトリ</param>
        public async Task<StdPostResponseM> Img2ImgRequest(string uri, string inputFile, StdImg2ImgM prompt)
        {
            StdPostResponseM tmp = new StdPostResponseM();
            string request = string.Empty;

            // エンドポイント + パラメータ
            string url = uri + "/sdapi/v1/img2img";

            StringContent payload = prompt.GetPayload(inputFile);    // Payloadの取得
            request = await tmp.Request(url, payload);      // Requestの実行

            // 実行してJSON形式をデシリアライズ
            var ret = JSONUtil.DeserializeFromText<StdPostResponseM>(request);

            return ret;

        }
        #endregion

        #region Base64ファイルをイメージファイルに変換し出力します
        /// <summary>
        /// Base64ファイルをイメージファイルに変換し出力します
        /// </summary>
        /// <param name="base64Text">Base64文字列</param>
        /// <param name="filepath">出力先ファイルパス</param>
        public static void ConvertImage(string base64Text, string filepath)
        {
            SaveByteArrayAsImage(filepath, base64Text);
        }
        #endregion

        #region Base64文字列をファイルに保存する処理
        /// <summary>
        /// Base64文字列をファイルに保存する処理
        /// </summary>
        /// <param name="fullOutputPath">出力先ファイルパス</param>
        /// <param name="base64String">Base64文字列</param>
        private static void SaveByteArrayAsImage(string fullOutputPath, string base64String)
        {
            // ディレクトリがない場合は作成する
            PathManager.CreateCurrentDirectory(fullOutputPath);

            // Base64文字列をbyteに分解
            byte[] bytes = Convert.FromBase64String(base64String);

            // ファイルに保存する
            File.WriteAllBytes(fullOutputPath, bytes);
        }
        #endregion
    }
}
