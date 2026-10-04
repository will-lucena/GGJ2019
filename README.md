# Geraldo: The Rogue

Jogo de plataforma 2D feito na **Global Game Jam 2019** pela Sekuela Games. O velho Geraldo, com escudo e clava, contra as criaturas da floresta.

![Menu do jogo](https://will-lucena.com.br/img/jogos/ggj2019.jpg)

## Como rodar

Atualizado para **Unity 6 (6000.6.2f1)** em outubro de 2026. Abra a pasta no Unity Hub com essa versão, ou gere o build pela linha de comando:

```sh
# WebGL (precisa do módulo "Web Build Support")
Unity.exe -batchmode -quit -projectPath . -buildTarget WebGL -executeMethod WebGLBuild.Build
# Windows
Unity.exe -batchmode -quit -projectPath . -buildTarget Win64 -executeMethod WebGLBuild.BuildWindows
```

O build sai em `Builds/`. O script fica em `Assets/Editor/WebGLBuild.cs`.
