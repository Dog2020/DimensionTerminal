# DimensionTerminal
 摘要：DimensionTerminal是Dimensionsoft的一个新项目，旨在用户可以自己打造一个“模拟终端”，那么现在，本自述文件将为您带来如何使用“DimensionTerminal”框架（以下简称“DT框架”)

---------

## 关于DT框架
DT框架是Dimensionsoft自主研发的一个“模拟终端”框架，使用***VisualStudio***开发，未来，Dimensionsoft将会使用DT框架进行多种工作，例如管理  
但请注意，您可以无偿使用DT框架内的所有内容，但所使用的DT框架版权仍属于Dimensionsoft，如果您想要再创作后的成品版权归属与自己的话，请与Dimensionsoft联系  
联系邮箱：***coreball@foxmail.com***
下面，将为您带来如何去使用DT框架的各部分：  

1，内部后缀为：“.xaml”或“.cs”的文件均为代码文件，请规范操作  
2，请不要对“.editorconfig”,“.config”,“.csproj”,“.dll”等文件进行操作，这有可能会毁了整个框架  
3，请不要对“obj”，“.vs”，“Properties”文件夹内的文件进行操作  
4，生成的应用程序在bin\Release路径中  
5，在bin文件夹中，有TerminalLog和TerminalSettings文件夹，请注意这两个文件夹在打包后需复制粘贴至打包文件夹中，否则程序可能无法正常运行  
***6，请注意，“Dconsole..dll”文件是整个框架的核心，请不断更新它，确保这个核心永远是最新的***  
7，在使用DT框架中，您可以多看看注释以了解各代码的作用  

以上是关于DT框架的详细信息，接下来，将为您带来如何使用DT框架内的各种函数，结构体，以及其他的内容（“.cs”）  

----------
## DConsole的使用
**DConsole(namespace)**  
DConsole是框架的命名空间，在使框架前，需要：
```C#
using DConsole
```
或者使用如下方式，不使用“using”指令：
```C#
DConsole.Terminal.Console.AppendForConsole(OutPut, "hello")  //输出
```
----------
**init(func)**
在文件中，您可以看到这样一个函数：  
```C#
private void InitRun(object sender, RoutedEventArgs e)
```   
它的作用是：负责Terminal的所有主要工作  
或者您可以把它理解为一个“主函数”  

----------
**TerminalObject(class)**    
TerminalObject是整个Terminal核心类中的基础，整个Terminal离不开该类  
以下是TerminalObject类中的主要成员：
|成员名|说明|
|:----|:----:|
|`AppendForConsole(RichTextBox richtextbox, string str, AssemblyColor ac)`|在Console屏幕上追加输出“str”，输出颜色为“ac”（参数“ac”可不写）|
|`WriteForConsole(RichTextBox richtextbox, string str, AssemblyColor ac)`|在Console屏幕上先清空，后输出“str”，输出颜色为“ac”（参数“ac”可不写）|
|`GetForConsole(RichTextBox richtextbox)`|获得RichTextBox“richtextbox”内的内容并返回其内容，类型为“string”|
|`GetLen(RichTextBox name)`|返回RichTextBox“name”内的内容的长度并返回，类型为“int”|
|`Clear(RichTextBox name)`|清空“name”内的所有内容|
|`GetForTextBox(TextBox name)`|获得TextBox“name”中的内容，并返回，类型为“string”|
|`GetSplitCommand(TextBox name, char splitChar)`|获得TextBox“name”中的内容，并按‘splitChar’分割为字符列表，并返回，类型为“string[]”|
|`GetSplit(string name, char splitChar)`|按照“splitChar”分割“name”为字符列表，并返回|
  
**Example:**
如果你想输出一段文字为“hello”，可以这样做：
```C#
using DConsole;
namespace Terminal
{
    private void InitRun(object sender, RoutedEventArgs e)
    {
        string[] arr = TerminalObject.GetSplit(InputCommand.Text, ' ');   //把输入框的文字以“ ”分割为字符数组
        TerminalObject.AppendForConsole(OutPut, arr[2])   //输出该数组的第二项
        TerminalObject.AppendForConsole(OutPut, "hello");   //输出文字
    }
}
```  
---------
**TerminalEvents(class/event)**
在“Terminal”中，所有事情都是由某一个事件所产生的，所以便出现了一个“TerminalEvents”类  
这个类的主要作用便是担当“Terminal”的“事件引擎”，负责处理，绑定（注册）事件
以下是该类的几个主要成员：
|成员名|说明|
|:----|:----:|
|`OnIsErr(bool Condition)`|当达到“Condition”时，执行事件“IsErr”对应绑定的函数|
|`RegisterIsErrorEvent(TODO Todo)`|对“IsErr”注册一个事件函数“Todo”|
