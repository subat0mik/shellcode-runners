#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

//shellcode
unsigned char buf[] = "";

int main (int argc, char **argv)
{
	char xor_key = 's';
        int payload_len = (int) sizeof(buf);

        for (int i = 0; i < payload_length; i++)
        {
                printf("\\x%02X",buf[i]^xor_key);
        }
	return 0;
}
