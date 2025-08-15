# Invoke-MinimizeWindow

指定プロセスのウィンドウを最小化・復元する

## Usage:

```
Invoke-MinimizeWindow.exe {ProcessName} {--toggle|--minimize|--restore}
```

| arguments | 機能 |
| ---- | ---- |
| processName | 対象プロセス |
| -minimize | 最小化 |
| -restore  | 最小化から復元 |
| -toggle   | 最小化と復元のトグル |
 
## Example usage:

リモートデスクトップ接続(`mstsc.exe`)のウィンドウ最小化をトグル
```
Invoke-MinimizeWindow.exe mstsc --toggle
```

ローカルデバイスに割り当てるとリモートデスクトップのウィンドウをワンボタンで最小化・復元できる。
(マウスのボタンのマクロで実行、Stream Deckのボタンで実行、など)
