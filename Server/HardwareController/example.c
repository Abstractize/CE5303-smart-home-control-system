#include "include/raspGPIO.h"
#include <stdio.h>
#include <stdlib.h>

int main(int argc, char const *argv[])
{
    printf("%s\n", getenv("SYS_PATH"));
    int pin = 1;
    enablePin(pin);
    printf("pin enabled ...\n");
    pinMode(pin, OUTPUT);
    printf("pin set as OUTPUT ...\n");
    digitalWrite(pin, HIGH);
    printf("pin value set to HIGH ...\n");
    printf("pin %d : %d\n",pin, digitalRead(pin));
    digitalWrite(pin, LOW);
    printf("pin value set to LOW ...\n");
    printf("pin %d : %d\n",pin, digitalRead(pin));
    disablePin(pin);
    printf("pin disabled ...\n");

    return 0;
}
