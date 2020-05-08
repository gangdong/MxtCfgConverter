# MxtCfgConverter

## Introduction [介绍]
A tiny tool to translate the ATMEL maXTouch series touchscreen controller configuration file into a C header file.

ATMEL maXTouch touchscreen controller uses a specified format text file as configuration file. Under some circumstances, this kind of format file is not easy to use for the software integration, for example, when the phone was developing, it requires to load/read the chips configuration, the device driver obviously needs a standard recognizable format file rather than a specified format file. 

This tool translates it into a Hex array, outputs a standard C header file. 

Coding with C#.

一个小的windows平台下的工具，用于将ATMEL maXTouch 系列触摸屏控制芯片的配置文件转换为标准的 C 头文件。

ATMEL maXTouch触摸屏控制器使用指定格式的文本文件作为配置文件。在某些情况下，这种格式文件不易用于软件集成，例如在手机开发时，需要加载/读取芯片配置，设备驱动程序显然需要一个标准的可识别格式文件而不是指定的格式文件。

这个工具会将配置文件转换为一个通用数组的格式，输出到一个标准的C语言头文件中。以便用于软件集成开发的目的。

C# 语言开发。

## Usage
1. Build this project with VS.
2. Run "MXT Raw2Array Converter.exe".
![screenshot](https://github.com/gangdong/MxtCfgConverter/raw/master/Screenshot/Screenshot.PNG)
3. Click "import" button and select the configuration file you want to translate.
![screenshot](https://github.com/gangdong/MxtCfgConverter/raw/master/Screenshot/Screnshot1.PNG)
4. After selected one, click "convert" button to start translate, the data being translated will be displayed and refresh the text box. Once translated is done, click "save" button to store the new file into the place where you want with a C standard header file.

-----
## 使用
1. VS 下编译该工程
2. 运行 “MXT Raw2Array Converter.exe”
3. 点击 “import” 按钮并选择需要转换的配置文件
4. 点击 “convert”按钮开始进行转换，转换过程中转换的数据会实时显示在文本框内。转换完成后点击 “Save” 选择要存放的路径。保存生成的头文件。
