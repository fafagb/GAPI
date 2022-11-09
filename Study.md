# dotnet  new  sln  -n  GAPI
#   dotnet sln   GAPI.sln    add   **/*.csproj

#   git diff ^M的消除 
# Windows用CR LF来定义换行，Linux用LF。
# CR全称是Carriage Return ,或者表示为\r, 意思是回车。
# LF全称是Line Feed，它才是真正意义上的换行表示符。
# 如果用git diff的时候看到^M字符，就说明两个文件在换行符上有所差别。
# git config --global core.whitespace cr-at-eol    

# vi  /etc/supervisord.d/GAPI.ini 


# dotnet publish -c Release



# task.json 项目生成的配置
# launch.json是vscode用于调试的配置文件




#有时候我们会忘记先在.gitignore文件中添加一些诸如生产环境配置文件的操作，这个时候，这些敏感文件已经被上传到了库中。。。。而此时再添加.gitignore记录为时已晚，怎么办呢？

git rm -r --cached .\.vscode\
git commit -m "脱离.vscode的版本控制"
在.gitignore文件中配置你需要不受版本控制的文件 .vscode
git push origin master（分支名）



stage changes  阶段性提交  （部分提交区）
unstage changes 从阶段性提交移除

应用场景 如果部分提交区没有文件，那么commit的时候就提交的所有发生改变的文件，如果部分提交区有文件，那么commit的时候提交的只是部分提交区的文件，常用于有的文件想提交有的文件不想提交的场景


stash  changes  把文件移动到隐藏区  经常用于切换分支的时候不想提交改变的文件
git stash pop   将最近一次藏起来的内容提取出来
git stash apply 如果stash了好几次，要提取其中某一次的内容，可以使用 git stash apply命令



github不用翻墙：安装fastgithub.ui



动态编译
代码片段





