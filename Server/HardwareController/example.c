#include "include/raspGPIO.h"
#include <stdio.h>
#include <stdlib.h>

call(char * value)
{
    printf(value);
}

int main(int argc, char const *argv[])
{
    char * sysPath = getenv("SYS_PATH")
    printf("%s\n", sysPath);
    int pin = 1;
    enablePin(pin, sysCall, call);
    printf("pin enabled ...\n");
    pinMode(pin, OUTPUT, sysCall, call);
    printf("pin set as OUTPUT ...\n");
    digitalWrite(pin, HIGH, sysCall, call);
    printf("pin value set to HIGH ...\n");
    printf("pin %d : %d\n",pin, digitalRead(pin, sysCall, call));
    digitalWrite(pin, LOW, sysCall, call);
    printf("pin value set to LOW ...\n");
    printf("pin %d : %d\n",pin, digitalRead(pin, sysCall, call));
    disablePin(pin, sysCall, call);
    printf("pin disabled ...\n");

    return 0;
}
