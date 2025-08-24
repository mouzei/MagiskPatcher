# MagiskPatcher - C#面具修补程序
## 简介
Windows上的命令行面具修补工具
## 目前支持版本
Magisk官方稳定版17000-29000，以及各种改版  
## 依赖文件
存放于dependencies目录，均可自定义路径，具体用法请查看程序Usage。  
- MagiskPatcher.csv：控制程序修补流程的配置文件
- magiskboot.exe：magiskboot的Windows版本，用于解打包和修补boot
  - dependencies中的magiskboot.exe来自于 https://github.com/13584452567 的构建，最低支持在Windows7原版32位系统运行
  - 其他可用的版本：https://github.com/CircleCashTeam/magiskboot_build （基于官方290001版本构建，理论上更稳定，但只支持Windows10及以上版本系统）
- 7z.exe和7z.dll：7z的必要程序组件，用于解压apk或zip
## 用法
需要命令行调用，具体用法请查看程序Usage。
## 常见问题说明
- 修补后没有权限：尝试加入参数`-ls=true`进行修补，还是不行就改为`-ls=false`
## 更多问题反馈
请提交issue。如果是请求适配面具包，请附上面具包文件下载链接。  
