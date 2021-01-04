
    format PE GUI

start:
    int3
    push    eax
    mov     eax,0
    mov     edx,0
    mov     ecx,225000000
    subRt:
        call    lRes
        add     edx,eax
        mov     eax,0
        dec     ecx
        jnz     subRt
    pop     eax
    int3    


lRes:
    push    ecx
    push    ebx
    
    mov     ebx,0
    lResSubRt:
        push    ebx
        call    res
        cmp     bl,45
        jz      done
        add     bl,5
        jmp     lResSubRt
        
    done:
        pop     ebx
        pop     ecx
        ret

res:
    push    edx
    mov     dl,[esp+8]
    sub     dl,5
    jz      doneRes
    sub     dl,25
    jz      doneRes
    cmp     dl,10
    jz      doneRes
    jmp     doneRes0
    doneRes:
        inc     eax
        doneRes0:
            pop     edx
            ret     4
    