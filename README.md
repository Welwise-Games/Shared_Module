Общий модуль для всех модулей WelwiseGames

<b>Установка</b><br>
Установите пакеты по пути Package Manager -> Add package from git URL -> Вставить по очереди ссылки ниже:

1. https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask
2. https://github.com/Welwise-Games/Shared_Module.git

<b>Опционально</b><br>
Чтобы включить соответствующие части модуля, добавьте scripting define symbols в Project Settings -> Player -> Other Settings -> Script Compilation:
SERVER, WELWISE_SHARED_MODULE_LOCALIZATION, WELWISE_SHARED_MODULE_UI, WELWISE_SHARED_MODULE_CLIENT_NETWORK
