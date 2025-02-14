﻿using Stdapi.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stdapi.Models
{
    public class StdTxt2ImageM : StdBaseModel
    {
        public const string Endpoint = "/sdapi/v1/txt2img";

        Random _Rand = new Random();

        #region チェックポイント[CheckPoint]プロパティ
        /// <summary>
        /// チェックポイント[CheckPoint]プロパティ用変数
        /// </summary>
        string _CheckPoint = string.Empty;
        /// <summary>
        /// チェックポイント[CheckPoint]プロパティ
        /// </summary>
        public string CheckPoint
        {
            get
            {
                return _CheckPoint;
            }
            set
            {
                if (_CheckPoint == null || !_CheckPoint.Equals(value))
                {
                    _CheckPoint = value;
                    RaisePropertyChanged("CheckPoint");
                }
            }
        }
        #endregion

        #region Prompt for Webui A1111 api[Prompt]プロパティ
        /// <summary>
        /// Prompt for Webui A1111 api[Prompt]プロパティ用変数
        /// </summary>
        string _Prompt = string.Empty;
        /// <summary>
        /// Prompt for Webui A1111 api[Prompt]プロパティ
        /// </summary>
        public string Prompt
        {
            get
            {
                return _Prompt;
            }
            set
            {
                if (_Prompt == null || !_Prompt.Equals(value))
                {
                    _Prompt = value;
                    RaisePropertyChanged("Prompt");
                }
            }
        }
        #endregion

        #region Negative Prompt for Webui A1111 api[NegativePrompt]プロパティ
        /// <summary>
        /// Negative Prompt for Webui A1111 api[NegativePrompt]プロパティ用変数
        /// </summary>
        string _NegativePrompt = string.Empty;
        /// <summary>
        /// Negative Prompt for Webui A1111 api[NegativePrompt]プロパティ
        /// </summary>
        public string NegativePrompt
        {
            get
            {
                return _NegativePrompt;
            }
            set
            {
                if (_NegativePrompt == null || !_NegativePrompt.Equals(value))
                {
                    _NegativePrompt = value;
                    RaisePropertyChanged("NegativePrompt");
                }
            }
        }
        #endregion

        #region Steps[Steps]プロパティ
        /// <summary>
        /// Steps[Steps]プロパティ用変数
        /// </summary>
        int _Steps = 40;
        /// <summary>
        /// Steps[Steps]プロパティ
        /// </summary>
        public int Steps
        {
            get
            {
                return _Steps;
            }
            set
            {
                if (!_Steps.Equals(value))
                {
                    _Steps = value;
                    RaisePropertyChanged("Steps");
                }
            }
        }
        #endregion

        #region Picture width[Width]プロパティ
        /// <summary>
        /// Picture width[Width]プロパティ用変数
        /// </summary>
        int _Width = 512;
        /// <summary>
        /// Picture width[Width]プロパティ
        /// </summary>
        public int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (!_Width.Equals(value))
                {
                    _Width = value;
                    RaisePropertyChanged("Width");
                }
            }
        }
        #endregion

        #region Picture height[Height]プロパティ
        /// <summary>
        /// Picture height[Height]プロパティ用変数
        /// </summary>
        int _Height = 768;
        /// <summary>
        /// Picture height[Height]プロパティ
        /// </summary>
        public int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                if (!_Height.Equals(value))
                {
                    _Height = value;
                    RaisePropertyChanged("Height");
                }
            }
        }
        #endregion

        #region cfg scale value[CfgScale]プロパティ
        /// <summary>
        /// cfg scale value[CfgScale]プロパティ用変数
        /// </summary>
        decimal _CfgScale = 7;
        /// <summary>
        /// cfg scale value[CfgScale]プロパティ
        /// </summary>
        public decimal CfgScale
        {
            get
            {
                return _CfgScale;
            }
            set
            {
                if (!_CfgScale.Equals(value))
                {
                    if (value >= 0 && value <= 30)
                    {
                        _CfgScale = value;
                        RaisePropertyChanged("CfgScale");
                    }
                }
            }
        }
        #endregion

        #region Picture Sampler[SamplerIndex]プロパティ
        /// <summary>
        /// Picture Sampler[SamplerIndex]プロパティ用変数
        /// </summary>
        string _SamplerIndex = "DPM++ 2M Karras";
        /// <summary>
        /// Picture Sampler[SamplerIndex]プロパティ
        /// </summary>
        public string SamplerIndex
        {
            get
            {
                return _SamplerIndex;
            }
            set
            {
                if (_SamplerIndex == null || !_SamplerIndex.Equals(value))
                {
                    _SamplerIndex = value;
                    RaisePropertyChanged("SamplerIndex");
                    RaisePropertyChanged("Sampler");
                }
            }
        }
        #endregion

        #region Picture Sampler[Sampler]プロパティ
        /// <summary>
        /// Picture Sampler[Sampler]プロパティ
        /// </summary>
        public SamplerIndexEnum? Sampler
        {
            get
            {
                // 値を列挙してコンソールに出力する
                var samplers = Enum.GetValues(typeof(SamplerIndexEnum));

                // SamplerIndexの列挙を確認
                foreach (SamplerIndexEnum sampler in samplers)
                {
                    DescriptionAttribute? t = new DescriptionAttribute();   // Description属性を取得する
                    sampler.TryGetAttribute<DescriptionAttribute>(out t);

                    // SamplerIndexとの一致確認
                    if (t != null && t.Description.Equals(this.SamplerIndex))
                    {
                        return sampler;
                    }
                }
                return null;

            }
            set
            {
                if (_SamplerIndex == null || !_SamplerIndex.Equals(value))
                {
                    DescriptionAttribute? t = new DescriptionAttribute();   // Description属性を取得する

                    if (value != null && value.TryGetAttribute<DescriptionAttribute>(out t))
                    {
                        _SamplerIndex = t!.Description;
                        RaisePropertyChanged("Sampler");
                    }
                    else
                    {
                        _SamplerIndex = string.Empty;
                        RaisePropertyChanged("Sampler");
                    }
                }
            }
        }
        #endregion

        #region n_iter value[N_iter]プロパティ
        /// <summary>
        /// n_iter value[N_iter]プロパティ用変数
        /// </summary>
        int _N_iter = 1;
        /// <summary>
        /// n_iter value[N_iter]プロパティ
        /// </summary>
        public int N_iter
        {
            get
            {
                return _N_iter;
            }
            set
            {
                if (!_N_iter.Equals(value))
                {
                    if (value >= 1 && value <= 100)
                    {
                        _N_iter = value;
                        RaisePropertyChanged("N_iter");
                    }
                }
            }
        }
        #endregion

        #region Batch size value[BatchSize]プロパティ
        /// <summary>
        /// Batch size value[BatchSize]プロパティ用変数
        /// </summary>
        int _BatchSize = 1;
        /// <summary>
        /// Batch size value[BatchSize]プロパティ
        /// </summary>
        public int BatchSize
        {
            get
            {
                return _BatchSize;
            }
            set
            {
                if (!_BatchSize.Equals(value))
                {
                    if (value >= 1 && value <= 8)
                    {
                        _BatchSize = value;
                        RaisePropertyChanged("BatchSize");
                    }
                }
            }
        }
        #endregion

        #region Random seed[Seed]プロパティ
        /// <summary>
        /// Random seed[Seed]プロパティ用変数
        /// </summary>
        Int64 _Seed = -1;
        /// <summary>
        /// Random seed[Seed]プロパティ
        /// </summary>
        public Int64 Seed
        {
            get
            {
                return _Seed;
            }
            set
            {
                if (!_Seed.Equals(value))
                {
                    _Seed = value;
                    RaisePropertyChanged("Seed");
                }
            }
        }
        #endregion

        #region Seed値のバックアップ（最後に実行したSeed値）[SeedBackup]プロパティ
        /// <summary>
        /// Seed値のバックアップ（最後に実行したSeed値）[SeedBackup]プロパティ用変数
        /// </summary>
        Int64 _SeedBackup = -1;
        /// <summary>
        /// Seed値のバックアップ（最後に実行したSeed値）[SeedBackup]プロパティ
        /// </summary>
        public Int64 SeedBackup
        {
            get
            {
                return _SeedBackup;
            }
            set
            {
                if (!_SeedBackup.Equals(value))
                {
                    _SeedBackup = value;
                    RaisePropertyChanged("SeedBackup");
                }
            }
        }
        #endregion


        #region 512x768のような文字列を幅と高さに分割する
        /// <summary>
        /// 512x768のような文字列を幅と高さに分割する
        /// </summary>
        /// <param name="size">サイズ</param>
        /// <param name="w">幅</param>
        /// <param name="h">高さ</param>
        /// <returns>true:分割成功 false:分割失敗(デフォルト 512x768)</returns>
        public static bool SizeToWH(string size, out int w, out int h)
        {
            string[] wh = size.Split('x');

            if (wh.Length >= 2)
            {
                int tmp;
                w = int.TryParse(wh[0], out tmp) ? tmp : 512;
                h = int.TryParse(wh[1], out tmp) ? tmp : 768;
                return true;
            }
            else
            {
                w = 512;
                h = 768;
                return false;
            }

        }
        #endregion

        #region Payloadの作成処理
        /// <summary>
        /// Payloadの作成処理
        /// </summary>
        /// <returns></returns>
        public StringContent GetPayload()
        {
            var prompt = this;
            this.SeedBackup = _Rand.Next(); // ランダムのSeed値を作成しておく

            var data = new
            {
                prompt = prompt.Prompt,
                negative_prompt = prompt.NegativePrompt,
                steps = prompt.Steps,
                width = prompt.Width,
                height = prompt.Height,
                cfg_scale = prompt.CfgScale,
                sampler_index = prompt.SamplerIndex,
                n_iter = prompt.N_iter,
                batch_size = prompt.BatchSize,
                seed = prompt.Seed < 0 ? this.SeedBackup : prompt.Seed,
                //override_settings = new
                //{
                //    sd_model_checkpoint = prompt.CheckPoint
                //}
            };

            Debug.WriteLine(data.ToString());

            return data.AsJson();
        }
        #endregion

    }
}
