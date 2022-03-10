#ifndef RASPGPIO_H_INCLUDED
#define RASPGPIO_H_INCLUDED

#include <errno.h>
#include <fcntl.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <sys/stat.h>
#include <sys/types.h>
#include <unistd.h>

#define INPUT "in"
#define OUTPUT "out"
#define HIGH 1
#define LOW 0

int pinMode(int pin, char *mode, char * sysPath, void (*print)(char *));
int digitalWrite(int pin, int value, char * sysPath, void (*print)(char *));
int digitalRead(int pin, char * sysPath, void (*print)(char *));
int enablePin(int pin, char * sysPath, void (*print)(char *));
int disablePin(int pin, char * sysPath, void (*print)(char *));

#endif