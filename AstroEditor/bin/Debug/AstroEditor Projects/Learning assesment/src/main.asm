
   format PE GUI

start:
    int3
    call    loopOdds
    int3

loopOdds:
    
    push    ebx
    mov     ecx,85000000
    mov     ebx,0
    loopOddsSub:
        push    nums
        call    getOdds
        add     ebx,eax
        dec     ecx
        jnz     loopOddsSub
    mov     eax,ebx
    pop     ebx
    ret

getOdds: ; Return value=No. of odds as hex
    
    push    edx
    push    ebx
    mov     edx,[esp+12]
    mov     eax,0
    
    subr:
        mov     bl, byte [edx]
        inc     dl
        cmp     bl,0
        je      done
        test    bl,1
        jz      subr
        inc     eax
        jmp     subr
    
    done:
        pop     ebx
        pop     edx
        ret     4

section 'nums' data readable writeable

nums:
    db  1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,0
    