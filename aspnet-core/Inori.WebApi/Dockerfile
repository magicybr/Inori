# 从微软服务器拉取docker容器 基础镜像
FROM mcr.microsoft.com.dotnet/core/aspnet:3.1
# FROM registry.cn-hangzhou.aliyuncs.com/yoyosoft/dotnet/core/aspnet:3.1
# 将publish(dist) 文件夹下的应用程序复制到 app 文件夹下
COPY dist /app
# 工作目录
WORKDIR /app
# 容器内IP设置
EXPOSE 80/tcp
# 设置运行程序入口点
ENTRYPOINT ["dotnet","Inori.Webapi.dll"]

# 发布.net core项目 并自定义参数
# dotnet publish --framework netcoreapp3.1 --configuration Release --output dist

# 创建docker镜像
# docker build . -t inori/webapi -f Dockerfile

# 创建容器
# docker create -p 5001:80 --name inoriWebapi inori/webapi
# docker run -p 5001:80 --name inoriWebapi inori/webapi
# docker run -p 5001:80 --rm --name inoriWebapi inori/webapi --自动删除
# docker run -d -p 5001:80 -name inoriWebApi --net inoribridge inori/webapi:target 创建自定义网络的容器

# 查看创建的docker容器信息
# docker inspect inoriWebApi

# 复制文件到Docker
# docker cp filepath inoriWebapi:/app/filepath

# 操作docker容器
# docker exet -it inoriWebapi /bin/bash

# 保存为本地镜像
# 

# 创建docker网络
# docker network create -d bridge inoribridge

# 将容器链接到自定义的桥接网络 
# docker network connect inoribridge [database] 

# 查看docker网络
# docker network ls

# 启动全部容器
# docker start $(docker ps -aq)

# 停止全部容器
# docker stop $(docker ps -q)

# 查看docker内日志
# docker logs inoriWebApi
# docker logs -f inoriWebApi

# 安装DNF包(centos/8)
# sudo yum install epel-release
# sudo yum install dnf

# centos/7安装.net core
# https://docs.microsoft.com/zh-cn/dotnet/core/install/linux-centos
# https://docs.microsoft.com/zh-cn/dotnet/core/tools/troubleshoot-usage-issues

# docker-compose 启动顺序问题
# https://docs.docker.com/compose/startup-order/
# https://github.com/Eficode/wait-for
# https://segmentfault.com/a/1190000021504344