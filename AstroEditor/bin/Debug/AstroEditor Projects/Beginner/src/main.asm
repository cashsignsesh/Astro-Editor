;AstroEditor Project by Environment.UserName
;Filename created DateTime.Now

include 'win64ax.inc'

.code
    
    ;Sample FASM hello world source

    ;Useful AstroEditor keybinds:
    ;Ctrl+Scroll to zoom
    ;Ctrl+F to find/replace
    ;F5 to debug
    
    start:
        invoke  MessageBox,HWND_DESKTOP,"Hello world",invoke GetCommandLine,MB_OK
        invoke  ExitProcess,0
    

.end start