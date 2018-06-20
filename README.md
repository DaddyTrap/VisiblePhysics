# Visible Physics

> 中山大学虚拟现实课程项目

Visible Physics 是一个结合 AR 技术、能可视化物理现象、用于物理学习的应用。

## 开发 (Develop)

为安全起见， **Vuforia** 的 App License Key 没有上传到仓库，开发前需要自行复制 `Assests/Resources/VuforiaConfiguration.asset.example` 到相同目录下，并重命名为 `VuforiaConfiguration.asset` ，再打开 Unity

然后可以在 Unity 中找到该文件，填入 App License Key 即可

**Unity 版本: 2018.1.0f2**

## 构建 (Build)

依赖于 Unity 的 AR Support ，需要在安装 Unity 时勾选 AR Support 一项才能进行构建

由于 Vuforia 的限制，无法构建 PC 运行的版本，但可以构建 Android 平台的版本

## 贡献者 (Contributors)

+ 程序
  + [DaddyTrap](https://github.com/DaddyTrap) - 粒子系统
  + [Sevennn](https://github.com/Sevennn) - UI
  + [SYSUZZY](https://github.com/SYSUZZY) - UI

+ 需求
  + [KingsleyChung](https://github.com/KingsleyChung)
  + [MinxinZhong](https://github.com/MinxinZhong)

## Screenshots

### 识别标记

![](/docs/imgs/detect.gif)

### 选择不同波

![](/docs/imgs/select.gif)

### 拖拽改变位置

![](/docs/imgs/drag.gif)