# 汉字转拼音工具(.net 版)

将汉字转为拼音。基于 [hotoo/pinyin](https://github.com/hotoo/pinyin) 开发。 可以用于汉字注音、~~排序~~ 等。

由于工作中需要将中文转为拼音，没找到有比较好的 .net 版转拼音工具。感觉[hotoo/pinyin](https://github.com/hotoo/pinyin)比较不错，于是就用 c# 改了一下。

目前只是简单的实现了常用汉字转拼音的功能，像一些分词功能，多音字功能目前还没加，有需要的自己可以参考别的版本进行实现。

# 使用方法

引入 **NPinyin.dll**

1. 基本使用

```csharp
using NPinyin;

var hans = "中文";
var pinyin = new Pinyin();
var result = pinyin.ConvertToPinyin(hans); // zhong wen
```

2. 可选参数

```csharp
using NPinyin;

var hans = "中文";
var pinyin = new Pinyin();
pinyin.Option = new PinyinOption()
{
    Style = PinyinStyle.Normal, // 不带声调(默认) zhong wen
    // Style = PinyinStyle.Tone // 带声调 zhōng wén
    EnableInterval = true       // 多个拼音之间是否启用间隔 zhong wen  zhongwen
};
var result = pinyin.ConvertToPinyin(hans); // zhong wen
```

# 支持版本

- .NET 5.0
- .NET Framework 3.5 - 4.8

# 相关项目

- [hotoo/pinyin](https://github.com/hotoo/pinyin)：汉字拼音转换工具 Node.js/JavaScript 版
- [python-pinyin](https://github.com/mozillazg/python-pinyin)：汉字拼音转换工具 python 版

