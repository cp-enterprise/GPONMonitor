﻿using System.Collections.Generic;

namespace GPONMonitor.Models.ComplexStateTypes
{
    public class BlockReason
    {
        private int? value;
        public int? Value
        {
            get
            {
                return value;
            }
            set
            {
                ResponseDescription responseDescription;

                if (BlockReasonResponseDictionary.ContainsKey(value))
                {
                    BlockReasonResponseDictionary.TryGetValue(value, out responseDescription);
                }
                else
                {
                    BlockReasonResponseDictionary.TryGetValue(null, out responseDescription);
                }

                DescriptionEng = responseDescription.DescriptionEng;
                DescriptionPol = responseDescription.DescriptionPol;
                Severity = responseDescription.Severity;
                this.value = value;
            }
        }

        public string DescriptionEng { get; private set; }
        public string DescriptionPol { get; private set; }
        public SeverityLevel Severity { get; private set; }


        // ONT Block Reason
        // 1 - manual block
        // 2 - sourcemac block
        // 255 - unblock

        readonly Dictionary<int?, ResponseDescription> BlockReasonResponseDictionary = new Dictionary<int?, ResponseDescription>()
        {
            { 1, new ResponseDescription("manual block", "blokada ręczna", SeverityLevel.Danger) },
            { 2, new ResponseDescription("sourcemac block", "blokada sourcemac", SeverityLevel.Danger) },
            { 255, new ResponseDescription("unblock", "brak blokady", SeverityLevel.Success) }
        };

    }
}