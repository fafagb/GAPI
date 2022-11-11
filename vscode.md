alt多光标
shift alt 多光标多列
ctrl+r 改变变量及所有引用变量名
ctrl+shift+t 触发参数提示
ctrl+alt+t 触发建议
alt+. 显示修补程序
ctrl+l+l转换小写
ctrl+u+u转换大写   
ctrl+shift+p 打开命令面板
f9 切换断点
ctrl+shift+f9 删除所有断点
ctrl+k+s  快捷键修改
shift+enter 光标换行
ctrl+shift+k 删除当前行
ctrl+alt+m json格式化
ctrl+k+d 格式化
ctrl+tab 切换页签
ctrl+q 切换菜单栏

VsCode开发.net5 服务时碰到C#的类、方法等使用ctrl+鼠标左键都无法跳转的问题
文件夹中可能有多个"项目",VSCode选择了"错误"项目.
使用ctrl-shift-P并选择"OmniSharp:选择项目


Omnisharp.Path 
指定路径
C:\Users\Administrator\.vscode\extensions\ms-dotnettools.csharp-1.25.2-win32-ia32\.omnisharp\1.39.3-beta.11-net6.0\OmniSharp.dll
下载最新的OmniSharp：latest 




  <activePackageSource>
    <add key="nuget.org" value="https://www.nuget.org/api/v2/" />
  </activePackageSource>



1、列出Nuget本地的路径
dotnet nuget locals all  -l
2、使用dotnet命令安装引用Nuget包
dotnet add package NLog
3、安装引用指版本使用-v
dotnet add package NLog -v 4.6.7
4、使用特定源安装引用Nuget包
dotnet add package Microsoft.AspNetCore.StaticFiles -s https://dotnet.myget.org/F/dotnet-core/api/v3/index.json
注意：执行命令的目录是要安装的项目的.csproj文件位置
5、指定项目.csproj文件位置
dotnet add ToDo.csproj package NLog -v 1.0.0