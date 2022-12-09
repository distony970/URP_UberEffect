# URP_UberEffect

Effect Shader with common feature in Unity Universal Pipeline

## About The Shader

|功能类|功能选项概览|功能预览|
|-|-|-|
|MainTex类|![](ReadmeSrc/MainTex1.png)|![](ReadmeSrc/MainTex2.png)|
|MaskTex类|![](ReadmeSrc/MaskTex1.png)|![](ReadmeSrc/MaskTex2.png)|
|DissolveMap类Case1|![](ReadmeSrc/DissolveMap1_1.png)|![](ReadmeSrc/DissolveMap1_2.png)|
|DissolveMap类Case2|![](ReadmeSrc/DissolveMap2_1.png)|![](ReadmeSrc/DissolveMap2_2.png)|
|FlowMap类|![](ReadmeSrc/FlowMap1.png)|![](ReadmeSrc/FlowMap2.png)|
|Rim类|![](ReadmeSrc/Rim1.png)|![](ReadmeSrc/Rim2.png)|
|VertDisplacement类|![](ReadmeSrc/VertDisplacement1.png)|![](ReadmeSrc/VertDisplacement2.png)|
|SoftParticle类|未开启![](ReadmeSrc/SoftParticle_Off.png)|开启![](ReadmeSrc/SoftParticle_On.png)|
|SceneLighting类|![](ReadmeSrc/SceneLighting1.png)|![](ReadmeSrc/SceneLighting2.png)![](ReadmeSrc/SceneLighting3.png)|
## Installation
将UberEffect文件夹放入Unity工程中任意位置,创建材质球使用shader: (`Distony/URP/UberEffect`)
软粒子和其他需要深度的功能需要URP管线开启深度图情况才可以使用.
材质面板中关于CustomCoord的使用
1. 可以利用ObjectTween脚本传入值
![](ReadmeSrc/ObjectTween.png)
2. 可以利用unity的粒子系统Particle System的CustomData把值传入
![](ReadmeSrc/ParticleSystemCustomData.png)