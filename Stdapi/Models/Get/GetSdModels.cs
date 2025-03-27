using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Stdapi.Models.Get
{
    public class GetSdModels : StdBaseModel
    {
        public const string Endpoint = "/sdapi/v1/sd-models";

        #region タイトル
        /// <summary>
        /// タイトル
        /// </summary>
        string _Title = string.Empty;
        /// <summary>
        /// タイトル
        /// </summary>
        [JsonPropertyName("title")]
        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                if (_Title == null || !_Title.Equals(value))
                {
                    _Title = value;
                    RaisePropertyChanged("Title");
                }
            }
        }
        #endregion

        #region モデル名
        /// <summary>
        /// モデル名
        /// </summary>
        string _ModelName = string.Empty;
        /// <summary>
        /// モデル名
        /// </summary>
        [JsonPropertyName("model_name")]
        public string ModelName
        {
            get
            {
                return _ModelName;
            }
            set
            {
                if (_ModelName == null || !_ModelName.Equals(value))
                {
                    _ModelName = value;
                    RaisePropertyChanged("ModelName");
                }
            }
        }
        #endregion

        #region ハッシュ値
        /// <summary>
        /// ハッシュ値
        /// </summary>
        string _Hash = string.Empty;
        /// <summary>
        /// ハッシュ値
        /// </summary>
        [JsonPropertyName("hash")]
        public string Hash
        {
            get
            {
                return _Hash;
            }
            set
            {
                if (_Hash == null || !_Hash.Equals(value))
                {
                    _Hash = value;
                    RaisePropertyChanged("Hash");
                }
            }
        }
        #endregion

        #region Sha256
        /// <summary>
        /// Sha256
        /// </summary>
        string _Sha256 = string.Empty;
        /// <summary>
        /// Sha256
        /// </summary>
        [JsonPropertyName("sha256")]
        public string Sha256
        {
            get
            {
                return _Sha256;
            }
            set
            {
                if (_Sha256 == null || !_Sha256.Equals(value))
                {
                    _Sha256 = value;
                    RaisePropertyChanged("Sha256");
                }
            }
        }
        #endregion

        #region ファイル名
        /// <summary>
        /// ファイル名
        /// </summary>
        string _FileName = string.Empty;
        /// <summary>
        /// ファイル名
        /// </summary>
        [JsonPropertyName("filename")]
        public string FileName
        {
            get
            {
                return _FileName;
            }
            set
            {
                if (_FileName == null || !_FileName.Equals(value))
                {
                    _FileName = value;
                    RaisePropertyChanged("FileName");
                }
            }
        }
        #endregion

        #region コンフィグ
        /// <summary>
        /// コンフィグ
        /// </summary>
        string _Config = string.Empty;
        /// <summary>
        /// コンフィグ
        /// </summary>
        [JsonPropertyName("config")]
        public string Config
        {
            get
            {
                return _Config;
            }
            set
            {
                if (_Config == null || !_Config.Equals(value))
                {
                    _Config = value;
                    RaisePropertyChanged("Config");
                }
            }
        }
        #endregion


    }
}
