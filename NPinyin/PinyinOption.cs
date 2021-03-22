using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NPinyin
{
    /// <summary>
    /// 参数配置
    /// </summary>
    public class PinyinOption
    {
        /// <summary>
        /// 拼音风格
        /// </summary>
        public PinyinStyle Style { get; set; } = PinyinStyle.Normal;

        /// <summary>
        /// 拼音之间是否启用间隔
        /// </summary>
        public bool EnableInterval { get; set; } = true;
    }
}
