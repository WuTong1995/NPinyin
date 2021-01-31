using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPinyin
{
    /// <summary>
    /// 拼音风格
    /// </summary>
    public enum PinyinStyle
    {
        /// <summary>
        /// 不带声调
        /// </summary>
        Normal,

        /// <summary>
        /// 声调在韵母的第一个字母上
        /// </summary>
        Tone,

        /// <summary>
        /// 声调以数字形式在拼音之后，使用数字 0~4 标识
        /// </summary>
        Tone2,

        /// <summary>
        /// 声调以数字形式在声母之后，使用数字 0~4 标识
        /// </summary>
        Tone3,

        /// <summary>
        /// 仅需要声母部分
        /// </summary>
        Initial,

        /// <summary>
        /// 仅保留首字母
        /// </summary>
        FirstLetter

    }
}
