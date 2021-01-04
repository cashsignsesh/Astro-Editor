
    format  PE

start:
    int3
    push    myStr
    call    printStr

printStr:
    mov     ah,0Eh ;Setting mode to print char
    mov     edx,[esp+4] ;Take parameter off stack
    pStrSub: ;Creating a subroutine (loop)
        mov     al,byte [edx] ;Move al to the current character
        test    al,al ;Test if its 0
        jz      done  ;If 0 then that means we're done, so go to done
        mov     byte [edx],0h
        inc     edx ;Go to the next character
        jmp     pStrSub ;Loop
    
    done: ;We go here when the loop is done
        ret     2 ;Return and exit out of printStr

myStr db  'Hello world',0