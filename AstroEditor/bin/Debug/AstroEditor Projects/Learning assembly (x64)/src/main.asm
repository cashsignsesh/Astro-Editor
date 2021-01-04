;x64 notes:

;In regards to registers r8-r15:
;To access 32 bit, add suffix d
;          16                 w
;          8                  b
;i.e register r8 32x equivalent = r8d
;                16x              r8w
;                8x               r8b

;To access last 4 bytes of register like rsi, it is the last 2 letters plus l
;i.e rsi=sil, rdi=dil

;Can't use new registers like dil with old registers like ah

;DW = DQ (Dword to dquad, this is 32x to 64x equivalent)

;64 bit uses fast call convention
;This means you don't push parameters
;You pass the first 4 arguments in registers:
; - rcx,rdx,r8,r9
;Also, preserve spaces in stack
;Preserve by sub rsp 4*8
;          > sub rsp 10*8
;          > sub rsp 8+10*8
;                    ^ ^== To preserve spaces in stack and to make space for the 4 arguments in the stack (because they sometimes will have to be)
;                    ^==== To align the stack

;rax, rcx, rdx, r8, r9, r10 and r11 are the registers that may be destroyed

    format  PE64

start:

    sub     rsp,8+10*8
    
    mov     rax,123456789ABCDEF0h
    call    mboxHex
    
    mov     ecx,0
    lea     rdx,[text]
    lea     r8, [title]
    mov     r9d,0
    call    [MessageBoxA]
    
    mov     eax,0
    call    [ExitProcess]

mboxHex:
    
    push    rbp
    mov     rbp,rsp
    sub     rsp,32+4*8
    
    ;   [rbp-32]: Local area
    ;   [rbp]   : Stored rbp
    ;   [rbp+8] : Return address
    mov     rdx,rcx
    
    lea     r10,[rbp-32]
    mov     ecx,60
    process:
        mov     rax,rdx
        shr     rax,cl
        and     eax,1111b
        mov     al,[digits+rax]
        mov     [r10],al
        inc     r10
        sub     ecx,4
        jnc     process
        mov     byte [r10],0
    
        xor     ecx,ecx
        lea     rdx,[rbp-32]
        mov     r8,rdx
        xor     r9d,r9d
        call    [MessageBoxA]
        
        leave
        ret

section 'myMbox' data readable writeable

text:
    db  'Hello world',0

title:
    db  'My title',0

plhdr:
    db  '________',0

digits db  '0123456789ABCDEF'

section '.idata' import data readable writeable

  dd 0,0,0,RVA kernel_name,RVA kernel_table
  dd 0,0,0,RVA user_name,RVA user_table
  dd 0,0,0,0,0

  kernel_table:
    ExitProcess dq RVA _ExitProcess
    dq 0
  user_table:
    MessageBoxA dq RVA _MessageBoxA
    dq 0

  kernel_name db 'KERNEL32.DLL',0
  user_name db 'USER32.DLL',0

  _ExitProcess dw 0
    db 'ExitProcess',0
  _MessageBoxA dw 0
    db 'MessageBoxA',0