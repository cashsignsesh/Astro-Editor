
    format  PE

start:
    int3
    push    10
    push    10
    lea     eax,[A_character_]
    call    drawChar64_16

drawChar64_16:
    
    xor     edx,edx
    xor     ecx,ecx
    xor     ebx,ebx
    
    mov     cx,8
    

    dC6416Subrt:
        mov     dx,8
        mov     bl,byte [eax]
        dC6416Subrt0:
            push    ebx
            and     ebx,01
            test    ebx,ebx
            jz      dC6416NotPixel
            call    hehehe
            dC6416NotPixel:
                pop     ebx
                shr     bl,1
                dec     dx
                jnz     dC6416Subrt0

        inc     eax
        dec     cx
        jnz     dC6416Subrt
        
    ret

hehehe:
    nop
    nop
    nop
    nop
    ret

chars:
        dd  0
        dd  0
        dd  0
    A_character_:
        db  00000000b
        db  00011000b
        db  00100100b
        db  01000010b
        db  01111110b
        db  01000010b
        db  01000010b
        db  00000000b