format PE GUI 4.0 DLL
entry DllEntryPoint

include 'win32a.inc'

section '.text' code readable executable

proc DllEntryPoint hinstDLL,fdwReason,lpvReserved
	mov	eax,TRUE
	ret
endp

;----------------------------------------------------- 
proc	myFC
	    ret ;Do nothing
endp 
;----------------------------------------------------- 



section '.edata' export data readable

  export 'mydll.dll',\
	 myFC,'myFC'

section '.reloc' fixups data discardable