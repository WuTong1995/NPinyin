using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPinyin
{
    public class Pinyin
    {
        /// <summary>
        /// 配置项
        /// </summary>
        private PinyinOption option;

        /// <summary>
        /// 参数配置
        /// </summary>
        public PinyinOption Option
        {
            get
            {
                if (option == null)
                {
                    option = new PinyinOption();
                }
                return option;
            }
            set
            {
                option = value;
            }
        }

        public Pinyin()
        {

        }

        public Pinyin(PinyinOption option)
        {
            Option = option;
        }

        /// <summary>
        /// 汉字转拼音
        /// </summary>
        /// <param name="hans">汉字字符串</param>
        /// <returns>拼音字符串</returns>
        public string ConvertToPinyin(string hans)
        {
            if (string.IsNullOrEmpty(hans)) return "";
            var len = hans.Length;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < len; i++)
            {
                sb.Append(GetSinglePinyin(hans[i].ToString()));
            }
            return sb.ToString().Trim();
        }

        private string GetSinglePinyin(string word)
        {
            var code = StringToHex(word, Encoding.BigEndianUnicode);
            if (PinyinDict.PinyinData.ContainsKey(code))
            {
                var pinyinStr = PinyinDict.PinyinData[code].Split(',')[0];
                return FormatPinyin(pinyinStr, Option.Style) + (Option.EnableInterval == true ? " " : "");
            }
            else
            {
                return word;
            }
        }

        /// <summary>
        /// 格式化拼音字符串
        /// </summary>
        /// <param name="pinyin">拼音字符串</param>
        /// <param name="style">格式化类型</param>
        /// <returns></returns>
        private string FormatPinyin(string pinyin, PinyinStyle style)
        {
            switch (style)
            {
                case PinyinStyle.Normal:
                    pinyin = GetNormalPinyin(pinyin);
                    break;
                case PinyinStyle.Tone:
                    break;
                case PinyinStyle.Tone2:
                    pinyin = GetTone2Pinyin(pinyin);
                    break;
                case PinyinStyle.Tone3:
                    pinyin = GetTone3Pinyin(pinyin);
                    break;
                case PinyinStyle.Initial:
                    pinyin = GetInitialPinyin(pinyin);
                    break;
                case PinyinStyle.FirstLetter:
                    pinyin = GetFirstLetterPinyin(pinyin);
                    break;
                default:
                    break;
            }
            return pinyin;
        }

        private string GetNormalPinyin(string pinyin)
        {
            var sb = new StringBuilder();
            foreach (var item in pinyin)
            {
                if (PinyinDict.PhoneticSymbol.ContainsKey(item.ToString()))
                {
                    sb.Append(PinyinDict.PhoneticSymbol[item.ToString()].Remove(1));
                }
                else
                {
                    sb.Append(item.ToString());
                }
            }
            return sb.ToString();
        }

        private string GetTone2Pinyin(string pinyin)
        {
            var sb = new StringBuilder();
            var tone = "";
            foreach (var item in pinyin)
            {
                if (PinyinDict.PhoneticSymbol.ContainsKey(item.ToString()))
                {
                    var temp = PinyinDict.PhoneticSymbol[item.ToString()];
                    sb.Append(temp.Remove(1));
                    tone = temp.Substring(1);
                }
                else
                {
                    sb.Append(item.ToString());
                }
            }
            sb.Append(tone);
            return sb.ToString();
        }

        private string GetTone3Pinyin(string pinyin)
        {
            var sb = new StringBuilder();
            foreach (var item in pinyin)
            {
                if (PinyinDict.PhoneticSymbol.ContainsKey(item.ToString()))
                {
                    sb.Append(PinyinDict.PhoneticSymbol[item.ToString()]);
                }
                else
                {
                    sb.Append(item.ToString());
                }
            }
            return sb.ToString();
        }

        private string GetInitialPinyin(string pinyin)
        {
            foreach (var item in PinyinDict.InitialData)
            {
                if (pinyin.Contains(item))
                {
                    return item;
                }
            }
            return "";
        }

        private string GetFirstLetterPinyin(string pinyin)
        {
            if (string.IsNullOrEmpty(pinyin)) return "";
            var firstCode = pinyin[0].ToString();
            if (PinyinDict.PhoneticSymbol.ContainsKey(firstCode))
            {
                return PinyinDict.PhoneticSymbol[firstCode].Remove(1);
            }
            return firstCode;
        }

        /// <summary>
        /// 字符串转16进制
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="encode">编码方式</param>
        /// <returns></returns>
        private int StringToHex(string str, Encoding encode)
        {
            var byteArr = encode.GetBytes(str);
            var sb = new StringBuilder();
            for (int i = 0; i < byteArr.Length; i++)
            {
                var tempByte = Convert.ToString(byteArr[i], 16);
                sb.Append(tempByte.Length == 2 ? tempByte : "0" + tempByte);
            }
            return Convert.ToInt32(sb.ToString(), 16);
        }

    }
}
