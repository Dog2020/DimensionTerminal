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
