#include <stdio.h>
#include <stdlib.h>
#include <unistd.h>

unsigned char buf[] = "";

int main (int argc, char **argv)
{
	int (*ret)() = (int(*)())buf;
	ret();
}
