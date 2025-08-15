# Invoke-MinimizeWindow

指定プロセスのウィンドウの最小化・復元する

## Usage:

Invoke-MinimizeWindow.exe [プロセス名] [--toggle | --minimize | --restore]
 
## Example usage:

リモートデスクトップ接続(mstsc.exe)のウィンドウをトグル (Minimize <--> Normal)
```
Invoke-MinimizeWindow.exe mstsc --toggle
```