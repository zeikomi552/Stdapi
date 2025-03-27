using Stdapi.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stdapi.Models.Post
{
    public class PostOptions : StdBaseModel
    {
        public const string Endpoint = "/sdapi/v1/options";

        #region sd_model_checkpoint
        /// <summary>
        /// sd_model_checkpoint
        /// </summary>
        string _SdModelCheckpoint = string.Empty;
        /// <summary>
        /// sd_model_checkpoint
        /// </summary>
        public string SdModelCheckpoint
        {
            get
            {
                return _SdModelCheckpoint;
            }
            set
            {
                if (_SdModelCheckpoint == null || !_SdModelCheckpoint.Equals(value))
                {
                    _SdModelCheckpoint = value;
                    RaisePropertyChanged("SdModelCheckpoint");
                }
            }
        }
        #endregion

        #region CLIP_stop_at_last_layers
        /// <summary>
        /// CLIP_stop_at_last_layers
        /// </summary>
        int _CLIPStopAtLastLayers = 2;
        /// <summary>
        /// CLIP_stop_at_last_layers
        /// </summary>
        public int CLIPStopAtLastLayers
        {
            get
            {
                return _CLIPStopAtLastLayers;
            }
            set
            {
                if (!_CLIPStopAtLastLayers.Equals(value))
                {
                    _CLIPStopAtLastLayers = value;
                    RaisePropertyChanged("CLIPStopAtLastLayers");
                }
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

            var data = new
            {
                sd_model_checkpoint = prompt.SdModelCheckpoint,
                CLIP_stop_at_last_layers = prompt.CLIPStopAtLastLayers,
            };

            Debug.WriteLine(data.ToString());

            return data.AsJson();
        }
        #endregion
    }
}
