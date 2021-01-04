
;BYTE - 1 BYTE
;DWORD - 4 BYTES

;RET-Subtracts ESP by 4 (goes back to the call address from stack) & additionally
;subtracts ESP by it's parameter

;ENTER-Enter 8,0 for instance will preserve EBP and reserve space on the stack for 2 vars
;LEAVE-Restores the perserved EBP value and enter's reserved spaces

;Ecx, edx & eax registers may be destroyed
;Other registers should be preserved

;Ecx:Counter
;Eax:Return value
;Esp:Stack pointer
;Ebp:Stored stack pointer for direct access

;Signed vs unsigned:
;0111111 - Signed(=127)
;0000001 - Signed(=1)...
;1111111 - Signed(=-1)
;1111110 - Signed(=-2)
;1000000 - Signed(=-128)...
;1111111 - Unsigned(=256)
;0000001 - Unsigned(=1)...

;MOVZX - Copies the source to the target register and fills 0's behind it according to the size.
;MOVSX - Signed extension.
;XLATB - Locates index stored in AL register from table stored in EBX register, and spits back the entry from the table into AL register.
; ^      ^ ( Preserve EBX )
; ^ Same as xlat    byte [al]

;OR - Merges bits from 2 numbers into 1
; i.e 00100110b
;     01110010b
;    =01110110b

;AND - Only leaves shared bits
; i.e 01110110b
;     01101111b
;    =01100110b
;TEST - Sets flags for AND but doesn't perform the operation.
;A and B = A * B

;XOR - Similar to or/and
;      01110110
;      01101011
;     =00011101
; 1 one, but not 2
;A xor B = A + B = A - B  (Bitwise subtraction)

;SHL - Shift left
;SHR - Shift right
;Ex : 
;shl 123467Eh
;=   234567E0
;shr 234567E0
;=   0234567E

;ROL - Rotate left
;ROR - Rotate right
;Ex :
;ror 1234567Eh
;   =E1234567h
;rol E1234567h
;   =1234567Eh

;LEA - Load effective address
;Use to perform arithmetic on a register that you
;are using to calculate the address.
;Ex: mov eax,[esp+4] will move the content of what esp+4 points to into the eax register
;    lea eax,[ebx*8] this will move the effective address at ebx*8, not what is found at
;    that location. It is also possible to multiply by factors of two (scaling) while mov
;    is limited to addition and subtraction.
;-Additional notes, because I still don't understand fully:
;LEA will load a pointer to the item you are addressing
;vs
;MOV will load the value at that address

;shr 1 divides a number by 2, shl 1 multiplies by 2, shl 2 multiplies by 4, etc.
;shl works with signed numbers
;SAR - sar is shr except it works with signed numbers
;Shift arithmetically right
;You can do an operation like this as well:
;sar eax,cl

;imul - Multiplies number, i.e imul eax,3, this is signed multiplication.
;mul - Multiplication for unsigned, requires two registers, but always stores result in eax
;      i.e eax:2
;          ebx:3
;          mul ebx
;         =eax=6
;Upper portion is stored in edx

;div - Divides number edx:eax by the parameter, result is stored in eax
;    - Remainder is stored in edx
;(Very slow instruction)


;Comment what every line does
    
    format PE GUI ; Windows GUI app format
                  ; PE = Windows
    
start:
    
    int3    ; Debugger interrupt
    
    mov     eax,12345678h
     
    push    eax
    call    mboxHex
    
    push    edx
    call    mboxHex
    
    push    name    ; The argument for the subroutine
    call    toLower ; Calling the subroutine
    
    push    0;Parameter: hWnd=0(No handle of owner window required)
    push    name;Parameter: lpText=data @ example
    push    name;Parameter: lpCaption=this is the title
    push    0;Parameter: uType=Not necessary
    call    [MessageBoxA];Message Box ASCII
    
    push    0;Parameter: exitCode=0
    call    [ExitProcess];Call ExitProcess from winapi
    
toLower:
    push    ebp
    mov     ebp,esp
    
               ;[ebp]-Stored ebp
               ;[ebp+4]-Return address(call subroutine) 
    mov     edx,[ebp+8];First push val
    
    push    ebx
    mov     ebx,table
    
    lower:
        movzx   eax,byte [edx]
        test    al,al
        je      done

        mov     al,[ebx+eax]
        ; if table was dd instead of db
        ; you could do [ecx+eax*4] in x86
        ; because of SIB, to accomodate for the
        ; extra size I'm guessing?
        mov     [edx],al
        
    skipLwr:
        inc     edx
        jmp     lower
     done:
        pop     ebx
        leave
        ret     4

mboxHex:
    
    pop     eax
    pop     edx
    push    eax
    
    mov     ebx,plhdr
    mov     ecx,28

    paSubrt:

        mov     eax,edx
        shr     eax,cl
        and     eax,0000000Fh
        mov     al,[digits+eax]
        mov     [ebx],al
        inc     ebx
        sub     ecx,4
        jnc     paSubrt
        
    xor     eax,eax
    push    0
    push    plhdr
    push    plhdr
    push    0
    call    [MessageBoxA]

    ret
    
section 'name' data readable writeable

table:
    repeat 256
            if %-1 >= 'A' & %-1 <= 'Z'
                db %-1-'A'+'a'
            else
                db %- 1
            end if
    end repeat

name:
        db 'JaKe123!',0 ;db=data byte, dd=data doubleword

plhdr:
        db  '________',0

digits db '0123456789ABCDEF'
    
section '.idata' import data readable writeable

  dd 0,0,0,RVA kernel_name,RVA kernel_table
  dd 0,0,0,RVA user_name,RVA user_table
  dd 0,0,0,0,0

  kernel_table:
    ExitProcess dd RVA _ExitProcess
    dd 0
  user_table:
    MessageBoxA dd RVA _MessageBoxA
    dd 0

  kernel_name db 'KERNEL32.DLL',0
  user_name db 'USER32.DLL',0

  _ExitProcess dw 0
    db 'ExitProcess',0
  _MessageBoxA dw 0
    db 'MessageBoxA',0