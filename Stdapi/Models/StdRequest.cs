using Stdapi.Models.Get;
using Stdapi.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stdapi.Models
{
    public class StdRequest : StdBaseModel
    {
        #region 接続用クライアントの作成
        /// <summary>
        /// 接続用クライアントの作成
        /// </summary>
        /// <param name="url">パラメータ</param>
        /// <returns>Task</returns>
        public async Task<string> RequestPost(string url, StringContent payload)
        {
            using (var client = new HttpClient())
            {
                // タイムアウト無制限
                client.Timeout = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);

                // 上から来たクエリをそのまま実行
                var response = await client.PostAsync(url, payload);

                // レスポンスを返却
                return await response.Content.ReadAsStringAsync();
            }
        }
        #endregion

        #region 接続用クライアントの作成
        /// <summary>
        /// 接続用クライアントの作成
        /// </summary>
        /// <param name="url">パラメータ</param>
        /// <returns>Task</returns>
        public async Task<string> RequestGet(string url)
        {
            using (var client = new HttpClient())
            {
                // タイムアウト無制限
                client.Timeout = new TimeSpan(0, 0, 0, 0, Timeout.Infinite);

                // 上から来たクエリをそのまま実行
                var response = await client.GetAsync(url);

                // レスポンスを返却
                return await response.Content.ReadAsStringAsync();
            }
        }
        #endregion

        //#region Base64文字列をファイルに保存する処理
        ///// <summary>
        ///// Base64文字列をファイルに保存する処理
        ///// </summary>
        ///// <param name="fullOutputPath">出力先ファイルパス</param>
        ///// <param name="base64String">Base64文字列</param>
        //private void SaveByteArrayAsImage(string fullOutputPath, string base64String)
        //{
        //    // ディレクトリがない場合は作成する
        //    PathManager.CreateCurrentDirectory(fullOutputPath);

        //    // Base64文字列をbyteに分解
        //    byte[] bytes = Convert.FromBase64String(base64String);

        //    // ファイルに保存する
        //    File.WriteAllBytes(fullOutputPath, bytes);
        //}
        //#endregion

        //#region POSTのリクエスト実行処理
        ///// <summary>
        ///// POSTのリクエスト実行処理
        ///// </summary>
        ///// <param name="uri">URI</param>
        ///// <param name="outdir">出力先ディレクトリ</param>
        //public async Task<(bool, List<string>)> Text2ImgRequest(string uri, string outdir, string filename, StdTxt2ImageM prompt)
        //{
        //    StdPostResponseM tmp = new StdPostResponseM();
        //    string request = string.Empty;

        //    // エンドポイント + パラメータ
        //    string url = uri + StdTxt2ImageM.Endpoint;

        //    StringContent payload = prompt.GetPayload();    // Payloadの取得
        //    request = await tmp.RequestPost(url, payload);      // Requestの実行

        //    // 実行してJSON形式をデシリアライズ
        //    var request_model = JSONUtil.DeserializeFromText<StdPostResponseM>(request);

        //    int count = 0;
        //    List<string> ret_path = new List<string>();
        //    foreach (var base64string in request_model.Images)
        //    {
        //        string path = Path.Combine(outdir, $"{filename + count.ToString()}.png");
        //        SaveByteArrayAsImage(path, base64string);
        //        ret_path.Add(path);
        //        count++;
        //    }

        //    return (true, ret_path);
        //}
        //#endregion

        //#region POSTのリクエスト実行処理
        ///// <summary>
        ///// POSTのリクエスト実行処理
        ///// </summary>
        ///// <param name="uri">URI</param>
        ///// <param name="outdir">出力先ディレクトリ</param>
        //public async Task<(bool, List<GetSdModels>)> GetSdModelsRequest(string uri)
        //{
        //    // エンドポイント + パラメータ
        //    string url = uri + GetSdModels.Endpoint;

        //    string request = await this.RequestGet(url);      // Requestの実行

        //    // 実行してJSON形式をデシリアライズ
        //    var request_model = JSONUtil.DeserializeFromText<List<GetSdModels>>(request);

            
        //    return (true, request_model);
        //}
        //#endregion

    }
}
